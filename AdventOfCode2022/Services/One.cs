using System.Linq;

namespace AdventOfCode2022.Services
{
    public class One
    {
        public int CalculateTopOneElf()
        {
            return GetEachElfTotalCal().Max();
        }

        public int CalculateTopThreeElves()
        {
            return GetEachElfTotalCal().OrderByDescending(x => x).Take(3).Sum();
        }

        private List<int> GetEachElfTotalCal()
        {
            List<int> listOfTotalCalsPerElf = new List<int>();
            int currentElfVal = 0;
            foreach (var line in File.ReadLines("data/one.txt"))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    currentElfVal += int.Parse(line);
                }
                else
                {
                    listOfTotalCalsPerElf.Add(currentElfVal);
                    currentElfVal = 0;
                }
            }

            return listOfTotalCalsPerElf;
        }
    }
}
