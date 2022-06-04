using Light.Entities;
using Light.Map;
using System.Drawing;

namespace Light.Controller
{
    class ControllerCamera
    {
        public static Point cameraOffset = new Point(0, 0); // Смещение камеры на X, Y
        const int sideСap = 58;

        public static void ChangingCameraPosition(Player player, int offset, int directionMovement)
        {
            var gameFormH_2 = GameForm.heightGameForm / 2;
            var gameFormW_2 = GameForm.WidthGameForm / 2;

            //    cameraOffset.X += offset;

            //if (player.positionX > gameFormW_2 && player.positionX < CreatingMap.sizeMap * CreatingMap.mapWidth - gameFormW_2)
            //    cameraOffset.X += offset;

            if (player.positionY > gameFormH_2 && player.positionY < CreatingMap.GetHight() - gameFormH_2 && directionMovement == 2)
                cameraOffset.Y += offset;

            if (player.positionX > gameFormW_2 && player.positionX < CreatingMap.GetWidth() - gameFormW_2 && directionMovement == 1)
                cameraOffset.X += offset;
        }
    }
}
