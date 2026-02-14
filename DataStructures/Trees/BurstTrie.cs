using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class BurstTrie
    {
        public int MaxContainerSize;
        private BurstNode root;
        public int Count => root.Count;
        public BurstTrie(int maxContainerSize = 10)
        {
            MaxContainerSize = maxContainerSize;
            root = new ContainerNode(this);
        }
        public void Insert(string value)
        {
            root = root.Insert(value, 0);
        }
        public bool Remove(string value)
        {
            bool success;
            root = root.Remove(value, 0, out success);
            return success;
        }
        public List<string> Search(string prefix)
        {
            BurstNode node = root.Search(prefix, 0);
            List<string> output = new List<string>();
            node.GetAll(output);
            return output;
        }
        public List<string> GetAll()
        {
            List<string> output = new List<string>();
            root.GetAll(output);
            return output;
        }
    }
}
