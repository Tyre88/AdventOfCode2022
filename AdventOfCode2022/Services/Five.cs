using System.Collections.Generic;

namespace AdventOfCode2022.Services
{
    public class Five
    {
        public List<List<string>> GetCargoData()
        {
            List<List<string>> cargoData = new List<List<string>>(9);

            foreach (string line in File.ReadLines("Data/five-cargos.txt"))
            {
                for (int i = 0; i < line.Length; i += 4)
                {
                    string data;
                    if (line.Length >= i + 4)
                    {
                        data = line.Substring(i, 4).Trim().Replace("[", "").Replace("]", "");
                    }
                    else
                    {
                        data = line.Substring(i).Trim().Replace("[", "").Replace("]", "");
                    }

                    if (cargoData.Count <= i / 4)
                    {
                        List<string> newList = new List<string>();
                        newList.Add(data);
                        cargoData.Add(newList);
                    }
                    else
                    {
                        cargoData[i / 4].Insert(0, data);
                    }
                }
            }

            for (int i = 0; i < cargoData.Count; i++)
            {
                cargoData[i] = cargoData[i].Where(d => !string.IsNullOrEmpty(d)).ToList();
            }

            return cargoData;
        }

        public List<CargoMove> GetCargoMoves()
        {
            List<CargoMove> cargoMoves = new List<CargoMove>();
            foreach (string line in File.ReadLines("Data/five.txt"))
            {
                cargoMoves.Add(new CargoMove()
                {
                    FullCargoMoveString = line
                });
            }

            return cargoMoves;
        }

        public string GetCargoLettersAfterFullMove()
        {
            List<List<string>> originalData = GetCargoData();

            foreach (CargoMove move in GetCargoMoves())
            {
                for(int i = 0; i < move.Amount; i++)
                {
                    string letter = originalData[move.FromNumber - 1].Last();
                    originalData[move.FromNumber - 1].RemoveAt(originalData[move.FromNumber - 1].Count - 1);
                    originalData[move.ToNumber - 1].Add(letter);
                }
            }

            return GetLetters(originalData);
        }

        public string GetCargoLetters9001()
        {
            List<List<string>> originalData = GetCargoData();

            foreach (CargoMove move in GetCargoMoves())
            {
                List<string> cratesToMove = originalData[move.FromNumber - 1].TakeLast(move.Amount).ToList();
                originalData[move.FromNumber - 1].RemoveRange(originalData[move.FromNumber - 1].Count() - move.Amount, move.Amount);
                originalData[move.ToNumber - 1].AddRange(cratesToMove);
            }

            return GetLetters(originalData);
        }

        private string GetLetters(List<List<string>> originalData)
        {
            List<string> letters = new List<string>();

            foreach (List<string> data in originalData)
            {
                letters.Add(data.Last());
            }

            return string.Concat(letters);
        }
    }
    public class CargoMove
    {
        public string FullCargoMoveString { get; set; }
        public int Amount 
        {
            get
            {
                return int.Parse(FullCargoMoveString.Substring(FullCargoMoveString.IndexOf("move") + 5, 2).Trim());
            }
        }
        public int FromNumber 
        { 
            get
            {
                return int.Parse(FullCargoMoveString.Substring(FullCargoMoveString.IndexOf("from") + 5, 2).Trim());
            }
        }
        public int ToNumber 
        { 
            get
            {
                return int.Parse(FullCargoMoveString.Substring(FullCargoMoveString.IndexOf("to") + 3, 1));
            }
        }
    }
}
