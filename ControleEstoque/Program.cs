using ControleEstoque.ProdutoContext;
using ControleEstoque.MenuContext;
using ControleEstoque.ClientContext;


namespace ControleEstoque
{
    class Program
    {
        static IList<Produto> Produtos = new List<Produto>();
        static IList<Cliente> Clientes = new List<Cliente>();
        static IList<Venda> Vendas = new List<Venda>();

        static void Main(string[] args)
        {
            Menu.Show();
        }


        public static void CadastrarProduto()
        {
            try
            {
                Console.Write("Nome do produto: ");
                var nome = Console.ReadLine();
                Console.Write("Preço de Compra: ");
                var precoCompra = Convert.ToDouble(Console.ReadLine());
                Console.Write("Preço de Venda: ");
                var precoVenda = Convert.ToDouble(Console.ReadLine());
                Console.Write("Quantidade: ");
                var quantidade = Convert.ToInt32(Console.ReadLine());
                Console.Write("Este produto é perecivel? (S/N): ");
                var verificaPerecivel = Console.ReadLine();

                if (verificaPerecivel.ToUpper() == "S")
                {
                    Console.Write("Data de Validade do Produto: ");
                    var dataValidade = Convert.ToDateTime(Console.ReadLine());
                    var data = DateOnly.FromDateTime(dataValidade);

                    var produtoP = new ProdutoPerecivel(nome, precoCompra, precoVenda, quantidade, data);
                    Produtos.Add(produtoP);
                }
                else if (verificaPerecivel.ToUpper() == "N")
                {
                    var produto = new Produto(nome, precoCompra, precoVenda, quantidade);
                    Produtos.Add(produto);
                }
            }
            catch
            {
                Console.WriteLine("Opção invalida");
                Thread.Sleep(1000);
                MenuProduto.Show();
            }

            Console.WriteLine("Produto cadastrado com sucesso!");
            Console.ReadKey();
            MenuProduto.Show();
        }


        public static string VerificaDataValidade(Produto produto, ProdutoPerecivel produtoP)
        {
            string data = "";

            data = produto.GetDataValidade().ToString();
            DateOnly? dataValidade = produto.GetDataValidade();
            if (produto.GetType() == produtoP.GetType())
            {
                data = produto.GetDataValidade().ToString();

            }
            else
            {
                data = "Ausente";

            }
            return data;
        }


        public static void ListarProdutos()
        {
            using (var produtoP = new ProdutoPerecivel("", 0, 0, 0, new DateOnly()))
            {
                Console.WriteLine("Produtos cadastrados");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                foreach (var produto in Produtos)
                {
                    var data = VerificaDataValidade(produto, produtoP);

                    Console.WriteLine($"| ID: {produto.GetId()} | Nome: {produto.GetNomeProduto()} | Preço de compra: {produto.GetPrecoCompra():C} | Preço de Venda: {produto.GetPrecoVenda():C} | Quantidade: {produto.GetQuantidade()} | Data de validade: {data} |");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");

                }
                produtoP.DiminuiId();
            }
            Console.ReadKey();
            MenuProduto.Show();
        }


        public static void ListarProdutosAtivos()
        {
            using (var produtoP = new ProdutoPerecivel("", 0, 0, 0, new DateOnly()))
            {
                Console.WriteLine("Produtos cadastrados disponiveis");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                foreach (var produto in Produtos)
                {
                    var data = VerificaDataValidade(produto, produtoP);

                    if (produto.VerificaIsActive())
                    {
                        Console.WriteLine($"| ID: {produto.GetId()} | Nome: {produto.GetNomeProduto()} | Preço de compra: {produto.GetPrecoCompra():C} | Preço de Venda: {produto.GetPrecoVenda():C} | Quantidade: {produto.GetQuantidade()} | Data de validade: {data} |");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                    }
                }
                produtoP.DiminuiId();
            }
            Console.ReadKey();
            MenuProduto.Show();
        }


        public static void ListarProdutosEsgotados()
        {
            using (var produtoP = new ProdutoPerecivel("", 0, 0, 0, new DateOnly()))
            {
                Console.WriteLine("Produtos esgotados");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                foreach (var produto in Produtos)
                {
                    var data = VerificaDataValidade(produto, produtoP);

                    if (!produto.VerificaIsActive())
                    {
                        Console.WriteLine($"| ID: {produto.GetId()} | Nome: {produto.GetNomeProduto()} | Preço de compra: {produto.GetPrecoCompra():C} | Preço de Venda: {produto.GetPrecoVenda():C} | Quantidade: {produto.GetQuantidade()} | Data de validade: {data} |");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                    }
                }
                produtoP.DiminuiId();
            }
            Console.ReadKey();
            MenuProduto.Show();
        }


        public static void AdicionarQuantidade()
        {
            if (Produtos.Count == 0)
            {
                Console.WriteLine("Primeiro é necessário cadastrar produtos");
            }
            else
            {
                try
                {
                    Console.Write("Digite o ID do produto que deseja aumentar a quantidade: ");
                    var iD = Convert.ToInt32(Console.ReadLine());
                    var achou = false;
                    foreach (var produto in Produtos)
                    {
                        if (iD == produto.GetId())
                        {
                            Console.Write("Informe a quantidade que deseja adicionar: ");
                            var qntd = Convert.ToInt32(Console.ReadLine());
                            produto.AumentaQuantidade(qntd);
                            achou = true;
                            Console.WriteLine("Quantidade adicionada");
                        }
                    }
                    if (!achou)
                    {
                        Console.WriteLine("ID não encontrado");
                    }
                }
                catch
                {
                    Console.WriteLine("Opção invalida");
                    Thread.Sleep(1000);
                    MenuProduto.Show();
                }

            }
            Console.ReadKey();
            MenuProduto.Show();
        }


        public static void RemoverProduto()
        {
            if (Produtos.Count == 0)
            {
                Console.WriteLine("Primeiro é necessário cadastrar produtos");
            }
            else
            {
                try
                {
                    Console.Write("Digite o ID do produto a ser removido: ");
                    var iD = Convert.ToInt32(Console.ReadLine());
                    var achou = false;
                    var produtosID = Produtos;
                    for (int i = 0; i < Produtos.Count; i++)
                    {
                        if (produtosID[i].GetId() == iD)
                        {
                            produtosID.Remove(produtosID[i]);
                            achou = true;
                            Console.WriteLine("produto removido com sucesso");
                        }
                    }
                    if (!achou)
                    {
                        Console.WriteLine("ID não encontrado");
                    }
                }
                catch
                {
                    Console.WriteLine("Opção invalida");
                    Thread.Sleep(1000);
                    MenuProduto.Show();
                }

            }
            Console.ReadKey();
            MenuProduto.Show();
        }


        public static void CadastrarCliente()
        {
            try
            {
                Console.Write("Nome: ");
                var nome = Console.ReadLine();
                var email = " ";
                do
                {
                    Console.Write("Email: ");
                    email = Console.ReadLine();
                } while (!email.Contains("@"));

                var cliente = new Cliente(nome, DateTime.Now, email);
                Clientes.Add(cliente);
            }
            catch
            {
                Console.WriteLine("Opção invalida");
                Thread.Sleep(1000);
                MenuCliente.Show();
            }

            Console.WriteLine("Cliente cadastrado com sucesso");
            Console.ReadKey();
            MenuCliente.Show();
        }


        public static void ListarClientes()
        {
            Console.WriteLine("Clientes cadastrados");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var cliente in Clientes)
            {
                Console.WriteLine($"| ID: {cliente.GetId()} | Nome: {cliente.GetNome()} | Email: {cliente.GetEmail()} | Data de cadastro: {cliente.GetDataCadastro()} |");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            }
            Console.ReadKey();
            MenuCliente.Show();
        }


        public static void EditarCliente()
        {
            if (Clientes.Count == 0)
            {
                Console.WriteLine("Primeiro cadastre um cliente");
            }
            else
            {
                try
                {
                    Console.Write("ID do cliente a ser editado: ");
                    var id = Convert.ToInt32(Console.ReadLine());
                    var achou = false;
                    for (int i = 0; i < Clientes.Count; i++)
                    {
                        if (Clientes[i].GetId() == id)
                        {
                            Console.Write("Novo nome:");
                            var nome = Console.ReadLine();
                            Console.Write("Novo email: ");
                            var email = Console.ReadLine();

                            Clientes[i].SetNome(nome);
                            Clientes[i].SetEmail(email);
                            achou = true;
                            Console.WriteLine("Cliente editado com sucesso");
                            break;
                        }
                    }
                    if (!achou)
                    {
                        Console.WriteLine("ID não encontrado");
                    }
                }
                catch
                {
                    Console.WriteLine("Opção invalida");
                    Thread.Sleep(1000);
                    MenuCliente.Show();
                }

            }
            Console.ReadKey();
            MenuCliente.Show();
        }


        public static void CadastrarVenda()
        {
            if (Produtos.Count() == 0)
            {
                Console.WriteLine("Nenhum produto disponivel");
            }
            if (Clientes.Count() == 0)
            {
                Console.WriteLine("Nenhum cliente para comprar");
            }
            else
            {
                try
                {
                    Console.Write("Nome do cliente para qual será realizada a venda: ");
                    var nome = Console.ReadLine();

                    var nomes = new List<string>();
                    foreach (var cliente in Clientes)
                    {
                        nomes.Add(cliente.GetNome().ToLower());
                    }
                    if (nomes.Contains(nome.ToLower()))
                    {
                        Console.Write("ID do produto a ser vendido: ");
                        var id = Convert.ToInt32(Console.ReadLine());

                        var message = "Produto indisponivel";
                        foreach (var produto in Produtos)
                        {
                            if (produto.GetId() == id & produto.VerificaIsActive())
                            {
                                Console.Write("Quantidade: ");
                                var qntd = Convert.ToInt32(Console.ReadLine());

                                if (produto.GetQuantidade() - qntd < 0)
                                {
                                    message = "Quantidade invalida";
                                    break;
                                }

                                var venda = new Venda(nome, DateTime.Now, produto);
                                Vendas.Add(venda);
                                produto.DiminuiQuantidade(qntd);
                                message = "Venda realizada!";
                            }
                        }
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("Cliente Invalido");
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Opção invalida");
                    Thread.Sleep(1000);
                    MenuProduto.Show();
                }

            }
            Console.ReadKey();
            MenuProduto.Show();
        }


        public static void ListarVendas()
        {
            Console.WriteLine("Vendas cadastradas");
            Console.WriteLine("------------------");
            foreach (var venda in Vendas)
            {
                Console.WriteLine($"Nome do cliente: {venda.GetNome()} | Data da Venda: {venda.GetDataCadastro()} | Produto vendido: {venda.GetProduto().GetNomeProduto()}");

            }
            Console.ReadKey();
            MenuProduto.Show();
        }
    }
}