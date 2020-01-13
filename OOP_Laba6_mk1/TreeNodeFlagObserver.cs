using System.Windows.Forms;
using StorageForPainDLL;

namespace OOP_Laba6_mk1
{
    public class TreeNodeFlagObserver : IFlagObserver
    {
        private readonly TreeNode _node;

        public TreeNodeFlagObserver(TreeNode node)
        {
            _node = node;
        }

        public void Update(bool flag)
        {
            _node.Checked = flag;
        }
    }
}