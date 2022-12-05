using Microsoft.AspNetCore.Http.Connections;

namespace AdventOfCode2022.Services
{
    public class Three
    {
        public List<Backpack> GetBackpacks()
        {
            List<Backpack> backpacks = new List<Backpack>();
            foreach (string line in File.ReadLines("Data/three.txt"))
            {
                int length = line.Length;
                backpacks.Add(new Backpack()
                {
                    FirstCompartment = line.Substring(0, length / 2),
                    SecoundCompartment = line.Substring(length / 2),
                });
            }

            return backpacks;
        }

        public int GetBackpacksTotalScore()
        {
            int totalScore = 0;
            foreach (Backpack backpack in GetBackpacks())
            {
                string backpackChar = GetCompartmentSameChar(backpack);
                totalScore += GetScoreFromChar(backpackChar);
            }

            return totalScore;
        }

        public int GetElfPackTotalScore()
        {
            int totalScore = 0;
            foreach (string c in GetElfPackSameChar(GetBackpacks()))
            {
                totalScore += GetScoreFromChar(c);
            }

            return totalScore;
        }
        

        private int GetScoreFromChar(string backpackChar)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return alphabet.IndexOf(backpackChar) + 1;
        }

        private string GetCompartmentSameChar(Backpack backpack)
        {
            string result = string.Empty;

            char[] compartmentOneChars = backpack.FirstCompartment.ToCharArray();
            char[] compartmentTwoChars = backpack.SecoundCompartment.ToCharArray();

            foreach (char oneChar in compartmentOneChars)
            {
                foreach (char twoChar in compartmentTwoChars)
                {
                    if (oneChar == twoChar) result = oneChar.ToString();
                }
            }

            return result;
        }

        private List<string> GetElfPackSameChar(List<Backpack> backpacks)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < backpacks.Count; i+= 3)
            {
                bool gotHit = false;
                foreach (char oneChar in backpacks[i].AllCompartments.ToCharArray())
                {
                    foreach (char twoChar in backpacks[i + 1].AllCompartments.ToCharArray())
                    {
                        foreach (char threeChar in backpacks[i + 2].AllCompartments.ToCharArray())
                        {
                            if (oneChar == twoChar && oneChar == threeChar && twoChar == threeChar)
                            {
                                result.Add(oneChar.ToString());
                                gotHit = true;
                                break;
                            }
                        }
                        if (gotHit) break;
                    }
                    if (gotHit) break;
                }
            }

            return result;
        }

    }

    public class Backpack
    {
        public string FirstCompartment { get; set; }
        public string SecoundCompartment { get; set; }
        public string AllCompartments { get { return FirstCompartment + SecoundCompartment; } }
    }
}
