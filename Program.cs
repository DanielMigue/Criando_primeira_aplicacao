using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mensagem = " Bem-vindo ao Screen Sound!";
            Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
            bandasRegistradas.Add("For Today", new List<int> { 10, 8, 6 });
            bandasRegistradas.Add("Oficina G3", new List<int>());

            void ExibirLogo()
            {
                Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
                Console.WriteLine("\n" + mensagem);
            }
            void ExibirOpcoesDoMenu()
            {
                ExibirLogo();
                Console.WriteLine
                    ("\n Digite 1 para registrar uma banda\n" +
                    " Digite 2 para mostrar todas as bandas\n" +
                    " Digite 3 para avaliar uma banda\n" +
                    " Digite 4 para exibir a média de uma banda\n" +
                    " Digite -1 para sair" );

                Console.Write("\n Digite a sua opção: ");
                int opcaoEscolhida = Convert.ToInt32(Console.ReadLine());
               switch (opcaoEscolhida)
                {
                    case 1: RegistrarBanda();
                        break;
                    case 2:
                        MostrarBandasRegistradas();
                        break;
                    case 3:
                        AvaliarUmaBanda();
                        break;
                    case 4:
                        ExibirMediaDaBanda();
                        break;
                    case -1:
                        Console.WriteLine("Tchau tchau :)");

                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                       
                        break;
                }
            }
            void RegistrarBanda()
            {
                Console.Clear();
                ExibirTituloDaOpcao(" Registro das Bandas");
                Console.Write("\n Digite o nome da banda que deseja registrar: ");
                string nomeDaBanda = Console.ReadLine();
                bandasRegistradas.Add(nomeDaBanda, new List<int>());
                Console.WriteLine($"\n A banda {nomeDaBanda} foi registrada com sucesso"); //"$"(Interpolação de string), ele inicia-se com sifrão e onde vc quer referenciar uma variável você envolve ela com chaves
                Thread.Sleep(2000);// Espera por 2 milissegundo
                Console.Clear();
                ExibirOpcoesDoMenu();
            }
            void MostrarBandasRegistradas()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

                /*for (int i = 0; i < listaDasBandas.Count; i++) <----- (exemplo)
                {
                    Console.WriteLine($" Banda: {listaDasBandas[i]}");
                }
                
                O Armazenamento das várias váriaveis pode ser feita tanto com for como foreach. Acima está um exemplo da utilização do for e abaixo a utilização de "foreach".
                */
                foreach (string banda in bandasRegistradas.Keys) // Usado somente para percorrer uma lista tranquilamente, nada mais. Porém a desvantagem é que não dá para usar índice do for tradicional
                {
                    Console.WriteLine($" {banda}");
                }

                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void ExibirTituloDaOpcao(string titulo)
            {
                int quantidadeDeLetras = titulo.Length; //lenght retorna o numero total de elementos
                string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
                Console.WriteLine(asteriscos);
                Console.WriteLine(titulo);
                Console.WriteLine(asteriscos + "\n");
            }

            void AvaliarUmaBanda()
            {
                // digite qual banda deseja avaliar
                // se a banda existir no dicionario >> atribua nota
                // se nao existir voltar ao menu principal
                Console.Clear();
                ExibirTituloDaOpcao("Avaliação de Bandas");
                foreach(string banda in bandasRegistradas.Keys)
                {
                    Console.WriteLine($"{banda}");
                }
                Console.Write("\nDigite a banda que deseje avaliar: ");
                string nomeDaBanda = Console.ReadLine(); 

                if(bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    Console.Write($"Digite a nota da banda {nomeDaBanda}: ");
                    int nota = int.Parse(Console.ReadLine());
                    bandasRegistradas[nomeDaBanda].Add(nota);
                    Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
                else
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} ainda não foi registrada");
                    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirOpcoesDoMenu();

                }

            }
            void ExibirMediaDaBanda()
            {
                /*
                 * 
                 */
                Console.Clear();
                ExibirTituloDaOpcao("Média da Banda");
                foreach (string banda in bandasRegistradas.Keys)
                {
                    Console.WriteLine($"{banda}");
                }

                Console.WriteLine("\nDigite a banda que você que ver a média");
                string nomeDaBanda = Console.ReadLine();
                

                if (bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    double mediaDaBanda = bandasRegistradas[nomeDaBanda].Average();                  
                    Console.WriteLine($"\nA média da banda {nomeDaBanda} é de {mediaDaBanda}");
                    Console.WriteLine("\nDigite um tecla para voltar ao menu");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
                else
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} ainda não foi registrada");
                    Console.WriteLine("\nDigite um tecla para voltar ao menu");
                    Console.ReadKey();
                    Console.Clear();
                    Thread.Sleep(2000);
                    ExibirOpcoesDoMenu();
                }
            }
            ExibirOpcoesDoMenu();

            Console.ReadKey();
        }
    }
}
