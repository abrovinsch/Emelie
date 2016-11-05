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
		public List<string> attributes;
		public Dictionary<string,uint> personalityPoints;
		public float finalAge;
		public float currentAge;
		public string gender;
		public uint economicClass;

		public EmelieCharacter(EmelieSimulationContext context)
		{
			traits = new List<EmelieTrait>();
			attributes = new List<string>();

			personalityPoints = new Dictionary<string, uint>();
			for(int i = 0; i < context.personalityMeasurements.Length; i++)
			{
				string personalityMeasurement = context.personalityMeasurements[i];


				if(!personalityPoints.ContainsKey(personalityMeasurement)) 
					personalityPoints.Add(personalityMeasurement, 5);
				
			}

			if(EmelieUtilities.PercentageChance(50f))
			{
				gender = "male";
			}
			else
			{
				gender = "female";
			}
		}


		public bool AddTrait(EmelieTrait trait)
		{
			if(traits.Contains(trait))
				return false;

			traits.Add(trait);
					
			if(!personalityPoints.ContainsKey(trait.pointAffected))
			{
				Log.SyntaxError("Undefined personality-point: '" + trait.pointAffected + "'");
				return false;
			}

			personalityPoints[trait.pointAffected] = (uint)(personalityPoints[trait.pointAffected] + trait.effect);
			return true;
		}

		public bool HaveTrait(string _trait)
		{
			
			foreach(EmelieTrait t in traits)
			{
				if (_trait == t.name)
				{
					return true;
				}
			}
			return false;
		}

		public bool AddAttribute(string attribute)
		{
			if(!attributes.Contains(attribute)) 
			{
				attributes.Add(attribute);
				return true;
			}
			return false;
		}
			
	}



}
