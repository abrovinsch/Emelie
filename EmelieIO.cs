//
// Code by Oskar Lundqvist / Aborvinsch 2016
//
// ------------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;

namespace Emelie
{
		public static class EmelieIO
	{
		public static void WriteStringToFile (string content, string path)
		{
			if(!path.EndsWith(".txt") && !path.EndsWith(".evert"))
			{
				Log.Error("May only write to .txt or .evert files! You are trying to write to \"" + path + "\"");
				return;
			}

			if(IsFileinUse(path))
			{
				Log.Error("Can't write to \"" + path + "\" because the file is in use by another process");
				return;
			}

			try 
			{
				File.WriteAllText(path, content, Encoding.UTF8);
				Log.Msg ("Succesfully wrote to " + path);
			} 
			catch (Exception ex) 
			{
				Log.Error("failed writing to target: " + ex.Message);
			}
		}

		static bool IsFileinUse(string filePath)
		{
			FileInfo file = new FileInfo(filePath);

			FileStream stream = null;

			try
			{
				stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			}
			catch (System.IO.IOException)
			{
				//the file is unavailable because it is:
				//still being written to
				//or being processed by another thread
				//or does not exist (has already been processed)
				return true;
			}
			finally
			{
				if (stream != null)
					stream.Close();
			}
			return false; 
		}

		public static string ReadFile(string path)
		{
			path = path.Replace("%20","gg");

			if(File.Exists(path))
			{
				try
				{
					string fileContents = File.ReadAllText(path,UTF8Encoding.Default);
					return fileContents;
				}
				catch (Exception ex) 
				{
					Log.Error("failed reading file: " + ex.Message);
					return null;
				}
			}
			else 
			{
				Log.Error("File does not exist: \"" + path + "\"");
				return null;
			}

		}
			
	}

}
