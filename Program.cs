/* O RDI My Book Library foi desenvolvido durante o treinamento de C#
 * da CodeRDIversity organizado pela Prosper Tech Talents em parceria com
 * a RDI Software.
 * 
 * Esse projeto foi orientado por Rodrigo Grigoleto e simula o sistema de
 * cadastro e empréstimo de livros de uma biblioteca, sendo realizado em
 * Março de 2023 pelos alunos:
 * 
 *  - Barbara Nogueira Passaro
 *  - Carolina Aizawa Moreira
 *  - Marcos Ferreira Shirafuchi
 *  - Phelipe Augusto Tisoni
 */
namespace RDIMyBookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool voltarMenu = true;
            int selecao = 0;

            ArteTela.ExibirAbertura();

            while (voltarMenu)
            {
                CorFonte.MultiplasCores
                    ("ciano", "\nUse ", "dourado", "▲", "ciano", " ou ", "dourado", "▼", 
                    "ciano", " para navegar no Menu e pressione ", "verde", "Enter", 
                    "ciano", " para selecionar\n\n"); 

                string[] opcoes = {"Cadastrar Pessoa", "Cadastrar Livro", "Emprestar Livro",
                    "Devolver Livro", "Listar Todos os Livros Cadastrados", 
                    "Listar Todas as Pessoas Cadastradas", "Listar Todos os Livros Emprestados", 
                    "Sair"};

                int opcao = Menu.ExibirMenu(opcoes, selecao);
                selecao = opcao;

                switch (opcao)
                {
                    case 0: //Cadastro de Pessoa
                        CorFonte.Ciano("Digite as informações para o cadastro pessoal:\n\n");

                        string nome = Validacao.ArmazenarString("Nome: ", 0);
                        string cpf = Validacao.ArmazenarString("CPF: ", 1);
                        string telefone = Validacao.ArmazenarString("Telefone: ", 2);
                        int id = Validacao.ArmazenarInteiro("ID Pessoal: ", 3);

                        if (id > 0)
                        {
                            Pessoa pessoa = new (nome, cpf, telefone, id);
                            Biblioteca.CadastrarPessoa(pessoa);                        
                        }
                        break;

                    case 1: //Cadastro de Livro
                        CorFonte.Ciano("Digite as informações para o cadastro do livro:\n\n");

                        string titulo = Validacao.ArmazenarString("Título: ", 0);
                        string autor = Validacao.ArmazenarString("Autor: ", 1);
                        string editora = Validacao.ArmazenarString("Editora: ", 2);
                        int idLivro = Validacao.ArmazenarInteiro("ID Livro: ", 3);

                        if (idLivro > 0)
                        {
                            Livro livro = new (titulo, autor, editora, idLivro); 
                            Biblioteca.CadastrarLivro(livro);
                        }
                        break;             

                    case 2: //Emprestar Livro
                        CorFonte.Ciano("Digite as infromações de identificação para emprestar um livro:\n\n");
                        int idLivroEmprestado;
                        int idPessoaEmprestou = Validacao.ArmazenarInteiro("Insira o ID da Pessoa: ", 0);

                        if (idPessoaEmprestou > 0)
                        {
                            idLivroEmprestado = Validacao.ArmazenarInteiro("Insira o ID do Livro: ", 1);
                            if (idLivroEmprestado > 0)
                            {
                                Biblioteca.EmprestarLivroBiblioteca(idLivroEmprestado, idPessoaEmprestou);
                            }
                        }
                        break;

                    case 3: //Devolver Livro
                        CorFonte.Ciano("Digite as informações de identificação para devolver um livro:\n\n");
                        int idLivroDevolvido;
                        int idPessoaDevolveu = Validacao.ArmazenarInteiro("Insira o ID da Pessoa: ", 0);
                        if (idPessoaDevolveu > 0)
                        {

                            idLivroDevolvido = Validacao.ArmazenarInteiro("Insira o ID do Livro: ", 1);
                            if (idLivroDevolvido > 0)
                            {
                                Biblioteca.DevolverLivroBiblioteca(idLivroDevolvido, idPessoaDevolveu);
                            }
                        }
                        break;

                    case 4: // Listar Livros Cadastrados
                        CorFonte.Ciano("Essa é a lista de livros cadastrados no sistema da biblioteca:\n\n");
                        Validacao.ListarLivrosCadastrados();                      
                        break;

                    case 5: // Listar Pessoas Cadastradas
                        CorFonte.Ciano("Essa é a lista de pessoas cadastradas no sistema da biblioteca:\n\n");
                        Validacao.ListarPessoasCadastradas();                        
                        break;

                    case 6: // Listar Livros Emprestados
                        CorFonte.Ciano("Essa é a lista de livros emprestados do sistema da biblioteca:\n\n");
                        Validacao.ListarLivrosEmprestados();                                
                        break;

                    case 7:
                        voltarMenu = false;
                        break;
                }
            }
            ArteTela.ExibirEncerramento();
            Environment.Exit(0);
        }
    }
}