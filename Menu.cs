using System.Text;

namespace RDIMyBookLibrary
{
    internal static class Menu
    {
        private static string[] Opcoes { get; set; }

        public static int ExibirMenu(string[] opcoes, int selecao)
        {
            Opcoes = opcoes;
            int menu = ConstruirMenu(opcoes, selecao);
            return menu;
        }
        private static int ConstruirMenu(string[] opcoes, int selecao)
        {
            ConsoleKeyInfo tecla;            
            bool opcaoSelecionada = false;
            (int left, int top) = Console.GetCursorPosition();

            while (!opcaoSelecionada)
            {
                Console.SetCursorPosition(left, top);

                for (int i = 0; i < opcoes.Length; i++)
                    CorFonte.Verde($"{(selecao == i ? "♦ " : "\u001b[0m  ")}{opcoes[i]}\n"); // \u001b[0m = Reset cor (unicode)

                tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {
                    case ConsoleKey.DownArrow:
                        selecao = (selecao == opcoes.Length - 1 ? 0 : selecao + 1);
                        break;
                    case ConsoleKey.UpArrow:
                        selecao = (selecao == 0 ? opcoes.Length - 1 : selecao - 1);
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        opcaoSelecionada = true;
                        break;
                }
            }
            return selecao;
        }
        public static void RetornarMenu()
        {
            Console.Write("\n\u001b[0mPressione qualquer tecla para retornar ao menu...");
            Console.CursorVisible = true;
            Console.ReadKey();
            Console.Clear();
        }
    }
}