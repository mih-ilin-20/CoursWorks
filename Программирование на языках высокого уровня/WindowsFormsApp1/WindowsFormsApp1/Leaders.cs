using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Leaders : Form
    {
        public Leaders()
        {
            InitializeComponent();

            StreamReader reader = new StreamReader("Leaders.txt");
            //while (!reader.EndOfStream)
            //{
            //    string[] leader = reader.ReadLine().Split('◙');
            //    label1.Text = leader[0] + "    " + leader[1] + "  " + leader[2] + "\n";
            //}
            string[] leader = reader.ReadToEnd().Split('◙');
            label1.Text = leader[0] + "    " + leader[1] + "  " + leader[2] + "\n";
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}
