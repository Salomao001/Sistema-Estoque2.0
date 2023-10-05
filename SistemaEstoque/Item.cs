namespace SistemaEstoque
{
    public class Item
    {
        static private int UltimoId = 0;
        private int Id;
        private string Nome;
        private int Qntd;
        private double Preco;
        public Item(string nome, int qntd, double preco)
        {
            Id = ++UltimoId;
            Nome = nome;
            Qntd = qntd;
            Preco = preco;
        }

        public int GetId()
        {
            return Id;
        }
        public string GetNome()
        {
            return Nome;
        }

        public int GetQntd()
        {
            return Qntd;
        }

        public double GetPreco()
        {
            return Preco;
        }
    }
}