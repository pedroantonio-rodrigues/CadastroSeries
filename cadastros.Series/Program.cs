using System;
using cadastros.Series.classes;

namespace cadastros.Series
{
    class Program
    {
        static SeriesRepositorios repositorio = new SeriesRepositorios();

        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
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
                OpcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços. ");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(genero), i));
            }
            Console.Write("Digite o genero entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("digite o ano de inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizarSerie = new Series(id: indiceSerie,
                                        genero: (genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizarSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("nenhuma serie cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                var Excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), ((bool)Excluido ? "*Excluido*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(genero), i));
            }
            Console.Write("digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("digite o Titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite Ano de inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                            genero: (genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Pagina de  Cadastro de Series ");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Series");
            Console.WriteLine("3- Atualizar series");
            Console.WriteLine("4- Excluir series");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;

        }
    }

}
