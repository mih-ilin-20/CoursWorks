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
    public partial class Model : Form
    {
        public Model()
        {
            InitializeComponent();
        }

        

        private void Model_Load(object sender, EventArgs e)
        {
            Button[,] cases = new Button[3, 4];
            Panel[] containers = new Panel[3];

            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    cases[i, j] = new Button
                    {
                        Size = new Size(80, 30),
                        Location = new Point(40 + i * 120, 130 - j * 30),
                        Text = "Тип 1 или 2",
                        Enabled = false,
                        TextAlign = (ContentAlignment)HorizontalAlignment.Center
                    };
                    panel1.Controls.Add(cases[i, j]);
                }
                containers[i] = new Panel
                {
                    Size = new Size(90, 100),
                    Location = new Point(35 + i * 120, 65),
                    BorderStyle = BorderStyle.FixedSingle
                };
                panel1.Controls.Add(containers[i]);
            }
        }
    }
}
