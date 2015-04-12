using UnityEngine;
using System;
using System.Text;
using System.IO;  

//code from Drakestar  http://answers.unity3d.com/questions/279750/loading-data-from-a-txt-file-c.html
public class FileIO  {
	public Word[] Load(string fileName) 
	{
		Word[] returnvals = new Word[50];
		// Handle any problems that might arise when reading the text
		try
		{
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);

			Debug.Log("FUCKING SHIT DAMN ASS NIGGER FUCK");
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:
				int i = 0;
				do
				{
					line = theReader.ReadLine();
					
					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						string[] entries = line.Split();
						returnvals[i] = new Word(entries[0], Convert.ToInt32( entries[1].Trim()) );
					}
					i++;
				}
				while (line != null);
				
				// Done reading, close the reader and return true to broadcast success    

				Debug.Log(returnvals[0].word);
				theReader.Close();
				return (Word[]) returnvals.Clone();
			}
		}
		
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (Exception e)
		{
			Debug.LogException(e);
			return null;
		}
	}
}