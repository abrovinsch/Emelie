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
									"\norigin\n{\n" +
									"";

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
			resultingEvert += "<= character_name " + c.name + " >\n";
			resultingEvert += "<= gender " + c.gender + " >\n";

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
				resultingEvert += "<= IS_" + trait.name + " " + r.ToString().ToLower()	 +">\n";
			}

			foreach(string s in context.personalityMeasurements)
			{
				resultingEvert += "<= " + s + " " + c.personalityPoints[s] + ">\n";
			}

			EmelieState startingState = context.GetStartingState();

			SimLog(c.currentAge, "Character Born, gender=" + c.gender + ", final age=" + System.Math.Round((double)c.finalAge).ToString());
			resultingEvert += "<# character_born>";

			EmelieState currentState = startingState;

			while(c.currentAge < c.finalAge)
			{

				List<string> possibleEvents = new List<string>();
				possibleEvents.AddRange(currentState.events);
				possibleEvents.AddRange(context.alwaysPossibleEvents);

				foreach(string eventName in possibleEvents)
				{
					EmelieEvent _event = context.GetEvent(eventName);

					if(EmelieUtilities.PercentageChance( _event.probability))
					{
						bool passedAlltests = true;
						foreach(EmelieRequirement req in _event.requirements)
						{
							if(!req.IsMet(c,_event)) 
							{
								passedAlltests = false;
								break;
							}
						}

						if(!passedAlltests) continue;




						SimLog(c.currentAge,"EVENT: " + _event.name);
						resultingEvert += "<= currentAge " + c.currentAge + ">";
						resultingEvert += "<# EVENT_" + _event.name + ">";

						foreach(string attr in _event.attributesAdded)
						{	
							c.AddAttribute(attr);
							SimLog(c.currentAge,"ATTRIBUTE_ADDED: " + attr);
							resultingEvert += "<= HAS_ATTRIBUTE_" + attr + " true>";
						}

						if(_event.destinationState != "")
						{
							currentState = context.GetState(_event.destinationState);
							SimLog(c.currentAge,"STATE: " + currentState.name);
							continue;
						}
					}
				}

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
