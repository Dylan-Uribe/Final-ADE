using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelHeroesAndVillainsTree
{
    public class MarvelTree
    {
        private TreeNode root;

        public MarvelTree() {
            root = null;
        }

        public void Insert(string name, bool isHero)
        {
            root = Insert(root, name, isHero);
        }

        private TreeNode Insert(TreeNode node, string name, bool isHero)
        {
            if (node == null)
            {
                return new TreeNode(name, isHero);
            }
            if (string.Compare(name, node.Name) < 0)
            {
                node.Left = Insert(node.Left, name, isHero);
            }
            else
            {
                node.Right = Insert(node.Right, name, isHero);
            }
            return node;
        }

        public List<string> ListVillains()
        {
            var villains = new List<string>();
            InOrderTraversal(root, villains, false);
            villains.Sort();
            return villains;
        }

        private void InOrderTraversal(TreeNode node, List<string> result, bool ? isHero)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, result, isHero);
            if (isHero == null || node.IsHero == isHero)
            {
                result.Add(node.Name);
            }
            InOrderTraversal(node.Right, result, isHero);
        }

        public List<string> ListHeroesStartingWithC()
        {
            var heroes = new List<string>();
            InOrderTraversal(root, heroes, true, "C");
            return heroes;
        }

        private void InOrderTraversal(TreeNode node, List<string> result, bool? isHero, string startsWith)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, result, isHero, startsWith);
            if ((isHero == null || node.IsHero == isHero) && node.Name.StartsWith(startsWith))
            {
                result.Add(node.Name);
            }
            InOrderTraversal(node.Right, result, isHero, startsWith);
        }

        public int CountHeroes()
        {
            return CountNodes(root, true);
        }

        private int CountNodes(TreeNode node, bool ? isHero)
        {
            if(node == null) return 0;
            int count = (isHero == null || node.IsHero == isHero) ? 1 : 0;
            return count + CountNodes(node.Left, isHero) + CountNodes(node.Right, isHero);
        }

        public void ModifyName(string oldName, string newName)
        {
            var node = FindNode(root, oldName);
            if(node != null)
            {
                node.Name = newName;
            }
        }

        private TreeNode FindNode(TreeNode node, string name)
        {
            if (node == null || node.Name == name)
            {
                return node;
            }
            if (string.Compare(name, node.Name) < 0)
            {
                return FindNode(node.Left, name);
            }
            else
            {
                return FindNode(node.Right, name);
            }
        }

        public List<string> ListHeroesDescending()
        {
            var heroes = new List<string>();
            InOrderTraversal(root, heroes, true);
            heroes.Sort((a, b) => string.Compare(b, a));
            return heroes;
        }

        public void SplitForest (out MarvelTree heroTree, out MarvelTree villainTree)
        {
            heroTree = new MarvelTree();
            villainTree = new MarvelTree();
            SplitTree(root, heroTree, villainTree);
        }

        private void SplitTree(TreeNode node, MarvelTree heroTree, MarvelTree villainTree)
        {
            if (node == null) return;
            if (node.IsHero)
            {
                heroTree.Insert(node.Name, true);
            }
            else
            {
                villainTree.Insert(node.Name, false);
            }
            SplitTree(node.Left, heroTree, villainTree);
            SplitTree(node.Right, heroTree, villainTree);
        }

        public int CountNodes()
        {
            return CountNodes(root, null);
        }

        public List<string> InOrderTraversal()
        {
            var result = new List<string>();
            InOrderTraversal(root, result, null);
            return result;
        }

    }
}
