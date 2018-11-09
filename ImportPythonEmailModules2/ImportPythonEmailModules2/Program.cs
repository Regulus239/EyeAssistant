using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
// Taken from https://code.msdn.microsoft.com/windowsdesktop/C-and-Python-interprocess-171378ee
// Altered to fit EyeAssistant by jsneal
// This module is both roughly commented and roughly designed. The importing from Python and the string manipulation
// Produces the desired List of dictionaries to be sent to our UI.

// I need to try importing this into another module.
// I should also run some better test cases on this method as I have only tested this on a few emails and am worried that it will not work for all.
// I also need to clean up commented out code. I have it there for now because I am still testing this code to see it works with various test-case emails.

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
            // Proof that the function works->Build ImportPythonEmailModules2:
            List<Dictionary<string, string>> emailList = new List<Dictionary<string, string>>();
            string pythonEmailString;
            string[] pythonEmailArray;
            pythonEmailString = importPythonEmailString();
            pythonEmailArray = separateEmailStrings(pythonEmailString);
            emailList = createListOfEmailDicts(pythonEmailArray);
            // Then see that these console functions respond appropriately (feel free to index any which way you'd like using the list index and dictionary keys).
            Console.WriteLine(emailList[0]["From"]);
            Console.ReadKey();
        }

       static List<Dictionary<string, string>> createListOfEmailDicts(string[] unfixedEmailArray)
        {
            char[] dictBrackets = { '{', '}' }; // For getting rid of Python dictionary brackets
            char[] singleQuote = { '\'' }; // for getting rid of Python dictionary keys
            string[] emailArrayChars = { "',", ", '" }; // for splitting entries in Python dictionary from each other

            // String manipulation functions for extraction
            List<Dictionary<string, string>> emailList = new List<Dictionary<string, string>>(); // Final output of method to be sent to our UI

            for (int i = 0; i<unfixedEmailArray.Length; i++)
            {
                string[] emailArray;
                unfixedEmailArray[i] = unfixedEmailArray[i].Trim(dictBrackets); // getting rid of Python dictionary brackets

                // Taking a particular dictionary (an email data set) and separating it into fields
                emailArray = unfixedEmailArray[i].Split(emailArrayChars, StringSplitOptions.None);

                // Each element of emailArray corresponds to a field of the email dictionary
                emailArray[0] = emailArray[0].Replace("'Date': ", "").Trim(singleQuote);
                emailArray[1] = emailArray[1].Replace(" 'To': ", "").Trim(singleQuote);
                emailArray[2] = emailArray[2].Replace(" 'Content': ", "").Trim(singleQuote);
                // This next one is kinda hack-y with the Replace("From': ", ""). Need to find a cleaner way.
                emailArray[3] = emailArray[3].Replace(" 'From': ", "").Replace("From': ", "").Trim(singleQuote);
                emailArray[4] = emailArray[4].Replace(" 'Subject': ", "").Trim(singleQuote);

                // Creating C# email dictionary
                Dictionary<string, string> singleEmailDict = new Dictionary<string, string>()
                                        {
                                            {"Date",emailArray[0]},
                                            {"To", emailArray[1]},
                                            {"Content",emailArray[2]},
                                            {"From",emailArray[3]},
                                            {"Subject",emailArray[4]}
                                        };
                // Adding dictionary to list of dictionaries
                emailList.Add(singleEmailDict);
            }

            //List<Dictionary<string, string>> emailListDict; for testing
            //emailListDict = emailString2ListDict(newString); for testing

            // write the output we got from python app 
            //Console.WriteLine(returnStrs[2]);
            //Console.ReadKey();
            return emailList;
        }

        static string importPythonEmailString()
        {
            // full path of python interpreter  (change for your specifications)
            string python = @"C:\Users\jsnea\Anaconda2\python.exe";

            // python app to call (change for your specifications)
            string myPythonMain = "C:\\Users\\jsnea\\Desktop\\ec601code\\Python_Email_Modules\\main.py";

            // Create new process start info 
            ProcessStartInfo python2Filepath = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            python2Filepath.UseShellExecute = false;
            python2Filepath.RedirectStandardOutput = true;

            // start python app with 3 arguments  
            // 1st arguments is pointer to itself,  
            // 2nd and 3rd are actual arguments we want to send 
            python2Filepath.Arguments = myPythonMain;

            Process python2Process = new Process();
            // assign start information to the process 
            python2Process.StartInfo = python2Filepath;

            //Console.WriteLine("Calling main.py"); (from old code, just keeping here for testing)

            // start the process 
            python2Process.Start();

            // Read the standard output of the app we called.  
            // in order to avoid deadlock we will read output first 
            // and then wait for process terminate: 
            StreamReader pythonMainStdOut = python2Process.StandardOutput;
            //string myString = myStreamReader.ReadLine();

            //if you need to read multiple lines, you might use: 
            string stdOutString = pythonMainStdOut.ReadToEnd(); // horrible variable name (needs to be replaced)
            string fixedStdOutString; // horrible variable name (needs to be replaced) for myString without random \r's and \n's from reading from stdout via Python
            fixedStdOutString = stdOutString.Replace("\\r", "").Replace("\\n", ""); // for myString without random \r's and \n's from reading from stdout via Python

            // wait exit signal from the app we called and then close it. 
            python2Process.WaitForExit();
            python2Process.Close();

            return fixedStdOutString;
        }

        static string[] separateEmailStrings(string fixedStdOutString)
        {
            //There are a lot of char[]'s for various trimming steps
            char[] listBrackets = { '[', ']' }; // for getting rid of Python List brackets
            char[] trimQuotes = { '\'' }; // for getting rid of Python dictionary keys

            // A few string[]'s for various splitting steps
            string[] endOfDictChars = { "}, " }; // For splitting dictioanries in the Python list from each other

            string[] returnStrs; // result of split with newString, probably not necessary
            fixedStdOutString = fixedStdOutString.Trim(listBrackets); // getting rid of Python list brackets
            returnStrs = fixedStdOutString.Split(endOfDictChars, StringSplitOptions.None); // getting rid of Python dictionary brackets
            return returnStrs;
        }


    }
}
