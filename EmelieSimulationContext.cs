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
		public string[] personalityMeasurements;
		public string startingState;
		public float simulationStep;
		public int year;
		public string[] alwaysPossibleEvents;

		public EmelieState[] states;
		public EmelieEvent[] events;
		public EmelieTrait[] traits;

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
								  "\n[Startingstate] " + startingState);
		}

		public EmelieSimulationContext ()
		{
			name = "SIMULATION_NAME";
			states = new EmelieState[2];
			states[0] = new EmelieState();
			states[1] = new EmelieState();

			events = new EmelieEvent[2];
			events[0] = new EmelieEvent();
			events[1] = new EmelieEvent();

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

		public EmelieState GetState(string stateName)
		{
			foreach(EmelieState state in states)
			{
				if(state.name == stateName)
					return state;
			}


			Log.Error("Undefined state: \"" + stateName + "\"");
			return null;
		}


		public EmelieEvent GetEvent(string eventName)
		{
			int t = 0;

			foreach(EmelieEvent _event in events)
			{
				if(_event == null)
					Log.SyntaxError("Event # " + t.ToString() + "/" + events.Length.ToString() + " was null");

				t++;

				if(_event.name == eventName)
					return _event;
			}

			Log.Error("Undefined event: \"" + eventName + "\"");
			return null;
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

