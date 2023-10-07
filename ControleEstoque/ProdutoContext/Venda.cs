
namespace ControleEstoque.ProdutoContext
{
    public class Venda
    {
        private string NomeCliente { get; set; }
        private DateTime DataCadastro;
        private Produto Produto;

        public Venda(string nomeCliente, DateTime dataCadastro, Produto produto)
        {
            NomeCliente = nomeCliente;
            DataCadastro = dataCadastro;
            Produto = produto;
        }

        public string GetNome()
        {
            return NomeCliente;
        }
        public DateTime GetDataCadastro()
        {
            return DataCadastro;
        }

        public Produto GetProduto()
        {
            return Produto;
        }

    }
}