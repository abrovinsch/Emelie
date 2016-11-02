//
// Code by Oskar Lundqvist / Aborvinsch 2016
//
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Emelie
{
	public class EmelieTrait : System.Object
	{
		public string name;
		public string pointAffected;
		public int effect;

		public EmelieTrait()
		{
			name = "TRAIT_FOOL";
			pointAffected = "INTELLIGENCE";
			effect  = -5;
		}
			
	}


}
