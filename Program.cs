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
            int dayNum;
            int maxTemp;
            int minTemp;
            List<Day> days = new List<Day>();
            //Handle text file
            try
            {
                string path = "./weather.txt";
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        string[] subStrings = line.Split(new char[] { ' ', '*' }, StringSplitOptions.RemoveEmptyEntries);



                        if (subStrings[0].All(char.IsDigit))
                        {
                            dayNum = Convert.ToInt32(subStrings[0]);

                            if (subStrings[1].All(char.IsDigit))
                            {
                                maxTemp = Convert.ToInt32(subStrings[1]);

                                if (subStrings[2].All(char.IsDigit))
                                {
                                    minTemp = Convert.ToInt32(subStrings[2]);

                                    //Create a new object with the day and difference
                                    Day newDay = new Day(dayNum, getDifference(maxTemp, minTemp));

                                    //Add object to an array
                                    days.Add(newDay);
                                }
                            }
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
                    //If current array object.getTempDif is smaller, variable = current object
                    if (days[currentDif].getTempDif < smallestDif.getTempDif)
                    {
                        smallestDif = days[currentDif];
                    }
                }
                Console.WriteLine("The day with the least variation in temperature is day #" + smallestDif.getDayNum + " with a difference of " + smallestDif.getTempDif + " degrees.");
            }
        }
    }

    //Day class with day# and temperature difference properties and getters and setters
    public class Day
    {
        int dayNum;
        int tempDif;

        public Day(int dayNum, int tempDif)
        {
            this.dayNum = dayNum;
            this.tempDif = tempDif;
        }

        public int getDayNum
        {
            get => dayNum;
            set => dayNum = value;
        }

        public int getTempDif
        {
            get => tempDif;
            set => tempDif = value;
        }
    }
}
