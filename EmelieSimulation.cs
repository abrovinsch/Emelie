//
// Code by Oskar Lundqvist / Aborvinsch 2016
//
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Emelie
{
	public class EmelieSimulation
	{

		public static bool printSimLog = true;
		private List<string> simulationLog;

		public string Run(EmelieSimulationContext context, string programVersion)
		{
			string resultingEvert = "\n" + 
									"// -- Using Emelie Simulation Engine v." + programVersion + " --\n" + 
				                    "// -- Generated on " + System.DateTime.Now.ToString("G") + " --\n" +
									"\norigin\n{\n\n//Setting Variables:\n";

			simulationLog = new List<string>();

			if(context.simulationStep <= 0f) 
			{
				Log.Error("simulationStep cannot be" +
					" 0"); 
				return "Simulation Failed";
			}


			// Create charcter
			EmelieCharacter c = new EmelieCharacter(context);

			c.name = "<# name>";
			resultingEvert += "<$ character_name " + c.name + " >\n";
			c.finalAge = EmelieUtilities.RandomRange(5f,90f);


			c.currentAge = 0f;


			int numOfTraits = 3;

			while(c.traits.Count 
				< numOfTraits)
			{
				EmelieTrait randomTrait = context.traits[EmelieUtilities.RandomRange(0,context.traits.Length)];
				if(c.AddTrait(randomTrait))
				{
					SimLog(c.currentAge, "born with trait " + randomTrait.name);
				}
			}

			foreach(EmelieTrait trait in context.traits)
			{
				bool r = c.traits.Contains(trait);
				resultingEvert += "<$ has_trait_" + trait.name + " " + r.ToString() +">\n";
			}

			EmelieState startingState = context.GetStartingState();

			SimLog(c.currentAge, "Character Born");
			resultingEvert += "\n//Actual story:\n\n<# character_born>\n";

			while(c.currentAge < c.finalAge)
			{

				//foreach(EmelieTransition in 

				c.currentAge += context.simulationStep;
				if(c.currentAge > c.finalAge) c.currentAge = c.finalAge;

			}
			resultingEvert += "<# story_end>\n" +
				"}\n\n" +
				"[i sailorLife]\n" +
				"// [Emelie end]" +
				"";
			return resultingEvert;

		}

		public void SimLog(float age, string msg)
		{
			string logMsg = age.ToString("F1") + ": " + msg;
			simulationLog.Add(logMsg);
			if(printSimLog) Log.Msg(logMsg);
		}

	}

}
