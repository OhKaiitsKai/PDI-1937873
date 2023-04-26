namespace PDI_1937873
{
    partial class RT
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filtrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imágenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vídeosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox1.Location = new System.Drawing.Point(28, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(774, 419);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Indigo;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(854, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 74);
            this.button1.TabIndex = 12;
            this.button1.Text = "Activar cámara";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBox1.Location = new System.Drawing.Point(64, 495);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 45);
            this.textBox1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(200, 501);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "# Personas";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1045, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filtrosToolStripMenuItem
            // 
            this.filtrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imágenesToolStripMenuItem,
            this.vídeosToolStripMenuItem});
            this.filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            this.filtrosToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.filtrosToolStripMenuItem.Text = "Filtros";
            this.filtrosToolStripMenuItem.Click += new System.EventHandler(this.FiltrosToolStripMenuItem_Click);
            // 
            // imágenesToolStripMenuItem
            // 
            this.imágenesToolStripMenuItem.Name = "imágenesToolStripMenuItem";
            this.imágenesToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.imágenesToolStripMenuItem.Text = "Imágenes";
            this.imágenesToolStripMenuItem.Click += new System.EventHandler(this.ImágenesToolStripMenuItem_Click);
            // 
            // vídeosToolStripMenuItem
            // 
            this.vídeosToolStripMenuItem.Name = "vídeosToolStripMenuItem";
            this.vídeosToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.vídeosToolStripMenuItem.Text = "Vídeos";
            this.vídeosToolStripMenuItem.Click += new System.EventHandler(this.VídeosToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(828, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 39);
            this.label2.TabIndex = 16;
            this.label2.Text = "Dispositivos:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(835, 247);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 24);
            this.comboBox1.TabIndex = 17;
            // 
            // RT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1045, 568);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RT";
            this.Text = "Webcam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RT_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RT_FormClosed);
            this.Load += new System.EventHandler(this.RT_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filtrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imágenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vídeosToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}