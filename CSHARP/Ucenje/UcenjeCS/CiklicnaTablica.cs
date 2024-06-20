
namespace UcenjeCS
{
    internal class CiklicnaTablica
    {
        public static void Izvedi()
        {
            int rows, columns;
            while (true)
            {
                Console.Write("Unesi broj redova: ");
                try
                {
                    rows = int.Parse(Console.ReadLine());
                    if (rows < 1 || rows > 20)
                    {
                        Console.WriteLine("Broj redova mora biti veći od 0 i manji od 20!");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Niste unijeli ispravan broj za redove!");
                    continue;
                }

                Console.Write("Unesi broj stupaca: ");
                try
                {
                    columns = int.Parse(Console.ReadLine());
                    if (columns < 1 || columns > 20)
                    {
                        Console.WriteLine("Broj stupaca mora biti veći od 0 i manji od 20!");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Niste unijeli ispravan broj za stupce!");
                    continue;
                }
                break;
            }

            int[,] table = new int[rows, columns];
            int bottomRow = rows - 1;
            int leftColumn = 0;
            int topRow = 0;
            int rightColumn = columns - 1;
            int currentNum = 1;

            Console.WriteLine();
            Console.WriteLine("Redova: {0} - Stupaca: {1} - Ukupno: {2}", rows, columns, table.Length);
            Console.WriteLine("***************************************");

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

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    Console.Write("{0, 5}", table[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
