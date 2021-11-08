using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaOtroEjemplo
{
    abstract class Vehiculo
    {
        public string color = "";
        public int asientos = 0;
        protected string título = "";
        public Vehiculo(string c)
        {
            this.color = c;
            Console.WriteLine("Estamos en el constructor de vehículo QUE ASIGNA COLOR");
            return;
        }
        
        public Vehiculo(string c, int ctdad_asientos)
        {
            this.color = c;
            this.asientos = ctdad_asientos;
            return;
        }

        public Vehiculo()
        {
            Console.WriteLine("Estamos en el constructor POR DEFECTO de vehículo");
        }

        public virtual void mostrarDatos()
        {
            Console.WriteLine("Color: " + this.color);
            Console.WriteLine("Cantidad de asientos: " + this.asientos);
        }


        public void pintar(string color)
        {
            this.color = color;
        }

    }

    class Automovil: Vehiculo
    {
        int agno_fabricacion;
        int combustible;//1 - NAFTA, 2 - GASOIL, 3 - GNC, 4 - ALCOHOL, 5 - ELECTRICO
        public Automovil(string color, int x, int agno): base(color, x)
        {
            this.Agno_fabricacion = agno;
            this.combustible = 0;
            Console.WriteLine("Estamos en el constructor de automóvil");
        }

        public int Agno_fabricacion { get => agno_fabricacion; set => agno_fabricacion = value; }

        /*Combustible es una property que no es por defecto.
         * Le estamos agregando lógica, es decir, se van a realizar
         * validaciones para los valores a setear y se va a mostrar por pantalla
         * realizando también una conversión */
        public int Combustible
        {
            get
            {
                return combustible;
            }
            set
            {
                if (value < 1 || value > 5)
                    Console.WriteLine("Error: Debe asignar un número entre 1 y 5");
                else
                    combustible = value;
            }
        }

       

        public override void mostrarDatos()
        {
            Console.WriteLine("***************** DATOS DEL AUTOMOVIL ************");
            base.mostrarDatos();
            Console.WriteLine("Año de fabricación: " + this.Agno_fabricacion);
            switch(Combustible)
            {
                case 1:
                    Console.WriteLine("Combustible: Nafta");
                    break;
                case 2:
                    Console.WriteLine("Combustible: Gasoil");
                    break;
                case 3:
                    Console.WriteLine("Combustible: GNC");
                    break;
                case 4:
                    Console.WriteLine("Combustible: Alcohol");
                    break;
                case 5:
                    Console.WriteLine("Combustible: Eléctrico");
                    break;
                default:
                    Console.WriteLine("Combustible: Indeterminado");
                    break;
            }
          
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            //Vehiculo v = new Vehiculo();
            Automovil a = new Automovil("negro", 5,1992);
            a.mostrarDatos();
            /*Si color es public, no hay problema, se accede tanto desde afuera como
             * desde adentro de la clase padre y sus hijas: */
            //a.color = Console.ReadLine(); 
            while (a.Combustible == 0)
            {
                Console.WriteLine("Ingrese el tipo de combustible:");
                //Manejo de excepciones:
                try
                {
                    a.Combustible = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                //Se puede utilizar el TryParse, pero no se pueden pasar properties por out.
                //Por lo tanto, para no romper el modelo, dejamos vigente la opción try-catch
                //int.TryParse(Console.ReadLine(), out a.combustible) ;
             
            }
            a.mostrarDatos();
            Console.WriteLine("Fin del programa");
            Console.ReadKey();
        }
    }
}
