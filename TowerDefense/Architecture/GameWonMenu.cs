using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense.Architecture
{
    public partial class GameWonMenu : Form
    {
        public GameWonMenu()
        {
            InitializeComponent();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Hide();
            Form gameWindow = new GameWindow(Levels.TestLevel);
            gameWindow.Show();
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            Hide();
            Form mainMenu = new MainMenuWindow();
            mainMenu.Show();
        }
    }
}
