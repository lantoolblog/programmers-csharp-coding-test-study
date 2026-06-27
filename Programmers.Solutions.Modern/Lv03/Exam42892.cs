namespace Programmers.Solutions.Modern.Lv03;

/// <summary>
/// 길 찾기 게임 - 42892
/// - 이 문제는 프로그래머스에서 C#으로는 풀수 없다.
/// </summary>
internal static class Exam42892
{
    private sealed class Node
    {
        public int Value { get; }
        public int X { get; }
        public int Y { get; }

        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(int value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
        }
    }

    public static int[][] Solution(int[][] nodeInfo)
    {
        var nodes = new Node[nodeInfo.Length];

        for (var i = 0; i < nodeInfo.Length; i++)
        {
            nodes[i] = new Node(i + 1, nodeInfo[i][0], nodeInfo[i][1]);
        }

        Array.Sort(nodes, (a, b) => b.Y.CompareTo(a.Y));

        var root = ConstructTree(nodes);

        var preorder = new List<int>();
        PreOrder(root, preorder);

        var postorder = new List<int>();
        PostOrder(root, postorder);

        return [preorder.ToArray(), postorder.ToArray()];
    }

    private static Node ConstructTree(Node[] nodes)
    {
        var root = nodes[0];

        for (var i = 1; i < nodes.Length; i++)
        {
            Insert(root, nodes[i]);
        }

        return root;
    }

    private static void Insert(Node root, Node node)
    {
        // x 좌표에 따라 root 노드가 나타내는 트리에 node 삽입
        if (node.X < root.X)
        {
            // 왼쪽 서브 트리에 삽입
            if (root.Left == null)
            {
                root.Left = node;
            }
            else
            {
                Insert(root.Left, node);
            }
        }
        else
        {
            // 오른쪽 서브 트리에 삽입
            if (root.Right == null)
            {
                root.Right = node;
            }
            else
            {
                Insert(root.Right, node);
            }
        }
    }

    private static void PreOrder(Node? node, List<int> visits)
    {
        if (node == null)
        {
            return;
        }

        visits.Add(node.Value);
        PreOrder(node.Left, visits);
        PreOrder(node.Right, visits);
    }

    private static void PostOrder(Node? node, List<int> visits)
    {
        if (node == null)
        {
            return;
        }

        PostOrder(node.Left, visits);
        PostOrder(node.Right, visits);
        visits.Add(node.Value);
    }
}
