//
// Code by Oskar Lundqvist / Aborvinsch 2016
//
// ------------------------------------------------------------------------------
using System;

namespace Emelie
{
	class MainClass
	{
		static string VERSION = "0.0";

		public static void Main (string[] args)
		{
			Console.WriteLine ("------          Starting Emelie Text Engine v" + VERSION + "        ------\n" +
							   "Code by Oskar Lundqvist 2016 | @oskar_lq | lundqvist.oskar01@gmail.com\n");

			bool programIsRunning = true;
			EmelieSimulationContext context = new EmelieSimulationContext();
			Log.Msg(EmelieSimulationContext.Serialize(context,""));

			while(programIsRunning)
			{
				Console.WriteLine ("Enter a command:");

				string resultingLine = "";
				while(resultingLine == "")
					resultingLine = Console.ReadLine();

				string[] parameters = resultingLine.Split(new string[] {" ","\t"}, StringSplitOptions.RemoveEmptyEntries);
				string command = parameters[0].ToLower();

				switch(command)
				{
					case "help" : Help(); break;
					
					case "quit" : { 
						programIsRunning = false;
						Console.WriteLine("Closing Emelie...");
					} break;

					case "run" : { 
						if(CheckParameters("run",parameters,1))
						{
							uint times = 0;
							if(!uint.TryParse(parameters[1],out times))
							{
								Log.Msg("Parameter " + parameters[1] + " could not be converted to a positive integer!");
							}
							else {
								for(uint i = 0; i < times; i++)
								{
									if(context != null)
									{
										RunSimulation(context);
									}
									else Log.Msg("No Simulation context has been set! Please load an emelie file to set it!");
								}
							}
						}
							
					} break;

					default : Console.WriteLine ("Unknown command '" + command + "'. Type 'help' to get a list of commands."); break;
				}

			}
		}

		private static void Help()
		{
			Console.WriteLine ("\nList of commands:\n" +
				"quit - closes the program\n" +
				"help - prints a list of all commands\n" +
				"load -filepath – loads a .emelie file and sets it as current simulation context\n" +
				"run -times - runs the simulation a certain amount of time");
		}

		private static string RunSimulation(EmelieSimulationContext context)
		{
			EmelieSimulation simulation = new EmelieSimulation();
			string result = simulation.Run(context);
			Log.Msg("SIMULATION RESULT: '" + result + "'");
			return result;
		}

		private static bool CheckParameters(string commandName, string[] parameters, int amount)
		{
			if(parameters.Length != amount + 1)
			{
				Log.Msg("Command '" + commandName + "' requires " + amount.ToString() + " parameter");
				return false;
			}
			return true;
		}

		/*public static string[] LoadFile(string filepath)
		{
			if(System.
			System.IO.File.ReadAllLines(filepath);
			return filepath.S
		}
		*/
	}
}
