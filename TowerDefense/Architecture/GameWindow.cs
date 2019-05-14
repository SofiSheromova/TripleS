using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TowerDefense.Architecture;

namespace TowerDefense
{
    public class GameWindow : Form
    {
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        public GameState gameState;
        private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();
        private int tickCount;
        public static Point ClickPosition;
        public static Tuple<int, int> RightClickIndexes;


        public GameWindow(Level level, DirectoryInfo imagesDirectory = null)
        {
            InitializeComponent();
            gameState = new GameState(level);
            pressedKeys = new HashSet<Keys>();
            tickCount = 0;
            bitmaps = new Dictionary<string, Bitmap>();

            ClientSize = new Size(
                GameState.ElementSize * gameState.game.MapWidth,
                GameState.ElementSize * gameState.game.MapHeight + GameState.ElementSize);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo("Images");
            foreach (var e in imagesDirectory.GetFiles("*.png"))
                bitmaps[e.Name] = (Bitmap) Image.FromFile(e.FullName);
            var timer = new Timer {Interval = 20};
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void playSimpleSound(string sound)
        {
            SoundPlayer simpleSound = new SoundPlayer(sound);
            simpleSound.Play();
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
            gameState.game.KeyPressed = e.KeyCode;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
            gameState.game.KeyPressed = pressedKeys.Any() ? pressedKeys.Min() : Keys.None;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0 && e.Clicks == 1)
            {
                ClickPosition = e.Location;
            }

            if ((e.Button & MouseButtons.Right) != 0 && e.Clicks == 1)
            {
                var click = GetXYIndex(e.Location);
                if (gameState.game.Map[click.Item1, click.Item2] == null && gameState.game.Cash >= 20)
                {
                    gameState.game.Cash -= 20;
                    RightClickIndexes = click;
                }
                else if (gameState.game.Map[click.Item1, click.Item2] is Wall && gameState.game.Map[click.Item1, click.Item2].Live < 3 && gameState.game.Cash >= 20)
                {
                    gameState.game.Map[click.Item1, click.Item2].Live++;
                    RightClickIndexes = click;
                }
                
            }

            playSimpleSound(@"Sounds\tilin.wav");
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
            if (Game.IsOver)
            {
                Hide();
                StopGame();
            }
            e.Graphics.TranslateTransform(0, GameState.ElementSize);
            e.Graphics.FillRectangle(
                Brushes.Black, 0, 0, GameState.ElementSize * gameState.game.MapWidth,
                GameState.ElementSize * gameState.game.MapHeight);
            foreach (var a in gameState.Animations)
                e.Graphics.DrawImage(bitmaps[a.Creature.GetImageFileName()], a.Location);
            e.Graphics.ResetTransform();
            var stringState =
                $"Cash: {gameState.game.Cash}   Live: {gameState.game.Tower.Live}    Monsters: {Game.RemainingMonsters}";
            e.Graphics.DrawString(stringState, new Font("Arial", 15), Brushes.MediumPurple, 0, 0);
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
            gameState.TimeInSecond += 0.02;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.SuspendLayout();
            // 
            // GameWindow
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Cursor = NativeMethods.LoadCustomCursor("Images/cursor2.cur");
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "GameWindow";
            this.ResumeLayout(false);
        }

        private static void StopGame()
        {
            Game.IsOver = false;
            Form gameOverWindow = new GameOverWindow();
            gameOverWindow.Show();
        }

        static class NativeMethods
        {
            public static Cursor LoadCustomCursor(string path)
            {
                IntPtr hCurs = LoadCursorFromFile(path);
                if (hCurs == IntPtr.Zero) throw new Win32Exception();
                var curs = new Cursor(hCurs);
                // Note: force the cursor to own the handle so it gets released properly
                var fi = typeof(Cursor).GetField("ownHandle", BindingFlags.NonPublic | BindingFlags.Instance);
                fi.SetValue(curs, true);
                return curs;
            }
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern IntPtr LoadCursorFromFile(string path);
        }
    }
}