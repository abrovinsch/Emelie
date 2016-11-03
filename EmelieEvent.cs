//
// Code by Oskar Lundqvist / Abrovinsch 2016
//
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Emelie
{
	public class EmelieEvent
	{
		public string name;
		public float probability;
		public string destinationState;
		public EmelieRequirement[] requirements;

		public EmelieEvent()
		{
			name = "EVENT_NAME";
			destinationState = "DEST_STATE";
			probability = 10;
			requirements = new EmelieRequirement[1];
			requirements[0] = new EmelieRequirement();
		}
	}

}

