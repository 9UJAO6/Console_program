// Infinity Stride 

internal class Program
{
    private static void Main(string[] args)
    {
         
        string mensagemDeAcesso = "Enjoy your Feet Ride";

        Dictionary<string, List<Tuple<decimal, int>>> tenisRegistrados = new Dictionary<string, List<Tuple<decimal, int>>>();




        void exibeAcesso()
        {
            Console.WriteLine(@"In̲f̲i̲n̲i̲t̲y̲ St̲r̲i̲d̲e̲");
            Console.WriteLine(mensagemDeAcesso);

        }

        void exibeMenu()
        {

            Console.WriteLine("\n[1]Novo");
            Console.WriteLine("[2]Ver estoque");
            Console.WriteLine("[3]Remover do estoque");
            Console.WriteLine("[4]Entrou no estoque");
            Console.WriteLine("[5]Saiu do estoque");
            Console.WriteLine("[0]Sair");

            Console.Write("\nDigite Sua Opção: ");
            string opcaoEscolida = Console.ReadLine()!;
            int opcaoEscolidaNumerica = int.Parse(opcaoEscolida);

            switch (opcaoEscolidaNumerica)
            {
                case 1:
                    registrarTenis();
                    break;
                case 2:
                    mostrarTenisEmEstoque();
                    break;
                case 3:
                    removerTenis();
                    break;
                case 4:
                    entraEmEstoque();
                    break;

                case 5:
                    saiDoEstoque();
                    break;

                case 0:
                    Console.WriteLine("Obrigado por utilizar o Infinty Stride");
                    break;

                default:
                    Console.WriteLine("Opção Inválida");
                    break;


            }




        }
        void registrarTenis() //opção número 1
        {

            {
                Console.Clear();
                Console.WriteLine("Registrar novo Tênis");
                Console.Write("Digite o Tênis que quer adicionar ao Estoque: ");
                string novoTenis = Console.ReadLine()!;
                Console.Write($"Digite o preço do tênis {novoTenis}: ");
                decimal preco = decimal.Parse(Console.ReadLine()!);

                Console.WriteLine($"O tênis {novoTenis} foi registrado com preço {preco:C}\n");
                tenisRegistrados.Add(novoTenis, new List<Tuple<decimal, int>> { Tuple.Create(preco, 0) });

            }
            Console.Write("Adicionar novo Produto? S/N: ");
            string adicionarNovoProduto = Console.ReadLine()!.ToLower();

            if (adicionarNovoProduto == "s")
            {
                registrarTenis();
            }
            else if (adicionarNovoProduto == "n")
            {
                Thread.Sleep(2000);
                Console.Clear();
                exibeAcesso();
                exibeMenu();
            }
            else
            {
                Console.WriteLine("Opção inválida. Voltando ao menu principal.");
                Thread.Sleep(2000);
                Console.Clear();
                exibeAcesso();
                exibeMenu();
            }
        }




        void mostrarTenisEmEstoque() //função 2
        {
            Console.Clear();
            Console.WriteLine("Tenis registrados no Infitnity estoque\n");

            if (tenisRegistrados.Count > 0)
            {
                foreach (var tenis in tenisRegistrados)
                {
                    string novoTenis = tenis.Key;
                    List<Tuple<decimal, int>> info = tenis.Value;

                    Console.WriteLine($"Tênis: {novoTenis}, \nPreço: {info.First().Item1:C}, \nQuantidade: {info.First().Item2}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum tênis registrado no estoque.");
            }

            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibeAcesso();
            exibeMenu();
        }

        void removerTenis() //função 3 
        {
            Console.Clear();
            Console.WriteLine("Remover produtos");

            Console.Write("\nDigite o nome do Tênis que quer remover de nosso estoque: ");
            string removeTenis = Console.ReadLine()!;


            if (tenisRegistrados.ContainsKey(removeTenis))
            {
                tenisRegistrados.Remove(removeTenis);
                Console.WriteLine($"O Tênis {removeTenis} foi removido de nosso estoque");
            }
            else
            {
                Console.WriteLine($"O Tênis {removeTenis} não foi encontrado. Pressione uma tecla para retornar ao menu");
                Console.ReadKey();
                Console.Clear();
                exibeAcesso();
                exibeMenu();
                return;
            }
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibeAcesso();
            exibeMenu();

        }
        void entraEmEstoque() //função 4
        {
            Console.Clear();
            Console.WriteLine("Adicionar ao estoque");
            Console.Write("Digite o Tênis que quer adicionar ao estoque: ");

            string nomeDoTenis = Console.ReadLine()!;

            if (tenisRegistrados.ContainsKey(nomeDoTenis))
            {
                List<Tuple<decimal, int>> info = tenisRegistrados[nomeDoTenis];

                Console.Write($"Digite a quantidade de {nomeDoTenis} que quer adicionar ao estoque: ");
                int adicionaTenis = int.Parse(Console.ReadLine()!);
                info[0] = Tuple.Create(info[0].Item1, info[0].Item2 + adicionaTenis);
                Console.WriteLine($"Foram adicionadas {adicionaTenis} unidades do {nomeDoTenis}. Total no estoque: {info.First().Item2}");
                Console.Write("Adicionar mais tênis ao estoque? S/N: ");   
                string adicionarMais = Console.ReadLine()!.ToLower();

                if (adicionarMais == "s")
                {
                    entraEmEstoque();
                }
                else if (adicionarMais == "n")
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    exibeAcesso();
                    exibeMenu();
                }
                else
                {
                    Console.WriteLine("Opção inválida. Voltando ao menu principal.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    exibeAcesso();
                    exibeMenu();
                }

            }
            else
            {
                Console.WriteLine($"O {nomeDoTenis} não foi encontrado no estoque.");
                Console.ReadKey();
                Console.Clear();
                exibeAcesso();
                exibeMenu();
                return;
            }

            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibeAcesso();
            exibeMenu();
        }
        void saiDoEstoque() //função 5
        {
            Console.Clear();
            Console.WriteLine("Sai de estoque");
            Console.Write("Digite o Tênis que quer retirar: ");
            string retiraTenis = Console.ReadLine()!;
            if (tenisRegistrados.ContainsKey(retiraTenis))
            {
                List<Tuple<decimal, int>> info = tenisRegistrados[retiraTenis];
                Console.Write($"Digite a quantidade de {retiraTenis} que quer retirar do estoque: ");
                int quantidadeARetirar = int.Parse(Console.ReadLine()!);

                if (quantidadeARetirar <= info.First().Item2)
                {
                    info[0] = Tuple.Create(info[0].Item1, info[0].Item2 - quantidadeARetirar);

                    if (info[0].Item2 == 0)
                    {
                        tenisRegistrados.Remove(retiraTenis);
                        Console.WriteLine($"O Tênis {retiraTenis} foi totalmente removido de nosso estoque");
                    }
                    else
                    {
                        Console.WriteLine($"Foram retiradas {quantidadeARetirar} unidades do {retiraTenis}. Quantidade restante no estoque: {info.First().Item2}");
                    }
                }
                else
                {
                    Console.WriteLine($"Quantidade insuficiente no estoque. Voltando ao menu principal.");
                }
            }
            else
            {
                Console.WriteLine($"O Tênis {retiraTenis} não foi encontrado. Voltando ao menu principal.");
            }
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            exibeAcesso();
            exibeMenu();

        }
            exibeAcesso();
            exibeMenu();
    } 
    
}