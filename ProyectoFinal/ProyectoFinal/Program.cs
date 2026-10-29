using System;

namespace ProyectoFinal
{
    internal class Program
    {
        static string[] contraCa = new string[15];
        static string[] usuarCa = new string[15];
        static int numCaj = 0;
        static string contraAd = "123";
        static string usuarAd = "Admin";
        static string rol;
        static int opciones;
        static void Main(string[] args)
        {

            Autenticacion();
            

        }
        static void Autenticacion()
        {

            string usuar;
            string contra;
            int oportunidades = 2;//Solo 2 porque el intento inicial no lo cuenta, siendo 3 intentos en total

            Console.WriteLine("ingrese su rol, en minúsculas");
            rol = Console.ReadLine();

            while (rol != "administrador" && rol!= "cajero")
            {
                Console.Clear();
                Console.WriteLine("No es un rol valido, vuelva a ingresarlo");
                rol = Console.ReadLine();
            }
            if (rol == "cajero")
            {
                Console.WriteLine("Escoja el cajero al que desea ingresar:");
                numCaj = CapturarOpcion();
            }

            Console.WriteLine("Ingrese su usuario");
            usuar = Console.ReadLine();

            Console.WriteLine("ingrese su contraseña");
            contra = Console.ReadLine();

            if (rol == "administrador")
            {
                if (contra == contraAd && usuar == usuarAd)
                {
                    MenuAdministrador();
                    OpcionesAdministrador(CapturarOpcion());
                }
                else
                {
                    do
                    {
                        Console.WriteLine($"Los datos ingresados son incorrectos, le quedan {oportunidades} oportunidades");
                        Console.WriteLine("Ingrese su usuario");
                        usuar = Console.ReadLine();
                        Console.WriteLine("ingrese su contraseña");
                        contra = Console.ReadLine();

                        if (contra != contraAd && usuar != usuarAd)
                        {
                            oportunidades--;
                        }
                        
                    } while (oportunidades > 0 && contra != contraAd && usuar != usuarAd);
                    
                    if(oportunidades == 0)
                    {
                        Console.WriteLine("Ha sobrepasado el limite de errores, comuniquese con ferney.chica@upb.edu.co para soporte técnico");
                    }
                   
                    if (contra == contraAd && usuar == usuarAd)
                    {
                            MenuAdministrador();
                            OpcionesAdministrador(CapturarOpcion());
                    }
                    
                }
            }
            if (rol == "cajero")
            {
                if (contra == contraCa[numCaj - 1] && usuar == usuarCa[numCaj - 1])// El cajero pondrá su posición en el arrglo, no el indice, por lo que hay que restarle 1
                {
                    MenuCajero();
                    OpcionesCajero(CapturarOpcion());
                }
                else
                {
                    do
                    {
                        Console.WriteLine($"Los datos ingresados son incorrectos, le quedan {oportunidades} oportunidades");
                        Console.WriteLine("Ingrese su usuario");
                        usuar = Console.ReadLine();
                        Console.WriteLine("ingrese su contraseña");
                        contra = Console.ReadLine();

                        if (contra != contraCa[numCaj - 1] && usuar != usuarCa[numCaj - 1])
                        {
                            oportunidades--;
                        }

                    } while (oportunidades > 0 && contra != contraCa[numCaj - 1] && usuar != usuarCa[numCaj - 1]);

                    if (oportunidades == 0)
                    {
                        Console.WriteLine("Ha sobrepasado el limite de errores, comuniquese con ferney.chica@upb.edu.co para soporte técnico");
                    }

                    if (contra == contraAd && usuar == usuarAd)
                    {
                        MenuAdministrador();
                        OpcionesAdministrador(CapturarOpcion());
                    }

                }


            }
        }

        static void MenuAdministrador()
        {
            Console.WriteLine("--------------------Menú--------------------" +
                "\n1.Gestión cuenta administrador.                     2.Gestión cuenta cajero." +
                "\n3.Gestión de conductores                            4.Salir(Menú autenticación)");
        }

        static void OpcionesAdministrador(int opciones)
        {
            Console.Clear();
            switch (opciones)
            {

                case 1:
                    MenuEditarUsuarContra();
                    OpcionesEditarUsuarContra(CapturarOpcion());



                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
        
        static int CapturarOpcion()
        {
            return int.Parse(Console.ReadLine());
        }
        static void MenuCajero()
        {
            Console.WriteLine("--------------------Menú--------------------\n1.Gestión cuenta cajero                     2.Gestión de rutas\n3.Realizar venta");
        }
        static void OpcionesCajero(int opciones)
        {
            Console.Clear();
            switch (opciones)
            {

                case 1:
                    MenuEditarUsuarContra();
                    OpcionesEditarUsuarContra(CapturarOpcion());
                    break;
                case 2:
                    MenuGestRutas();
                    break;
                case 3:
                    break;
                case 4:
                    Autenticacion();
                    break;
            }

        }
        static void MenuEditarUsuarContra()
        {
            Console.WriteLine("--------------------Menú--------------------\n1.Editar usuario                      2.Editar Contraseña\n3.Salir");
           
        }
        static void OpcionesEditarUsuarContra(int opciones)//Módulo encargado de llamar a los menú de gestión de usuarioy contraseña.
        {
            if (rol == "cajero")
            {
                switch (opciones)
                {

                    case 1:
                        EditarUsuar();
                        break;
                    case 2:
                        EditarContra();
                        break;
                    case 3:
                        Console.Clear();
                        MenuCajero();
                        OpcionesCajero(CapturarOpcion());
                        break;
                }
            }
            else if (rol == "administrador")
            {
                switch (opciones)
                {
                    case 1:
                        EditarUsuar();
                        break;
                    case 2:
                        EditarContra();
                        break;
                    case 3:
                        Console.Clear();
                        MenuAdministrador();
                        OpcionesAdministrador(CapturarOpcion());
                        break;
                }
            }
        }

        static void EditarUsuar()
        {
            
            if (rol == "administrador")
            {
                Console.WriteLine("Introduzca su nuevo usuario");
                usuarAd= Console.ReadLine();
                Console.WriteLine("Persione 1 para salir");
                switch (CapturarOpcion())
                {
                    case 1:
                        MenuEditarUsuarContra();
                        OpcionesEditarUsuarContra(CapturarOpcion());
                    break;
                }
            }
            
            
        }
        static void EditarContra()
        {
            if (rol == "administrador")
            {
                Console.WriteLine("Introduzca su nueva contraseña");
                contraAd = Console.ReadLine();
            }
        }
        static void MenuGestRutas()
        {
            Console.WriteLine("--------------------Menú--------------------\n1.Crear Ruta                      2.Editar Ruta\n3.Ver Lista de rutas          4.Asignar Conductore a ruta\n5.Salir");
        }


    }
}
