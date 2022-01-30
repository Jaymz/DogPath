public class Grid
{
    public char[][] Cells;

    public Grid(params string[] strArr)
    {
        FoodNodes = new List<(int x, int y)>();

        Cells = new char[strArr.Length][];
        for (int x = 0; x < strArr.Length; x++)
        {
            Cells[x] = new char[strArr[x].Length];

            for (int y = 0; y < strArr[x].Length; y++)
            {
                Cells[x][y] = strArr[y][x];

                switch (strArr[y][x])
                {
                    case 'F': 
                        FoodNodes.Add((x, y));
                        break;
                    case 'H':
                        HomeNode = (x, y);
                        break;
                    case 'C':
                        StartNode = (x, y);
                        break;
                }
            }
        }
    }

    public List<(int x, int y)> FoodNodes { get; private set; }
    public (int x, int y) HomeNode { get; set; }
    public (int x, int y) StartNode { get; set; }
}
