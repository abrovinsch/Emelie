//
// Code by Oskar Lundqvist / Aborvinsch 2016
//
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Emelie
{
	public class EmelieSimulationContext : System.Object
	{

		public string name;
		public EmelieState[] states;
		public EmelieTransition[] transitions;
		public EmelieTrait[] traits;
		public string[] personalityMeasurements;
		public string startingState;
		public float simulationStep
		;

		public EmelieState GetStartingState()
		{
			foreach(EmelieState state in states)
			{
				if(state.name == startingState)
					return state;
			}
			return states[0];
		}


		public override string ToString ()
		{
			return string.Format ("[EmelieSimulationContext]\n" +
								  "[Name:] " + name +
								  "\n[Startingstate] " + startingState +
								  "\n[PersonalityMeasurment] " + EmelieUtilities.StringArrayToString(personalityMeasurements));
		}

		public EmelieSimulationContext ()
		{
			name = "SIMULATION_NAME";
			states = new EmelieState[2];
			states[0] = new EmelieState();
			states[1] = new EmelieState();

			transitions = new EmelieTransition[2];
			transitions[0] = new EmelieTransition();
			transitions[1] = new EmelieTransition();

			personalityMeasurements = new string[4];
			personalityMeasurements[0] = "KIND";
			personalityMeasurements[1] = "5";
			personalityMeasurements[2] = "BRAVE";
			personalityMeasurements[3] = "5";

			traits = new EmelieTrait[2];
			traits[0] = new EmelieTrait();
			traits[1] = new EmelieTrait();

			startingState = "STATE_INFANCY";
		}

		public static string Serialize(EmelieSimulationContext context)
		{
			return JsonConvert.SerializeObject(context,Formatting.Indented);
		}

		public static EmelieSimulationContext Deserialize(string json)
		{
			try{
				EmelieSimulationContext newContext =  (EmelieSimulationContext)JsonConvert.DeserializeObject(json,
																				typeof(EmelieSimulationContext));
				return newContext;
			}
			catch(Exception e)
			{
				Log.Error("Failure in parsing JSON: \"" + e.Message + "\"");
				return null;
			}

		}
	}
}

