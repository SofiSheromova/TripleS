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
    public partial class MainMenuWindow : Form
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void MainMenuWindow_Load(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            Hide();
            Form gameWindow = new GameWindow();
            gameWindow.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
