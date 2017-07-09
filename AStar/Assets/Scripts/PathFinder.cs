using System.Collections.Generic;

public static class PathFinder
{
	public static List<Grid.Position> FindPath( Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition )
	{
        PathNode node = BreadthFirstSearch(tiles, fromPosition, toPosition);
        var path = new List<Grid.Position>();

        while (node != null)
        {
            path.Add(node.position);
            node = node.parent;
        }

        path.Reverse();
        return path;
    }

    public class PathNode
    {
        public Grid.Position position;
        public PathNode parent;

        public PathNode(Grid.Position position, PathNode parent)
        {
            this.position = position;
            this.parent = parent;
        }
    }

    private static PathNode BreadthFirstSearch(Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition)
    {
        HashSet<PathNode> nodes = new HashSet<PathNode>();
        var queue = new Queue<PathNode>();

        var root = new PathNode(fromPosition, null);

        nodes.Add(root);
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            PathNode node = queue.Dequeue();
            if (node.position.x == toPosition.x && node.position.y == toPosition.y)
            {
                return node;
            }
            else
            {
                TryEnqueueNode(tiles, queue, nodes, node, new Grid.Position {x = node.position.x + 1, y = node.position.y });
                TryEnqueueNode(tiles, queue, nodes, node, new Grid.Position {x = node.position.x - 1, y = node.position.y });
                TryEnqueueNode(tiles, queue, nodes, node, new Grid.Position {x = node.position.x, y = node.position.y + 1 });
                TryEnqueueNode(tiles, queue, nodes, node, new Grid.Position {x = node.position.x, y = node.position.y - 1 });
                TryEnqueueNode(tiles, queue, nodes, node, new Grid.Position { x = node.position.x + 1, y = node.position.y + 1 });
                TryEnqueueNode(tiles, queue, nodes, node, new Grid.Position { x = node.position.x - 1, y = node.position.y + 1 });
                TryEnqueueNode(tiles, queue, nodes, node, new Grid.Position { x = node.position.x + 1, y = node.position.y - 1 });
                TryEnqueueNode(tiles, queue, nodes, node, new Grid.Position { x = node.position.x - 1, y = node.position.y - 1 });
            }
        }
        return null;
    }

    private static void TryEnqueueNode(Tile[,] tiles, Queue<PathNode> queue, HashSet<PathNode> nodes, PathNode currentNode, Grid.Position position)
    {
        int wBorder = tiles.GetLength(0);
        int hBorder = tiles.GetLength(1);

        if (position.x > wBorder || position.x < 0 || position.y > hBorder || position.y < 0)
        {
            return;
        }

        else
        {
            var node = new PathNode(position, currentNode);

            nodes.Add(node);
            queue.Enqueue(node);
        }
    }
}
