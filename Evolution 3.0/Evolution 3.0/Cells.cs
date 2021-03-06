﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_3._0
{
    /// <summary>
    /// Класс объектов типа клетка
    /// </summary>
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
        public bool isSelect;

        public Cells(int carbon, int xCell, int yCell)
        {
            idCell = countCell;
            countCell++;

            X = xCell;
            Y = yCell;
            prewX = X;
            prewY = Y;
            /* if (carbon == 1)
                 group = rnd.Next(2, 6);
             else
                 group = carbon;*/
            group = carbon;
            range = 100;
            stepLength = 2;
            maxHp = 50 + 100 * group;
            hp = maxHp;
            isSelect = false;
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


        public void Moving(List<Food> Foods, List<Cells> Cells)
        {
            double prewHypotenuse = range + 1;
            int catchFood = -1;
            int countFood = 0;

            int catchCell = -1;
            int countCell = 0;

            int moveX = rnd.Next(-1, 2);
            int moveY = rnd.Next(-1, 2);

            foreach (var f in Foods)
            {
                int h = Y - f.Y;
                int w = X - f.X;

                double hypotenuse = Math.Sqrt(h*h + w*w);

                if (hypotenuse <= range && hypotenuse < prewHypotenuse)
                {
                    prewHypotenuse = hypotenuse;
                    catchFood = countFood;
                }
                countFood++;
            }


            foreach (var c in Cells)
            {
                int h = Y - c.Y;
                int w = X - c.X;

                double hypotenuse = Math.Sqrt(h * h + w * w);

                if (hypotenuse <= range && hypotenuse < prewHypotenuse && idCell !=c.idCell)
                {
                    prewHypotenuse = hypotenuse;
                    catchCell = countCell;
                }
                countCell++;
            }

            if (catchCell != -1)
            {
                int time = (int)(prewHypotenuse / stepLength);
                int deltaX = Cells[catchCell].X - X;
                int deltaY = Cells[catchCell].Y - Y;
                int stepX = 0;
                int stepY;

                if (time ==0)
                {
                    stepX = 0;
                    stepY = 0;
                    Cells[catchCell].hp -= rnd.Next(10);
                }
                else
                {
                    stepX = deltaX / time;
                    stepY = deltaY / time;
                }

                X += stepX;
                Y += stepY;
            }
            else if (catchFood != -1)
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
                    Foods.Remove(Foods[catchFood]);

                    int upHp = 10;
                    maxHp += upHp;

                    if (hp <= maxHp - upHp * 3)
                        hp += upHp * 3;
                    else
                        hp = maxHp;

                    if (maxHp >= 50 + 100 * group +50)
                        group++;
                }
            }

            else
            {
                X += moveX * stepLength;
                Y += moveY * stepLength;
            }
        }

        public bool Born()
        {
            if (maxHp > 800 && hp > 600)
            {
                maxHp /= 2;
                hp /= 2;
                group /= 2;
                X -= Block.widthCell;
                return true;
            }
            return false;
        }
    }
}


