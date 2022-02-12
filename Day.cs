using System;
namespace weather_solution
{
    public class Day
    {
        string dayNum;
        int tempDif;

        public Day(string dayNum, int tempDif)
        {
            this.dayNum = dayNum;
            this.tempDif = tempDif;
        }

        public string getDayNum
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
