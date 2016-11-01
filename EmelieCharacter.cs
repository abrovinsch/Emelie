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
		private List<EmelieTrait> traits;
		private Dictionary<string,uint> personalityPoints;

		public EmelieCharacter(EmelieSimulationContext context)
		{
			foreach(string personalityMeasurement in context.personalityMeasurements)
			{
				personalityPoints.Add(personalityMeasurement, 5);
			}
		}

		public void AddTrait(EmelieTrait trait)
		{
			if(traits.Contains(trait))return;

			traits.Add(trait);

			for(int i = 0; i < trait.personalityEffects.Length; i+=2)
			{
				string personalityPointAffected = trait.personalityEffects[i];

				if(!personalityPoints.ContainsKey(personalityPointAffected))
				{
					Log.SyntaxError("Undefined personality-point: '" + personalityPointAffected + "'");
				}

				uint effect;
				if( uint.TryParse(trait.personalityEffects[i+1],out effect))
				{
					personalityPoints[trait.personalityEffects[i]] += effect;
				}
				else
				{
					Log.SyntaxError("Cannot convert '" + trait.personalityEffects[i+1] + "' to a positive integer");
				}
			}

		}
			
	}


}
