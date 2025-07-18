using SadanConsole.Core;
using System;

namespace SadanConsole.Menus
{
    public class GameUI
    {
        //public void Location(Player player)
        //{
        //    Console.SetCursorPosition(81, 20);
        //    Console.WriteLine("Oyuncu Konumu");
        //    Console.SetCursorPosition(81, 21);
        //    Console.Write(' ');
        //    Console.SetCursorPosition(81, 21);
        //    Console.Write($"X: {player.Position.X} Y: {player.Position.Y}");
        //}
        public void ShowHealth(int health)
        {
            Console.SetCursorPosition(81, 8);
            Console.Write("               ");
            Console.SetCursorPosition(81, 8);
            Console.Write($"Can: {health}");
        }

        public void ShowCoinInfo(int collected, int total)
        {
            Console.SetCursorPosition(81, 22);
            Console.Write("                ");
            Console.SetCursorPosition(81, 22);
            Console.Write($"Coinler: {collected}/{total}");
        }

        public void Label()
        {
            Console.SetCursorPosition(0, 0);
            Console.Title = "Coin Hunt! Sadan Console"; //oyun adi
            Console.Write("← W A S D ile hareket et, $ coinleri topla");
            
        }
    }
}
