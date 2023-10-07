namespace ControleEstoque.ClientContext
{
    public class Cliente
    {
        public Cliente(string nome, DateTime dataCadastro, string email)
        {
            Nome = nome;
            DataCadastro = dataCadastro;
            Email = email;
            Id = ++UltimoID;
        }
        static private int UltimoID = 0;
        private int Id;
        private string Nome { get; set; }
        private DateTime DataCadastro { get; set; }
        private string Email { get; set; }

        public int GetId()
        {
            return Id;
        }

        public string GetNome()
        {
            return Nome;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public DateTime GetDataCadastro()
        {
            return DataCadastro;
        }
    }
}