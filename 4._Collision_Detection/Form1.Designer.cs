namespace Pong1
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
            this.Ball = new System.Windows.Forms.PictureBox();
            this.Computer = new System.Windows.Forms.PictureBox();
            this.Player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Computer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.White;
            this.Ball.Image = global::Pong1.Properties.Resources.Ball;
            this.Ball.Location = new System.Drawing.Point(0, 0);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(25, 25);
            this.Ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Ball.TabIndex = 1;
            this.Ball.TabStop = false;
            // 
            // Computer
            // 
            this.Computer.BackColor = System.Drawing.Color.Fuchsia;
            this.Computer.Location = new System.Drawing.Point(749, 167);
            this.Computer.Name = "Computer";
            this.Computer.Size = new System.Drawing.Size(27, 127);
            this.Computer.TabIndex = 5;
            this.Computer.TabStop = false;
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Yellow;
            this.Player.Location = new System.Drawing.Point(10, 167);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(27, 127);
            this.Player.TabIndex = 4;
            this.Player.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.Computer);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.Ball);
            this.Name = "Form1";
            this.Text = "Simple Pong";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Computer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.PictureBox Computer;
        private System.Windows.Forms.PictureBox Player;
    }
}

