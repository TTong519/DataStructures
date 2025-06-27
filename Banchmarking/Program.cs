using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using DataStructures.Trees;
namespace Banchmarking
{
    [MemoryDiagnoser] //we need this attribute if we want to see memory usage
    public class Test
    {
        AVLTree<int> AVL = new AVLTree<int>();
        BinarySearchTree<int> BST = new BinarySearchTree<int>();
        List<int> List = new List<int>();

        [GlobalSetup] //the baseline attribute 
        public void Setup()
        {
            Random random = new Random(283762384);
            for (int i = 0; i < 5000000; i++)
            {
                int thing = random.Next();
                AVL.Insert(thing);
                BST.Insert(thing);
                List.Add(thing);
            }
        }
        [Benchmark] //we need this one if we want this function to be detected and run
        public void AVLSearch() //MAKE SURE your function is public and non-static
        {
            foreach (var item in List)
            {
                AVL.Find(item);
            }
        }
        [Benchmark]
        public void BSTMark()
        {
            foreach (var item in List)
            {
                BST.Search(item);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Test>();
        }
    }
}
