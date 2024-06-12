using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediManagement
{
    public class JediTree
    {
        private JediTreeNode root;

        public JediTree() { root = null;}

        public void Insert(Jedi data, Func<Jedi, string> keySelector)
        {
            root = Insert(root, data, keySelector);
        }

        private JediTreeNode Insert(JediTreeNode node, Jedi data, Func<Jedi, string> keySelector)
        {
            if (node == null)
            {
                return new JediTreeNode(data);
            }
            if (string.Compare(keySelector(data), keySelector(node.Jedi)) < 0)
            {
                node.Left = Insert(node.Left, data, keySelector);
            }
            else
            {
                node.Right = Insert(node.Right, data, keySelector);
            }
            return node;
        }

        public List<Jedi> InOrderTraversal()
        {
            var result = new List<Jedi>();
            InOrderTraversal(root, result);
            return result;
        }

        private void InOrderTraversal(JediTreeNode node, List<Jedi> result)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, result);
            result.Add(node.Jedi);
            InOrderTraversal(node.Right, result);
        }

        public List<Jedi> LevelOrderTraversal()
        {
            var result = new List<Jedi>();
            if (root == null) return result;

            var queue = new Queue<JediTreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current.Jedi);

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }

            return result;
        }

    }
}
