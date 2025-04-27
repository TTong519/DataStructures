using DataStructures.Trees;
using DataStructures.StacksAndQueues;
using DataStructures;
namespace Testing
{

    struct HighScore : IComparable<HighScore>
    {
        public int Score;
        public string Name;

        public HighScore(int score, string name)
        {
            Score = score;
            Name = name;
        }

        public int CompareTo(HighScore other)
        {
            return Score.CompareTo(other.Score);
        }

        public override string ToString() => $"{Name} scored {Score}!";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> asdlfasd = new List<int>();
            asdlfasd.Add(1);
            asdlfasd.Add(2);
            asdlfasd.Add(3);
            asdlfasd.Add(4);
            asdlfasd.Add(5);
            asdlfasd.Add(6);
            asdlfasd.Add(7);
            asdlfasd.Insert(3, 1);
            foreach (int i in asdlfasd)
            {
                Console.WriteLine(i);
            }
        }
    }
}
