using System.Windows.Forms;
using StorageForPainDLL;

namespace OOP_Laba6_mk1
{
    public class TreeViewStorageObserver : IStorageObserver
    {
        private readonly TreeView _treeView;

        public TreeViewStorageObserver(TreeView treeView)
        {
            _treeView = treeView;
        }

        public void Update(Storage storage)
        {
            _treeView.Nodes.Clear();
            for (var i = 1; i <= storage.GetMaxIndex(); i++)
            {
                var node = new TreeNode();
                ProcessNode(node, storage.GetItem(i));
                _treeView.Nodes.Add(node);
            }
        }

        private void ProcessNode(TreeNode node, Shape shape)
        {
            node.Text = shape.Name;
            node.Checked = shape.Flag;
            shape.AddFlagObserver(new TreeNodeFlagObserver(node));
            node.Tag = new ShapeFlagObserver(shape);

            if (shape.GetType() == typeof(Group))
            {
                var group = (Group) shape;
                var storage = group.GroupStorage;
                for (var i = 1; i <= storage.GetMaxIndex(); i++)
                {
                    var childNode = new TreeNode("Group");
                    ProcessNode(childNode, storage.GetItem(i));
                    node.Nodes.Add(childNode);
                }
            }
        }
    }
}