using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_3._0
{
    /// <summary>
    /// Класс объектов типа еда
    /// </summary>
    class Food : Block
    {
        static int countFood = 0;
        public int idFood;

        public bool isAlive;

        int x;
        int y;

        public Food (int xFood, int yFood)
        {
            idFood = countFood;
            countFood++;

            isAlive = true;
            X = xFood;
            Y = yFood;
        }

        public new int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value < Block.widthBlock * Block.widthField - Block.widthFood*2 && value >= 0)
                    x = value;
                else if (value >= Block.widthBlock * Block.widthField - Block.widthFood*2)
                    x = Block.widthBlock * Block.widthField - Block.widthFood*2;
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
                if (value < Block.heightBlock * Block.heightField - Block.heightFood*2 && value >= 0)
                    y = value;
                else if (value >= Block.heightBlock * Block.heightField - Block.heightFood*2)
                    y = Block.heightBlock * Block.heightField - Block.heightFood*2;
            }
        }
    }
}
