using System;
using System.Diagnostics.Contracts;

namespace ControleEstoque.ProdutoContext
{
    public class Produto : IDisposable
    {
        public Produto(string? nome, double precoCompra, double precoVenda, int quantidade)
        {
            NomeProduto = nome;
            PrecoCompra = precoCompra;
            PrecoVenda = precoVenda;
            Quantidade = quantidade;
            Id = ++UltimoID;
        }

        static private int UltimoID = 0;
        private int Id;
        private string? NomeProduto { get; set; }
        private double PrecoCompra { get; set; }
        private double PrecoVenda { get; set; }
        private int Quantidade { get; set; }
        private bool IsActive { get; set; }
        protected DateOnly DataValidade;

        public int GetId()
        {
            return Id;
        }

        public string? GetNomeProduto()
        {
            return NomeProduto;
        }

        public double GetPrecoCompra()
        {
            return PrecoCompra;
        }

        public double GetPrecoVenda()
        {
            return PrecoVenda;
        }

        public int GetQuantidade()
        {
            return Quantidade;
        }

        public DateOnly GetDataValidade()
        {
            return DataValidade;
        }
        public bool VerificaIsActive()
        {
            if (Quantidade > 0)
            {
                return true;
            }
            return false;
        }
        public int AumentaQuantidade(int valor)
        {
            return Quantidade += valor;
        }

        public void DiminuiQuantidade(int valor)
        {
            Quantidade -= valor;
        }
        public int DiminuiId()
        {
            return UltimoID--;
        }
        public void Dispose() { }
    }
}