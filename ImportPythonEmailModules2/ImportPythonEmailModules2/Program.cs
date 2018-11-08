using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
// Taken from https://code.msdn.microsoft.com/windowsdesktop/C-and-Python-interprocess-171378ee
// Altered to fit EyeAssistant by jsneal
// This module is both roughly commented and roughly designed. The importing from Python and the string manipulation
// Produces the desired List of dictionaries to be sent to our UI.

// I just need to create a method with these steps and test it as a method (since I've already tested the algorithm) in the main I have here.
// I should also run some better test cases on this method as I have only tested this on a few emails and am worried that it will not work for all.
namespace ImportPythonEmailModules
{
    /// <summary> 
    /// Used to show simple C# and Python interprocess communication 
    /// Author      : Ozcan ILIKHAN 
    /// Created     : 02/26/2015 
    /// Last Update : 04/30/2015 
    /// </summary> 
    class Program
    {
        static void Main(string[] args)
        {
            // full path of python interpreter 
            string python = @"C:\Users\jsnea\Anaconda2\python.exe";

            // python app to call 
            string myPythonApp = "C:\\Users\\jsnea\\Desktop\\ec601code\\Python_Email_Modules\\main.py";

            // Create new process start info 
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;

            // start python app with 3 arguments  
            // 1st arguments is pointer to itself,  
            // 2nd and 3rd are actual arguments we want to send 
            myProcessStartInfo.Arguments = myPythonApp; // + " " + x + " " + y;

            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;

            Console.WriteLine("Calling main.py");

            // start the process 
            myProcess.Start();

            // Read the standard output of the app we called.  
            // in order to avoid deadlock we will read output first 
            // and then wait for process terminate: 
            StreamReader myStreamReader = myProcess.StandardOutput;
            //string myString = myStreamReader.ReadLine();

            //if you need to read multiple lines, you might use: 
            string myString = myStreamReader.ReadToEnd(); // horrible variable name (needs to be replaced)
            string newString; // horrible variable name (needs to be replaced) for myString without random \r's and \n's from reading from stdout via Python
            newString = myString.Replace("\\r", "").Replace("\\n", ""); // for myString without random \r's and \n's from reading from stdout via Python

            // wait exit signal from the app we called and then close it. 
            myProcess.WaitForExit();
            myProcess.Close();

            // String manipulation functions for extraction
            List<Dictionary<string, string>> emailList = new List<Dictionary<string, string>>(); // Final output of method to be sent to our UI
            
            //There are a lot of char[]'s for various trimming steps
            char[] chars2Trim = {'[', ']'}; // for getting rid of Python List brackets
            char[] returnStrsChars2Trim = { '{', '}' }; // For getting rid of Python dictionary brackets
            char[] trimQuotes = {'\''}; // for getting rid of Python dictionary keys

            // A few string[]'s for various splitting steps
            string[] str2Split = { "}, " }; // For splitting dictioanries in the Python list from each other
            string[] splitStrArrayChars = { "',", ", '" }; // for splitting entries in Python dictionary from each other

            string[] returnStrs; // result of split with newString, probably not necessary
            newString = newString.Trim(chars2Trim); // getting rid of Python list brackets
            returnStrs = newString.Split(str2Split, StringSplitOptions.None); // getting rid of Python dictionary brackets
            for (int i = 0; i < returnStrs.Length; i++)
            {
                string[] splitStrArray;
                returnStrs[i] = returnStrs[i].Trim(returnStrsChars2Trim); // getting rid of Python dictionary brackets

                // Taking a particular dictionary (an email data set) and separating it into fields
                splitStrArray = returnStrs[i].Split(splitStrArrayChars, StringSplitOptions.None); 

                // Each element of splitStrArray corresponds to a field of the email dictionary
                splitStrArray[0] = splitStrArray[0].Replace("'Date': ", "").Trim(trimQuotes);
                splitStrArray[1] = splitStrArray[1].Replace(" 'To': ", "").Trim(trimQuotes);
                splitStrArray[2] = splitStrArray[2].Replace(" 'Content': ", "").Trim(trimQuotes);
                splitStrArray[3] = splitStrArray[3].Replace(" 'From': ", "").Replace("From': ", "").Trim(trimQuotes);
                splitStrArray[4] = splitStrArray[4].Replace(" 'Subject': ", "").Trim(trimQuotes);

                // Creating C# email dictionary
                Dictionary<string, string> singleEmailDict = new Dictionary<string, string>()
                                        {
                                            {"Date",splitStrArray[0]},
                                            {"To", splitStrArray[1]},
                                            {"Content",splitStrArray[2]},
                                            {"From",splitStrArray[3]},
                                            {"Subject",splitStrArray[4]}
                                        };
                // Adding dictionary to list of dictionaries
                emailList.Add(singleEmailDict);
            }

            //List<Dictionary<string, string>> emailListDict; for testing
            //emailListDict = emailString2ListDict(newString); for testing

            // write the output we got from python app 
            //Console.WriteLine(returnStrs[2]);
            //Console.ReadKey();
        }

       /* static List<Dictionary<string, string>> emailString2ListDict(string) Perhaps this will be the structure for the method I create later
        {
            List<Dictionary<string, string>> emailListDict;

            


            return emailListDict;
        }*/
    }
}
