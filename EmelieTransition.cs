//
// Code by Oskar Lundqvist / Abrovinsch 2016
//
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Emelie
{
	public class EmelieTransition
	{
		public string name;
		public float probability;
		public string destinationState;
		public EmelieRequirements requirements;

		public EmelieTransition()
		{
			name = "TRANSITION_NAME";
			destinationState = "DEST_STATE";
			probability = 10;
			requirements = new EmelieRequirements();
		}
	}

}

