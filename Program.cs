using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace weather_solution
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayNum;
            int maxTemp;
            int minTemp;
            List<Day> days = new List<Day>();

            try
            {
                string path = "./weather.txt";

                //Read lines of the file individually and add to lines array
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    //Bypass empty lines
                    if (line != "")
                    {
                        //Split line into sub strings based on whitespace or * and removing empty sub strings
                        string[] subStrings = line.Split(new char[] { ' ', '*' }, StringSplitOptions.RemoveEmptyEntries);


                        //Handle the line only if the first sub string is made up of digits
                        if (subStrings[0].All(char.IsDigit))
                        {
                            //Assign the max and min temp
                            maxTemp = Convert.ToInt32(subStrings[1]);
                            minTemp = Convert.ToInt32(subStrings[2]);

                            dayNum = subStrings[0];

                            //Create a new object with the day and difference
                            Day newDay = new Day(dayNum, getDifference(maxTemp, minTemp));

                            //Add object to an array
                            days.Add(newDay);
                        }
                    }
                }
                findLowestDif();
            }
            catch (FileNotFoundException e)
            {
                Console.Write(e);
            }


            //Find the difference in max and min temp
            int getDifference(int maxTemp, int minTemp)
            {
                return (maxTemp - minTemp);
            }

            void findLowestDif()
            {
                //New variable of the smallest difference in temp
                Day smallestDif = days[0];

                for (int currentDif = 1; currentDif < days.Count; currentDif++)
                {
                    //Compare currentDif to smallestDif
                    if (days[currentDif].getTempDif < smallestDif.getTempDif)
                    {
                        smallestDif = days[currentDif];
                    }
                }
                Console.WriteLine("The day with the least variation in temperature is day #" + smallestDif.getDayNum + " with a difference of " + smallestDif.getTempDif + " degrees.");
            }
        }
    }
}
