namespace AdventOfCode2022.Services
{
    public class Four
    {

        public int GetFullyOverlappingElfCount()
        {
            int overlappingElfCount = 0;

            foreach (Assignment item in GetAssignments())
            {
                if (item.IsFullyOverlapping())
                {
                    overlappingElfCount++;
                }
            }

            return overlappingElfCount;
        }

        public int GetOverlappingElfCount()
        {
            return GetAssignments().Count(a => a.IsOverlapping());
        }
        
        private List<Assignment> GetAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();
            foreach (string line in File.ReadLines("Data/four.txt"))
            {
                List<string> lineSplit = line.Split(',').ToList();
                assignments.Add(new Assignment()
                {
                    FirstElf = lineSplit[0],
                    SecoundElf = lineSplit[1],
                });
            }

            return assignments;
        }
    }

    public class Assignment
    {
        public string FirstElf { get; set; }
        public string SecoundElf { get; set; }

        internal bool IsFullyOverlapping()
        {
            int firstElfStartIndex = int.Parse(FirstElf.Split('-')[0]);
            int firstElfEndIndex = int.Parse(FirstElf.Split('-')[1]);

            int secoundElfStartIndex = int.Parse(SecoundElf.Split('-')[0]);
            int secoundElfEndIndex = int.Parse(SecoundElf.Split('-')[1]);

            if ((firstElfStartIndex <= secoundElfStartIndex && firstElfEndIndex >= secoundElfEndIndex)
                || (secoundElfStartIndex <= firstElfStartIndex && secoundElfEndIndex >= firstElfEndIndex))
            {
                return true;
            }
            else return false;
        }

        internal bool IsOverlapping()
        {
            int firstElfStartIndex = int.Parse(FirstElf.Split('-')[0]);
            int firstElfEndIndex = int.Parse(FirstElf.Split('-')[1]);

            int secoundElfStartIndex = int.Parse(SecoundElf.Split('-')[0]);
            int secoundElfEndIndex = int.Parse(SecoundElf.Split('-')[1]);

            if ((firstElfStartIndex <= secoundElfStartIndex && firstElfEndIndex >= secoundElfStartIndex)
                || (secoundElfStartIndex <= firstElfStartIndex && secoundElfEndIndex >= firstElfStartIndex))
            {
                return true;
            }
            
            else return false;
        }
    }
}
