using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace Week_9_Assignment_C_Number
{
    class Program
    {
        static void Main(string[] args)
        {
           try
            {
                Console.WriteLine("Enter a File");

                string filePath = Console.ReadLine();

                var numChecker = new Regex(@"^([A-Za-z0-9]+.*)([A-Za-z0-9]+\.)\w{3}$");

                if (numChecker.IsMatch(filePath))
                {
                    Console.WriteLine("Congrats, I got your File! Loading now...");
                }
                else
                {
                    Console.WriteLine("Hey, that's not right");
                }


                StreamReader sr = new StreamReader(filePath);

                string line;
                do
                {
                    line = sr.ReadLine();
                    Console.WriteLine(line);
                }
                while (line != null);
            }
            catch (Exception e)
            {
                Console.WriteLine("Encountered a problem! \n" + e.Message);
            }

            
           
        }
    }
}