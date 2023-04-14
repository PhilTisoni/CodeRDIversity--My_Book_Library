using System.Text;

namespace RDIMyBookLibrary
{
    internal static class CorFonte
    {
        public static void Amarelo(string texto)
        {
            Console.CursorVisible = false;
            Console.Write($"\u001b[93m{texto}\u001b[0m");
        }

        public static void Branco(string texto)
        {
            Console.CursorVisible = false;
            Console.Write($"\u001b[97m{texto}\u001b[0m");
        }

        public static void Ciano(string texto)
        {
            Console.CursorVisible = false;
            Console.Write($"\u001b[96m{texto}\u001b[0m");
        }

        public static void Verde(string texto)
        {
            Console.CursorVisible = false;
            Console.Write($"\u001b[32m{texto}\u001b[0m");
        }

        public static void Vermelho(string texto)
        {
            Console.CursorVisible = false;
            Console.Write($"\u001b[91m{texto}\u001b[0m");
        }

        public static void MultiplasCores(string cor, string texto,
            string cor2 = default, string texto2 = default,
            string cor3 = default, string texto3 = default,
            string cor4 = default, string texto4 = default,
            string cor5 = default, string texto5 = default,
            string cor6 = default, string texto6 = default,
            string cor7 = default, string texto7 = default,
            string cor8 = default, string texto8 = default,
            string cor9 = default, string texto9 = default)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;

            string[] corSelecionada = { cor, cor2, cor3, cor4, cor5, cor6, cor7, cor8, cor9 };
            string[] textoSelecionado = { texto, texto2, texto3, texto4, texto5, texto6, texto7, texto8, texto9 };

            string formatacao = "";

            for (int i = 0; i < corSelecionada.Length; i++)
            {
                switch (corSelecionada[i])
                {
                    case "amarelo":
                        formatacao += ($"\u001b[93m{textoSelecionado[i]}\u001b[0m");
                        break;

                    case "branco":
                        formatacao += ($"\u001b[97m{textoSelecionado[i]}\u001b[0m");
                        break;

                    case "ciano":
                        formatacao += ($"\u001b[96m{textoSelecionado[i]}\u001b[0m");
                        break;

                    case "dourado":
                        formatacao += ($"\u001b[33m{textoSelecionado[i]}\u001b[0m");
                        break;

                    case "roxo":
                        formatacao += ($"\u001b[95m{textoSelecionado[i]}\u001b[0m");
                        break;

                    case "verde":
                        formatacao += ($"\u001b[32m{textoSelecionado[i]}\u001b[0m");
                        break;

                    case "vermelho":
                        formatacao += ($"\u001b[91m{textoSelecionado[i]}\u001b[0m");
                        break;

                    default:
                        break;
                }
            }
            Console.Write(formatacao);
        }
    }
}