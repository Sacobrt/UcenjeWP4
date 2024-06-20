
namespace UcenjeCS
{
    internal class E06ForPetlja
    {
        public static void Izvedi()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Osijek");
            }
            Console.WriteLine("********************************");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("********************************");
            int suma = 0;
            for (int i = 1; i <= 100; i++)
            {
                suma += i;
            }
            Console.WriteLine(suma);
            Console.WriteLine("********************************");

            int brojOd = 3;
            int brojDo = 29;
            for (int i = brojOd; i < brojDo; i++)
            {
                if (i % 2 == 0) Console.WriteLine(i);
            }
            Console.WriteLine("********************************");
            int[] niz = { 29, 91, 81, 61, 25, 5, 1, 2 };
            for (int i = 0; i < niz.Length; i++)
            {
                Console.WriteLine(niz[i]);
            }

            Console.WriteLine("********************************");
            for (int i = 20; i >= 10; i--)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("********************************");

            int ukupno = 0;
            bool prim;
            for (int i = 2; i < 1400; i++)
            {
                prim = true;
                for (int j = 2; j < i; j++)
                {
                    //Console.WriteLine("{0} % {1} = {2}", i, j, i % j);
                    if (i % j == 0)
                    {
                        prim = false;
                        break;
                    }
                    if (!prim) ukupno++;
                }
                if (prim) Console.WriteLine(i);

            }
            Console.WriteLine("Nepotrebno izvodio " + ukupno);

            Console.WriteLine("********************************");

            for (int i = 0; i < 10; i++)
            {
                if (i == 3) continue;
                if (i == 5) break;

                Console.WriteLine(i);
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine(i * j);
                    goto labela;
                }
            }

        labela:
            /*Console.WriteLine("********************************");


            int broj;
            for (; ; )
            {
                Console.Write("Unesi broj od 1 do 10: ");
                broj = int.Parse(Console.ReadLine());
                if (broj < 1 || broj > 10)
                {
                    Console.WriteLine("Nisi unio broj u rasponu!");
                    continue;
                }
                break;
            }
            Console.WriteLine(broj);*/


            Console.WriteLine("********************************");

            niz = PodaciInt.niz;

            Console.WriteLine(niz.Length);

            /*for (int i = 0; i < niz.Length; i++)
            {
                Console.WriteLine(niz[i]);
            }*/

            /*for (int i = 0; i < niz.Length; i++)
            {
                if (i % 10000 == 0) Console.Write("*");
                for (int j = i + 1; j < niz.Length; j++)
                {
                    if (niz[i] == niz[j])
                    {
                        Console.WriteLine(niz[i]);
                        goto kraj;
                    }
                }
            }
        kraj:
            Console.WriteLine("********************************");*/

            string[] imena = PodaciString.Niz;
            Console.WriteLine(imena.Length);

            string grad = "Osijek";
            Console.WriteLine(grad[0]);
            Console.WriteLine(grad[grad.Length - 1]);

            // Domaća zadaća. Ispisati tablicu množenja 10x10. Formatirati na ovaj način
            //  1   2   3   4   5  6   7   8   9   10
            //  2   4   6   8  10  12  14  16  18  20
            //  3   6   9  12  15  18  21  24  27  30
            //  4   8  12  16  20  24  28  32  36  40
            //  5  10  15  20  25  30  35  40  45  50
            //  6  12  18  24  30  36  42  48  54  60
            //  7  14  21  28  35  42  49  56  63  70
            //  8  16  24  32  40  48  56  64  72  80
            //  9  18  27  36  45  54  63  72  81  90
            // 10  20  30  40  50  60  70  80  90 100

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0, 5}", (i + 1) * (j + 1));
                }
                Console.WriteLine();
            }
        }
    }
}
