namespace kurs
{
    partial class Model
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Model));
            this.DataL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataL
            // 
            this.DataL.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataL.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataL.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DataL.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DataL.Location = new System.Drawing.Point(0, 0);
            this.DataL.Name = "DataL";
            this.DataL.Size = new System.Drawing.Size(978, 273);
            this.DataL.TabIndex = 1;
            this.DataL.Text = resources.GetString("DataL.Text");
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-1, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(978, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Исходные данные. N - количество контейнеров, n - количество пластин в контейнере." +
    "\r\n\r\n\r\n\r\n";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 273);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 271);
            this.panel1.TabIndex = 3;
            // 
            // Model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 544);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DataL);
            this.Name = "Model";
            this.Text = "Model";
            this.Load += new System.EventHandler(this.Model_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DataL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}