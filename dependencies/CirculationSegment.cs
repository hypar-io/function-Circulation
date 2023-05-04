using Elements;
using System;
using System.Linq;
using System.Collections.Generic;
using Elements.Geometry;
using Newtonsoft.Json;

namespace Elements
{
    public partial class CirculationSegment
    {
        [JsonProperty("Add Id")]
        public string AddId { get; set; }

        public override void UpdateRepresentations()
        {
            this.Representation = new Representation(new List<Elements.Geometry.Solids.SolidOperation>());
            base.UpdateRepresentations();
        }
    }
}