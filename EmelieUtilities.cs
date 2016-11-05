// 
//  Code by Oskar Lundqvist / Abrovinsch (c) 2016
// 
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO; 

namespace Emelie
{
	public static class EmelieUtilities
	{
		static Random RANDOM;
		public static int RandomRange(int min, int max)
		{   if(RANDOM == null) RANDOM = new Random(System.DateTime.Now.Millisecond * System.DateTime.Now.Second);
			return RANDOM.Next(min, max);

		}

		public static float RandomRange(float min, float max)
		{   
			if(RANDOM == null) RANDOM = new Random(System.DateTime.Now.Millisecond * System.DateTime.Now.Second);
			return (float)RANDOM.NextDouble() * (max - min) + min;
		}

		public static bool PercentageChance(float percentage)
		{   
			return (RandomRange(0f,100f) <= percentage);
		}

		public static bool IsAllWhiteSpace(string s)
		{
			foreach (char whitespace_symbol in SyntaxDef.WHITESPACE_SYMBOLS)
			{
				s = s.Replace(whitespace_symbol, '');
				s = s.Replace("", "");
			}
			return (s == "");
		}

		public static string RemoveWhiteSpaceInFrontAndBack(string s)
		{
			s = s.TrimStart(SyntaxDef.WHITESPACE_SYMBOLS);
			s = s.TrimEnd(SyntaxDef.WHITESPACE_SYMBOLS);
			return s;
		}

		public static string WriteStringList(IEnumerable<string> list, bool writeHeaderAndFooter)
		{
			string result = "";
			if(writeHeaderAndFooter) result += "-----LIST:-----\n";

			foreach (string s in list)
			{
				result += s + "\n";
			}

			if(writeHeaderAndFooter) result += "--END OF LIST--";

			return result;
		}

		public static string StringArrayToString(IEnumerable<string> list, string separator = "")
		{
			string result = "";
			foreach (string s in list)
			{
				result += s+separator;
			}
			return result;
		}

		public static bool IsLegalIdentifierName(string name)
		{
			if(name.Length == 0) 
			{
				Log.SyntaxError("Illegal Syntax: A identifier must have a name that is at least one character long");
				return false;
			}
			foreach(char intChar in SyntaxDef.LEGAL_INTEGER_CHAR)
			{
				if(name[0] == intChar)
				{
					Log.SyntaxError("Illegal Syntax: Illegal beggining character \"" + intChar + "\" at start of identifier name \"" + 
						name + "\". May not start with a number or a minus sign");
					return false;
				}
			}
			foreach(char illegalChar in SyntaxDef.ILLEGAL_IDENTIFIER_NAME_CHARS)
			{
				if(name.Contains(illegalChar.ToString()))
				{
					Log.SyntaxError("Illegal Syntax: Illegal character \"" + illegalChar + "\" in identifier name \"" + name + "\"");
				}
			}
			return true;
		}
	}
}

