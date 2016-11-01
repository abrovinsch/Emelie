// 
//  Code by Oskar Lundqvist / Abrovinsch (c) 2016
// 
// ------------------------------------------------------------------------------

using System;
namespace Emelie
{
	public static class SyntaxDef
	{
		public const string FILE_EXTENSION = ".emelie";

		public static char[] WHITESPACE_SYMBOLS = {' ','\t'};
		public const string COMMENT_SYMBOL = "//";

		public const string ESCAPE_SYMBOL_NOTHING = "§0";
		public const string ESCAPE_SYMBOL_QUOTE_SIGN = "§1";
		public const string ESCAPE_SYMBOL_NUMBER_SIGN = "§2";
		public const string ESCAPE_SYMBOL_DOLLAR = "§3";
		public const string ESCAPE_SYMBOL_EQUALS = "§4";
		public const string ESCAPE_SYMBOL_QUESTION_MARK = "§5";
		public const string ESCAPE_SYMBOL_EXCLAMATION_MARK = "§6";
		public const string ESCAPE_SYMBOL_PLUS = "§7";
		public const string ESCAPE_SYMBOL_OPENING_BRACKET = "§8";
		public const string ESCAPE_SYMBOL_CLOSING_BRACKET = "§9";
		public const string ESCAPE_SYMBOL_OPENING_SQUARE_BRACKET = "§10";
		public const string ESCAPE_SYMBOL_CLOSING_SQUARE_BRACKET = "§11";
		public const string ESCAPE_SYMBOL_PERCENT_SIGN = "§12";

		public const char ESCAPE_CHAR_SPACE = '∫';
		public const char ESCAPE_CHAR_TAB = '»';
		public const char ESCAPE_CHAR_GREATER_THAN = '›';
		public const char ESCAPE_CHAR_LESS_THAN = '‹';
		public const char ESCAPE_CHAR_SEMICOLON = '·';

		public static char[] ILLEGAL_IDENTIFIER_NAME_CHARS = new char[] {'<','>',' ','\t','\n','{','}','[',']','$','#','=','?','!','+','%','(',')'};

		public static char [] LEGAL_INTEGER_CHAR = new char[] {'-','0','1','2','3','4','5','6','7','8','9'};
	}
}