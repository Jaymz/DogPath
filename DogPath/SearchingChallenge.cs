public class SearchingChallenge
{
    public int Search(params string[] strArr)
    {
        var grid = new Grid(strArr);
        int bestDistance = 9999;
        var permutations = Permutation.GetPermutations(grid.FoodNodes.ToArray());
        foreach (var permutation in permutations)
        {
            int totalDistance = CalculatePermutation(permutation.ToList(), grid);
            if (totalDistance < bestDistance)
            {
                bestDistance = totalDistance;
            }
        }

        return bestDistance;
    }

    int CalculatePermutation(List<(int x, int y)> foodNodes, Grid grid)
    {
        int totalDistance = 0;

        var currentNode = (grid.StartNode.x, grid.StartNode.y);
        foreach (var foodNode in foodNodes)
        {
            var distance = DistanceToNode(currentNode, foodNode, grid.HomeNode);
            totalDistance += distance;

            currentNode = (foodNode.x, foodNode.y);
        }

        totalDistance += DistanceToNode(currentNode, grid.HomeNode);

        return totalDistance;
    }

    int DistanceToNode((int x, int y) start, (int x, int y) target, (int x, int y)? homeNode = null)
    {
        (int x, int y) current = (start.x, start.y);

        int moves = 0;
        while (current.x != target.x || current.y != target.y)
        {
            int currentMoves = moves;
            if (current.x > target.x)
            {
                if (CanMoveToNode((current.x - 1, current.y), homeNode)) {
                    current.x--;
                    moves++;
                }
            }
            if (current.x < target.x)
            {
                if (CanMoveToNode((current.x + 1, current.y), homeNode)) {
                    current.x++;
                    moves++;
                }
            }


            if (current.y > target.y)
            {
                if (CanMoveToNode((current.x, current.y - 1), homeNode))
                {
                    current.y--;
                    moves++;
                }
            }
            if (current.y < target.y)
            {
                if (CanMoveToNode((current.x, current.y + 1), homeNode))
                {
                    current.y++;
                    moves++;
                }
            }

            if (homeNode.HasValue)
            {
                // Hack to move around the home node if it blocked us
                if (moves == currentMoves)
                {
                    var hn = homeNode.Value;
                    if (current.x + 1 == hn.x)
                    {
                        current.x += 2;
                    }
                    else if (current.x - 1 == hn.x)
                    {
                        current.x -= 2;
                    }
                    else if (current.y + 1 == hn.y)
                    {
                        current.y += 2;
                    }
                    else if (current.y - 1 == hn.y)
                    {
                        current.y -= 2;
                    }

                    moves += 4;
                }
            }
        }

        return moves;
    }

    bool CanMoveToNode((int x, int y) node, (int x, int y)? homeNode)
    {
        return homeNode != null && node.x != homeNode?.x || node.y != homeNode?.y;
    }
}
