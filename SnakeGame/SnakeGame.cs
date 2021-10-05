using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SnakeGame
{
    partial class Snake
    {
        private int yilanbasLeft;
        private int yilanbasTop;

        private int yilansonLeft;
        private int yilansonTop;

        public int[,] yilangövdekoordinatlari = new int[100, 2];
        public ArrayList yilangövdeRectangle = new ArrayList();

        public int YilanbasLEFT
        {
            get { return yilanbasLeft; }
            set { this.yilanbasLeft = value; }
        }

        public int YilanbasTOP
        {
            get { return yilanbasTop; }
            set { this.yilanbasTop = value; }
        }

        public int YilansonLEFT
        {
            get { return yilansonLeft; }
          
        }

        public int YilansonTOP
        {
            get { return yilansonTop; }
            
        }
    } 
}
