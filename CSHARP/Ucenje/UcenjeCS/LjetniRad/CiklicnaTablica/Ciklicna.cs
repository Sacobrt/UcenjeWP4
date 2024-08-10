
namespace UcenjeCS.LjetniRad.CiklicnaTablica
{
    internal class Table
    {
        public Table()
        {
            while (true)
            {
                int rows = Helpers.NumberInput("Unesi broj redova (2-50)", 2, 50);
                int columns = Helpers.NumberInput("Unesi broj stupaca (2-50)", 2, 50);

                int[,] table = new int[rows, columns];

                Console.WriteLine();
                Console.WriteLine("Redova: {0} - Stupaca: {1} - Ukupno: {2}", rows, columns, table.Length);
                Console.WriteLine("***************************************");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("***** OPCIJE *****");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("1. dolje lijevo početak u smjeru kazaljke na satu");
                Console.WriteLine("2. dolje desno početak u smjeru kazaljke na satu (inicijalni zadatak)");
                Console.WriteLine("3. gore lijevo početak u smjeru kazaljke na satu");
                Console.WriteLine("4. gore desno početak u smjeru kazaljke na satu");
                Console.WriteLine("5. dolje lijevo početak u kontra smjeru kazaljke na satu");
                Console.WriteLine("6. dolje desno početak u kontra smjeru kazaljke na satu");
                Console.WriteLine("7. gore lijevo početak u kontra smjeru kazaljke na satu");
                Console.WriteLine("8. gore desno početak u kontra smjeru kazaljke na satu");
                Console.WriteLine("9. sredina lijevo u smjeru kazaljke na satu");
                Console.WriteLine("10. sredina desno u smjeru kazaljke na satu");
                Console.WriteLine("11. sredina gore u smjeru kazaljke na satu");
                Console.WriteLine("12. sredina dolje u smjeru kazaljke na satu");
                Console.WriteLine("13. sredina lijevo u kontra smjeru kazaljke na satu");
                Console.WriteLine("14. sredina desno u kontra smjeru kazaljke na satu");
                Console.WriteLine("15. sredina gore u kontra smjeru kazaljke na satu");
                Console.WriteLine("16. sredina dolje u kontra smjeru kazaljke na satu");
                Console.ForegroundColor = ConsoleColor.Green;
                int option = Helpers.NumberInput("Odaberite opciju (1-16)", 1, 16);
                Console.ForegroundColor = ConsoleColor.White;

                PopuniMatricu(table, option);

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("{0, 5}", table[r, c]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Želite li generirati još jednu tablica? (DA/NE)");
                string response = Console.ReadLine().Trim().ToUpper();
                if (response == "NE") break;
            }
        }
        private static void PopuniMatricu(int[,] table, int option)
        {
            int rows = table.Length;
            int currentNum = 1;

            switch (option)
            {
                case 1:
                    Rotation.BottomLeft(table, ref currentNum);
                    break;
                case 2:
                    Rotation.BottomRight(table, ref currentNum);
                    break;
                case 3:
                    Rotation.TopLeft(table, ref currentNum);
                    break;
                case 4:
                    Rotation.TopRight(table, ref currentNum);
                    break;
                case 5:
                    Rotation.BottomLeftCounter(table, ref currentNum);
                    break;
                case 6:
                    Rotation.BottomRightCounter(table, ref currentNum);
                    break;
                case 7:
                    Rotation.TopLeftCounter(table, ref currentNum);
                    break;
                case 8:
                    Rotation.TopRightCounter(table, ref currentNum);
                    break;
                case 9:
                    Rotation.MiddleLeft(table, ref currentNum);
                    break;
                case 10:
                    Rotation.MiddleRight(table, ref currentNum);
                    break;
                case 11:
                    Rotation.MiddleTop(table, ref currentNum);
                    break;
                case 12:
                    Rotation.MiddleBottom(table, ref currentNum);
                    break;
                case 13:
                    Rotation.MiddleLeftCounter(table, ref currentNum);
                    break;
                case 14:
                    Rotation.MiddleRightCounter(table, ref currentNum);
                    break;
                case 15:
                    Rotation.MiddleTopCounter(table, ref currentNum);
                    break;
                case 16:
                    Rotation.MiddleBottomCounter(table, ref currentNum);
                    break;
            }
        }
    }
}
