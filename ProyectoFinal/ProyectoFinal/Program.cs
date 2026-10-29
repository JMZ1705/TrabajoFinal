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
        static int oportunidades;
        static void Main(string[] args)
        {

            Autenticacion();
            

        }

        //-----------AUTENTICACIÓN-------------
        static void Autenticacion()
        {

            string usuar;
            string contra;
            oportunidades = 2;//Solo 2 porque el intento inicial no lo cuenta, siendo 3 intentos en total

            Console.WriteLine("ingrese su rol, en minúsculas");
            rol = Console.ReadLine();//No ingresar como cajero hasta que sean creados los cajeros

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
                if (contra == contraCa[numCaj - 1] && usuar == usuarCa[numCaj - 1])// El cajero pondrá su posición en el arreglo, no el indice, por lo que hay que restarle 1
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

                    if (contra == contraCa[numCaj - 1] && usuar == usuarCa[numCaj - 1])
                    {
                        MenuCajero();
                        OpcionesCajero(CapturarOpcion());
                    }

                }


            }
        }

        //-------------CAPTURAR OPCIÓN (SIRVE PARA TODO)-----
        static int CapturarOpcion()
        {
            return int.Parse(Console.ReadLine());
        }

        //-------------MENÚ ADMINISTRADOR--------------------
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
                    MenuGestionCuentaCajero();
                    SwitchGestionCuentaCajeros(CapturarOpcion());
                    break;
                case 3:
                    MenuGestionConductores();
                    SwitchGestionConductores(CapturarOpcion());
                    break;
                case 4:
                    Autenticacion();
                    break;
            }
        }


        //---------Gestion cuenta cajero---------
        static void MenuGestionCuentaCajero()
        {
            Console.WriteLine("--------------------Menú--------------------\n1.Crear Cajero                      2.Editar Cajero \n3.Ver Lista de Cajeros          4.Salir");
        }
        static void SwitchGestionCuentaCajeros(int opciones)
        {
            switch (opciones)
            {

                case 1:
                    CrearCajero();

                    break;
                case 2:
                    EditarCajero();
                    break;
                case 3:
                    VerListaCajeros();
                    break;
                case 4:
                    Console.Clear();
                    MenuCajero();
                    OpcionesCajero(CapturarOpcion());
                    break;

            }

        }
        static void CrearCajero()//Crea un usuario y contraseña por defecto para cada nuevo cajero
        {
            for(int i =0; i < 15; i++)
            {
                usuarCa[i] = $"Cajero{i + 1}";
                contraCa[i] = "456";
            }
            Console.WriteLine("Se han creado los 15 cajeros");
            Console.WriteLine("Persione 1 para salir");
            switch (CapturarOpcion())
            {
                case 1:
                    MenuGestionCuentaCajero();
                    SwitchGestionCuentaCajeros(CapturarOpcion());
                    break;
            }
        }
        static void EditarCajero()//Permite editar tanto el usuario como la contraseña
        {
            Console.WriteLine("Ingrese el numero de cajero que quiere editar");
            numCaj = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo usuario");
            usuarCa[numCaj-1] = Console.ReadLine();//-1 porque el usuario pone la posicion, mas no el indice
            Console.WriteLine("Ingrese la nueva contraseña");
            contraCa[numCaj-1] = Console.ReadLine();
            Console.WriteLine("Persione 1 para salir");
            switch (CapturarOpcion())
            {
                case 1:
                    MenuGestionCuentaCajero();
                    SwitchGestionCuentaCajeros(CapturarOpcion());
                    break;
            }
        }

        static void VerListaCajeros()
        {
     
            for(int i = 0; i < 15; i++)
            {
                Console.Write($"Usuario:{usuarCa[i]} Contraseña:{contraCa[i]}");
                Console.WriteLine();
            }
            Console.WriteLine("Persione 1 para salir");
            switch (CapturarOpcion())
            {
                case 1:
                    MenuGestionCuentaCajero();
                    SwitchGestionCuentaCajeros(CapturarOpcion());
                    break;
            }
        }

        


        //-------------Gestión de conductores----------------
        static void MenuGestionConductores()
        {
            Console.WriteLine("--------------------Menú--------------------\n1.Crear Conductor                     2.Editar Conductor \n3.Asignar ruta a un conductor                    4.Ver lista de rutas de un Conductor\n5.Ver Lista de Conductores                    6.Salir");
        }

        static void SwitchGestionConductores(int opciones)
        {

        }

        

        //-------------MENÚ CAJERO---------------------------
        static void MenuCajero()
        {
            Console.WriteLine("--------------------Menú--------------------\n1.Gestión cuenta cajero                     2.Gestión de rutas\n3.Realizar venta                     4.Salir");
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
                    SwitchGestionRutas(CapturarOpcion());
                    break;
                case 3:
                    PasosRealizarVenta();
                    break;
                case 4:
                    Autenticacion();
                    break;
            }

        }
        //----Gestión de rutas----------
        static void MenuGestRutas()
        {
            Console.WriteLine("--------------------Menú--------------------\n1.Crear Ruta                      2.Editar Ruta\n3.Ver Lista de rutas          4.Asignar Conductore a ruta\n5.Salir");
        }

        static void SwitchGestionRutas(int opciones)
        {

            switch (opciones)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    MenuCajero();
                    OpcionesCajero(CapturarOpcion());
                    break;
            }
        }
        //--------Pasos automaticos hacia realizar venta---------
        static void PasosRealizarVenta()
        {
            string nombre;
            Console.WriteLine("--------------------Pasos Venta--------------------\n1.Ingresar Nombre del Comprador                      2.Seleccionar una Ruta\n3.Ingresar Cantidad de Tiquetes          4.Imprimir el tiquete\n5.Volver al menu cajero");
            Console.WriteLine("Ingresar el nombre del comprador");
            nombre = Console.ReadLine();
            Console.WriteLine("Seleccione una ruta");
            Console.WriteLine("Ingresar la cantidad de tiquetes");
            Console.WriteLine("Tiqute impreso");
            MenuCajero();
            OpcionesCajero(CapturarOpcion());

        }

        




        //---EDITAR USUARIO Y CONTRASEÑA (SIRVE TANTO PARA ADMINISTRADOR COMO PARA CAJERO)-----
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
               
            }
            if (rol == "cajero")
            {
                Console.WriteLine("Introduzca su nuevo usuario");
                usuarCa[numCaj - 1] = Console.ReadLine();
                
                
            }

            Console.WriteLine("Persione 1 para salir");
            switch (CapturarOpcion())
            {
                case 1:
                    MenuEditarUsuarContra();
                    OpcionesEditarUsuarContra(CapturarOpcion());
                    break;
            }


        }
        static void EditarContra()
        {
            if (rol == "administrador")
            {
                Console.WriteLine("Introduzca su nueva contraseña");
                contraAd = Console.ReadLine();
                
            }
            if (rol == "cajero")
            {
                Console.WriteLine("Introduzca su nueva contraseña");
                contraCa[numCaj-1] = Console.ReadLine();

            }

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
}
