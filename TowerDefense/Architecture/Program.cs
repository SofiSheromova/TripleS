using System;
using System.IO;
using System.Windows.Forms;
using TowerDefense;

namespace TowerDefense
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            //Game.CreateMap();
            Game.CreateMapPreset();
            Application.Run(new GameWindow(new DirectoryInfo("Images")));
        }
    }
}