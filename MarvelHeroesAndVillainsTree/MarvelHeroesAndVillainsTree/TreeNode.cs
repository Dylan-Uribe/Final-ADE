using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelHeroesAndVillainsTree
{
    public class TreeNode
    {
        public string Name { get; set; }

        public bool IsHero { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode(string name, bool isHero) 
        {
            Name = name;
            IsHero = isHero;
            Left = null; 
            Right = null;
        }
    }
}
