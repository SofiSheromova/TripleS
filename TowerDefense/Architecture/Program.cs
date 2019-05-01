using System;
using System.Windows.Forms;
using TowerDefense;

namespace TowerDefense
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Game.CreateMap();
            Application.Run(new GameWindow());
        }
    }
}