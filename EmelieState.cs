//
// Code by Oskar Lundqvist / Abrovinsch 2016
//
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Emelie
{
	public class EmelieState : System.Object
	{
		public string name;

		public string[] events;

		public EmelieState()
		{
			name = "STATE_NAME";
			events = new string[2];
			events[0] = "EVENT";
			events[1] = "EVENT";
		}


	}

}

