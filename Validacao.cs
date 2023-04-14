namespace RDIMyBookLibrary
{
    internal static class Validacao
    {
        public static string ArmazenarString(string texto, int linha)
        {
            string entrada;
            linha += 2;
            Console.Write($"{texto}");
            do
            {
                Console.SetCursorPosition(texto.Length, linha);
                entrada = Convert.ToString(Console.ReadLine());
            }
            while (entrada == string.Empty || entrada == null);
            return entrada;
        }
        public static int ArmazenarInteiro(string texto, int linha)
        {
            string entrada = ArmazenarString(texto, linha);

            if (int.TryParse(entrada, out int saida) && saida > 0)
                return saida;       
            else
            {
                CorFonte.Vermelho("\nID Inválido! Digite um número maior que zero.\n");
                Menu.RetornarMenu();
                return 0;
            }
        }
        public static void ListarLivrosCadastrados()
        {

            if (Biblioteca.ListarLivros().Count == 0)
            {
                CorFonte.Vermelho("\nNenhum livro cadastrado no sistema\n");
                Menu.RetornarMenu();
            }
            else
            {
                foreach (var cadastros in Biblioteca.ListarLivros())
                    CorFonte.MultiplasCores("ciano", " ● ",
                        "amarelo", $"{cadastros.AcessarTitulo()}\n");
                Menu.RetornarMenu();
            }
        }

        public static void ListarPessoasCadastradas()
        {
            if (Biblioteca.ListarPessoas().Count == 0)
            {
                CorFonte.Vermelho("\nNenhuma pessoa cadastrada no sistema\n");
                Menu.RetornarMenu();
            }
            else
            {
                foreach (var cadastros in Biblioteca.ListarPessoas())
                    CorFonte.MultiplasCores("ciano", " ● ",
                        "amarelo", $"{cadastros.AcessarNome()}\n");
                Menu.RetornarMenu();
            }
        }

        public static void ListarLivrosEmprestados()
        {
            int contador = 0;
            if (Biblioteca.ListarPessoas().Count == 0)
            {
                CorFonte.Vermelho("\nNenhuma pessoa emprestou livros\n");
                Menu.RetornarMenu();
            }
            else if (Biblioteca.ListarPessoas() != null)
            {
                foreach (var pessoas in Biblioteca.ListarPessoas())
                {
                    if (pessoas.AcessarLivrosEmprestados() != null)
                    {
                        foreach (var livrosEmprestados in pessoas.AcessarLivrosEmprestados())
                        {
                            CorFonte.MultiplasCores("ciano", "  ● ",
                                "amarelo", $"{pessoas.AcessarNome()} - " +
                                $"{livrosEmprestados.AcessarTitulo()}\n");
                            contador++;
                        }
                    }
                }
                if (contador < 1)
                    CorFonte.Vermelho("\nNenhuma pessoa emprestou livros\n");
                Menu.RetornarMenu();
            }
        }  
    }
}
