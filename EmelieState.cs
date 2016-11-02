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

		public string[] transitions;

		public EmelieState()
		{
			name = "STATE_NAME";
			transitions = new string[2];
			transitions[0] = "TRANSITION";
			transitions[1] = "TRANSITION";
		}
		/*
		public EmelieTransition[] GetPossibleTransitions()
		{
			
		}
		*/
	}

}

