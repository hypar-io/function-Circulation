using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Circulation
{
	/// <summary>
	/// Override metadata for CirculationOverrideRemoval
	/// </summary>
	public partial class CirculationOverrideRemoval : IOverride
	{
        public static string Name = "Circulation Removal";
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