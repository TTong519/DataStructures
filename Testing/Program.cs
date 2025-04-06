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
            BinarySearchTree<int> Tree = new();
            Tree.Insert(58);
            Tree.Insert(57);
            Tree.Insert(76);
            Tree.Insert(10);
            Tree.Insert(31);
            Tree.Insert(90);
            Tree.Insert(74);
            Tree.Insert(62);
            Tree.Insert(67);
            Tree.Remove(76);
            var val = Tree.InOrderTraversal();
            ;
        }
    }
}
