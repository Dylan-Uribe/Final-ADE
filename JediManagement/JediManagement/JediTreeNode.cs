using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediManagement
{
    public class JediTreeNode
    {
        public Jedi Jedi { get; set; }
        public JediTreeNode Left {  get; set; }
        public JediTreeNode Right { get; set; }

        public JediTreeNode(Jedi jedi) 
        {
            Jedi = jedi;
            Left = null; Right = null;
        }
    }
}
