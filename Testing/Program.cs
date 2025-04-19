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
            Random random = new();
            for(int i = 0; i < 1000000; i++)
            {
                Queue<int> results = new();
                List<int> trialresults = new();
                BinarySearchTree<int> ints = new();
                for(int j = 0; j < 1000000; j++)
                {
                    ints.Insert(random.Next(47592572));
                }
                results = ints.InOrderTraversal();
                ints.InOrderTraversalRecursive(trialresults, ints.Root);
                if(!results.SequenceEqual(trialresults))
                {
                    Console.WriteLine("failure");
                    break;
                }
            }
        }
    }
}
