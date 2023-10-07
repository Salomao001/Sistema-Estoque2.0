namespace ControleEstoque.MenuContext
{
    public class Menu
    {


        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("---Sistema de controle de estoque---");
            Console.WriteLine("Como deseja operar?");
            Console.WriteLine("[1] Lojista");
            Console.WriteLine("[2] Cliente");
            Console.Write("=> ");
            try
            {
                var opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1: MenuProduto.Show(); break;
                    case 2: MenuCliente.Show(); break;
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