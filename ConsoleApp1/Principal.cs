using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica1
{
    class Principal
    {
        static void Main(string[] args)
        {
            Tv tele = new Tv();
            Principal p = new Principal();
            ConsoleKey[] teclas = { ConsoleKey.Enter, ConsoleKey.Spacebar, ConsoleKey.Backspace, ConsoleKey.UpArrow,
                                    ConsoleKey.DownArrow, ConsoleKey.I, ConsoleKey.Escape};

            ConsoleKey ck;

            p.datosTV(ref tele);

            p.menu();
            ck = Console.ReadKey().Key;

            do
            {
                p.seleccion(ck, tele);
                int n;
                
                do
                {
                    System.Threading.Thread.Sleep(1);
                    ck = Console.ReadKey().Key;
                    n = Array.IndexOf(teclas, ck);
                    Console.WriteLine(n);
                } while (n < 0);

                p.menu();
                                
            } while (ck != ConsoleKey.Escape);
            
        }

        #region Imprimir especiales
        public static void impVerde(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(s);
            Console.ResetColor();
        }

        public static void impCyan(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(s);
            Console.ResetColor();
        }
        
        public static void impError(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(s);
            Console.ResetColor();
        }

        #endregion

        #region Comprobación de Inputs
        private int comprobarNumInt(string s)
        {
            int n;
            bool esNum = int.TryParse(s, out n);

            if (s.Length == 0)  //Comprueba que no esté vacío
            {
                impError("\nERROR. No ha introducido ningún valor.\n");
            }
            else if (!esNum)    //Comprueba que sea un valor numérico
            {
                impError("\nERROR. Valor no entero numérico.\n");
            }
            else if (s.Length > 8)  //Limita la longitud
            {
                impError("\nERROR. Número demasiado extenso.\n");
                n = -1;
            }

            return n;
        }

        //Método para comprobar que la entrada sea un double
        private double comprobarNumDouble(string s)
        {
            double n;

            //Sustitución del punto por una coma en caso de decimal
            s = s.Replace('.', ',');

            bool esNum = double.TryParse(s, out n);

            if (s.Length == 0)  //Comprueba que no esté vacío
            {
                impError("\nERROR. No ha introducido ningún valor.\n");
            }
            else if (!esNum)    //Comprueba que sea un valor numérico
            {
                impError("\nERROR. Valor no numérico.\n");
            }
            else if (s.Length > 15)  //Limita la longitud
            {
                impError("\nERROR. Número demasiado extenso.\n");
                n = 0;
            }

            return n;
        }

        //Método pulsar para continuar
        public void continuar()
        {
            Console.Write("\nPulse cualquier tecla para continuar.");
            Console.ReadKey();
            Console.WriteLine("\n");
        }
        #endregion

        public void datosTV(ref Tv tele)
        {
            Console.WriteLine("Introduzca los datos de su nueva televisión:\n");

            impVerde("Marca: ");
            tele.Marca = Console.ReadLine();
            
            do
            {
                impVerde("\nPulgadas: ");
                tele.Pulgadas = comprobarNumDouble(Console.ReadLine());
            } while (tele.Pulgadas == 0);

            do
            {
                impVerde("\nConsumo: ");
                tele.Consumo = comprobarNumDouble(Console.ReadLine());
            } while (tele.Consumo == 0);

            do
            {
                impVerde("\nPrecio: ");
                tele.Precio = comprobarNumDouble(Console.ReadLine());
            } while (tele.Precio == 0);
        }
                
        #region Menú
        public void menu()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────────┐");
            Console.WriteLine("|    Seleccione una opción:                |");
            Console.WriteLine("| Enter.    Apagar/Encender                |");
            Console.WriteLine("| Espacio.  Cambiar de canal               |");
            Console.WriteLine("| Back.     Canal anterior                 |");
            Console.WriteLine("| ↑.        Subir Volumen                  |");
            Console.WriteLine("| ↓.        Bajar Volumen                  |");
            Console.WriteLine("| i.        Información Técnica            |");
            Console.WriteLine("| Esc.      Salir                          |");
            Console.WriteLine("└──────────────────────────────────────────┘");
        }

        public void seleccion(ConsoleKey ck, Tv tele)
        {
            switch(ck)
            {
                case ConsoleKey.Enter:
                    tele.pulsarOnOff();
                    tele.mostrarEstado();
                    break;
                case ConsoleKey.Spacebar:
                    if (tele.estadoActual())
                    {
                        Console.Write("\nIntroduzca un ");
                        impVerde("canal: ");
                        int canal = comprobarNumInt(Console.ReadLine());
                        tele.ponerCanal(canal);
                        tele.mostrarEstado();
                    }
                    break;
                case ConsoleKey.Backspace:
                    if (tele.estadoActual())
                    {
                        tele.cambiarCanalAnterior();
                        tele.mostrarEstado();
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (tele.estadoActual())
                    {
                        tele.subirVolumen();
                        tele.mostrarEstado();
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (tele.estadoActual())
                    {
                        tele.bajarVolumen();
                        tele.mostrarEstado();
                    }
                    break;
                case ConsoleKey.I:
                    tele.informacionTecnica();
                    break;
                default:
                    impError("\nERROR. Opción no válida.\n");
                    break;
            }
        }
        #endregion
    }
}
