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
			EmelieSimulationContext context;

			while(programIsRunning)
			{
				Console.WriteLine ("Enter a command:");
				string resultingLine = Console.ReadLine();

				string[] parameters = resultingLine.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
				string command = parameters[0];

				switch(command)
				{
					case "help" : Help(); break;
					case "quit" : { 
						programIsRunning = false;
						Console.WriteLine("Closing Emelie...");
					} break;
				default : Console.WriteLine ("Unknown command '" + command + "'. Type 'Help' to get a list of commands."); break;
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

		/*public static string[] LoadFile(string filepath)
		{
			if(System.
			System.IO.File.ReadAllLines(filepath);
			return filepath.S
		}
		*/
	}
}
