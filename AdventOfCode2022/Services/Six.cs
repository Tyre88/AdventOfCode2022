namespace AdventOfCode2022.Services
{
    public class Six
    {
        private string GetDataStream()
        {
            return File.ReadAllText("Data/six.txt");
        }

        public int GetFirstMarker(int amount)
        {
            return GetMarkers(GetDataStream(), amount).First();
        }

        private List<int> GetMarkers(string data, int amount)
        {
            List<int> markers = new List<int>();
            List<char> chars = data.ToCharArray().ToList();

            for (int i = 0; i < chars.Count; i++)
            {
                List<char> chunk = chars.Skip(i).Take(amount).ToList();
                bool isMarker = true;
                foreach (char c in chunk)
                {
                    if (chunk.Count(x => x == c) > 1)
                    {
                        isMarker = false;
                        break;
                    }
                }
                if (isMarker)
                {
                    markers.Add(i + amount);
                }
            }

            return markers;
        }
    }
}
