using Spectre.Console;
using System;

namespace SadanConsole.Menus
{
    public static class GameOverMenu
    {
        private static readonly string[] asciiGameOver = new[]
        {
            "                                                                          ",
            "                                                                          ",
            " ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ ",
            "██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗",
            "██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝",
            "██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║██║   ██║██╔══╝  ██  ██═╝",
            "╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝╚██████╔╝███████╗██   ██ ",
            " ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝  ╚═════╝ ╚══════╝╚═════╝ "
        };

        public static int Show()
        {
            Console.Clear();
            Console.CursorVisible = false;

            // ASCII ile GAME OVER başlığı
            foreach (string line in asciiGameOver)
            {
                Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }

            Console.WriteLine();
            AnsiConsole.MarkupLine("[bold red]Canınız bitti! Oyun sona erdi.[/]");
            Console.WriteLine();

            string[] options = { "PLAY AGAIN", "MAIN MENU" };
            int selected = 0;
            ConsoleKey key;

            while (true)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selected)
                    {
                        AnsiConsole.MarkupLine($"[yellow]   ■[/]");
                        AnsiConsole.Write(
                            new FigletText(options[i])
                                .Centered()
                                .Color(Color.Yellow));
                    }
                    else
                    {
                        Console.WriteLine();
                        AnsiConsole.Write(
                            new FigletText(options[i])
                                .Centered()
                                .Color(Color.Grey));
                    }
                    Console.WriteLine();
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                    selected = (selected - 1 + options.Length) % options.Length;
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                    selected = (selected + 1) % options.Length;
                else if (key == ConsoleKey.Enter)
                    return selected;

                // Yeniden çizim
                Console.Clear();

                foreach (string line in asciiGameOver)
                {
                    Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                    Console.WriteLine(line);
                }

                Console.WriteLine();
                AnsiConsole.MarkupLine("[bold red]Canınız bitti! Oyun sona erdi.[/]");
                Console.WriteLine();
            }
        }
    }
}
