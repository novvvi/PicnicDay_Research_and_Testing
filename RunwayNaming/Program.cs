using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace RunwayNaming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<string> arr = new List<string>(){"NE","SE", "SW", "NW"};
            runWay(arr, 340);
        }

        private static void runWay(List<string> identList, double windDirection)
        {
            // wind 360 = N , wind 0 = all direction
            // pulling le & he ident data because there could be a chance as 90 degree 
            // of wind blowing from the left or right to the runway.
            // remove all the same number 
            // remove all the Char
            // 
            
            

            Regex checkRgx = new Regex(@"^\d{1}");
            string[] caridnals = { "N", "NE", "E", "SE", "S", "SW", "W", "NW", "N" };


            if (checkRgx.IsMatch(identList[1]))
            {
                Console.WriteLine("---------------Degree Type");
                for(int i = 0; i < identList.Count; i++)
                {

                    double runwayDegree;
                    Regex runwayRgx = new Regex(@"^\d{1,2}[A-Z]{1}");


                    if (identList[i].IndexOf("H") == 1)
                    {
                        Console.WriteLine("-----------------H1 check");
                        if (identList.Count == 1)
                        {
                            identList[1] = "All";
                        }
                        else
                        {
                            identList.RemoveAt(i);
                            i --;
                        }
                    }


                    else
                    {
                        Console.WriteLine("--------Degree with Multi");
                        Regex runwaysRgx = new Regex(@"[A-Z]{1}$");

                        
                        if (runwaysRgx.IsMatch(identList[i])) //check string last index == char ? remove char and parse
                        {
                            string removedLastChar = identList[i].Remove(identList[i].Length -1);
                            runwayDegree = Double.Parse(removedLastChar);
                        }
                        else // without char and convert string to double
                        {
                            runwayDegree = Double.Parse(identList[i]);
                        }

                        string identFormat = runwayDegree + "0";
                        double identDegree = double.Parse(identFormat);
                        double result = Math.Abs(identDegree - windDirection);
                        Console.WriteLine($"\n degree: {identFormat}\n");

                        // check if runway are within 90 range of wind"
                        if (result > 90)
                        {
                            int caridenalIndex = (int)Math.Round(((double)identDegree % 360) / 45);
                            identList[i] = caridnals[caridenalIndex];
                            Console.WriteLine(identList[i]);
                        }
                        else
                        {
                            identList.RemoveAt(i);
                            Console.WriteLine("**Out of Range**");
                            i --;
                        }
                    }
                }
                // temperoary console logging
                identList.ForEach(i => Console.Write("{0}\t", i));
            }

            else
            {
                Console.WriteLine("-------------------Caridnals");
                int windIndex = (int)Math.Round(((double)windDirection % 360) / 45);
                Console.WriteLine($"\n {caridnals[windIndex]} Direction \n");
                for(int x = 0; x < identList.Count; x++)
                {
                    string breakStringToChar = caridnals[windIndex];
                    if(identList[x].Intersect(breakStringToChar).Any())
                    {
                        identList.RemoveAt(x);
                        x --;
                    }
                }
                identList.ForEach(i => Console.Write("{0}\t", i));
            }
        
        }
    }
}
