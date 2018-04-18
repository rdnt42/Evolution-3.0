using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_3._0
{
    class Cells : Block
    {
        static int countCell = 0;
        public int idCell;

        public int group;
        public int hp;
        public int maxHp;
        public int range;
        int stepLength;
        int x;
        int y;
        public int prewX;
        public int prewY;

        public Cells(int carbon, int xCell, int yCell)
        {
            idCell = countCell;
            countCell++;

            X = xCell;
            Y = yCell;
            prewX = X;
            prewY = Y;
            if (group == 1)
                group = rnd.Next(2, 6);
            else
                group = carbon;
            range = 100;
            stepLength = 2;
            maxHp = 50 + 100 * carbon;
            hp = maxHp;
        }

        public new int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value < Block.widthBlock * Block.widthField - Block.widthCell && value >= 0)
                    x = value;
            }
        }

        public new int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value < Block.heightBlock * Block.heightField - Block.heightCell && value >= 0)
                    y = value;
            }
        }


        public void Moving(List<Food> Foods)
        {
            double prewHypotenuse = range + 1;
            int catchFood = -1;
            int countFood = 0;

            int moveX = rnd.Next(-1, 2);
            int moveY = rnd.Next(-1, 2);

            foreach (var f in Foods)
            {
                double h = Y - f.Y;
                double w = X - f.X;

                double hypotenuse = Math.Sqrt(Math.Pow(h, 2) + Math.Pow(w, 2));

                if (hypotenuse <= range && hypotenuse < prewHypotenuse)
                {
                    prewHypotenuse = hypotenuse;
                    catchFood = countFood;
                }
                countFood++;
            }

            if (catchFood != -1)
            {
                int time = (int)(prewHypotenuse / stepLength);
                int deltaX = Foods[catchFood].X - X;
                int deltaY = Foods[catchFood].Y - Y;
                int stepX;
                int stepY;

                if (time == 0)
                {
                    stepX = 0;
                    stepY = 0;
                }
                else
                {
                    stepX = deltaX / time;
                    stepY = deltaY / time;
                }

                X += stepX;
                Y += stepY;
                if (deltaX == 0 && deltaY == 0)   //здесь клетка съедает еду
                {
                    Foods[catchFood].isAlive = false;
                    Foods.Remove(Foods[catchFood]);

                    int upHp = 10;
                    maxHp += upHp;

                    if (hp <= maxHp - upHp * 3)
                        hp += upHp * 3;
                    else
                        hp = maxHp;

                    if (hp % 50 == 0)
                        group++;
                }
            }

            else
            {
                X += moveX * stepLength;
                Y += moveY * stepLength;
            }
        }
    }
}


