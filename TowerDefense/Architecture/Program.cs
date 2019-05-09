using System;
using System.IO;
using System.Windows.Forms;
using TowerDefense;
using TowerDefense.Architecture;

namespace TowerDefense
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            //Game.CreateMap();
            //Game.CreateMapPreset(testMap);
            Application.Run(new MainMenuWindow());
        }

        private const string testMap = @"
                 
                 
        WW       
        WT       
                 
                 ";
    }
}