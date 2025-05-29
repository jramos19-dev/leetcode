using System.Diagnostics.Contracts;

public class TreeProblems
{
    public bool IsBalanced(TreeNode root)
    {
        return dfs(root).Item1;
    }

    private Tuple<bool, int> dfs(TreeNode root)
    {
        if (root == null)
        {
            return new Tuple<bool, int>(true, 0);
        }

        var left = dfs(root.left);
        var right = dfs(root.right);

        bool balanced = (left.Item1 == true && right.Item1 == true && (Math.Abs(left.Item2 - right.Item2) <= 1));
        int height = 1 + Math.Max(left.Item2, right.Item2);

        return new Tuple<bool, int>(balanced ? true : false, height);
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
