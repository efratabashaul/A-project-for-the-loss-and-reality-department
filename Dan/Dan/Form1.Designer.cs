
namespace Dan
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.lblD = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtDr = new System.Windows.Forms.TextBox();
            this.lblDr = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.lblC = new System.Windows.Forms.Label();
            this.btnD = new System.Windows.Forms.Button();
            this.btnDr = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(275, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "ברוכים הבאים";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.DarkBlue;
            this.button9.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(558, 183);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(131, 39);
            this.button9.TabIndex = 9;
            this.button9.Text = "מנהל";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblD.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblD.Location = new System.Drawing.Point(598, 242);
            this.lblD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(91, 20);
            this.lblD.TabIndex = 13;
            this.lblD.Text = ":הקש סיסמה";
            this.lblD.Visible = false;
            this.lblD.Click += new System.EventHandler(this.lblD_Click);
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(486, 242);
            this.txtD.Margin = new System.Windows.Forms.Padding(4);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(99, 22);
            this.txtD.TabIndex = 14;
            this.txtD.Visible = false;
            this.txtD.TextChanged += new System.EventHandler(this.txtD_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkBlue;
            this.button1.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(345, 183);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 39);
            this.button1.TabIndex = 15;
            this.button1.Text = "נהג";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkBlue;
            this.button2.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(134, 183);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 39);
            this.button2.TabIndex = 16;
            this.button2.Text = "לקוח";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtDr
            // 
            this.txtDr.Location = new System.Drawing.Point(270, 323);
            this.txtDr.Margin = new System.Windows.Forms.Padding(4);
            this.txtDr.Name = "txtDr";
            this.txtDr.Size = new System.Drawing.Size(99, 22);
            this.txtDr.TabIndex = 18;
            this.txtDr.Visible = false;
            this.txtDr.TextChanged += new System.EventHandler(this.txtDr_TextChanged);
            // 
            // lblDr
            // 
            this.lblDr.AutoSize = true;
            this.lblDr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDr.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDr.Location = new System.Drawing.Point(385, 323);
            this.lblDr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDr.Name = "lblDr";
            this.lblDr.Size = new System.Drawing.Size(91, 20);
            this.lblDr.TabIndex = 17;
            this.lblDr.Text = ":הקש סיסמה";
            this.lblDr.Visible = false;
            this.lblDr.Click += new System.EventHandler(this.lblDr_Click);
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(60, 321);
            this.txtC.Margin = new System.Windows.Forms.Padding(4);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(99, 22);
            this.txtC.TabIndex = 20;
            this.txtC.Visible = false;
            this.txtC.TextChanged += new System.EventHandler(this.txtC_TextChanged);
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblC.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblC.Location = new System.Drawing.Point(174, 322);
            this.lblC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(91, 20);
            this.lblC.TabIndex = 19;
            this.lblC.Text = ":הקש סיסמה";
            this.lblC.Visible = false;
            this.lblC.Click += new System.EventHandler(this.lblC_Click);
            // 
            // btnD
            // 
            this.btnD.BackColor = System.Drawing.Color.DarkBlue;
            this.btnD.Font = new System.Drawing.Font("Snap ITC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnD.ForeColor = System.Drawing.Color.White;
            this.btnD.Location = new System.Drawing.Point(486, 283);
            this.btnD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(61, 34);
            this.btnD.TabIndex = 21;
            this.btnD.Text = "OK";
            this.btnD.UseVisualStyleBackColor = false;
            this.btnD.Visible = false;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // btnDr
            // 
            this.btnDr.BackColor = System.Drawing.Color.DarkBlue;
            this.btnDr.Font = new System.Drawing.Font("Snap ITC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDr.ForeColor = System.Drawing.Color.White;
            this.btnDr.Location = new System.Drawing.Point(270, 362);
            this.btnDr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDr.Name = "btnDr";
            this.btnDr.Size = new System.Drawing.Size(61, 34);
            this.btnDr.TabIndex = 22;
            this.btnDr.Text = "OK";
            this.btnDr.UseVisualStyleBackColor = false;
            this.btnDr.Visible = false;
            this.btnDr.Click += new System.EventHandler(this.btnDr_Click);
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.Color.DarkBlue;
            this.btnC.Font = new System.Drawing.Font("Snap ITC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnC.ForeColor = System.Drawing.Color.White;
            this.btnC.Location = new System.Drawing.Point(60, 358);
            this.btnC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(61, 34);
            this.btnC.TabIndex = 23;
            this.btnC.Text = "OK";
            this.btnC.UseVisualStyleBackColor = false;
            this.btnC.Visible = false;
            this.btnC.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkBlue;
            this.button3.Font = new System.Drawing.Font("Snap ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(380, 233);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 32);
            this.button3.TabIndex = 25;
            this.button3.Text = "נהג חדש";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkBlue;
            this.button4.Font = new System.Drawing.Font("Snap ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(380, 272);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 32);
            this.button4.TabIndex = 26;
            this.button4.Text = "נהג קיים";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkBlue;
            this.button5.Font = new System.Drawing.Font("Snap ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(160, 235);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 32);
            this.button5.TabIndex = 27;
            this.button5.Text = "לקוח חדש";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkBlue;
            this.button6.Font = new System.Drawing.Font("Snap ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(169, 272);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 32);
            this.button6.TabIndex = 28;
            this.button6.Text = "לקוח קיים";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.DarkBlue;
            this.button7.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(406, 114);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(131, 39);
            this.button7.TabIndex = 29;
            this.button7.Text = " על דן";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.DarkBlue;
            this.button8.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(224, 114);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(131, 39);
            this.button8.TabIndex = 30;
            this.button8.Text = "צור קשר";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Dan.Properties.Resources.OIP__42_10;
            this.ClientSize = new System.Drawing.Size(727, 461);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnDr);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.txtDr);
            this.Controls.Add(this.lblDr);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDr;
        private System.Windows.Forms.Label lblDr;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnDr;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}

