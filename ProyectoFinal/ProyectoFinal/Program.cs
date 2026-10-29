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

        static int[] conductores = new int[15];//Por terminos de practicidad, los conductores se identifican con numero entero.
        static int[] rutas = new int[15];
        static int[] conductorDeRuta = new int[15];

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
            Console.WriteLine("Presione 1 para salir");
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
            Console.WriteLine("Presione 1 para salir");
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
            Console.WriteLine("Presione 1 para salir");
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
            switch (opciones)
            {
                case 1:
                    CrearConductor();
                    break;
                case 2:
                    EditarConductor();
                    break;
                case 3:
                    AsignarRutaAConductor();
                    break;
                case 4:
                    VerRutasDeConductor();
                    break;
                case 5:
                    VerListaConductores();
                    break;
                case 6:
                    MenuAdministrador();
                    OpcionesAdministrador(CapturarOpcion());
                    break;
            }
        }
        static void CrearConductor()
        {
            
            for (int i = 0; i < 15; i++)
            {
                conductores[i] = i+1;
            
            }
            Console.WriteLine("Se han creado los 15 Conductores");
            Console.WriteLine("Presione 1 para salir");
            if (CapturarOpcion() == 1)
            {
                MenuGestionConductores();
                SwitchGestionConductores(CapturarOpcion());
            }
        }
        

        static void EditarConductor()
        {
            Console.WriteLine("Ingrese la posición del conductor a editar (1 a 15):");
            int pos = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo ID del conductor:");
            conductores[pos - 1] = int.Parse(Console.ReadLine());

            Console.WriteLine("Conductor editado.");
            Console.WriteLine("Presione 1 para salir");
            if (CapturarOpcion() == 1)
            {
                MenuGestionConductores();
                SwitchGestionConductores(CapturarOpcion());
            }
        }

        static void VerListaConductores()
        {
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"Posición {i + 1} - ID Conductor: {conductores[i]}");
            }
            Console.WriteLine("Presione 1 para salir");
            if (CapturarOpcion() == 1)
            {
                MenuGestionConductores();
                SwitchGestionConductores(CapturarOpcion());
            }
        }

        static void AsignarRutaAConductor()
        {
            Console.WriteLine("Ingrese la posición de la ruta (1 a 15) que desea asignar:");
            int posRuta = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID del conductor al que se le asignará la ruta:");
            int idConductor = int.Parse(Console.ReadLine());

            // Se guarda el ID del conductor en la posición de la ruta (cumple regla: 1 conductor -> muchas rutas)
            conductorDeRuta[posRuta - 1] = idConductor;

            Console.WriteLine("Ruta asignada al conductor correctamente.");
            Console.WriteLine("Presione 1 para salir");
            if (CapturarOpcion() == 1)
            {
                MenuGestionConductores();
                SwitchGestionConductores(CapturarOpcion());
            }
        }

        static void VerRutasDeConductor()
        {
            Console.WriteLine("Ingrese el ID del conductor cuyas rutas quiere ver:");
            int idBuscado = int.Parse(Console.ReadLine());

            Console.WriteLine($"--- Rutas del Conductor {idBuscado} ---");
            for (int i = 0; i < 15; i++)
            {
                // Recorre el arreglo paralelo buscando todas las rutas que tengan este ID de conductor
                if (conductorDeRuta[i] == idBuscado)
                {
                    Console.WriteLine($"Ruta ID: {rutas[i]} (Posición {i + 1})");
                }
            }

            Console.WriteLine("Presione 1 para salir");
            if (CapturarOpcion() == 1)
            {
                MenuGestionConductores();
                SwitchGestionConductores(CapturarOpcion());
            }
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
                    CrearRuta();
                    break;
                case 2:
                    EditarRuta();
                    break;
                case 3:
                    VerListaRutas();
                    break;
                case 4:
                    AsignarConductorARuta();
                    break;
                case 5:
                    MenuCajero();
                    OpcionesCajero(CapturarOpcion());
                    break;
            }
        }

        static void CrearRuta()
        {
            Console.WriteLine("Ingrese la posición de la ruta a crear (1 a 15):");
            int pos = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID de la ruta:");
            rutas[pos - 1] = int.Parse(Console.ReadLine());
            conductorDeRuta[pos - 1] = -1; // -1 significa que nace sin conductor asignado

            Console.WriteLine("Ruta creada.");
            Console.WriteLine("Presione 1 para salir");
            if (CapturarOpcion() == 1)
            {
                MenuGestRutas();
                SwitchGestionRutas(CapturarOpcion());
            }
        }

        static void EditarRuta()
        {
            Console.WriteLine("Ingrese la posición de la ruta a editar (1 a 15):");
            int pos = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo ID de la ruta:");
            rutas[pos - 1] = int.Parse(Console.ReadLine());

            Console.WriteLine("Ruta editada.");
            Console.WriteLine("Presione 1 para salir");
            if (CapturarOpcion() == 1)
            {
                MenuGestRutas();
                SwitchGestionRutas(CapturarOpcion());
            }
        }

        static void VerListaRutas()
        {
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"Ruta ID: {rutas[i]} | Conductor Asignado ID: {conductorDeRuta[i]}");
            }
            Console.WriteLine("Presione 1 para salir");
            if (CapturarOpcion() == 1)
            {
                MenuGestRutas();
                SwitchGestionRutas(CapturarOpcion());
            }
        }

        static void AsignarConductorARuta()
        {
            // Hace exactamente lo mismo que el administrador, cumpliendo que el cajero también pueda hacerlo
            Console.WriteLine("Ingrese la posición de la ruta (1 a 15):");
            int posRuta = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID del conductor:");
            int idConductor = int.Parse(Console.ReadLine());

            conductorDeRuta[posRuta - 1] = idConductor;

            Console.WriteLine("Conductor asignado a la ruta.");
            Console.WriteLine("Presione 1 para salir");
            if (CapturarOpcion() == 1)
            {
                MenuGestRutas();
                SwitchGestionRutas(CapturarOpcion());
            }
        }
        //--------Pasos automaticos hacia realizar venta---------
        static void PasosRealizarVenta()
        {
            string nombre;
            int cantTiqs;
            int impTiq = 1;
            int seleccionRuta;
            int rutaSeleccionada = 0;

            Console.Clear();
            Console.WriteLine("--------------------Pasos Venta--------------------");
            Console.WriteLine("1. Ingresar Nombre del Comprador");
            Console.WriteLine("2. Seleccionar una Ruta");
            Console.WriteLine("3. Ingresar Cantidad de Tiquetes");
            Console.WriteLine("4. Imprimir el tiquete");
            Console.WriteLine("5. Volver al menu cajero\n");

            // Paso 1: Ingresar nombre
            Console.WriteLine("Ingrese el nombre del comprador:");
            nombre = Console.ReadLine();

            // Paso 2: Mostrar rutas disponibles y seleccionar una
            Console.WriteLine("\n--- Rutas Disponibles ---");
            for (int i = 0; i < 15; i++)
            {
                // Mostramos solo las rutas que han sido creadas (asumiendo que 0 significa vacía o puedes filtrar según tu lógica)
                if (rutas[i] != 0)
                {
                    Console.WriteLine($"{i + 1}. Ruta ID: {rutas[i]}");
                }
            }

            Console.WriteLine("Seleccione el número de la posición de la ruta que desea:");
            seleccionRuta = int.Parse(Console.ReadLine());

            // Guardamos el ID de la ruta seleccionada usando la posición ingresada (-1 por el índice del arreglo)
            if (seleccionRuta >= 1 && seleccionRuta <= 15)
            {
                rutaSeleccionada = rutas[seleccionRuta - 1];
            }

            // Paso 3: Ingresar cantidad de tiquetes
            Console.WriteLine("Ingrese la cantidad de tiquetes:");
            cantTiqs = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("-------------------- Tiquetes Impresos --------------------");
            while (cantTiqs > 0)
            {
                // Imprime el nombre y el ID de la ruta seleccionada en cada tiquete
                Console.WriteLine($"Tiquete {impTiq} | Comprador: {nombre} | Ruta ID: {rutaSeleccionada}");
                cantTiqs--;
                impTiq++;
            }

            Console.WriteLine("\nPresione cualquier tecla para volver al menú del cajero:");
            Console.ReadKey();
            Console.Clear();
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
                Console.WriteLine("Presione 1 para salir");
               
            }
            if (rol == "cajero")
            {
                Console.WriteLine("Introduzca su nuevo usuario");
                usuarCa[numCaj - 1] = Console.ReadLine();
                
                
            }

            Console.WriteLine("Presione 1 para salir");
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

            Console.WriteLine("Presione 1 para salir");
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
