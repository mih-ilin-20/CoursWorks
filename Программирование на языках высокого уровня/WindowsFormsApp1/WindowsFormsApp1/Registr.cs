﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Registr : Form
    {
        public static string player_name { get; set; }
        public Registr()
        {
            InitializeComponent();
        }

        private void Registr_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Новый игрок";
            else player_name = textBox1.Text;
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}
