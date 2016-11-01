//
// Code by Oskar Lundqvist / Aborvinsch 2016
//
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Emelie
{
	public static class Log
	{
		private static int syntax_errors;
		public static List<string> SYNTAX_ERRORS = new List<string>();
		public static List<string> ERRORS = new List<string>();
		public static List<string> MESSAGES = new List<string>();

		public static void Error(string errorMsg)
		{
			Console.WriteLine("[ERROR: " + errorMsg+"]");
			MESSAGES.Add(errorMsg);
			ERRORS.Add(errorMsg);
		}

		public static void SyntaxError(string errorMsg)
		{
			syntax_errors++;
			Console.WriteLine("[SYNTAX ERROR: " + errorMsg + "]");
			MESSAGES.Add(errorMsg);
			SYNTAX_ERRORS.Add(errorMsg);
		}

		public static void Msg(string logMsg)
		{
			Console.WriteLine("[" + logMsg +"]");
			MESSAGES.Add(logMsg);
		}

		public static bool HasSyntaxErrors()
		{
			return syntax_errors > 0;
		}

		public static void ResetSyntaxErrors()
		{
			SYNTAX_ERRORS = new List<string>();
			syntax_errors = 0;
		}
	}
}

