using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Circulation
{
	/// <summary>
	/// Override metadata for CirculationOverrideAddition
	/// </summary>
	public partial class CirculationOverrideAddition : IOverride
	{
        public static string Name = "Circulation Addition";
        public static string Dependency = null;
        public static string Context = "[*discriminator=Elements.CirculationSegment]";
		public static string Paradigm = "Edit";

        /// <summary>
        /// Get the override name for this override.
        /// </summary>
        public string GetName() {
			return Name;
		}

		public object GetIdentity() {

			return Identity;
		}

	}

}