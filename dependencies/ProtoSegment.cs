using Circulation;
using Elements.Geometry;

namespace Elements
{
    public class ProtoSegment : Element
    {

        public ProtoSegment(CirculationOverrideAddition add, IEnumerable<LevelVolume> levelVolumes)
        {
            Geometry = add.Value.Geometry;
            Geometry.Polyline = Geometry.Polyline.Project(Plane.XY);
            AddId = add.Id;
            var matchingLevelVolume = levelVolumes.FirstOrDefault(lv => add.Value.Level?.AddId != null && lv.AddId == add.Value.Level?.AddId) ??
                levelVolumes.FirstOrDefault(lv => lv.Name == add.Value.Level.Name && lv.BuildingName == add.Value.Level.BuildingName) ??
                levelVolumes.FirstOrDefault(lv => lv.Name == add.Value.Level.Name);
            LevelVolume = matchingLevelVolume;
        }

        public LevelVolume? LevelVolume { get; init; }
        public ThickenedPolyline Geometry { get; set; }

        public string AddId { get; init; }

        public bool Match(CirculationIdentity identity)
        {
            return AddId == identity.AddId;
        }

        public ProtoSegment Update(CirculationOverride edit)
        {
            this.Geometry = edit.Value.Geometry ?? this.Geometry;
            this.Geometry.Polyline = this.Geometry.Polyline.Project(Plane.XY);
            return this;
        }
    }
}