using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// переделано месторасположение клеток, теперь зависит от установленнной длины и ширины, метод движения
//добавлен массив предыдущих состояний,чтобы не отрисовывалось все заново
namespace Evolution_3._0
{
    public partial class Form1 : Form
    {
        byte[,,] Elements = new byte[2, Block.widthField, Block.heightField];
        enum Status : byte { E, C, O, H, P, N, S };
        byte[,,] rgb = new byte[3, Block.heightMap, Block.widthMap];
        static public Random rnd = new Random();

        List<Cells> ListCells = new List<Cells>();
        List<Food> ListFoods = new List<Food>();
        DateTime timeStart;

        DataTable dt = new DataTable();
        PictureBox map = new PictureBox();
        Bitmap restored;

        public Form1()
        {
            InitializeComponent();

            dt.Columns.Add("Id");
            dt.Columns.Add("Group");
            dt.Columns.Add("HP");
            dt.Columns.Add("MaxHP");
            dt.Columns.Add("Eat");
            /////////////BITMAP MY GAME/////////////////////////////////////////////////////////////////////
            map.Size = new Size(Block.widthMap, Block.heightMap);
            map.Location = new Point(0, 0);
            this.Controls.Add(map);
        }

        /************************************ ОБРАБОТЧИКИ КНОПОК *********************************************
         *****************************************************************************************************
         *****************************************************************************************************
         ******************************************************************************************************/

        /// <summary>
        ///   начальная геренация элементов на поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneration_Click(object sender, EventArgs e)
        {

            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    CreateElement(x, y);
                    Elements[1, x, y] = 0;
                }
            }
            PrintElement();
            DrowAll();
        }


        public void CreateElement(int x, int y)
        {
            switch (rnd.Next(12))
            {
                case 0:
                    Elements[0, x, y] = (byte)Status.H;
                    break;
                case 1:
                    Elements[0, x, y] = (byte)Status.C;
                    break;
                case 2:
                    Elements[0, x, y] = (byte)Status.N;
                    break;
                case 3:
                    Elements[0, x, y] = (byte)Status.O;
                    break;
                case 4:
                    Elements[0, x, y] = (byte)Status.S;
                    break;
                case 5:
                    Elements[0, x, y] = (byte)Status.P;
                    break;
                default:
                    Elements[0, x, y] = (byte)Status.E;
                    break;
            }
        }

        /// <summary>
        /// создание органики (Cell, Food)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_create_Click(object sender, EventArgs e)
        {
            /////////////////////////здесь заполнение массива карты
            for (int y = 2; y < Block.heightField - 2; y++)
                for (int x = 2; x < Block.widthField - 2; x++)
                    if (Elements[0, x, y] == (byte)Status.C)
                        CreateOrganic(2, 3, 2, 2, x, y);


            for (int y = 0; y < Block.heightField; y++)
                for (int x = 0; x < Block.widthField; x++)
                    Elements[0, x, y] = (byte)Status.E;

            PrintElement();
            foreach (var c in ListCells)
                PrintCell(c);
            foreach (var f in ListFoods)
                PrintFood(f);
            DrowAll();
        }

        /// <summary>
        /// запуск игровых таймеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            timerDraw.Enabled = true;
            timerTurn.Enabled = true;
            timeStart = DateTime.Now;
        }

        /// <summary>
        /// Событие при выобре элемента из таблицы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1 && e.ColumnIndex == 0)
            {
                (ListCells.Find(x => x.idCell == Convert.ToInt32(dataGridViewInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))).isSelect = true; ; // лямбда выражение (и предикат для поиска)
            }
        }

        /// <summary>
        /// событие при смене элемента из таблицы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewInfo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 0)
            {
                (ListCells.Find(x => x.idCell == Convert.ToInt32(dataGridViewInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))).isSelect = false; ; // лямбда выражение (и предикат для поиска)
            }
        }

        /************************* ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ЗАПОЛНЕНИЯ МАССИВА RGB *****************************
         *****************************************************************************************************
         *****************************************************************************************************
         ******************************************************************************************************/
        /// <summary>
        /// Метод для заполнения трехмерного массива
        /// </summary>
        /// <param name="xSet"> Координата Х</param>
        /// <param name="ySet"> Координата У</param>
        /// <param name="rSet"> Значение Red</param>
        /// <param name="gSet"> Значение Green</param>
        /// <param name="bSet"> Значение Blue</param>
        void PrintRGB(int xSet, int ySet, byte rSet, byte gSet, byte bSet)
        {
            rgb[0, ySet, xSet] = rSet;
            rgb[1, ySet, xSet] = gSet;
            rgb[2, ySet, xSet] = bSet;
        }

        /// <summary>
        /// Отрисовка каждого объекта Cells
        /// </summary>
        /// <param name="c"> объект Cells из ListCells</param>
        void PrintCell(Cells c)
        {
            for (int y = 0; y < Block.heightCell; y++)
                for (int x = 0; x < Block.widthCell; x++)
                {
                    byte r = 0, g = 0, b = 0;
                    //Фоновый цвет 
                    switch (c.group)
                    {
                        case 1:
                            r = 255; g = 228; b = 225;
                            break;
                        case 2:
                            r = 200; g = 208; b = 200;
                            break;
                        case 3:
                            r = 189; g = 183; b = 107;
                            break;
                        case 4:
                            r = 255; g = 255; b = 0;
                            break;
                        case 5:
                            r = 75; g = 0; b = 130;
                            break;
                        case 6:
                            r = 255; g = 0; b = 255;
                            break;
                        case 7:
                            r = 128; g = 0; b = 128;
                            break;
                        case 8:
                            r = 0; g = 0; b = 128;
                            break;
                        case 9:
                            r = 47; g = 79; b = 79;
                            break;
                        case 10:
                            r = 0; g = 255; b = 0;
                            break;
                        default:
                            r = 0; g = 0; b = 0;
                            break;
                    }

                    PrintRGB(c.X + x, c.Y + y, r, g, b);

                    if (x < 2 || x >= Block.widthCell - 2 || y < 2 || y >= Block.heightCell - 2)
                    {
                        if (c.isSelect)
                            //белая рамка при выделении объекта
                            PrintRGB(c.X + x, c.Y + y, 255, 255, 255);
                        else if (c.agro)
                            PrintRGB(c.X + x, c.Y + y, 255, 0, 0);
                        else
                            //черная рамка вокруг клетки
                            PrintRGB(c.X + x, c.Y + y, 0, 0, 0);
                    }
                    else
                    {
                        //цефра поверх основного фона объекта
                        switch (c.group)
                        {
                            case 1:
                                if ((x == 15 && y > 5 && y < 25) || (x > 10 && x < 15 && y > 5 && y < 15 && x + y == 20))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 0, 0, 0);
                                }
                                break;
                            case 2:
                                if ((x == 10 && y > 15 && y < 25) || (x == 15 && y > 5 && y < 15) || (y == 5 && x > 10 && x < 15) || (y == 15 && x > 10 && x < 15) || (y == 25 && x >= 10 && x < 15))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 0, 0, 0);
                                }
                                break;
                            case 3:
                                if ((x == 15 && y > 5 && y < 25) || (y == 5 && x >= 10 && x < 15) || (y == 15 && x >= 12 && x < 15) || (y == 25 && x >= 10 && x < 15))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 0, 0, 0);
                                }
                                break;
                            case 4:
                                if ((x == 15 && y > 5 && y < 25) || (x == 10 && y > 5 && y < 15) || (x > 10 && x < 15 && y == 15))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 0, 0, 0);
                                }
                                break;
                            case 5:
                                if ((x == 10 && y > 5 && y < 15) || (x == 15 && y > 15 && y < 25) || (y == 5 && x > 10 && x < 15) || (y == 15 && x > 10 && x < 15) || (y == 25 && x >= 10 && x < 15))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 255, 255, 255);
                                }
                                break;
                            case 6:
                                if ((x == 10 && y > 5 && y < 25) || (x == 15 && y > 15 && y < 25) || (y == 5 && x > 10 && x <= 15) || (y == 15 && x > 10 && x < 15) || (y == 25 && x >= 10 && x < 15))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 255, 255, 255);
                                }
                                break;

                            case 7:
                                if ((x == 15 && y > 5 && y < 25) || (y == 5 && x >= 10 && x <= 15) || (y == 15 && x >= 12 && x <= 18)) //|| (x > 10 && x < 15 && y > 5 && y < 25 && 2*x + y == 35))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 255, 255, 255);
                                }
                                break;
                            case 8:
                                if ((x == 10 && y > 5 && y < 25) || (x == 15 && y > 5 && y < 25) || (y == 5 && x > 10 && x < 15) || (y == 15 && x > 10 && x < 15) || (y == 25 && x > 10 && x < 15))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 255, 255, 255);
                                }
                                break;
                            case 9:
                                if ((x == 10 && y > 5 && y < 15) || (x == 15 && y > 5 && y < 25) || (y == 5 && x > 10 && x < 15) || (y == 15 && x > 10 && x < 15) || (y == 25 && x > 10 && x < 15))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 255, 255, 255);
                                }
                                break;
                            case 10:
                                if ((x == 10 && y > 5 && y < 25) || (x == 15 && y > 5 && y < 25) || (y == 5 && x > 10 && x < 15) || (y == 25 && x > 10 && x < 15))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 255, 255, 255);
                                }
                                break;
                            default:
                                if ((x >= 13 && x <= 15 && y > 5 && y < 25))
                                {
                                    PrintRGB(c.X + x, c.Y + y, 255, 255, 255);
                                }
                                break;
                        }
                    }
                }
        }

        /// <summary>
        /// Отрисовка каждого объекта Food
        /// </summary>
        /// <param name="f"> объект Food из ListFoods</param>
        void PrintFood(Food f)
        {
            for (int y = 0; y < Block.heightFood; y++)
                for (int x = 0; x < Block.widthFood; x++)
                    PrintRGB(f.X + x, f.Y + y, 255, 0, 0);
        }

        /// <summary>
        /// Отрисовка каждого элемента из массива Status[x, y]
        /// В отличие от Cells, Food элементы отрисовываются не через считывание параметров 
        /// из листа, а через двумерный массив координат
        /// </summary>
        void PrintElement()
        {
            byte r = 0, g = 0, b = 0;
            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    switch (Elements[0, x, y])
                    {
                        case (byte)Status.E:
                            r = 173; g = 216; b = 230;
                            break;
                        case (byte)Status.C:
                            r = 255; g = 104; b = 0;
                            break;
                        case (byte)Status.N:
                            r = 0; g = 184; b = 217;
                            break;
                        case (byte)Status.H:
                            r = 138; g = 127; b = 128;
                            break;
                        case (byte)Status.O:
                            r = 173; g = 216; b = 230;
                            break;
                        case (byte)Status.S:
                            r = 143; g = 254; b = 9;
                            break;
                        case (byte)Status.P:
                            r = 10; g = 10; b = 10;
                            break;
                    }

                    for (int h = 0; h < Block.heightBlock; h++)
                        for (int w = 0; w < Block.widthBlock; w++)
                            PrintRGB(Block.widthBlock * x + w, Block.heightBlock * y + h, r, g, b);
                }
            }
        }

        /// <summary>
        /// Отрисовка всей карты из трехмерного массива rgb[,,]
        /// </summary>
        public void DrowAll()
        {
            restored = Rgb.RgbToBitmapQ(rgb); //Rgb.RgbToBitmapNaive(rgb);
            map.Image = restored;
        }

        /************************* СОЗДАНИЕ ОБЪЕКТОВ CELLS, FOOD *********************************************
         *****************************************************************************************************
         *****************************************************************************************************
         ******************************************************************************************************/

        /// <summary>
        /// Создание новых объектов Cells,Food,текущая координата принимается за центр
        /// считываются блоки 5х5. Приоритет создания: Cells -> Food -> 
        /// </summary>
        /// <param name="minHydrogen">Минимальные требования кол-ва водорода</param>
        /// <param name="minCarbon">Минимальные требования кол-ва углерода</param>
        /// <param name="minNytrogen">Минимальные требования кол-ва азота</param>
        /// <param name="minOxygen">Минимальные требования кол-ва кислорода</param>
        /// <param name="xCell">Текущая координата Х</param>
        /// <param name="yCell">Текущая координата У</param>
        void CreateOrganic(int minHydrogen, int minCarbon, int minNytrogen, int minOxygen, int xCell, int yCell)
        {
            int hydrogen = 0;
            int carbon = 0;
            int nytrogen = 0;
            int oxygen = 0;

            for (int y = yCell - 2; y <= yCell + 2; y++)
            {
                for (int x = xCell - 2; x <= xCell + 2; x++)
                {
                    switch (Elements[0, x, y])
                    {
                        case (byte)Status.H:
                            hydrogen++;
                            break;
                        case (byte)Status.C:
                            carbon++;
                            break;
                        case (byte)Status.N:
                            nytrogen++;
                            break;
                        case (byte)Status.O:
                            oxygen++;
                            break;
                    }
                }
            }

            if (hydrogen > minHydrogen && carbon > minCarbon && oxygen > minOxygen && nytrogen > minHydrogen)
            {
                //create Cell
                Cells c = new Cells(carbon, xCell * Block.widthBlock, yCell * Block.heightBlock);
                ListCells.Add(c);

                for (int y = yCell - 2; y <= yCell + 2; y++)
                    for (int x = xCell - 2; x <= xCell + 2; x++)
                        Elements[0, x, y] = (byte)Status.E;

                DataRow r = dt.NewRow();
                r["Id"] = c.idCell;
                r["Group"] = c.group;
                r["MaxHP"] = c.maxHp;
                r["HP"] = c.hp;
                r["Eat"] = c.Fullness;
                dt.Rows.Add(r);
                dataGridViewInfo.DataSource = dt;
            }

            else if (hydrogen > minHydrogen && carbon > minCarbon && oxygen > minOxygen)// && nytrogen >= minNytrogen)
            {
                //create Food
                Food f = new Food(xCell * Block.widthBlock, yCell * Block.heightBlock);
                ListFoods.Add(f);

                for (int y = yCell - 2; y <= yCell + 2; y++)
                    for (int x = xCell - 2; x <= xCell + 2; x++)
                        // Status[x, y] = 'E';
                        Elements[0, x, y] = (byte)Status.E;
            }
        }

        /********************************************** ТАЙМЕРЫ *********************************************
        *****************************************************************************************************
        *****************************************************************************************************
        ******************************************************************************************************/
        /// <summary>
        /// Таймер отрисовки карты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerDraw_Tick(object sender, EventArgs e)
        {
            DrowAll();
        }

        /// <summary>
        /// Таймер хода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTurn_Tick(object sender, EventArgs e)
        {
            GenerationElement();

            PrintElement();
            foreach (var f in ListFoods)
            {
                PrintFood(f);
            }

            for (int i = 0; i < ListCells.Count; i++)
            {
                //движение всех клеток
                ListCells[i].Hunger();
                labelElements.Text = DateTime.Now.Millisecond.ToString();
                ListCells[i].Moving(ListFoods, ListCells);
                if (ListCells[i].Born())
                {
                    Cells cell = new Cells(ListCells[i].group, ListCells[i].X + Block.widthCell, ListCells[i].Y);
                    ListCells.Add(cell);
                    DataRow r = dt.NewRow();
                    r["Id"] = cell.idCell;
                    r["Group"] = cell.group;
                    r["MaxHP"] = cell.maxHp;
                    r["HP"] = cell.hp;
                    r["Eat"] = cell.Fullness;
                    dt.Rows.Add(r);
                    dataGridViewInfo.DataSource = dt;
                }

                //обновление таблицы данных при изменении кол-ва hp,maxHp,group


                PrintCell(ListCells[i]);
            }

            foreach (var c in ListCells)
            {
                RefreshData(c);
            }

            ListCells.RemoveAll(x => x.hp < 0);

            for (int y = 0; y < Block.heightField; y++) //старение и удаление элементов
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    if (Elements[0, x, y] != (byte)Status.E)
                    {
                        Elements[1, x, y]++;
                        if (Elements[1, x, y] >= 250)
                        {
                            Elements[0, x, y] = (byte)Status.E;
                            Elements[1, x, y] = 0;
                        }
                    }
                }
            }
            labelCells.Text = ListCells.Count.ToString();
            labelFoods.Text = ListFoods.Count.ToString();

            labelTime.Text = (DateTime.Now - timeStart).ToString().Substring(0, 8);
        }


        void RefreshData(Cells c)
        {
            dt.AsEnumerable().Where(p => Convert.ToInt32(p["Id"]) == c.idCell).ToList().ForEach( //обновление таблицы
                    k =>
                    {
                        if (Convert.ToInt32(k["MaxHP"]) != c.maxHp)
                        {
                            k.BeginEdit();
                            k["MaxHP"] = c.maxHp;
                            k.EndEdit();
                        }
                        if (Convert.ToInt32(k["HP"]) != c.hp)
                        {
                            k.BeginEdit();
                            k["HP"] = c.hp;
                            k.EndEdit();
                        }
                        if (Convert.ToInt32(k["Group"]) != c.group)
                        {
                            k.BeginEdit();
                            k["Group"] = c.group;
                            k.EndEdit();
                        }
                        /*if (Convert.ToInt32(k["Eat"]) != c.Fullness)
                        {
                            k.BeginEdit();
                            k["Eat"] = c.Fullness;
                            k.EndEdit();
                        }*/
                        if (c.hp <= 0)
                        {
                            dt.Rows.Remove(k);  //не удаляется, т.к. его могла убить другая клетка позже в листе
                        }
                    });
        }

        /// <summary>
        /// рандомная генерация новых элементов
        /// </summary>
        void GenerationElement()
        {
            int x;
            int y;
            int num = rnd.Next(6, 13);
            for (int i = 0; i < num; i++)
            {
                x = rnd.Next(2, Block.widthField - 2);
                y = rnd.Next(2, Block.heightField - 2);

                if (Elements[0, x, y] == (byte)Status.E)
                {
                    CreateElement(x, y);
                    CreateOrganic(0, 0, 0, 1, x, y);
                }
            }
        }
    }
}
