//
// Code by Oskar Lundqvist / Aborvinsch 2016
//
// ------------------------------------------------------------------------------
using System;

namespace Emelie
{
	class MainClass
	{
		static string VERSION = "0.1";


		public static void Main (string[] args)
		{
			Console.WriteLine ("------        Starting Emelie Text Engine v" + VERSION + "        ------\n" +
							   "Code by Oskar Lundqvist 2016 | @oskar_lq | lundqvist.oskar01@gmail.com\n");

			string OUTPUT_FILE = "";

			bool programIsRunning = true;
			EmelieSimulationContext context = new EmelieSimulationContext();
			//EmelieIO.WriteStringToFile(EmelieSimulationContext.Serialize(context,""),OUTPUT_FILE);

			if(args.Length == 1)
			{
				context = Load(args[0]);
			}
			if(args.Length == 2)
			{
				context = Load(args[0]);
				OUTPUT_FILE = args[1];
			}
			if(args.Length == 3)
			{
				context = Load(args[0]);
				OUTPUT_FILE = args[1];
				string[] f = new string[2
				];
				f[0] = "run";
				f[1] = args[2];
				Console.WriteLine(f.Length);
				Run(f,context,OUTPUT_FILE);
				programIsRunning = false;
			}

			string lastCommand = "help";

			while(programIsRunning)
			{
				Console.Write ("Enter a command: ");

				string resultingLine = "";
				while(resultingLine == "")
					resultingLine = Console.ReadLine();

				resultingLine = resultingLine.Replace("\\ ","%20");

				if(resultingLine == "a") resultingLine = lastCommand;
				else lastCommand = resultingLine;

				string[] parameters = resultingLine.Split(new string[] {" ","\t"}, StringSplitOptions.RemoveEmptyEntries);
				string command = parameters[0].ToLower();

				switch(command)
				{
					case "help" : Help(); break;
					
					case "quit" : { 
						programIsRunning = false;
						Console.WriteLine("Closing Emelie...");
					} break;

					case "set_output_file" : { 
						if(CheckParameters("set_output_file",parameters,1))
						{
							OUTPUT_FILE= parameters[1].Replace("%20"," ");
							Log.Msg("OUTPUT_FILE = " + OUTPUT_FILE);
						}
					} break;

					case "load" : { 
						if(CheckParameters("load",parameters,1))
						{
							context = Load(parameters[1]);
						}
					} break;


					case "out" : {
						if(OUTPUT_FILE != "")
						{
							EmelieIO.WriteStringToFile(EmelieSimulationContext.Serialize(context),OUTPUT_FILE);
						}
						else Log.Error("No output file set. Please use \"set_output_file\"");

					} break;

					case "run" : { 
						Run(parameters,context,OUTPUT_FILE);
					} break;

					default : Console.WriteLine ("Unknown command '" + command + "'. Type 'help' to get a list of commands."); break;
				}

			}
		}

		private static void Help()
		{
			Console.WriteLine ("\nLIST OF COMMANDS:\n" +
				"quit - closes the program\n" +
				"help - prints a list of all commands\n" +
				"load -filepath – loads a .emelie file and sets it as current simulation context\n" +
				"set_output_file -filepath – sets the file to write output to\n" +
				"run -times - runs the simulation a certain amount of time");
		}

		private static bool CheckParameters
		(string commandName, string[] parameters, int amount)
		{
			if(parameters.Length != amount + 1)
			{
				Log.Msg("Command '" + commandName + "' requires " + amount.ToString() + " parameter");
				return false;
			}
			return true;
		}

		private static EmelieSimulationContext Load(string path)
		{
			string fileToLoad= path.Replace("%20"," ");
			string fileContents = EmelieIO.ReadFile(fileToLoad);

			if(fileContents != null)
			{
				EmelieSimulationContext context = EmelieSimulationContext.Deserialize(fileContents);
				Log.Msg(context.ToString());
				return context;
			}
			return null;

		}

		private static void Run(string[] parameters, EmelieSimulationContext context, string outputFile)
		{
			outputFile = outputFile.Replace("%20"," ");

			if(CheckParameters("run",parameters,1))
			{
				string runResult = "\n" + 
					"// -- Using Emelie Simulation Engine v." + VERSION + " --\n" + 
					"// -- Generated on " + System.DateTime.Now.ToString("G") + " --\n" +
					"\n#stories\n{\n" +
					"";

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
							EmelieSimulation simulation = new EmelieSimulation();
							string result = simulation.Run(context, VERSION);
							Log.Msg("SIMULATION RESULT: '" + result + "'");
							runResult += result;
						}
						else Log.Msg("No Simulation context has been set! Please load an emelie file to set it!");
					}
					runResult += "}\n\n" +
								 "// [Emelie end]";
					EmelieIO.WriteStringToFile(runResult,outputFile);
				}
			}
		}
	}
}
