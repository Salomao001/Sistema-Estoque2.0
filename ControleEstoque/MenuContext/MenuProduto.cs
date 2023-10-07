using ControleEstoque.ClientContext;
using ControleEstoque.ProdutoContext;

namespace ControleEstoque.MenuContext
{
    class MenuProduto
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("------Lojista------");
            Console.WriteLine("Oque deseja fazer?");
            Console.WriteLine("[1] Cadastrar produto");
            Console.WriteLine("[2] Listar produtos cadastrados");
            Console.WriteLine("[3] Listar produtos cadastrados disponiveis");
            Console.WriteLine("[4] Listar produtos esgotados");
            Console.WriteLine("[5] Aumentar quantidade de um produto no estoque");
            Console.WriteLine("[6] Excluir um produto cadastrado");
            Console.WriteLine("[7] Cadastrar venda");
            Console.WriteLine("[8] Listar vendas");
            Console.WriteLine("[0] Voltar ao menu principal");
            Console.Write("=> ");
            try
            {
                var opcao = Convert.ToInt16(Console.ReadLine());

                switch (opcao)
                {
                    case 1: Program.CadastrarProduto(); break;
                    case 2: Program.ListarProdutos(); break;
                    case 3: Program.ListarProdutosAtivos(); break;
                    case 4: Program.ListarProdutosEsgotados(); break;
                    case 5: Program.AdicionarQuantidade(); break;
                    case 6: Program.RemoverProduto(); break;
                    case 7: Program.CadastrarVenda(); break;
                    case 8: Program.ListarVendas(); break;
                    default: Menu.Show(); break;
                }
            }
            catch
            {
                Console.WriteLine("Opção invalida");
                Thread.Sleep(1000);
                Show();
            }

        }
    }
}