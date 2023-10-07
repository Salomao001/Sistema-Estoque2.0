namespace ControleEstoque.ProdutoContext
{
    public class ProdutoPerecivel : Produto
    {
        public ProdutoPerecivel(string? nome, double precoCompra, double precoVenda, int quantidade, DateOnly dataValidade)
        : base(nome, precoCompra, precoVenda, quantidade)
        {
            DataValidade = dataValidade;
        }

    }
}