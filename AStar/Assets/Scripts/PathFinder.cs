using System.Collections.Generic;

public static class PathFinder
{
	public static List<Grid.Position> FindPath( Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition )
	{
		var path = new List<Grid.Position>();
		path.Add( fromPosition );
        while (fromPosition.x != toPosition.x || fromPosition.y != toPosition.y)
        {
            if (fromPosition.x < toPosition.x)
            {
                fromPosition.x += 1;
            }

            else if (fromPosition.x > toPosition.x)
            {
                fromPosition.x -= 1;
            }

            if (fromPosition.y < toPosition.y)
            {
                fromPosition.y += 1;
            }

            else if (fromPosition.y > toPosition.y)
            {
                fromPosition.y -= 1;
            }

            path.Add(fromPosition);
        }

        path.Add( toPosition );
		return path;
	}
}
