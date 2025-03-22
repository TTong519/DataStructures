using DataStructures.Trees;
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
            Tree.Insert(7);
            Tree.Insert(5);
            Tree.Insert(9);
            Tree.Insert(3);
            Tree.Insert(6);
            Tree.Insert(8);
            Tree.Insert(10);

            var thing = Tree.LevelOrderTraversal();
            ;
        }
    }
}
