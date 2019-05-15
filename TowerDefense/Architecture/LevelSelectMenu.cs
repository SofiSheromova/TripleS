using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework.Constraints;

namespace TowerDefense.Architecture
{
    public partial class LevelSelectMenu : Form
    {
        public LevelSelectMenu()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Hide();
            Form gameWindow = new GameWindow(Levels.TestLevel);
            gameWindow.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form gameWindow = new GameWindow(Levels.Level2);
            gameWindow.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form gameWindow = new GameWindow(Levels.Level3);
            gameWindow.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var mainMenu = new MainMenuWindow();
            mainMenu.Show();
            Hide();
        }
    }
}
