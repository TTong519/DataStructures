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
            BinarySearchTree<HighScore> Tree = new();
            Tree.Insert(new(1, "Tyler"));
            Tree.Insert(new(2, "Tyler"));
            Tree.Insert(new(0, "Tyler"));
            Tree.Insert(new(5, "Bob"));
            Tree.Insert(new(5, "Sally"));
            var thing = Tree.Search(new(5, "sdklfajsdlfkasjl"));
            ;
        }
    }
}
