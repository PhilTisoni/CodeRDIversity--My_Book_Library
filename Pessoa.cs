namespace RDIMyBookLibrary
{
    internal class Pessoa
    {
        private int Id { get; set; }
        private string Nome { get; set; }
        private string Cpf { get; set; }
        private string Telefone { get; set; }
        private List<Livro> LivrosEmprestados { get; set; }

        public Pessoa(string nome, string cpf, string telefone, int id)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Id = id;
        }

        public string AcessarNome()
        {
            return Nome;
        }

        public int AcessarId()
        {
            return Id;
        }

        public List<Livro> AcessarLivrosEmprestados()
        {
            if (LivrosEmprestados == null)
                LivrosEmprestados = new List<Livro>();

            return LivrosEmprestados;
        }

        public void AdicionarLivroLista(Livro livro)
        {
            if (LivrosEmprestados == null)
                LivrosEmprestados = new List<Livro>();
            LivrosEmprestados.Add(livro); 
            livro.OperarQuantidadeExemplares(false);
        }

        public bool RemoverLivroLista(Livro livro)
        {
            LivrosEmprestados.Remove(livro);
            livro.OperarQuantidadeExemplares(true);
            return true;
        }      
    }
}