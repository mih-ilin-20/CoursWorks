using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs
{
    public partial class cont_kurs : Form
    {
        public cont_kurs()
        {
            InitializeComponent();

        }

        static public int[] isit = new int[4] { 3, 2, 3, 0};
        static public int a;
        static public int b;
        int fail = 0;
        Label label = new Label();
        Button[] cases = new Button[isit[1]];
        Panel[] containers = new Panel[isit[0]];

        private void Form1_Load(object sender, EventArgs e)
        {
            a = this.Width = 580;
            b = this.Height = 510;
            this.MinimumSize = this.MaximumSize = new Size(a, b);
            tb1.Text = isit[0].ToString();
            tb2.Text = isit[1].ToString();
            tb3.Text = isit[2].ToString();
            label.Location = new Point(10, 140);
            label.Font = new Font("Verdana", 9);
            label.Size = new Size(280, 600);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Empty_tb(isit, 0);

            if (fail == 0)
            {
                if (Convert.ToInt32(tb1.Text) > 0 && Convert.ToInt32(tb1.Text) < 9) isit[0] = Convert.ToInt32(tb1.Text);
                else { MessageBox.Show("Введите корректное число!"); fail++; }
                if (Convert.ToInt32(tb2.Text) > 0) isit[1] = Convert.ToInt32(tb2.Text);
                else { MessageBox.Show("Введите корректное число!"); fail++; }
                if (Convert.ToInt32(tb3.Text) > 0 && Convert.ToInt32(tb3.Text) < 5) isit[2] = Convert.ToInt32(tb3.Text);
                else { MessageBox.Show("Введите корректное число!"); fail++; }
            }

            if (fail == 0)
            {
                label.Text = "";

                int product = isit[0] * isit[2];

                int[] res = new int[product + 1]; // создаем массив для N * n + 1 элементов
                int sum = 0;
                res[0] = 1;

                for (int i = 1; i < isit[1]; i++)
                {
                    res[i] = res[i - 1] * 2; // массив контейнера - веса пластин изначально 0
                }
                for (int i = isit[1]; i < product + 1; i++) // все контейнеры
                {
                    for (int lb = i - isit[1]; lb < i; lb++)
                    {
                        sum += res[lb];
                    }
                    res[i] = sum;
                    sum = 0;
                }

                for (int n = 0; n < isit[0]; n++)
                {
                    label.Text += (n + 1).ToString() + ") ";
                    for (int m = 1; m < isit[2] + 1; m++)
                    {
                        label.Text += res[m + isit[2] * n].ToString() + ' ';
                    }
                    label.Text += "\n";
                    label.Text += "\n";
                }
                bool count = true;
                if (label.Text.Length < 0 || count) panel1.Controls.Add(label);

                containers = new Panel[isit[0]];
                for (int i = 0; i < isit[0]; i++)
                {
                    if (i < 4)
                    {
                        containers[i] = new Panel
                        {
                            Size = new Size(90, 52),
                            Location = new Point(10, 120 + i * 60),
                            Name = "pan" + i,
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        panel2.Controls.Add(containers[i]);
                    }
                    else
                    {
                        containers[i] = new Panel
                        {
                            Size = new Size(90, 52),
                            Location = new Point(120, 120 + (i - 4) * 60),
                            Name = "pan" + i,
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        panel2.Controls.Add(containers[i]);
                    }
                    
                    cases = new Button[isit[2]];
                    int k = 0;
                    for (int j = 0; j < isit[2]; j++)
                    {  
                        if (k < isit[1])
                        {
                            cases[j] = new Button
                            {
                                Size = new Size(86, 52 / isit[2] - 2),
                                Location = new Point(1, 3 + j * 52 / isit[2] - 2),
                                Enabled = false,
                                BackColor = Color.Tomato,
                            };
                            k++;    
                        }
                        else
                        {
                            cases[j] = new Button
                            {
                                Size = new Size(86, 52 / isit[2] - 2),
                                Location = new Point(1, 3 + j * 52 / isit[2] - 2),
                                Enabled = false,
                                BackColor = Color.Gray,
                            };
                        }
                        containers[i].Controls.Add(cases[j]);
                    }
                }
            }
        }      

        private void button3_Click(object sender, EventArgs e)
        {
            Empty_tb(isit, 0);
            Empty_tb(isit, 1);
            if (fail == 0)
            {
                if (Convert.ToInt32(tb1.Text) > 0 && Convert.ToInt32(tb1.Text) < 9) isit[0] = Convert.ToInt32(tb1.Text);
                else { MessageBox.Show("Введите корректное число!"); fail++; }
                if (Convert.ToInt32(tb2.Text) > 0 && Convert.ToInt32(tb2.Text) < 5) isit[1] = Convert.ToInt32(tb2.Text);
                else { MessageBox.Show("Введите корректное число!"); fail++; }
                if (Convert.ToInt32(tb3.Text) > 0 && Convert.ToInt32(tb3.Text) < 5) isit[2] = Convert.ToInt32(tb3.Text);
                else { MessageBox.Show("Введите корректное число!"); fail++; }
                if (Convert.ToInt32(tb7.Text) > 0 && Convert.ToInt32(tb7.Text) < isit[0] + 1) isit[3] = Convert.ToInt32(tb7.Text);
                else { MessageBox.Show("Введите корректное число!"); fail++; }
            }

            if (fail == 0)
            {
                label11.Text = "";

                int product = isit[0] * isit[2];

                int[] res = new int[product + 1];
                int sum = 0;
                res[0] = 1;
                int index = isit[3];

                for (int i = 1; i < isit[1]; i++)
                {
                    res[i] = res[i - 1] * 2; // массив контейнера - веса пластин изначально 0
                }
                for (int i = isit[1]; i < product + 1; i++) // все контейнеры
                {
                    for (int lb = i - isit[1]; lb < i; lb++)
                    {
                        sum += res[lb];
                    }
                    res[i] = sum;
                    sum = 0;

                }
                label11.Text += index.ToString() + ") ";
                for (int m = index * isit[2] - isit[2] + 1; m < index * isit[2] + 1; m++)
                {
                        label11.Text += res[m].ToString() + ' ';
                }
            }
        }
        
        private void Empty_tb(int[] a, int variant)
        {
            fail = 0;
            int[] empty_mas = new int[4];
            var mas_lenght = new int[4]{
                Convert.ToInt32(tb1.TextLength),
                Convert.ToInt32(tb2.TextLength),
                Convert.ToInt32(tb3.TextLength),
                Convert.ToInt32(tb7.TextLength)};
            var mas_text = new string[4]{
                tb1.Text,
                tb2.Text,
                tb3.Text,
                tb7.Text };
            bool counter = false;
            if (variant == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (mas_lenght[i] > 0)
                    {
                        if (int.TryParse(mas_text[i], out empty_mas[i]))
                        {
                            if (empty_mas[i] != 0)
                            {
                                a[i] = Convert.ToInt32(empty_mas[i]);
                            }
                            else { if (!counter) { MessageBox.Show("Введите число!"); counter = true; } fail++; }
                        }
                        else { if (!counter) { MessageBox.Show("Введите число!"); counter = true; } fail++; }
                    }
                    else { if (!counter) { MessageBox.Show("Введите значение!"); counter = true; } fail++; }
                }
            }
            else if (variant == 1)
            {
                int i = 3;
                if (mas_lenght[i] > 0)
                {
                    if (int.TryParse(mas_text[i], out empty_mas[i]))
                    {
                        if (empty_mas[i] != 0)
                        {
                            a[i] = Convert.ToInt32(empty_mas[i]);
                        }
                        else { if (!counter) { MessageBox.Show("Введите число!"); counter = true; } fail++; }
                    }
                    else { if (!counter) { MessageBox.Show("Введите число!"); counter = true; } fail++; }
                }
                else { if (!counter) { MessageBox.Show("Введите значение!"); counter = true; } fail++; }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isit = new int[4] { 3, 2, 3, 0 };
            tb1.Text = isit[0].ToString();
            tb2.Text = isit[1].ToString();
            tb3.Text = isit[2].ToString();
            tb7.Text = null;
            label.Text = null;
            label11.Text = null;
            for (int i = 0; i < isit[2]; i++) cases[i].Dispose();
            for (int i = 0; i < isit[0]; i++) containers[i].Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            model.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
} 