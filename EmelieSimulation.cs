//
// Code by Oskar Lundqvist / Aborvinsch 2016
//
// ------------------------------------------------------------------------------
using System;

namespace Emelie
{
	class EmelieSimulation
	{

		public string Run(EmelieSimulationContext context)
		{

			EmelieCharacter c = new EmelieCharacter(context);

			c.name = "<$NAME>";

			for(int i = 0; i < EmelieUtilities.RandomRange(2,5);i++)
			{
				EmelieTrait randomTrait = context.traits[EmelieUtilities.RandomRange(0,context.traits.Length)];
				c.AddTrait(randomTrait);
			}


			EmelieState startingState = context.GetStartingState();
			return c.name;

		}

	}

}
