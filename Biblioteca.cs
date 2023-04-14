namespace RDIMyBookLibrary
{
    internal static class Biblioteca
    {
        private static List<Pessoa> Pessoas { get; set; }
        private static List<Livro> Livros { get; set; }

        public static List<Pessoa> ListarPessoas()
        {
            if (Pessoas == null)
                Pessoas = new List<Pessoa>();
            return Pessoas;
        }

        public static List<Livro> ListarLivros()
        {
            if (Livros == null)
                Livros = new List<Livro>();
            return Livros;
        }

        public static void CadastrarPessoa(Pessoa pessoa)
        {
            ListarPessoas();
            Pessoa pessoaProcurada = Pessoas.Find(idProcurado =>
            idProcurado.AcessarId() == pessoa.AcessarId());

            if (pessoaProcurada == null)
            {
                Pessoas.Add(pessoa);
                CorFonte.Amarelo("\nCadastro realizado com sucesso!\n");
                Menu.RetornarMenu();
            }
            else
            {
                CorFonte.Vermelho("\nPessoa já cadastrada\n");
                Menu.RetornarMenu();
            }
        }
        public static void CadastrarLivro(Livro livro)
        {
            ListarLivros();
            Livro livroProcurado = Livros.Find(idProcurado => 
            idProcurado.AcessarId() == livro.AcessarId());

            if (livroProcurado == null)
            {
                Livros.Add(livro);
                livro.OperarQuantidadeExemplares(true);

                CorFonte.Amarelo("\nCadastro realizado com sucesso!\n");
                Menu.RetornarMenu();
            }
            else
            {
                CorFonte.Vermelho("\n\u001b[91mLivro já cadastrado\n");
                Menu.RetornarMenu();
            }
        }
        public static void EmprestarLivroBiblioteca(int idLivro, int idPessoa)
        {
            Livro livroProcurado = Livros.Find(idProcurado => idProcurado.AcessarId() == idLivro);
            Pessoa pessoaProcurada = Pessoas.Find(idProcurado => idProcurado.AcessarId() == idPessoa);

            if (livroProcurado == null && pessoaProcurada == null)
            {
                CorFonte.Vermelho("\nPessoa e Livro não cadastrados\n");
                Menu.RetornarMenu();
            }
            else if (livroProcurado == null)
            {
                CorFonte.Vermelho("\nLivro não cadastrado\n");
                Menu.RetornarMenu();
            }
            else if (pessoaProcurada == null)
            {
                CorFonte.Vermelho("\nPessoa não cadastrada\n");
                Menu.RetornarMenu();
            }
            else
            {
                if (livroProcurado.AcessarQuantidadeExemplares() >= 1)
                {
                    livroProcurado.EmprestarLivro(1);
                    pessoaProcurada.AdicionarLivroLista(livroProcurado);

                    CorFonte.Amarelo($"\nO livro {livroProcurado.AcessarTitulo()} " +
                        $"foi emprestado para {pessoaProcurada.AcessarNome()}\n");
                    Menu.RetornarMenu();
                }
                else
                {
                    CorFonte.Vermelho("\nNão há quantidades disponíveis\n");
                    Menu.RetornarMenu();
                }
            }
               
        }
        public static void DevolverLivroBiblioteca(int idLivro, int idPessoa)
        {

            Livro livroProcurado = Livros.Find(idProcurado => idProcurado.AcessarId() == idLivro);
            Pessoa pessoaProcurada = Pessoas.Find(idProcurado => idProcurado.AcessarId() == idPessoa);

            if (livroProcurado == null && pessoaProcurada == null)
            {
                CorFonte.Vermelho("\nPessoa e Livro não cadastrados\n");
                Menu.RetornarMenu();
            }
            else if (livroProcurado == null)
            {
                CorFonte.Vermelho("\nLivro não cadastrado\n");
                Menu.RetornarMenu();
            }
            else if (pessoaProcurada == null)
            {
                CorFonte.Vermelho("\nPessoa não cadastrada\n");
                Menu.RetornarMenu();
            }
            else
            {
                if (pessoaProcurada.AcessarLivrosEmprestados().Count() >= 1)
                {
                    if (pessoaProcurada.AcessarLivrosEmprestados().Contains(livroProcurado))
                    {
                        livroProcurado.DevolverLivro(1);
                        pessoaProcurada.RemoverLivroLista(livroProcurado);

                        CorFonte.Amarelo($"\nO livro {livroProcurado.AcessarTitulo()} " + 
                            $"foi devolvido por {pessoaProcurada.AcessarNome()}\n");
                        Menu.RetornarMenu();
                    }
                    else
                    {
                        foreach (var livro in pessoaProcurada.AcessarLivrosEmprestados())
                        {
                            if (!pessoaProcurada.AcessarLivrosEmprestados().Contains(livroProcurado))
                            {
                                CorFonte.MultiplasCores("amarelo", $"\nO livro " +
                                    $"{livroProcurado.AcessarTitulo()} ", "vermelho", "não está com ",
                                    "amarelo", $"{pessoaProcurada.AcessarNome()}\n");
                                Menu.RetornarMenu();
                            }
                        }
                    }
                }
                else
                {
                    CorFonte.Vermelho("\nEssa pessoa não emprestou nenhum livro\n");
                    Menu.RetornarMenu();
                }
            }
        }
    }
}