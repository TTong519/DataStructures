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
            BinarySearchTree <int> BST= new BinarySearchTree<int>();
            BST.InsertRecursive(5323);
            BST.InsertRecursive(3427);
            BST.InsertRecursive(7436);
            BST.InsertRecursive(8239);
        }
    }
}
