using DataStructures.Trees;
using DataStructures.StacksAndQueues;
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
            Random rand = new(347520934);
            BinarySearchTree<int> Tree = new();
            for(int i = 0; i < 2000000; i++)
            {
                Tree.Insert(rand.Next());
            }
            Queue<int> thing = Tree.InOrderTraversal();
            bool thing1 = true;
            int temp = thing.Dequeue();
            for(int i = 0; i < 1999999; i++)
            {
                if(temp > thing.Dequeue())
                {
                    thing1 = false;
                    break;
                }
            }
            ;
        }
    }
}
