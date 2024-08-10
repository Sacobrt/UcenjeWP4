
namespace UcenjeCS.LjetniRad.CiklicnaTablica
{
    internal class Rotation
    {
        internal static void BottomLeftCounter(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int bottomRow = rows - 1;
            int leftColumn = 0;
            int topRow = 0;
            int rightColumn = columns - 1;

            while (currentNum <= table.Length)
            {
                for (int i = leftColumn; i <= rightColumn; i++)
                {
                    table[bottomRow, i] = currentNum++;
                }
                bottomRow--;

                for (int i = bottomRow; i >= topRow; i--)
                {
                    table[i, rightColumn] = currentNum++;
                }
                rightColumn--;

                if (topRow <= bottomRow)
                {
                    for (int i = rightColumn; i >= leftColumn; i--)
                    {
                        table[topRow, i] = currentNum++;
                    }
                    topRow++;
                }
                if (leftColumn <= rightColumn)
                {
                    for (int i = topRow; i <= bottomRow; i++)
                    {
                        table[i, leftColumn] = currentNum++;
                    }
                    leftColumn++;
                }
            }
        }
        internal static void BottomRight(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int bottomRow = rows - 1;
            int rightColumn = columns - 1;
            int topRow = 0;
            int leftColumn = 0;

            while (currentNum <= table.Length)
            {
                for (int t = 0; currentNum <= table.Length; t++)
                {
                    for (int i = rightColumn; i >= leftColumn; i--)
                    {
                        table[bottomRow, i] = currentNum++;
                    }
                    bottomRow--;

                    for (int i = bottomRow; i >= topRow; i--)
                    {
                        table[i, leftColumn] = currentNum++;
                    }
                    leftColumn++;

                    if (topRow <= bottomRow)
                    {
                        for (int i = leftColumn; i <= rightColumn; i++)
                        {
                            table[topRow, i] = currentNum++;
                        }
                        topRow++;
                    }
                    if (leftColumn <= rightColumn)
                    {
                        for (int i = topRow; i <= bottomRow; i++)
                        {
                            table[i, rightColumn] = currentNum++;
                        }
                        rightColumn--;
                    }
                }
            }
        }
        internal static void TopLeft(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int topRow = 0;
            int rightColumn = columns - 1;
            int bottomRow = rows - 1;
            int leftColumn = 0;

            while (currentNum <= table.Length)
            {
                for (int i = leftColumn; i <= rightColumn; i++)
                {
                    table[topRow, i] = currentNum++;
                }
                topRow++;

                for (int i = topRow; i <= bottomRow; i++)
                {
                    table[i, rightColumn] = currentNum++;
                }
                rightColumn--;

                if (topRow <= bottomRow)
                {
                    for (int i = rightColumn; i >= leftColumn; i--)
                    {
                        table[bottomRow, i] = currentNum++;
                    }
                    bottomRow--;
                }
                if (leftColumn <= rightColumn)
                {
                    for (int i = bottomRow; i >= topRow; i--)
                    {
                        table[i, leftColumn] = currentNum++;
                    }
                    leftColumn++;
                }
            }
        }
        internal static void TopRightCounter(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int topRow = 0;
            int rightColumn = columns - 1;
            int bottomRow = rows - 1;
            int leftColumn = 0;

            while (currentNum <= table.Length)
            {
                for (int i = rightColumn; i >= leftColumn; i--)
                {
                    table[topRow, i] = currentNum++;
                }
                topRow++;

                for (int i = topRow; i <= bottomRow; i++)
                {
                    table[i, leftColumn] = currentNum++;
                }
                leftColumn++;

                if (topRow <= bottomRow)
                {
                    for (int i = leftColumn; i <= rightColumn; i++)
                    {
                        table[bottomRow, i] = currentNum++;
                    }
                    bottomRow--;
                }
                if (leftColumn <= rightColumn)
                {
                    for (int i = bottomRow; i >= topRow; i--)
                    {
                        table[i, rightColumn] = currentNum++;
                    }
                    rightColumn--;
                }
            }
        }
        internal static void TopRight(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int topRow = 0;
            int rightColumn = columns - 1;
            int bottomRow = rows - 1;
            int leftColumn = 0;

            while (currentNum <= table.Length)
            {
                for (int i = topRow; i <= bottomRow; i++)
                {
                    table[i, rightColumn] = currentNum++;
                }
                rightColumn--;

                for (int i = rightColumn; i >= leftColumn; i--)
                {
                    table[bottomRow, i] = currentNum++;
                }
                bottomRow--;

                if (leftColumn <= rightColumn)
                {
                    for (int i = bottomRow; i >= topRow; i--)
                    {
                        table[i, leftColumn] = currentNum++;
                    }
                    leftColumn++;
                }
                if (topRow <= bottomRow)
                {
                    for (int i = leftColumn; i <= rightColumn; i++)
                    {
                        table[topRow, i] = currentNum++;
                    }
                    topRow++;
                }
            }
        }
        internal static void BottomLeft(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int bottomRow = rows - 1;
            int leftColumn = 0;
            int topRow = 0;
            int rightColumn = columns - 1;

            while (currentNum <= table.Length)
            {
                for (int i = bottomRow; i >= topRow; i--)
                {
                    table[i, leftColumn] = currentNum++;
                }
                leftColumn++;

                for (int i = leftColumn; i <= rightColumn; i++)
                {
                    table[topRow, i] = currentNum++;
                }
                topRow++;

                if (leftColumn <= rightColumn)
                {
                    for (int i = topRow; i <= bottomRow; i++)
                    {
                        table[i, rightColumn] = currentNum++;
                    }
                    rightColumn--;
                }
                if (topRow <= bottomRow)
                {
                    for (int i = rightColumn; i >= leftColumn; i--)
                    {
                        table[bottomRow, i] = currentNum++;
                    }
                    bottomRow--;
                }
            }
        }
        internal static void BottomRightCounter(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int bottomRow = rows - 1;
            int rightColumn = columns - 1;
            int topRow = 0;
            int leftColumn = 0;

            while (currentNum <= table.Length)
            {
                for (int i = bottomRow; i >= topRow; i--)
                {
                    table[i, rightColumn] = currentNum++;
                }
                rightColumn--;

                for (int i = rightColumn; i >= leftColumn; i--)
                {
                    table[topRow, i] = currentNum++;
                }
                topRow++;

                if (leftColumn <= rightColumn)
                {
                    for (int i = topRow; i <= bottomRow; i++)
                    {
                        table[i, leftColumn] = currentNum++;
                    }
                    leftColumn++;
                }
                if (topRow <= bottomRow)
                {
                    for (int i = leftColumn; i <= rightColumn; i++)
                    {
                        table[bottomRow, i] = currentNum++;
                    }
                    bottomRow--;
                }
            }
        }
        internal static void TopLeftCounter(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int topRow = 0;
            int leftColumn = 0;
            int bottomRow = rows - 1;
            int rightColumn = columns - 1;

            while (currentNum <= table.Length)
            {
                for (int i = topRow; i <= bottomRow; i++)
                {
                    table[i, leftColumn] = currentNum++;
                }
                leftColumn++;

                for (int i = leftColumn; i <= rightColumn; i++)
                {
                    table[bottomRow, i] = currentNum++;
                }
                bottomRow--;

                if (leftColumn <= rightColumn)
                {
                    for (int i = bottomRow; i >= topRow; i--)
                    {
                        table[i, rightColumn] = currentNum++;
                    }
                    rightColumn--;
                }
                if (topRow <= bottomRow)
                {
                    for (int i = rightColumn; i >= leftColumn; i--)
                    {
                        table[topRow, i] = currentNum++;
                    }
                    topRow++;
                }
            }
        }
        internal static void MiddleLeft(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int centerRow = rows / 2;
            int centerColumn = columns / 2;
            int currentRow = centerRow;
            int currentColumn = centerColumn;

            int[,] directions = new int[,]
            {
                { 0, -1 }, // left
                { -1, 0 }, // top
                { 0, 1 },  // right
                { 1, 0 }   // bottom
            };
            int directionIndex = 0;
            int steps = 1;

            while (currentNum <= table.Length)
            {
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (currentRow >= 0 && currentRow < rows && currentColumn >= 0 && currentColumn < columns)
                        {
                            table[currentRow, currentColumn] = currentNum++;
                        }
                        currentRow += directions[directionIndex, 0];
                        currentColumn += directions[directionIndex, 1];
                    }

                    directionIndex = (directionIndex + 1) % 4;
                }
                steps++;
            }
        }
        internal static void MiddleRight(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int centerRow = rows / 2;
            int centerColumn = columns / 2;
            int currentRow = centerRow;
            int currentColumn = centerColumn;

            int[,] directions = new int[,]
            {
                { 0, 1 },  // right
                { 1, 0 },  // bottom
                { 0, -1 }, // left
                { -1, 0 }  // top
            };
            int directionIndex = 0;
            int steps = 1;

            while (currentNum <= table.Length)
            {
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (currentRow >= 0 && currentRow < rows && currentColumn >= 0 && currentColumn < columns)
                        {
                            table[currentRow, currentColumn] = currentNum++;
                        }
                        currentRow += directions[directionIndex, 0];
                        currentColumn += directions[directionIndex, 1];
                    }

                    directionIndex = (directionIndex + 1) % 4;
                }
                steps++;
            }
        }
        internal static void MiddleTop(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int centerRow = rows / 2;
            int centerColumn = columns / 2;
            int currentRow = centerRow;
            int currentColumn = centerColumn;

            int[,] directions = new int[,]
            {
                { -1, 0 }, // top
                { 0, 1 },  // right
                { 1, 0 },  // bottom
                { 0, -1 }  // left
            };
            int directionIndex = 0;
            int steps = 1;

            while (currentNum <= table.Length)
            {
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (currentRow >= 0 && currentRow < rows && currentColumn >= 0 && currentColumn < columns)
                        {
                            table[currentRow, currentColumn] = currentNum++;
                        }
                        currentRow += directions[directionIndex, 0];
                        currentColumn += directions[directionIndex, 1];
                    }

                    directionIndex = (directionIndex + 1) % 4;
                }
                steps++;
            }
        }
        internal static void MiddleBottom(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int centerRow = rows / 2;
            int centerColumn = columns / 2;
            int currentRow = centerRow;
            int currentColumn = centerColumn;

            int[,] directions = new int[,]
            {
                { 1, 0 },  // bottom
                { 0, -1 }, // left
                { -1, 0 }, // top
                { 0, 1 }   // right
            };
            int directionIndex = 0;
            int steps = 1;

            while (currentNum <= table.Length)
            {
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (currentRow >= 0 && currentRow < rows && currentColumn >= 0 && currentColumn < columns)
                        {
                            table[currentRow, currentColumn] = currentNum++;
                        }
                        currentRow += directions[directionIndex, 0];
                        currentColumn += directions[directionIndex, 1];
                    }

                    directionIndex = (directionIndex + 1) % 4;
                }
                steps++;
            }
        }
        internal static void MiddleLeftCounter(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int centerRow = rows / 2;
            int centerColumn = columns / 2;
            int currentRow = centerRow;
            int currentColumn = centerColumn;

            int[,] directions = new int[,]
            {
                { 0, -1 }, // left
                { 1, 0 },  // bottom
                { 0, 1 },  // right
                { -1, 0 }  // top
            };
            int directionIndex = 0;
            int steps = 1;

            while (currentNum <= table.Length)
            {
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (currentRow >= 0 && currentRow < rows && currentColumn >= 0 && currentColumn < columns)
                        {
                            table[currentRow, currentColumn] = currentNum++;
                        }
                        currentRow += directions[directionIndex, 0];
                        currentColumn += directions[directionIndex, 1];
                    }

                    directionIndex = (directionIndex + 1) % 4;
                }
                steps++;
            }
        }
        internal static void MiddleRightCounter(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int centerRow = rows / 2;
            int centerColumn = columns / 2;
            int currentRow = centerRow;
            int currentColumn = centerColumn;

            int[,] directions = new int[,]
            {
                { 0, 1 },  // right
                { -1, 0 }, // top
                { 0, -1 }, // left
                { 1, 0 }   // bottom
            };
            int directionIndex = 0;
            int steps = 1;

            while (currentNum <= table.Length)
            {
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (currentRow >= 0 && currentRow < rows && currentColumn >= 0 && currentColumn < columns)
                        {
                            table[currentRow, currentColumn] = currentNum++;
                        }
                        currentRow += directions[directionIndex, 0];
                        currentColumn += directions[directionIndex, 1];
                    }

                    directionIndex = (directionIndex + 1) % 4;
                }
                steps++;
            }
        }
        internal static void MiddleTopCounter(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int centerRow = rows / 2;
            int centerColumn = columns / 2;
            int currentRow = centerRow;
            int currentColumn = centerColumn;

            int[,] directions = new int[,]
            {
                { -1, 0 }, // top
                { 0, -1 }, // left
                { 1, 0 },  // bottom
                { 0, 1 },  // right
            };
            int directionIndex = 0;
            int steps = 1;

            while (currentNum <= table.Length)
            {
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (currentRow >= 0 && currentRow < rows && currentColumn >= 0 && currentColumn < columns)
                        {
                            table[currentRow, currentColumn] = currentNum++;
                        }
                        currentRow += directions[directionIndex, 0];
                        currentColumn += directions[directionIndex, 1];
                    }

                    directionIndex = (directionIndex + 1) % 4;
                }
                steps++;
            }
        }
        internal static void MiddleBottomCounter(int[,] table, ref int currentNum)
        {
            int rows = table.GetLength(0);
            int columns = table.GetLength(1);
            int centerRow = rows / 2;
            int centerColumn = columns / 2;
            int currentRow = centerRow;
            int currentColumn = centerColumn;

            int[,] directions = new int[,]
            {
                { 1, 0 },  // bottom
                { 0, 1 },  // right
                { -1, 0 }, // top
                { 0, -1 }  // left
            };
            int directionIndex = 0;
            int steps = 1;

            while (currentNum <= table.Length)
            {
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (currentRow >= 0 && currentRow < rows && currentColumn >= 0 && currentColumn < columns)
                        {
                            table[currentRow, currentColumn] = currentNum++;
                        }
                        currentRow += directions[directionIndex, 0];
                        currentColumn += directions[directionIndex, 1];
                    }

                    directionIndex = (directionIndex + 1) % 4;
                }
                steps++;
            }
        }
    }
}
