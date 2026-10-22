using System;

namespace ProyectoFinal
{
    internal class Program
    {
        static string[] usuarios = new string[16];//1 administrador y 15 cajeros.

        static string[] contra = new string[16];
        static void Main(string[] args)
        {

            MenúCajero();
            OpcionesCajero(CapturarOpcion());

        }
        static void Autenticacion()
        {

            string rol;



            usuarios[0] = "Admin"; //el usuario del adminitrador sera el primero.
            contra[0] = "123";

            for (int i = 1; i < 16; i++)//Asigna usuar. y contra. por defecto y sera responsabilidad del usuario cambiarlas
            {
                usuarios[i] = $"Cajero{i}";
                contra[i] = "caja";
            }

            Console.WriteLine("ingrese su rol");
            rol = Console.ReadLine();
            for (int errores = 3; errores > 0; errores--)
            {
                if (rol == "administrador")
                {
                    //MenuAdministrador();
                }
                if (rol == "cajero")
                {

                }
                else
                {
                    Console.WriteLine($"ingrese una respuesta valida, le quedan {errores} intentos");
                }
            }

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
                switch (opciones)
                {
                    case 1:
                        MenúEditarUsuarContra();

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

        }
        static void EditarContraCajero()
        {

        }

    }
}
