// This code was generated by Hypar.
// Edits to this code will be overwritten the next time you run 'hypar init'.
// DO NOT EDIT THIS FILE.

using Elements;
using Elements.GeoJSON;
using Elements.Geometry;
using Elements.Geometry.Solids;
using Elements.Validators;
using Elements.Serialization.JSON;
using Hypar.Functions;
using Hypar.Functions.Execution;
using Hypar.Functions.Execution.AWS;
using Hypar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Line = Elements.Geometry.Line;
using Polygon = Elements.Geometry.Polygon;

namespace Circulation
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public  class CirculationInputs : S3Args
    
    {
        [Newtonsoft.Json.JsonConstructor]
        
        public CirculationInputs(Overrides @overrides, string bucketName, string uploadsBucket, Dictionary<string, string> modelInputKeys, string gltfKey, string elementsKey, string ifcKey):
        base(bucketName, uploadsBucket, modelInputKeys, gltfKey, elementsKey, ifcKey)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CirculationInputs>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @overrides});
            }
        
            this.Overrides = @overrides ?? this.Overrides;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("overrides", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Overrides Overrides { get; set; } = new Overrides();
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class Overrides 
    
    {
        public Overrides() { }
        
        [Newtonsoft.Json.JsonConstructor]
        public Overrides(OverrideAdditions @additions, OverrideRemovals @removals, IList<CirculationOverride> @circulation)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<Overrides>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @additions, @removals, @circulation});
            }
        
            this.Additions = @additions ?? this.Additions;
            this.Removals = @removals ?? this.Removals;
            this.Circulation = @circulation ?? this.Circulation;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Additions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public OverrideAdditions Additions { get; set; } = new OverrideAdditions();
    
        [Newtonsoft.Json.JsonProperty("Removals", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public OverrideRemovals Removals { get; set; } = new OverrideRemovals();
    
        [Newtonsoft.Json.JsonProperty("Circulation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<CirculationOverride> Circulation { get; set; } = new List<CirculationOverride>();
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class OverrideAdditions 
    
    {
        public OverrideAdditions() { }
        
        [Newtonsoft.Json.JsonConstructor]
        public OverrideAdditions(IList<CirculationOverrideAddition> @circulation)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<OverrideAdditions>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @circulation});
            }
        
            this.Circulation = @circulation ?? this.Circulation;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Circulation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<CirculationOverrideAddition> Circulation { get; set; } = new List<CirculationOverrideAddition>();
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class OverrideRemovals 
    
    {
        public OverrideRemovals() { }
        
        [Newtonsoft.Json.JsonConstructor]
        public OverrideRemovals(IList<CirculationOverrideRemoval> @circulation)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<OverrideRemovals>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @circulation});
            }
        
            this.Circulation = @circulation ?? this.Circulation;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Circulation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<CirculationOverrideRemoval> Circulation { get; set; } = new List<CirculationOverrideRemoval>();
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CirculationOverride 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CirculationOverride(string @id, CirculationIdentity @identity, CirculationValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CirculationOverride>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CirculationIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CirculationValue Value { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CirculationOverrideAddition 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CirculationOverrideAddition(string @id, CirculationIdentity @identity, CirculationOverrideAdditionValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CirculationOverrideAddition>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CirculationIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CirculationOverrideAdditionValue Value { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CirculationOverrideRemoval 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CirculationOverrideRemoval(string @id, CirculationIdentity @identity)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CirculationOverrideRemoval>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity});
            }
        
            this.Id = @id;
            this.Identity = @identity;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CirculationIdentity Identity { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CirculationIdentity 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CirculationIdentity(string @addId)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CirculationIdentity>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @addId});
            }
        
            this.AddId = @addId;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Add Id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AddId { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CirculationValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CirculationValue(ThickenedPolyline @geometry, CirculationValueLevel @level)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CirculationValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @geometry, @level});
            }
        
            this.Geometry = @geometry;
            this.Level = @level;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Geometry", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ThickenedPolyline Geometry { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Level", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CirculationValueLevel Level { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CirculationOverrideAdditionValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CirculationOverrideAdditionValue(ThickenedPolyline @geometry, CirculationOverrideAdditionValueLevel @level)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CirculationOverrideAdditionValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @geometry, @level});
            }
        
            this.Geometry = @geometry;
            this.Level = @level;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Geometry", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ThickenedPolyline Geometry { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Level", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CirculationOverrideAdditionValueLevel Level { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CirculationValueLevel 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CirculationValueLevel(string @name, string @buildingName, string @addId)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CirculationValueLevel>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @name, @buildingName, @addId});
            }
        
            this.Name = @name;
            this.BuildingName = @buildingName;
            this.AddId = @addId;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Building Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BuildingName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Add Id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AddId { get; set; }
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CirculationOverrideAdditionValueLevel 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CirculationOverrideAdditionValueLevel(string @name, string @buildingName, string @addId)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CirculationOverrideAdditionValueLevel>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @name, @buildingName, @addId});
            }
        
            this.Name = @name;
            this.BuildingName = @buildingName;
            this.AddId = @addId;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Building Name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BuildingName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Add Id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AddId { get; set; }
    
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();
    
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
}