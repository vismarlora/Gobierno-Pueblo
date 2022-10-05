using System;
using System.Threading;

namespace Gobierno_Pueblo
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var num = 0;
            int añosC = 0;
            int añosL = 0;
            var probabilidad = 0;
            int periodo = 4;
            int acL = 0;
            int acC = 0;
            string partido;
            string politica;
            string contienda = "";



            string Partido()
            {
                num = random.Next(0, 2);
                if (num == 0)
                    return "Conservador";
                else
                    return "Liberal";
            }

            string Politica()
            {
                num = random.Next(0, 2);
                if (num == 0)
                    return "Permisiva";
                else
                    return "Coercitiva";
            }

            string ContiendaCivil(int n)
            {
                probabilidad = random.Next(0, 100);

                if (probabilidad >= 1 && probabilidad <= n)
                {

                    return "Baja";
                }
                else
                {

                    return "Alta";
                }
            }

            void CambioDePolitica(string Contienda)
            {
                if (Contienda == "Alta")
                {

                    Console.WriteLine("La politica ha cambiado");
                    if (politica == "Permisiva")
                        politica = "Coercitiva";
                    else
                        politica = "Permisiva";

                }
                else
                {
                    Console.WriteLine("La politica ha cambiado");
                    if (politica == "Coercitiva")
                        politica = "Permisiva";
                    else
                        politica = "Coercitiva";

                }
            }
            void CambioGobierno()
            {
                Console.WriteLine("Cambio de Gobierno");
                acC = 0;
                acL = 0;
                partido = Partido();
                politica = Politica();
            }
            periodo = 4;
            partido = Partido();
            politica = Politica();
            do
            {


                if (acL < 3 && acC < 3)
                {
                    if (partido == "Liberal")
                    {
                        Console.WriteLine("Partido Liberal");
                        for (int i = 0; i < periodo; i++)
                        {
                            añosL++;
                            contienda = ContiendaCivil(50);
                            Console.WriteLine($"Contienda civil: {contienda}");
                            if (contienda == "Alta")
                            {
                                CambioDePolitica(contienda);
                            }
                            Thread.Sleep(2000);
                        }
                        Console.WriteLine("\n\n");

                        acL++;

                    }
                    else if (partido == "Conservador")
                    {
                        Console.WriteLine("Partido Conservador");
                        for (int i = 0; i < periodo; i++)
                        {
                            añosC++;
                            contienda = ContiendaCivil(50);
                            Console.WriteLine($"Contienda civil: {contienda}");
                            if (contienda == "Baja")
                            {
                                CambioDePolitica(contienda);
                            }
                            Thread.Sleep(2000);
                        }
                        Console.WriteLine("\n\n");
                        acC++;

                    }
                }
                else
                {

                    CambioGobierno();
                    Console.WriteLine("\n\n");

                }



            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
