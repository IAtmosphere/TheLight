using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Light.Map
{
    public class ObjectsMap
    {
        public PointF possition;
        public Size size;

        public ObjectsMap(PointF possition, Size size)
        {
            this.possition = possition;
            this.size = size;
        }
    }
}