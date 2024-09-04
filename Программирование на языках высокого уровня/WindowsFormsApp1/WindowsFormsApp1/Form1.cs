using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
//using System.Text;
//using System.Data;
//using System.Linq;
//using System.Collections.Generic;
//using System.ComponentModel;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
         
        Figure figure_variant;
        static int cell_size = 27;
        public static int a = 10;
        public static int b = 20;
        public static int score { get; set; }
        public static int _lines { get; set; }
        public int lines2 = 0;
        public int inter = 500;
        public int count = 0;

        // a*b — размеры сетки (Width, Heihgt)

        int[,] grid = new int[b, a];
        Registr registr = new Registr();

        public Form1()
        {
            InitializeComponent();
            Starting();
            

            this.KeyUp += new KeyEventHandler(Buttons);
        }

        public void Starting()
        {
            
            figure_variant = new Figure(a/2 -1, 0); // задает начальное положение фигуре
            timer.Interval = inter;
            timer.Tick += new EventHandler(Addiction);
            timer.Start();
        }

        public void Addiction(object sender, EventArgs e) // Выполнение всех функций с каждым тиком таймера
        {
            Clearing();

            if (Bottom_Check() == false)
            {
                figure_variant.MoveDown();
            }
            else
            {
                Connect();
                timer.Interval = inter;
                figure_variant = new Figure(a/2 -1, 0);
                DeleteLine();
                AddLeader(Registr.player_name, score, _lines);
                if (Bottom_Check() == true)
                {
                    //GameOver gameOver = new GameOver();
                    //gameOver.Show();

                    ClearGrid();
                    
                    Starting();
                    timer.Tick -= new EventHandler(Addiction);
                    timer.Stop();
                    MessageBox.Show("Ваш результат: " + score + "\n" + "Линий убрано: " + _lines);
                    паузаToolStripMenuItem.Text = "Продолжить";
                    
                }
            }
            Connect();
            Invalidate();
        }

        public void Connect()           //синхронизация фигур с картой  
        {
            for (int i = figure_variant.y; i < figure_variant.y + figure_variant.matr_size; i++)
            {
                for (int j = figure_variant.x; j < figure_variant.x + figure_variant.matr_size; j++)
                {
                    if (figure_variant.matr[i - figure_variant.y, j - figure_variant.x] != 0)
                        grid[i, j] = figure_variant.matr[i - figure_variant.y, j - figure_variant.x];
                }
            }
        }

        public void Clearing()
        {
            for (int i = figure_variant.y; i < figure_variant.y + figure_variant.matr_size; i++)
            {
                for (int j = figure_variant.x; j < figure_variant.x + figure_variant.matr_size; j++)
                {
                    if (i >= 0 && j >= 0 && i < b && j < a)
                    {
                        if (figure_variant.matr[i - figure_variant.y, j - figure_variant.x] != 0)
                        {
                            grid[i, j] = 0;
                        }
                    }
                }
            }
        }

        public void DeleteLine()
        {
            int cells;
            int lines = 0;
            for (int i = 0; i < b; i++)
            {
                cells = 0;
                for (int j = 0; j < a; j++)
                {
                    if (grid[i, j] != 0)
                        cells++;
                }
                if (cells == a)
                {
                    lines++;
                    for (int m = i; m > 0; m--)
                    {
                        for (int n = 0; n < a; n++)
                            grid[m, n] = grid[m - 1, n];
                    }
                }
            }
            for (int i = 1; i <= lines; i++)
            {
                score += (int) Math.Pow(4,(double) i);
            }
            _lines += lines;



            label1.Text = "Текущий счет : " + score;
            label2.Text = "Линий убрано : " + _lines;

            if (_lines % 4 == 0 && inter > 120)
            { 
                inter -= 10;
            }
            
        }

        public static void Grid(Graphics graphics)
        {
            Pen pen = new Pen(Color.White, 2);
            for (int i = 0; i <= b; i++)
            {
                graphics.DrawLine(pen, 75, 75 + i * cell_size, 75 + a * cell_size, 75 + i * cell_size);
            }
            for (int i = 0; i <= a; i++)
            {
                graphics.DrawLine(pen, 75 + i * cell_size, 75, 75 + i * cell_size, 75 + b * cell_size);
            }
        }

        public void Figures(Graphics graphics)
        {
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        graphics.FillRectangle(Brushes.Aqua, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                        graphics.DrawRectangle(Pens.Black, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                    }
                    if (grid[i, j] == 2)
                    {
                        graphics.FillRectangle(Brushes.Orange, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                        graphics.DrawRectangle(Pens.Black, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                    }
                    if (grid[i, j] == 3)
                    {
                        graphics.FillRectangle(Brushes.Blue, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                        graphics.DrawRectangle(Pens.Black, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                    }
                    if (grid[i, j] == 4)
                    {
                        graphics.FillRectangle(Brushes.Red, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                        graphics.DrawRectangle(Pens.Black, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                    }
                    if (grid[i, j] == 5)
                    {
                        graphics.FillRectangle(Brushes.Green, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                        graphics.DrawRectangle(Pens.Black, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                    }
                    if (grid[i, j] == 6)
                    {
                        graphics.FillRectangle(Brushes.Purple, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                        graphics.DrawRectangle(Pens.Black, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                    }
                    if (grid[i, j] == 7)
                    {
                        graphics.FillRectangle(Brushes.Yellow, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                        graphics.DrawRectangle(Pens.Black, 75 + j * cell_size + 1, 75 + i * cell_size + 1, cell_size - 2, cell_size - 2);
                    }
                }
            }
        }

        public void Buttons(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    
                    if (Wall_Check_Left() == false)
                    {
                        Clearing();
                        figure_variant.MoveLeft();
                        Connect();
                        Invalidate();
                    }
                    break;
                case Keys.A:
                    if (Wall_Check_Left() == false)
                    {
                        Clearing();
                        figure_variant.MoveLeft();
                        Connect();
                        Invalidate();
                    }
                    break;
                case Keys.Right:
                    if (Wall_Check_Right() == false)
                    {
                        Clearing();
                        figure_variant.MoveRight();
                        Connect();
                        Invalidate();
                    }
                    break;
                case Keys.D:
                    if (Wall_Check_Right() == false)
                    {
                        Clearing();
                        figure_variant.MoveRight();
                        Connect();
                        Invalidate();
                    }
                    break;
                case Keys.Space:    timer.Interval = 25; break; 
                case Keys.S:        timer.Interval = 25; break;
                case Keys.Down:     timer.Interval = 25; break;
                case Keys.W:
                    if (RoatteCheckFigure() == false)
                    {
                        Clearing();
                        figure_variant.Rotate();
                        Connect();
                        Invalidate();
                    }
                    break;
                case Keys.Up:
                    if (RoatteCheckFigure() == false)
                    {
                        Clearing();
                        figure_variant.Rotate();
                        Connect();
                        Invalidate();
                    }
                    break;
            }
        }

        public bool Bottom_Check()
        {
            for (int i = figure_variant.y + figure_variant.matr_size - 1; i >= figure_variant.y; i--)
            {
                for (int j = figure_variant.x; j < figure_variant.x + figure_variant.matr_size; j++)
                {
                    if (figure_variant.matr[i - figure_variant.y, j - figure_variant.x] != 0)  
                    {
                        if (i == b-1)
                        return true;
                        if (grid[i + 1, j] != 0)
                        return true; 

                    }

                }
            }
            return false;
        }

        public bool Wall_Check_Left()
        {
                for (int i = figure_variant.y; i < figure_variant.y + figure_variant.matr_size; i++)
                {
                    for (int j = figure_variant.x; j < figure_variant.x + figure_variant.matr_size; j++)
                    {
                        if (figure_variant.matr[i - figure_variant.y, j - figure_variant.x] != 0)
                        {
                        
                            if (j - 1 > a - 1 || j  - 1 < 0)
                            return true;

                            if (grid[i, j - 1] != 0)
                            {
                                if (j - figure_variant.x - 1 >= figure_variant.matr_size || j - figure_variant.x - 1 < 0)
                                    return true;
                                if (figure_variant.matr[i - figure_variant.y, j - figure_variant.x - 1] == 0)
                                    return true;
                            }
                        }
                    }
                }
            return false;
        }

        public bool Wall_Check_Right()
        {
                for (int i = figure_variant.y; i < figure_variant.y + figure_variant.matr_size; i++)
                {
                    for (int j = figure_variant.x; j < figure_variant.x + figure_variant.matr_size; j++)
                    {
                        if (figure_variant.matr[i - figure_variant.y, j - figure_variant.x] != 0)
                        {
                            if (j + 1 > a - 1  || j + 1 < 0)
                            return true;

                            if (grid[i, j + 1] != 0)
                            {
                                if (j - figure_variant.x + 1 >= figure_variant.matr_size || j - figure_variant.x + 1 < 0)
                                    return true;
                                if (figure_variant.matr[i - figure_variant.y, j - figure_variant.x + 1] == 0)
                                    return true;
                            }
                        }
                    }
                }
            return false;
        }

        public bool RoatteCheckFigure()
        {
            for (int i = figure_variant.y; i < figure_variant.y + figure_variant.matr_size; i++)
            {
                for (int j = figure_variant.x; j < figure_variant.x + figure_variant.matr_size; j++)
                {
                    if (i > 0 && i < b)
                    {
                        if (j > 0 && j < a )
                        {
                            if (grid[i, j] != 0 && figure_variant.matr[i - figure_variant.y, j - figure_variant.x] == 0)
                                return true;
                        }
                    }
                        
                }
            }
            return false;
        }

        public void ClearGrid()
        {
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < a; j++)
                    grid[i, j] = 0;
            }
        }

        public void Pause()
        {
            if (timer.Enabled)
            {
                паузаToolStripMenuItem.Text = "Продолжить";
                timer.Stop();
            }
            else
            {
                паузаToolStripMenuItem.Text = "Пауза";
                timer.Start();
            }
        }

        private void OnPaint (object sender, PaintEventArgs e)
        {

            Grid(e.Graphics);
            Figures(e.Graphics);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void AddLeader(string s, int i, int j)
        {
            StreamWriter file = new StreamWriter(@"Leaders.txt", false);
            file.WriteLine(s + '◙' + i + '◙' + j + "\n");
            file.Close();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Tick -= new EventHandler(Addiction);
            timer.Stop();
            ClearGrid();
            Starting();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
            Info info = new Info();
            this.Hide();
            info.Show();
        }

        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
        }

        private void результатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
            Leaders leaders = new Leaders();
            this.Hide();
            leaders.Show();
        }
    }
}
