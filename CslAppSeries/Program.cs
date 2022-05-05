using CslAppSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CslAppSeries
{
    class Program
    {
        private static readonly List<Series> SeriesData = new();
        private static void ErrorFindMessage()
        {
            Console.WriteLine();
            Console.Write(" Error na busca, pressione qualquer teclar para continuar ... ");
            Console.ReadKey();
        }
        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("*-----------------------------------*");
            Console.WriteLine("| 1 - Cadastro de Série             |");
            Console.WriteLine("| 2 - Editar Série                  |");
            Console.WriteLine("| 3 - Lista de Série                |");
            Console.WriteLine("| 4 - Excluir Série                 |");
            Console.WriteLine("| 5 - Finalizar                     |");
            Console.WriteLine("*-----------------------------------*");
        }
        private static void Insert()
        {
            Console.Clear();
            Console.WriteLine("*-----------------------------------*");
            Console.WriteLine("|         Cadastro de Série         |");
            Console.WriteLine("*-----------------------------------*");
            Console.Write(" Digite o título da serie: ");
            string title = Console.ReadLine();
            SeriesData.Add(new Series
            {
                Id = SeriesData.Count + 1,
                Title = title,
                Deleted = false
            });
            Console.WriteLine();
            Console.Write(" Dado inserido com êxito, pressione qualquer teclar para continuar ... ");
            Console.ReadKey();
        }
        private static void Edit()
        {           
            Console.Clear();
            Console.WriteLine("*-----------------------------------*");
            Console.WriteLine("|           Editar Série            |");
            Console.WriteLine("*-----------------------------------*");
            Console.Write(" Digite o id: ");
            string strId = Console.ReadLine();
            if (int.TryParse(strId, out int _id))
            {
                Series data = SeriesData.FirstOrDefault(x => x.Id == _id && x.Deleted == false);
                if (data != null)
                {
                    Console.WriteLine(" Titulo de series antigo: {0}", data.Title);
                    Console.Write(" Digite o título da serie: ");                    
                    string _title = Console.ReadLine();
                    data.Title = _title;
                    Console.WriteLine();
                    Console.Write(" Dado alterados com êxito, pressione qualquer teclar para continuar ... ");
                    Console.ReadKey();
                } 
                else
                {
                    ErrorFindMessage();
                }
            } 
            else
            {
                ErrorFindMessage();
            }
        }
        private static void Delete()
        {            
            Console.Clear();
            Console.WriteLine("*-----------------------------------*");
            Console.WriteLine("|           Excluir Série            |");
            Console.WriteLine("*-----------------------------------*");
            Console.Write(" Digite o id: ");
            string strId = Console.ReadLine();
            if (int.TryParse(strId, out int _id))
            {
                Series data = SeriesData.FirstOrDefault(x => x.Id == _id && x.Deleted == false);
                if (data != null)
                {
                    Console.WriteLine(" Titulo: {0}", data.Title);
                    Console.WriteLine();
                    Console.Write(" Deseja realmente inativa? (S)im ou qualquer teclar para cancelar ");
                    string _opt = Console.ReadLine();
                    if (_opt.ToLower() == "s")
                    {
                        data.Deleted = true;
                    }
                    Console.WriteLine();
                    Console.Write(" Dado inativado com êxito, pressione qualquer teclar para continuar ... ");
                    Console.ReadKey();
                }
                else
                {
                    ErrorFindMessage();
                }
            }
            else
            {
                ErrorFindMessage();
            }
        }
        private static void List()
        {
            Console.Clear();
            Console.WriteLine("*-----------------------------------*");
            Console.WriteLine("|           Lista de Série          |");
            Console.WriteLine("*-----------------------------------*");
            if (SeriesData.Count > 0)
            {
                foreach (Series item in SeriesData.Where(x => !x.Deleted))
                {
                    Console.WriteLine(" {0:0000} - {1}", item.Id, item.Title);
                }
                Console.WriteLine();
                Console.Write(" Dado listados com êxito, pressione qualquer teclar para continuar ... ");
            } 
            else
            {
                Console.Write("Não existe série cadastrada, pressione qualquer teclar para continuar ... ");
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            int menuId = 0;
            while (menuId != 5)
            {
                Menu();
                Console.Write(" Digite a opção: ");
                if (int.TryParse(Console.ReadLine(), out menuId) == false)
                {
                    menuId = 5;
                }
                switch (menuId)
                {
                    case 1:
                        {
                            Insert();
                            break;
                        }
                    case 2:
                        {
                            Edit();
                            break;
                        }
                    case 3:
                        {
                            List();
                            break;
                        }
                    case 4:
                        {
                            Delete();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}
