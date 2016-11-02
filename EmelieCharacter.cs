//
// Code by Oskar Lundqvist / Aborvinsch 2016
//
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Emelie
{
	public class EmelieCharacter
	{
		public string name;
		public List<EmelieTrait> traits;
		private Dictionary<string,uint> personalityPoints;
		public float finalAge;
		public float currentAge;

		public EmelieCharacter(EmelieSimulationContext context)
		{
			traits = new List<EmelieTrait>();

			personalityPoints = new Dictionary<string, uint>();
			for(int i = 0; i < context.personalityMeasurements.Length; i++)
			{
				string personalityMeasurement = context.personalityMeasurements[i];


				if(!personalityPoints.ContainsKey(personalityMeasurement)) 
					personalityPoints.Add(personalityMeasurement, 5);
				
				Log.Msg(personalityMeasurement);
			}
		}


		public bool AddTrait(EmelieTrait trait)
		{
			if(traits.Contains(trait))
				return false
					;

			traits.Add(trait);
					
			if(!personalityPoints.ContainsKey(trait.pointAffected))
			{
				Log.SyntaxError("Undefined personality-point: '" + trait.pointAffected + "'");
				return false;
			}

			personalityPoints[trait.pointAffected] = (uint)(personalityPoints[trait.pointAffected] + trait.effect);
			return true;
		}
			
	}



}
