using laboratorio3.DAO;
using laboratorio3.Data;
using laboratorio3.Models;
using Microsoft.Extensions.Options;

using (var db = new AsignaturaContext())
{
    db.Database.EnsureCreated();

    int Option = -1;
    while (Option != 0)
    {
        Console.Write("\n\tMenu  \n1. Agregar Registro \n2. Actualizar Registro \n3. Ver Registro \n4. Salir \n>> ");
        Option = Convert.ToInt32(Console.ReadLine());

        switch (Option)
        {
            case 1:
                bool agregarregistro = true;
                while (agregarregistro)
                {
                    Console.WriteLine("\n\tRegistrar Asignatura");
                    Console.WriteLine("Ingrese el nombre de la asignatura: ");
                    var nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese las unidades valorativas: ");
                    int UnidadesV = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el ciclo de estudio: ");
                    var Ciclo = (Console.ReadLine());
                    Console.WriteLine("Ingrese la cantidad de inscritos: ");
                    int Inscritos = Convert.ToInt32(Console.ReadLine());
                    var asignaturas = new asignaturas()
                    {
                        nombre = nombre,
                        unidades_valorativas = UnidadesV,
                        ciclo = Ciclo,
                        inscritos = Inscritos,
                    };
                    db.Add(asignaturas);
                    db.SaveChanges();
                    Console.WriteLine("Registro completado");
                    Console.WriteLine("¿Desea agregar otro registro? (s/n): ");
                    string respuesta = Console.ReadLine().ToLower().Trim();

                    switch (respuesta)
                    {
                        case "s":
                            break;
                        case "n":
                            agregarregistro = false;
                            break;
                        default:
                            Console.WriteLine("Respuesta no válida. Por favor, ingrese 's' o 'n'.");
                            break;
                    }
                    break;

                }
                break;

            case 2:
                Console.Write("\n\t Lista de Registros:");
                Console.WriteLine();
                var asignaturas1 = db.asignaturas.ToList();
                const int idL = 5;
                const int nombreL = 5;
                const int unidadesL = 50;
                const int cicloL = 10;
                const int inscritosL = 10;


                string format = $"{{0, -{idL}}}{{1, -{nombreL}}}{{2, -{unidadesL}}}{{3, -{cicloL}}}{{4, -{inscritosL}}}";

                Console.WriteLine(string.Format(format, "ID", "Nombre", "Unidades Valorativas", "Ciclo", "Inscritos"));
                Console.WriteLine(new string('-', idL + nombreL + unidadesL + cicloL + inscritosL));

                foreach (var asignaturas in asignaturas1)
                {
                    Console.WriteLine($"ID:{asignaturas.id}, Nombre:{asignaturas.nombre},     Unidades Valorativas:{asignaturas.unidades_valorativas},  Ciclo: {asignaturas.ciclo},   Inscritos:{asignaturas.inscritos}");
                }

                bool ActualizarRegistro = true;
                while (ActualizarRegistro)
                {
                    Console.WriteLine("\n\tActualizar Registro");
                    Console.WriteLine("Ingrese el ID del registro (o si desea volver a menu principal ingrese 0): ");
                    int asignaturasid = Convert.ToInt32(Console.ReadLine());

                    if (asignaturasid == 0)
                    {
                        ActualizarRegistro = false;
                        break;
                    }

                    var asignaturas = db.asignaturas.FirstOrDefault(e => e.id == asignaturasid); ;
                    if (asignaturas == null)
                    {
                        Console.WriteLine("  registro no encontrado.");
                    }
                    else
                    {
                        Console.Write($@" favor ingresa el campo a actualizar
1- Nombres {asignaturas.nombre}
2- Apellidos {asignaturas.unidades_valorativas}
3- Edad {asignaturas.ciclo}
4- Sexo {asignaturas.inscritos}

>> ");
                        var L = int.Parse(Console.ReadLine());
                        switch (L)
                        {
                            case 1:
                                Console.WriteLine("Ingresa el  nombre del registro: ");
                                asignaturas.nombre = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Ingrese las unidades valorativas: ");
                                asignaturas.unidades_valorativas = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 3:
                                Console.WriteLine("Ingrese el numero de ciclo: ");
                                asignaturas.ciclo = (Console.ReadLine());
                                break;
                            case 4:
                                Console.WriteLine("Ingrese el numero de inscritos): ");
                                asignaturas.inscritos = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Opción no válida.");
                                break;

                        }
                        db.Update(asignaturas);
                        db.SaveChanges();
                        Console.WriteLine("registro actualizado correctamente.");
                    }
                    
                }break;

            case 3:
                Console.WriteLine("\nListado de Registro");
                bool Lista = true;
                while (Lista)
                {
                    var asignaturas2 = db.asignaturas.ToList();
                    const int id = 5;
                    const int nombre = 20;
                    const int unidades = 5;
                    const int ciclo = 5;
                    const int inscritos = 5;

                    string format1 = $"{{0, -{id}}}{{1, -{nombre}}}{{2, -{unidades}}}{{3, -{ciclo}}}{{4, -{inscritos}}}";

                    Console.WriteLine(string.Format(format1, "ID", "Nombre", "Unidades Valorativas", "Ciclo", "Inscritos"));
                    Console.WriteLine(new string('-', id + nombre + unidades + ciclo + inscritos));

                    foreach (var asignaturas in asignaturas2)
                    {
                        Console.WriteLine($"ID: {asignaturas.id}, Nombre: {asignaturas.nombre}, Unidades Valorativas: {asignaturas.unidades_valorativas},Ciclo: {asignaturas.ciclo}, Inscritos: {asignaturas.inscritos}");
                    }

                    string respuesta2 = Console.ReadLine().ToLower().Trim();

                    switch (respuesta2)
                    {
                        case "s":
                            Lista = false;
                            break;
                        case "n":
                            break;
                        default:
                            Console.WriteLine("Respuesta no válida. Por favor, ingrese 's' o 'n'.");
                            break;
                    }

                }
                break;

            case 4:
                Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                Option = 0;
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, elige una opción válida.");
                break;
        } 
    }
}