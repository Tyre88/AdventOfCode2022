namespace AdventOfCode2022.Services
{
    public class Two
    {
        Dictionary<string, int> baseScore = new Dictionary<string, int>();
        Dictionary<RockPaperScissorPlacement, int> scoringPoints = new Dictionary<RockPaperScissorPlacement, int>();

        public Two()
        {
            baseScore.Add("X", 1);
            baseScore.Add("Y", 2);
            baseScore.Add("Z", 3);

            scoringPoints.Add(RockPaperScissorPlacement.loss, 0);
            scoringPoints.Add(RockPaperScissorPlacement.tie, 3);
            scoringPoints.Add(RockPaperScissorPlacement.win, 6);
        }
        public int CalculateRockPaperScissorsScore()
        {
            int totalScore = 0;
            List<RockPaperScissorFight> fights = GetData();

            foreach (var fight in fights)
            {
                totalScore += (baseScore[fight.MyValue] + scoringPoints[fight.Fight()]);
            }

            return totalScore;
        }

        public int CalculateScorePartTwo()
        {
            int totalScore = 0;
            List<RockPaperScissorFight> fights = GetData();

            foreach (var fight in fights)
            {
                fight.MakeDraw();
                totalScore += (baseScore[fight.MyValue] + scoringPoints[fight.Fight()]);
            }

            return totalScore;
        }

        private List<RockPaperScissorFight> GetData()
        {
            List<RockPaperScissorFight> fights = new List<RockPaperScissorFight>();
            foreach (string line in File.ReadLines("Data/two.txt"))
            {
                fights.Add(new RockPaperScissorFight()
                {
                    ElfValue = line.Substring(0, 1),
                    MyValue = line.Substring(2, 1),
                });
            }

            return fights;
        }
    }

    public enum RockPaperScissorPlacement
    {
        loss,
        tie,
        win
    }

    public class RockPaperScissorFight
    {
        public string ElfValue { get; set; }
        public string MyValue { get; set; }

        public void MakeDraw()
        {
            //Need to loose
            if(MyValue == "X")
            {
                if (ElfValue == "A") MyValue = "Z";
                else if (ElfValue == "B") MyValue = "X";
                else if (ElfValue == "C") MyValue = "Y";
            }
            //Need to make a tie
            else if(MyValue == "Y")
            {
                if (ElfValue == "A") MyValue = "X";
                else if (ElfValue == "B") MyValue = "Y";
                else if (ElfValue == "C") MyValue = "Z";
            }
            //Need to win
            else if(MyValue == "Z")
            {
                if (ElfValue == "A") MyValue = "Y";
                else if (ElfValue == "B") MyValue = "Z";
                else if (ElfValue == "C") MyValue = "X";
            }
        }

        public RockPaperScissorPlacement Fight()
        {
            if(ElfValue == "A")
            {
                if(MyValue == "X") return RockPaperScissorPlacement.tie;
                else if(MyValue == "Y") return RockPaperScissorPlacement.win;
                else return RockPaperScissorPlacement.loss;
            }
            else if(ElfValue == "B")
            {
                if (MyValue == "X") return RockPaperScissorPlacement.loss;
                else if(MyValue == "Y") return RockPaperScissorPlacement.tie;
                else return RockPaperScissorPlacement.win;
            }
            else
            {
                if(MyValue == "X") return RockPaperScissorPlacement.win;
                else if(MyValue == "Y") return RockPaperScissorPlacement.loss;
                else return RockPaperScissorPlacement.tie;
            }
        }
    }
}
