using Playground1.DataStructures;

namespace Playground1 {
    public class BinaryTreeCourt1 {
        public void Play() {

        }

        public BinaryTreeNode MergeTrees(BinaryTreeNode root1, BinaryTreeNode root2) {
            if (root1 == null && root2 == null) return null;
            if (root1 == null) return root2;
            if (root2 == null) return root1;

            var newTree = new BinaryTreeNode();
            newTree.val = root1.val + root2.val;

            newTree.left = MergeTrees(root1.left, root2.left);
            newTree.right = MergeTrees(root1.right, root2.right);

            return newTree;
        }



    }
}