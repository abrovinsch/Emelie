//
// Code by Oskar Lundqvist / Abrovinsch 2016
//
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Emelie
{

	public class EmelieRequirement : System.Object
	{
		const string HAVE_ATTRIBUTE = "HAVE_ATTRIBUTE";
		const string DONT_HAVE_ATTRIBUTE = "DONT_HAVE_ATTRIBUTE";
		const string HAVE_TRAIT = "HAVE_TRAIT";
		const string DONT_HAVE_TRAIT = "DONT_HAVE_TRAIT";
		const string IS_OLDER_THAN = "IS_OLDER_THAN";
		const string IS_YOUNGER_THAN = "IS_YOUNGER_THAN";
		const string HAS_GENDER = "HAS_GENDER";
		const string PERSONALITY_POINT_GREATER_THAN = "PERSONALITY_POINT_GREATER_THAN";
		const string PERSONALITY_POINT_LESS_THAN = "PERSONALITY_POINT_LESS_THAN";
		const string CLASS_GREATER_THAN = "CLASS_GREATER_THAN";
		const string CLASS_LESS_THAN = "CLASS_LESS_THAN";

		public string comparer;
		public string text;
		public uint number;

		public EmelieRequirement()
		{
			comparer = HAVE_ATTRIBUTE;
			text = "ATTRIBUTE_NAME";
			number = 0;
		}

		public bool IsMet(EmelieCharacter c, EmelieEvent _event)
		{
			
			switch(comparer)
			{

				case HAVE_ATTRIBUTE :
				{
					return c.attributes.Contains(text);
				}

				case DONT_HAVE_ATTRIBUTE :
				{
					return !c.attributes.Contains(text);
				}

				case HAVE_TRAIT :
				{
					return c.HaveTrait(text);
				}

				case DONT_HAVE_TRAIT :
				{
					return !c.HaveTrait(text);
				}

				case IS_OLDER_THAN :
				{
					return c.currentAge > 
						number;
				}

				case IS_YOUNGER_THAN :
				{
					return c.currentAge < number;
				}

				case HAS_GENDER :
				{
					return c.gender == text;
				}
					
				case PERSONALITY_POINT_GREATER_THAN :
				{
					return c.personalityPoints[text] > number;
				} 

				case PERSONALITY_POINT_LESS_THAN :
				{
					return c.personalityPoints[text] < number;
				}

				case CLASS_GREATER_THAN :
				{
					return c.economicClass > number;
				}

				case CLASS_LESS_THAN :
				{
					return c.economicClass < number;
				}

			}

			return true;
		}
	}


}

