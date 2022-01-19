using System;
using DIO.Series;

namespace Dio.Series
{
    class Program
    {
        //static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(String[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("");
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            SerieRepositorio novaSerie = new SerieRepositorio();
            novaSerie.Exclui(entradaId);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int entrdadaId = int.Parse(Console.ReadLine());

            SerieRepositorio serie = new SerieRepositorio();
            serie.RetornaPorId(entrdadaId);
        }

        private static void AtualizarSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            string genero = Enum.GetName(typeof(Genero), entradaGenero);
            SerieRepositorio novaSerie = new SerieRepositorio();
            novaSerie.Atualiza(entradaId, entradaTitulo, genero, entradaAno, entradaDescricao);
        }

        private static void ListarSeries()
        {
            SerieRepositorio lista = new SerieRepositorio();
            lista.Lista();
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine(" ");
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            string genero = Enum.GetName(typeof(Genero), entradaGenero);
            SerieRepositorio novaSerie = new SerieRepositorio();
            novaSerie.Insere(entradaTitulo, genero, entradaAno, entradaDescricao);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Séries a seu dispor!!!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1- Listar Séries");
            System.Console.WriteLine("2- Inserir nova série");
            System.Console.WriteLine("3- Atualizar série");
            System.Console.WriteLine("4- Excluir série");
            System.Console.WriteLine("5- Visualizar série");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}

