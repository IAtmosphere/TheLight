using Light.Controller;
using Light.Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Light.Entities
{
    class Entity
    {
        public int positionX;
        public int positionY;

        public int directionX;
        public int directionY;
        public bool isMoving;

        public Image spriteSheet;

        public Entity(int positionX, int positionY, Image spriteSheet)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.spriteSheet = spriteSheet;
        }
    }

    class Player : Entity
    {
        public int sizeImageX;
        public int sizeImageY;

        public int speedMoving;

        public int currentFrameX; // Текущий кадр по X
        public int currentFrameY; // Текущий кадр по Y
        public int currentLimitFrames; // Колличество кадров анимации того либо иного действия
        public int turnFrame; // Переменная, отвечающая за поворот персонажа

        public int calmnessFrames; // Кадр спокойствия
        public int movingFramesX; // Кадры движения по X оба направления
        public int moveingFramesY_OnMe; // Кадры движения по Y на меня
        public int movingFramesY_FromMe; // Кадры движения по Y от меня

        public Player(int positionX, int positionY, Image spriteSheet, int calmnessFrames, int movingFramesX, int moveingFramesY_OnMe, int movingFramesY_FromMe) 
            : base(positionX, positionY, spriteSheet)
        {
            sizeImageX = 18;
            sizeImageY = Convert.ToInt16(sizeImageX * 1.48);
            this.calmnessFrames = calmnessFrames;
            this.movingFramesX = movingFramesX;
            this.moveingFramesY_OnMe = moveingFramesY_OnMe;
            this.movingFramesY_FromMe = movingFramesY_FromMe;
            currentLimitFrames = this.calmnessFrames;
            currentFrameX = 0;
            currentFrameY = 1;
            turnFrame = 1;
            speedMoving = 2;
        }

        public void Move()
        {
            positionX += directionX;
            positionY += directionY;
        }

        public void PlayAnimation(Graphics g)
        {
            if (currentFrameX < currentLimitFrames - 1) currentFrameX++;
            else currentFrameX = 0;

            g.DrawImage(spriteSheet, new Rectangle(new Point(positionX - (turnFrame * sizeImageX / 2) + ControllerCamera.cameraOffset.X, positionY + ControllerCamera.cameraOffset.Y),
                new Size(turnFrame * sizeImageX, sizeImageY)), 47f * currentFrameX, 78 * currentFrameY, 47, 77, GraphicsUnit.Pixel);
        }

        public void GetSetAnimations(int currentFrameY)
        {
            this.currentFrameY = currentFrameY;

            switch (currentFrameY)
            {
                case 0:
                    currentLimitFrames = calmnessFrames;
                    break;
                case 1:
                    currentLimitFrames = movingFramesX;
                    break;
                case 2:
                    currentLimitFrames = moveingFramesY_OnMe;
                    break;
                case 3:
                    currentLimitFrames = movingFramesY_FromMe;
                    break;
            }
        }
    }

    class Ghost : Entity
    {
        public Ghost(int positionX, int positionY, Image spriteSheet) 
            : base(positionX, positionY, spriteSheet)
        {

        }
    }
}