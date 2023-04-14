using System.Text;

namespace RDIMyBookLibrary
{
    internal static class ArteTela
    {        
        public static void ExibirAbertura()
        {
            Console.Title = "CodeRDIversity - My Book Library";

            CorFonte.MultiplasCores
                ("branco", "\n\n         ******  ******   ***           " +
                             "\n         **    * **    *  ***  ", "vermelho", "MY",
                 "branco",   "\n         * * *   **     * ***  ", "vermelho", "BOOK",
                 "branco",   "\n         ** *    **    *  ***  ", "vermelho", "LIBRARY",
                 "branco",   "\n         **  **  *****    ***          ",
                 "dourado", "\n          _______ by _______\n\n");

            Thread.Sleep(2000);

            CorFonte.MultiplasCores
                ("branco", "     ● ", "ciano", " Barbara Nogueira Passaro\n",
                 "branco", "     ● ", "ciano", " Carolina Aizawa Moreira\n",
                 "branco", "     ● ", "ciano", " Marcos Ferreira Shirafuchi\n",
                 "branco", "     ● ", "ciano", " Phelipe Augusto Tisoni\n");

            Menu.RetornarMenu();
        }

        public static void ExibirEncerramento()
        {
            CorFonte.MultiplasCores
                ("branco", "\n\n\n         * *****                    "   +
                             "\n           **    *                   "   +         
                             "\n           * * *            **       "   +
                             "\n           **   ** * ****  *    **** ","roxo",  "    **** ", "branco", "** * " +
                             "\n           **   **   *  *    *  *   *", "roxo", "  **** ", "branco", "  **   " +
                             "\n           **   **   ****  ***  ***  ", "roxo", "****   ", "branco", "  **   " +
                             "\n                                *     " +
                             "\n                                *   ",
                 "amarelo", "\n                 _______ Thank You _______\n\n");

            Thread.Sleep(3000);
        }
    }
}