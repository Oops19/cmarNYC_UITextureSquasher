namespace UITextureSquasher
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ATIfile2_button = new System.Windows.Forms.Button();
            this.ATIfile1_button = new System.Windows.Forms.Button();
            this.ATItoBMPgo_button = new System.Windows.Forms.Button();
            this.ATIfile1 = new System.Windows.Forms.TextBox();
            this.ATIfile2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BMPfile_button = new System.Windows.Forms.Button();
            this.BMPtoATIgo_button = new System.Windows.Forms.Button();
            this.PNGfile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.ATIfile2_button);
            this.groupBox1.Controls.Add(this.ATIfile1_button);
            this.groupBox1.Controls.Add(this.ATItoBMPgo_button);
            this.groupBox1.Controls.Add(this.ATIfile1);
            this.groupBox1.Controls.Add(this.ATIfile2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Convert two UI encoded DDS images into one png file";
            // 
            // ATIfile2_button
            // 
            this.ATIfile2_button.Location = new System.Drawing.Point(735, 89);
            this.ATIfile2_button.Name = "ATIfile2_button";
            this.ATIfile2_button.Size = new System.Drawing.Size(95, 36);
            this.ATIfile2_button.TabIndex = 6;
            this.ATIfile2_button.Text = "Select";
            this.ATIfile2_button.UseVisualStyleBackColor = true;
            this.ATIfile2_button.Click += new System.EventHandler(this.ATIfile2_button_Click);
            // 
            // ATIfile1_button
            // 
            this.ATIfile1_button.Location = new System.Drawing.Point(735, 36);
            this.ATIfile1_button.Name = "ATIfile1_button";
            this.ATIfile1_button.Size = new System.Drawing.Size(95, 36);
            this.ATIfile1_button.TabIndex = 5;
            this.ATIfile1_button.Text = "Select";
            this.ATIfile1_button.UseVisualStyleBackColor = true;
            this.ATIfile1_button.Click += new System.EventHandler(this.ATIfile1_button_Click);
            // 
            // ATItoBMPgo_button
            // 
            this.ATItoBMPgo_button.Location = new System.Drawing.Point(319, 130);
            this.ATItoBMPgo_button.Name = "ATItoBMPgo_button";
            this.ATItoBMPgo_button.Size = new System.Drawing.Size(198, 33);
            this.ATItoBMPgo_button.TabIndex = 4;
            this.ATItoBMPgo_button.Text = "Convert";
            this.ATItoBMPgo_button.UseVisualStyleBackColor = true;
            this.ATItoBMPgo_button.Click += new System.EventHandler(this.ATItoPNGgo_button_Click);
            // 
            // ATIfile1
            // 
            this.ATIfile1.Location = new System.Drawing.Point(177, 43);
            this.ATIfile1.Name = "ATIfile1";
            this.ATIfile1.Size = new System.Drawing.Size(552, 22);
            this.ATIfile1.TabIndex = 3;
            // 
            // ATIfile2
            // 
            this.ATIfile2.Location = new System.Drawing.Point(177, 96);
            this.ATIfile2.Name = "ATIfile2";
            this.ATIfile2.Size = new System.Drawing.Size(552, 22);
            this.ATIfile2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Smaller image \r\n(group ID 0x00064dc9): ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Larger image \r\n(group ID 0x00064dca): ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.BMPfile_button);
            this.groupBox2.Controls.Add(this.BMPtoATIgo_button);
            this.groupBox2.Controls.Add(this.PNGfile);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(23, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(837, 146);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Convert one png image into two UI encoded DDS images";
            // 
            // BMPfile_button
            // 
            this.BMPfile_button.Location = new System.Drawing.Point(735, 32);
            this.BMPfile_button.Name = "BMPfile_button";
            this.BMPfile_button.Size = new System.Drawing.Size(95, 36);
            this.BMPfile_button.TabIndex = 6;
            this.BMPfile_button.Text = "Select";
            this.BMPfile_button.UseVisualStyleBackColor = true;
            this.BMPfile_button.Click += new System.EventHandler(this.PNGfile_button_Click);
            // 
            // BMPtoATIgo_button
            // 
            this.BMPtoATIgo_button.Location = new System.Drawing.Point(319, 85);
            this.BMPtoATIgo_button.Name = "BMPtoATIgo_button";
            this.BMPtoATIgo_button.Size = new System.Drawing.Size(198, 33);
            this.BMPtoATIgo_button.TabIndex = 5;
            this.BMPtoATIgo_button.Text = "Convert";
            this.BMPtoATIgo_button.UseVisualStyleBackColor = true;
            this.BMPtoATIgo_button.Click += new System.EventHandler(this.PNGtoATIgo_button_Click);
            // 
            // PNGfile
            // 
            this.PNGfile.Location = new System.Drawing.Point(122, 39);
            this.PNGfile.Name = "PNGfile";
            this.PNGfile.Size = new System.Drawing.Size(607, 22);
            this.PNGfile.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "PNG image file:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 408);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ATIfile2_button;
        private System.Windows.Forms.Button ATIfile1_button;
        private System.Windows.Forms.Button ATItoBMPgo_button;
        private System.Windows.Forms.TextBox ATIfile1;
        private System.Windows.Forms.TextBox ATIfile2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BMPfile_button;
        private System.Windows.Forms.Button BMPtoATIgo_button;
        private System.Windows.Forms.TextBox PNGfile;
        private System.Windows.Forms.Label label3;
    }
}

