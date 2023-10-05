namespace SistemaEstoque
{
    class Program
    {
        static void Main(string[] args)
        {
            var itens = new List<Item>();
            Menu(itens);
        }
        static void Menu(List<Item> itens)
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Bem vindo ao sistema de controle de estoque");
            Console.WriteLine("Selecione uma operação");
            Console.WriteLine("1 - Listar itens");
            Console.WriteLine("2 - Adicionar itens");
            Console.WriteLine("3 - Remover itens");
            Console.WriteLine("0 - Sair");
            Console.Write("Sua opção: ");
            var opcao = Convert.ToInt16(Console.ReadLine());


            while (true)
            {
                switch (opcao)
                {
                    case 1: ListaItens(itens); break;

                    case 2: AdicionaItem(itens); break;

                    case 3: RemoveItem(itens); break;

                    case 0: Environment.Exit(0); break;
                }
            }
        }

        static void AdicionaItem(List<Item> itens)
        {
            Console.Write("Nome do item: ");
            var nome = Console.ReadLine();
            Console.Write("Quantidade: ");
            var qntd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Preço: ");
            var preco = Convert.ToDouble(Console.ReadLine());

            var item = new Item(nome, qntd, preco);
            itens.Add(item);

            Console.WriteLine("Item adicionado com sucesso!");
            Thread.Sleep(1500);

            Menu(itens);
        }

        static void ListaItens(List<Item> itens)
        {
            Console.Clear();
            Console.WriteLine("0-----------------------------------------------0");
            Console.WriteLine("ID               Nome               Quantidade               Preço");
            foreach (var item in itens)
            {
                Console.WriteLine($"{item.GetId()}               {item.GetNome()}              {item.GetQntd()}               {item.GetPreco():C}");
            }
            Console.ReadKey();

            Menu(itens);
        }

        static void RemoveItem(List<Item> itens)
        {
            Console.Write("ID do item a ser removido: ");
            var id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < itens.Count; i++)
            {
                int verificaId = itens[i].GetId();

                if (verificaId == id)
                {
                    itens.Remove(itens[i]);
                    Console.WriteLine("Item removido com sucesso!");
                    Thread.Sleep(1500);
                    Menu(itens);
                }

            }
            Console.WriteLine("ID não encontrado");
            Thread.Sleep(1500);
            Menu(itens);
        }
    }
}