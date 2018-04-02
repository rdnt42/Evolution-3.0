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
        char[,] Status = new char[Block.widthField, Block.heightField];
        char[,] PrewStatus = new char[Block.widthField, Block.heightField];
        static public Random rnd = new Random();
        List<Cells> ListCells = new List<Cells>();
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    Status[x, y] = 'E';
                }
            }
            dt.Columns.Add("Id");
            dt.Columns.Add("Group");
            dt.Columns.Add("HP");
            dt.Columns.Add("MaxHP");
        }

        private void btnGeneration_Click(object sender, EventArgs e)
        {

            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    switch (rnd.Next(12))
                    {
                        case 0:
                            Status[x, y] = 'H';
                            break;
                        case 1:
                            Status[x, y] = 'C';
                            break;
                        case 2:
                            Status[x, y] = 'N';
                            break;
                        case 3:
                            Status[x, y] = 'O';
                            break;
                        case 4:
                            Status[x, y] = 'S';
                            break;
                        case 5:
                            Status[x, y] = 'P';
                            break;
                        default:
                            Status[x, y] = 'E';
                            break;
                    }
                    //Block b = new Block();     // нам не нужны объекты, т.к. элементы можно задавать через статусы
                    // b.x = x * Block.widthBlock;
                    // b.y = y * Block.heightBlock;

                }
            }
        }

        public void DrowAll()
        {
            SolidBrush myBrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black, 2);
            Graphics g = CreateGraphics();
            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    if (Status[x, y] != PrewStatus[x, y])
                    {
                        switch (Status[x, y])
                        {
                            case 'E':
                                myBrush = new SolidBrush(Color.LightBlue);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case 'C':
                                myBrush = new SolidBrush(Color.Yellow);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case 'N':
                                myBrush = new SolidBrush(Color.Gray);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case 'H':
                                myBrush = new SolidBrush(Color.Red);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case 'O':
                                myBrush = new SolidBrush(Color.Orange);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case 'S':
                                myBrush = new SolidBrush(Color.Black);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case 'P':
                                myBrush = new SolidBrush(Color.Blue);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case '0':
                                myBrush = new SolidBrush(Color.Pink);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));

                                //  g.DrawRectangle(myPen, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case '1':
                                myBrush = new SolidBrush(Color.LightCoral);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                //   g.DrawRectangle(myPen, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));

                                break;
                            case '2':
                                myBrush = new SolidBrush(Color.LightBlue);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                // g.DrawRectangle(myPen, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case '3':
                                myBrush = new SolidBrush(Color.DarkCyan);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                // g.DrawRectangle(myPen, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case '4':
                                myBrush = new SolidBrush(Color.Indigo);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                //  g.DrawRectangle(myPen, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case '5':
                                myBrush = new SolidBrush(Color.DarkGreen);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                //g.DrawRectangle(myPen, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                            case '6':
                                myBrush = new SolidBrush(Color.Black);
                                g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                // g.DrawRectangle(myPen, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                break;
                        }
                        PrewStatus[x, y] = Status[x, y];
                    }
                }
            }
            myPen.Dispose();
            myBrush.Dispose();
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerDraw.Enabled = true;
            timerTurn.Enabled = true;
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            DrowAll();
            // Invalidate();
        }


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
                    switch (Status[x, y])
                    {

                        case 'H':
                            hydrogen++;
                            break;
                        case 'C':
                            carbon++;
                            break;
                        case 'N':
                            nytrogen++;
                            break;
                        case 'O':
                            oxygen++;
                            break;
                    }
                }
            }

            if (hydrogen > minHydrogen && carbon > minCarbon && oxygen > minOxygen && nytrogen > minHydrogen)
            {
                //create Cell
                Cells c = new Cells(carbon, xCell - 1, yCell - 1);
                ListCells.Add(c);

                DataRow r = dt.NewRow();
                r["Id"] = c.idCell;
                r["Group"] = c.group;
                r["MaxHP"] = c.maxHp;
                r["HP"] = c.hp;
                dt.Rows.Add(r);
                dataGridViewInfo.DataSource = dt;
                //r.Delete();

                for (int y = c.Y; y <= c.Y + Block.heightCell / Block.heightBlock; y++)
                {
                    for (int x = c.X; x <= c.X + Block.widthCell / Block.widthBlock; x++)
                    {
                        Status[x, y] = 'E';
                    }
                }

                for (int y = c.Y; y <= c.Y + Block.heightCell / Block.heightBlock; y++)
                {
                    for (int x = c.X; x <= c.X + Block.widthCell / Block.widthBlock; x++)
                    {
                        Status[x, y] = Convert.ToChar(c.group.ToString());
                    }
                }
            }

            else if (hydrogen >= minHydrogen && carbon >= minCarbon && oxygen >= minOxygen && nytrogen >= minNytrogen)
            {
                //create Food
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {

            for (int y = 2; y < Block.heightField - 2; y++)
            {
                for (int x = 2; x < Block.widthField - 2; x++)
                {
                    if (Status[x, y] == 'C')
                    {
                        CreateOrganic(2, 3, 2, 2, x, y);
                    }
                }
            }

            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    if (!char.IsDigit(Status[x, y]))
                    {
                        Status[x, y] = 'E';
                    }
                }
            }

        }

        private void timerTurn_Tick(object sender, EventArgs e)
        {
            foreach (var c in ListCells)
            {
                c.Moving(Status);
                dt.AsEnumerable().Where(p => Convert.ToInt32(p["Id"]) == c.idCell).ToList().ForEach( //обновление таблицы
                    k =>
                    {
                        if (Convert.ToInt32(k["MaxHP"]) != c.maxHp)
                        {
                            k.BeginEdit();
                            k["MaxHP"] = c.maxHp;
                            k.EndEdit();
                        }
                    });
            }

            labelCells.Text = ListCells.Count.ToString();
        }
    }
}
