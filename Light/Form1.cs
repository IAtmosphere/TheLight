using Light.Entities;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Light.Map;
using System.Threading.Tasks;
using Light.Controller;

namespace Light
{
    public partial class GameForm : Form
    {
        public const int HorizontalMovement = 1;
        public const int VerticalMovement = 2;

        public static int WidthGameForm;
        public static int heightGameForm;

        private Image playerSheet;
        private Player player;

        public GameForm()
        {
            InitializeComponent();
            timer.Interval = 20;
            this.Width = 600;
            this.Height = 400;
            // this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow; Добавить ограничитель
            timer.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(OnKeyDown);
            KeyUp += new KeyEventHandler(OnKeyUp);
            InitializingGame();
            WidthGameForm = this.Width;
            heightGameForm = this.Height;
        }

        private void InitializingGame() // Перересовка интерфейса
        {
            //Parallel.Invoke(ControllerMap.InitializingMap);
            CreatingMap.InitializingMap();
            //this.Width = CreatingMap.GetWidth();
            //this.Height = CreatingMap.GetHight();

            playerSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Player.png"));
            player = new Player(100, 100, playerSheet, PlaeyrFrames.calmnessFrames, PlaeyrFrames.movingFramesX, PlaeyrFrames.moveingFramesY_OnMe, PlaeyrFrames.movingFramesY_FromMe);
            timer.Start();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            CreatingMap.DrawMap(g);
            player.PlayAnimation(g);
        }

        private void Update(object sender, EventArgs e)
        {
            if (!ControllerMoving.ObjectIdentification(player, new Point(player.directionX, player.directionY)))
            {
                if (player.isMoving) player.Move();
            }
            Invalidate();
            DoubleBuffered = true; // уберает мерцание
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.directionY = 0;
                    break;
                case Keys.S:
                    player.directionY = 0;
                    break;
                case Keys.A:
                    player.directionX = 0;
                    break;
                case Keys.D:
                    player.directionX = 0;
                    break;
            }

            if (player.directionX == 0 && player.directionY == 0)
            {
                player.isMoving = false;
                player.GetSetAnimations(0);
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    player.directionY = -player.speedMoving;
                    ControllerCamera.ChangingCameraPosition(player, player.speedMoving, VerticalMovement);
                    player.isMoving = true;
                    //if (player.positionY > this.Height / 2 && player.positionY < CreatingMap.sizeMap * CreatingMap.mapHeight - this.Height / 2)
                    //    CreatingMap.cameraOffset.Y += player.speedMoving;
                    player.GetSetAnimations(3);
                    break;
                case Keys.S:
                    player.directionY = player.speedMoving;
                    ControllerCamera.ChangingCameraPosition(player, -player.speedMoving, VerticalMovement);
                    player.isMoving = true;
                    //if (player.positionY > this.Height / 2 && player.positionY < CreatingMap.sizeMap * CreatingMap.mapHeight - this.Height / 2)
                    //    CreatingMap.cameraOffset.Y -= player.speedMoving;
                    player.GetSetAnimations(2);
                    break;
                case Keys.A:
                    player.directionX = -player.speedMoving;
                    ControllerCamera.ChangingCameraPosition(player, player.speedMoving, HorizontalMovement);
                    player.isMoving = true;
                    //if (player.positionX > this.Width / 2 && player.positionX < CreatingMap.sizeMap * CreatingMap.mapWidth - this.Width / 2)
                    //    CreatingMap.cameraOffset.X += player.speedMoving;
                    player.turnFrame = -1;
                    player.GetSetAnimations(1);
                    break;
                case Keys.D:
                    player.directionX = player.speedMoving;
                    ControllerCamera.ChangingCameraPosition(player, -player.speedMoving, HorizontalMovement);
                    player.isMoving = true;
                    //if (player.positionX > this.Width / 2 && player.positionX < CreatingMap.sizeMap * CreatingMap.mapWidth - this.Width / 2)
                    //    CreatingMap.cameraOffset.X -= player.speedMoving;
                    player.turnFrame = 1;
                    player.GetSetAnimations(1);
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        { }
        private void Form1_Load(object sender, EventArgs e)
        { }
    }
}
