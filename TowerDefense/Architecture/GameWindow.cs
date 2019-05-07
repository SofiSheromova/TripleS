using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TowerDefense
{
    public class GameWindow : Form
    {
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        private readonly GameState gameState;
        private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();
        private int tickCount;
        public static Point ClickPosition;
        public static Tuple<int, int> RightClickIndexes;


        public GameWindow(DirectoryInfo imagesDirectory = null)
        {
            gameState = new GameState();
            ClientSize = new Size(
                GameState.ElementSize * Game.MapWidth,
                GameState.ElementSize * Game.MapHeight + GameState.ElementSize);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo("Images");
            foreach (var e in imagesDirectory.GetFiles("*.png"))
                bitmaps[e.Name] = (Bitmap) Image.FromFile(e.FullName);
            var timer = new Timer {Interval = 20};
            timer.Tick += TimerTick;
            timer.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = "Tower Defense";
            DoubleBuffered = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            pressedKeys.Add(e.KeyCode);
            Game.KeyPressed = e.KeyCode;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
            Game.KeyPressed = pressedKeys.Any() ? pressedKeys.Min() : Keys.None;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0 && e.Clicks == 1)
            {
                ClickPosition = e.Location;}

            if ((e.Button & MouseButtons.Right) != 0 && e.Clicks == 1)
            {
                var click = GetXYIndex(e.Location);
                if (Game.Map[click.Item1, click.Item2] == null && Game.Cash >= 20)
                {
                    Game.Cash -= 20;
                    RightClickIndexes = click;
                }
            }
        }

        public static Tuple<int, int> GetXYIndex(Point click)
        {
            var x = 1;
            var y = 1;
            while (click.X > x * GameState.ElementSize)
                x++;
            while (click.Y > y * GameState.ElementSize)
                y++;
            x--; y--;
            return Tuple.Create(x, --y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, GameState.ElementSize);
            e.Graphics.FillRectangle(
                Brushes.Black, 0, 0, GameState.ElementSize * Game.MapWidth,
                GameState.ElementSize * Game.MapHeight);
            foreach (var a in gameState.Animations)
                e.Graphics.DrawImage(bitmaps[a.Creature.GetImageFileName()], a.Location);
            e.Graphics.ResetTransform();
            var stringState = $"Cash: {Game.Cash}    Live: {Game.Tower.Live}     Time: {Math.Round(GameState.TimeInSecond)}";
            e.Graphics.DrawString(stringState, new Font("Arial", 16), Brushes.MediumPurple, 0, 0);
        }

        private void TimerTick(object sender, EventArgs args)
        {
            if (tickCount == 0) gameState.BeginAct();
            foreach (var e in gameState.Animations)
                e.Location = new Point(e.Location.X + 4 * e.Command.DeltaX, e.Location.Y + 4 * e.Command.DeltaY);
            if (tickCount == 7)
                gameState.EndAct();
            tickCount++;
            if (tickCount == 8)
                tickCount = 0;
            Invalidate();
            GameState.TimeInSecond += 0.02;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.SuspendLayout();
            // 
            // GameWindow
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameWindow";
            this.ResumeLayout(false);

        }
    }
}