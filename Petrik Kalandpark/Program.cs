using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Petrik_Kalandpark
{
    internal class Program
    {
        static void MenuKiir()
        {
            Console.WriteLine("=== PETRIK KALANDPARK ===");

            Console.WriteLine("\n1.) Napijegy vásárlása");
            Console.WriteLine("2.) Pálya választása");
            Console.WriteLine("3.) Kupon kalkulátor");
            Console.WriteLine("4.) Napi bevétel");
            Console.WriteLine("5.) Kilépés");

            Console.Write("\nVálasztás: ");
        }
        static int JegyVasarlas()
        {
            string name;
            int age;

            Console.WriteLine("=== NAPIJEGY VÁSÁRLÁSA ===");

            Console.Write("\nNév: ");
            name = Console.ReadLine();
            do
            {
                Console.Write("Életkor: ");
                age = Convert.ToInt32(Console.ReadLine());

                if (age < 0 || age > 120)
                {
                    Console.Clear();
                    Console.WriteLine("Hibás életkor!");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (age < 0 || age > 120);

            Console.WriteLine($"\nSzia {name}!");
            Console.WriteLine($"Jegytípus: {JegyTipus(age)}");
            Console.WriteLine($"Fizetendő: {JegyAr(age)} Ft");

            Console.ReadLine();
            return JegyAr(age);
        }
        static string JegyTipus(int eletkor)
        {
            if (eletkor <= 7)
            {
                return "Mini jegy";
            }
            else if (eletkor <= 15)
            {
                return "Junior jegy";
            }
            else if (eletkor <= 24)
            {
                return "Ifjúsági jegy";
            }
            else if (eletkor <= 59)
            {
                return "Felnőttjegy";
            }
            else
            {
                return "Senior jegy";
            }
        }
        static int JegyAr(int eletkor)
        {
            if (eletkor <= 7)
            {
                return 1000;
            }
            else if (eletkor <= 15)
            {
                return 2200;
            }
            else if (eletkor <= 24)
            {
                return 3000;
            }
            else if (eletkor <= 59)
            {
                return 4500;
            }
            else
            {
                return 2800;
            }
        }
        static void PalyaValasztas()
        {
            int answer;
            int height;

            Console.WriteLine("=== KALANDPÁLYÁK ===");

            Console.WriteLine("\n1.) Gyerekpálya");
            Console.WriteLine("2.) Erdei pálya");
            Console.WriteLine("3.) Extrém pálya");

            Console.Write("\nVálasztás: ");
            answer = Convert.ToInt32(Console.ReadLine());

            height = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    if (height >= 90)
                    {
                        Console.WriteLine("Használhatod ezt a pályát!");
                    }
                    else
                    {
                        Console.WriteLine("Nem használhatod ezt a pályát!");
                    }
                    break;
                case 2:
                    if (height >= 130)
                    {
                        Console.WriteLine("Használhatod ezt a pályát!");
                    }
                    else
                    {
                        Console.WriteLine("Nem használhatod ezt a pályát!");
                    }
                    break;
                case 3:
                    if (height >= 160)
                    {
                        Console.WriteLine("Használhatod ezt a pályát!");
                    }
                    else
                    {
                        Console.WriteLine("Nem használhatod ezt a pályát!");
                    }
                    break;
                default:
                    Console.WriteLine("Nincs ilyen pálya!");
                    break;
            }

            Console.ReadLine();
        }
        static void KuponKalkulator()
        {
            int cost;
            int answer;

            Console.WriteLine("=== KUPON KALKULÁTOR ===");

            Console.Write("\nEredeti ár: ");
            cost = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n1.) Nincs kupon");
            Console.WriteLine("2.) SILVER kupon - 10%");
            Console.WriteLine("3.) GOLD kupon - 25%");

            Console.Write("\nKupon: ");
            answer = Convert.ToInt32(Console.ReadLine());

            if (KuponosAr(cost, answer) == 0)
            {
                Console.WriteLine("Nincs ilyen kupon!");
            }
            else
            {
                Console.WriteLine($"\nFizetendő: {KuponosAr(cost, answer)} Ft");
            }

            Console.ReadLine();
        }
        static int KuponosAr(int ar, int kupon)
        {
            switch (kupon)
            {
                case 1:
                    return ar;
                case 2:
                    return ar - (ar * 10 / 100);
                case 3:
                    return ar - (ar * 25 / 100);
                default:
                    return 0;
            }
        }
        static void Bevetel(int money)
        {
            Console.WriteLine("=== NAPI BEVÉTEL ===");

            Console.WriteLine($"\nA kalandpark mai bevétele: {money} Ft");

            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            int answer = 0;
            int money = 0;

            do
            {
                try
                {
                    Console.Clear();
                    MenuKiir();
                    answer = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    switch (answer)
                    {
                        case 1:
                            money += JegyVasarlas();
                            break;
                        case 2:
                            PalyaValasztas();
                            break;
                        case 3:
                            KuponKalkulator();
                            break;
                        case 4:
                            Bevetel(money);
                            break;
                        case 5:
                            Console.WriteLine("Viszlát!");
                            break;
                        default:
                            Console.WriteLine("Nincs ilyen opció!");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Hiba! Számot kell megadni!");
                    Console.ReadLine();
                }
            } while (answer != 5);
        }
    }
}
