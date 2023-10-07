using ControleEstoque.ClientContext;
using ControleEstoque.ProdutoContext;
namespace ControleEstoque.MenuContext
{
    public class MenuCliente
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("------Cliente------");
            Console.WriteLine("Oque deseja fazer?");
            Console.WriteLine("[1] Cadastrar cliente");
            Console.WriteLine("[2] Listar clientes");
            Console.WriteLine("[3] Editar cliente");
            Console.WriteLine("[0] Voltar ao menu principal");
            Console.Write("=> ");
            try
            {
                var opcao = Convert.ToInt16(Console.ReadLine());

                switch (opcao)
                {
                    case 1: Program.CadastrarCliente(); break;
                    case 2: Program.ListarClientes(); break;
                    case 3: Program.EditarCliente(); break;
                    case 0: Menu.Show(); break;
                    default: Show(); break;
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