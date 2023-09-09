using Elements;
using Elements.Geometry;
using System.Collections.Generic;

namespace Circulation
{
    public static class Circulation
    {
        private static Color CORRIDOR_MATERIAL_COLOR = new(0.996, 0.965, 0.863, 1.0);
        private static readonly Material CorridorMat = new("Circulation", CORRIDOR_MATERIAL_COLOR, doubleSided: true);

        /// <summary>
        /// The Circulation function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A CirculationOutputs instance containing computed results and the model with any new elements.</returns>
        public static CirculationOutputs Execute(Dictionary<string, Model> inputModels, CirculationInputs input)
        {
            var output = new CirculationOutputs();
            var levelsModel = inputModels["Levels"];
            var levelVolumes = levelsModel.AllElementsOfType<LevelVolume>().ToList() ?? new List<LevelVolume>();
            if (inputModels.TryGetValue("Conceptual Mass", out var massModel))
            {
                levelVolumes.AddRange(massModel.AllElementsOfType<LevelVolume>());
            }
            // Validate that level volumes are present in Levels dependency
            if (levelVolumes.Count == 0)
            {
                output.Warnings.Add("This function requires LevelVolumes, produced by functions like \"Simple Levels by Envelope\". Try a different levels function.");
                return output;
            }

            // Get Floors
            inputModels.TryGetValue("Floors", out var floorsModel);

            // Get Cores
            var hasCore = inputModels.TryGetValue("Core", out var coresModel);
            var cores = coresModel?.AllElementsOfType<ServiceCore>() ?? new List<ServiceCore>();

            // Get Walls
            var hasWalls = inputModels.TryGetValue("Walls", out var wallsModel);
            var walls = wallsModel?.Elements.Values.Where(e => new[] { typeof(Wall), typeof(WallByProfile), typeof(StandardWall) }.Contains(e.GetType())) ?? new List<Element>();
            // Get Columns
            var hasColumns = inputModels.TryGetValue("Columns", out var columnsModel);
            var columns = columnsModel?.AllElementsOfType<Column>() ?? new List<Column>();

            // Get Vertical Circulation
            inputModels.TryGetValue("Vertical Circulation", out var verticalCirculationModel);
            if (verticalCirculationModel != null)
            {
                var corridorCandidates = verticalCirculationModel.AllElementsAssignableFromType<CorridorCandidate>();
                foreach (var cc in corridorCandidates)
                {
                    var lvlVolume = levelVolumes.FirstOrDefault(lv => lv.Level.HasValue && lv.Level.Value == cc.Level);
                    lvlVolume?.CorridorCandidates.Add(cc);
                }
            }

            // create a collection of LevelElements (which contain other elements)
            // to add to the model
            var levels = new List<LevelElements>();

            // for every level volume
            foreach (var lvl in levelVolumes)
            {
                AdjustLevelVolumesToFloors(floorsModel, lvl);
                // var levelBoundary = new Profile(lvl.Profile.Perimeter, lvl.Profile.Voids, Guid.NewGuid(), null);

                // // Add any cores present within the level boundary as voids
                // var coresInBoundary = cores.Where(c => levelBoundary.Contains(c.Centroid)).ToList();
                // foreach (var core in coresInBoundary)
                // {
                //     levelBoundary.Voids.Add(new Polygon(core.Profile.Perimeter.Vertices).Reversed());
                //     levelBoundary.OrientVoids();
                // }

                // // if we have any walls, try to create boundaries from any enclosed spaces,
                // // and then continue to operate on the largest "leftover" region.
                // // var wallsInBoundary = walls.Where(w =>
                // // {
                // //     var pt = GetPointFromWall(w);
                // //     return pt.HasValue && levelBoundary.Contains(pt.Value);
                // // }).ToList();
                // var interiorZones = new List<Profile>();
                // // This was causing issues in plans with lots of complex walls.
                // // if (wallsInBoundary.Count() > 0)
                // // {
                // //     var newLevelBoundary = AttemptToSplitWallsAndYieldLargestZone(levelBoundary, wallsInBoundary, out var centerlines, out interiorZones, output.Model);
                // //     levelBoundary = newLevelBoundary;
                // // }

                // List<Profile> corridorProfiles = new();
                // List<Profile> thickerOffsetProfiles = new();
                // List<CirculationSegment> circulationSegments = new();
            }

            var thickenedPolylines = input.Overrides.Circulation.CreateElements(
              input.Overrides.Additions.Circulation,
              input.Overrides.Removals.Circulation,
              (add) => new ProtoSegment(add, levelVolumes),
              (seg, identity) => seg.Match(identity),
              (seg, edit) => seg.Update(edit)
            );

            foreach (var lvl in levelVolumes)
            {
                var thickenedPolylinesForLevel = thickenedPolylines.Where(pl => pl.LevelVolume == lvl).ToList();
                var geometry = thickenedPolylinesForLevel.Select(g => g.Geometry).ToList();
                var offsetGeometry = ThickenedPolyline.GetPolygons(geometry);
                if (geometry.Count != offsetGeometry.Count)
                {
                    output.Warnings.Add("Something strange happened with offset geometry. Try undoing your change and trying again.");
                    continue;
                }
                for (int i = 0; i < geometry.Count; i++)
                {
                    var proto = thickenedPolylinesForLevel[i];
                    var (offsetPolygon, offsetLine) = offsetGeometry[i];
                    if (offsetPolygon == null)
                    {
                        continue;
                    }
                    var circSegment = new CirculationSegment
                    {
                        Profile = offsetPolygon,
                        Thickness = 0.005,
                        Transform = lvl.Transform,
                        AddId = proto.AddId,
                        Material = CorridorMat,
                        Geometry = proto.Geometry,
                        Level = lvl.Id,
                        AdditionalProperties = proto.AdditionalProperties,
                    };
                    output.Model.AddElement(circSegment);
                }
            }

            return output;
        }

        /// <summary>
        /// If we have floors, we shrink our internal level volumes so they sit on top of / don't intersect with the floors.
        /// </summary>
        /// <param name="floorsModel">The floors model, which may or may not exist</param>
        /// <param name="lvl">The level volume</param>
        private static void AdjustLevelVolumesToFloors(Model? floorsModel, LevelVolume lvl)
        {
            if (floorsModel != null)
            {
                var floorAtLevel = floorsModel.AllElementsOfType<Floor>().FirstOrDefault(f => Math.Abs(lvl.Transform.Origin.Z - f.Transform.Origin.Z) < (f.Thickness * 1.1));
                if (floorAtLevel != null)
                {
                    lvl.Height -= floorAtLevel.Thickness;
                    var floorFaceOffset = (floorAtLevel.Transform.Origin.Z + floorAtLevel.Thickness) - lvl.Transform.Origin.Z;
                    if (floorFaceOffset > 0.001)
                    {
                        lvl.Transform.Concatenate(new Transform(0, 0, floorFaceOffset));
                        lvl.Height -= floorFaceOffset;
                    }
                }
            }
        }

    }
}