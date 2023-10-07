
namespace ControleEstoque.ProdutoContext
{
    public class Item
    {
        public Item(Produto produtoComprado, int quantidade)
        {
            ProdutoComprado = produtoComprado;
            Quantidade = quantidade;
        }

        public Produto ProdutoComprado { get; set; }
        public int Quantidade { get; set; }
    }
}