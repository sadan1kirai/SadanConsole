using Spectre.Console;
using System;
using System.Threading;

namespace SadanConsole.Menus
{
    public static class StartMenu
    {
        public static int Show()
        {
            Console.CursorVisible = false;

            string[] options = { "START", "EXIT" };
            int selected = 0;
            ConsoleKey key;

            while (true)
            {
                Console.Clear();

                string title = @"
               ██████╗  ██████╗ ██╗███╗   ██╗    ██╗  ██╗ ██╗   ██╗███╗   ██╗████████╗ ███████╗██████╗ 
             ██╔════╝ ██╔═══██╗██║████╗  ██║    ██║  ██║ ██║   ██║████╗  ██║╚══██╔══╝██╔════╝██╔══██╗
             ██║      ██║   ██║██║██╔██╗ ██║    ███████╝ ██║   ██║██╔██╗ ██║   ██║   █████╗  ██████╔╝
             ██║      ██║   ██║██║██║╚██╗██║    ██╔═ ██╗ ██║   ██║██║╚██╗██║   ██║   ██╔══╝  ██╔══██╗
             ╚██████╔ ╚██████╔╝██║██║ ╚████║    ██║  ██║ ██████╔╝ ██║ ╚████║   ██║   ███████╗██║  ██║
              ╚═════╝  ╚═════╝ ╚═╝╚═╝  ╚═══╝    ╚═╝  ╚═╝ ╚═════╝  ╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚═╝  ╚═╝";
              
                var lines = title.Split('\n');
                foreach (var line in lines)//ortaladik
                {
                    int windowWidth = Console.WindowWidth;
                    int leftPadding = Math.Max((windowWidth - line.Length) / 2, 0);
                    Console.SetCursorPosition(leftPadding, Console.CursorTop);
                    Console.WriteLine(line);
                }
                Console.WriteLine();//space

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selected)
                    {
                        AnsiConsole.MarkupLine("[white]■[/]");
                        AnsiConsole.Write(
                            new FigletText(options[i])
                                .Centered()
                                .Color(Color.Red));
                    }
                    else
                    {
                        Console.WriteLine();
                        AnsiConsole.Write(
                            new FigletText(options[i])
                                .Centered()
                                .Color(Color.White));
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

                Thread.Sleep(10);
            }
        }
    }
}
