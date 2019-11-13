/*
* PRÁCTICA.............: Práctica 1.
* NOMBRE y APELLIDOS...: Sara Blanco Muñoz
* CURSO y GRUPO........: 2º Desarrollo de Aplicaciones Multiplataforma
* TÍTULO de la PRÁCTICA: Diseño de clases. Herencia y polimorfismo.
* FECHA de ENTREGA.....: 23 de Octubre de 2017
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica1
{
    class Tv
    {
        #region Atributos
        private string marca;
        private double pulgadas, consumo, precio;
        private bool onOff;
        private int canal, canalAnterior, volumen;
        #endregion

        #region Propiedades
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public double Pulgadas
        {
            get { return pulgadas; }
            set
            {
                if (value > 0 && value < 500)
                {
                    pulgadas = value;
                }
                else
                {
                    Principal.impError("\nERROR. Pulgadas erróneas.\n");
                    Principal.continuar();
                }
            }
        }

        public double Consumo
        {
            get { return consumo; }
            set
            {
                if (value > 0)
                {
                    consumo = value;
                }
                else
                {
                    Principal.impError("\nERROR. Consumo erróneo.\n");
                    Principal.continuar();
                }
            }
        }

        public double Precio
        {
            get { return precio; }
            set
            {
                if (value > 0)
                {
                    precio = value;
                }
                else
                {
                    Principal.impError("\nERROR. Precio erróneo.\n");
                    Principal.continuar();
                }
            }
        }

        public bool OnOff
        {
            get { return onOff; }
            set { onOff = value; }
        }

        public int Canal
        {
            get { return canal; }
            set
            {
                if (value >= 0 && value < 100)
                    canal = value;
                else
                {
                    Console.Beep();
                    Principal.impError("\nCanal erróneo.\n");
                }
            }
        }

        public int CanalAnterior
        {
            get { return canalAnterior; }
            set
            {
                if (value >= 0 && value < 100)
                    canalAnterior = value;
                else
                    Principal.impError("\nCanal erróneo.\n");
            }
        }

        public int Volumen
        {
            get
            {
                return volumen;
            }
            set
            {
                if (value > 0 && value < 101)
                    volumen = value;
                else
                {
                    Console.Beep();
                    Principal.impError("\nLímite de volumen.\n");
                }
            }
        }
        #endregion

        #region Constructores
        public Tv() { }

        public Tv(string m, double pulg, double cons, double pr)
        {
            marca = m;
            pulgadas = pulg;
            consumo = cons;
            precio = pr;
            /*onOff = false;
            canal = 0;
            volumen = 1;*/
        }
        #endregion

        #region Métodos
        public void pulsarOnOff()
        {
            OnOff = !OnOff;

            if (OnOff)
            {
                Canal = 1;
                CanalAnterior = 1;
                Volumen = 25;
            }
        }
        
        public void subirVolumen()
        {
            Volumen = volumen+1;
        }

        public void bajarVolumen()
        {
            Volumen = volumen - 1;
        }

        public void ponerCanal(int nCanal)
        {
            CanalAnterior = Canal;
            Canal = nCanal;
        }

        public void cambiarCanalAnterior()
        {
            int aux = Canal;
            Canal = CanalAnterior;
            CanalAnterior = aux;
        }

        public bool estadoActual()
        {
            if(!OnOff)
            {
                for (int i = 0; i < 3; i++)
                    Console.Beep();

                Principal.impError("\nApagada.\n");
            }

            return OnOff;
        }

        public void informacionTecnica()
        {
            Principal.impCyan("\nMarca: ");
            Console.WriteLine(Marca);
            Principal.impCyan("Tamaño: ");
            Console.WriteLine(Pulgadas+"\"");
            Principal.impCyan("Precio: ");
            Console.WriteLine(Precio+" Euros");
        }

        public void mostrarEstado()
        {
            if (OnOff)
            {
                Principal.impCyan("\nEncendida ");
                Console.Write("->\t");
                Principal.impCyan("Canal: ");
                Console.Write(Canal);
                Principal.impCyan("\tVolumen: ");
                Console.WriteLine(Volumen);
            }
            else
            {
                Console.WriteLine("\nApagada.");
            }
        }

        #endregion

    }
}
