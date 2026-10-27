using System;

namespace ProyectoFinal
{
    internal class Program
    {
        //static string[] usuarios = new string[16];//1 administrador y 15 cajeros.

        //static string[] contra = new string[16];
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
            while (rol != "administrador")
            {
                Console.WriteLine("ingrese su rol, en minúsculas");
                rol = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("No es un rol valido, vuelva a ingresarlo");
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
        }

        static void MenuAdministrador()
        {
            Console.WriteLine("--------------------Menú--------------------" +
                "\n1.Gestión cuenta administrador.                     2.Gestión cuenta cajero." +
                "\n3.Gestión de conductores                            4.Salir(Menú autenticación)");
        }

        static void OpcionesAdministrador(int opciones)
        {

        }
        
        static int CapturarOpcion()
        {
            return int.Parse(Console.ReadLine());
        }
        static void MenúCajero()
        {
            Console.WriteLine("--------------------Menú--------------------\n1.Gestión cuenta cajero                     2.Gestión de rutas\n3.Realizar venta");
        }
        static void OpcionesCajero(int opciones)
        {
            Console.Clear();
                switch (opciones)
                {

                    case 1:
                        MenúEditarUsuarContra();
                        opciones = CapturarOpcion();
                        switch (opciones)
                        {
                            case 1:
                                EditarUsuarCajero();
                                break;
                            case 2:
                                EditarContraCajero();
                                break;
                            case 3:
                                Console.Clear();
                                MenúCajero();
                                OpcionesCajero(CapturarOpcion());   
                            break;
                        }
                       
                    
                    
                        break;
                case 2:
                    break;
                case 3:
                    break;
                }

        }
        static void MenúEditarUsuarContra()
        {
            Console.WriteLine("--------------------Menú--------------------\n1.Editar usuario                      2.Editar Contraseña\n3.Salir");
        }
        
        static void EditarUsuarCajero()
        {
            Console.WriteLine("Aqui se editaria el usuario");
        }
        static void EditarContraCajero()
        {
            Console.WriteLine("Aqui se editaria la contraseña");
        }
        static void MenuGestRutas()
        {
            Console.WriteLine("--------------------Menú--------------------\n1.Crear Ruta                      2.Editar Ruta\n3.Ver Lista de rutas          4.Asignar Conductore a ruta\n5.Salir");
        }
    }
}
