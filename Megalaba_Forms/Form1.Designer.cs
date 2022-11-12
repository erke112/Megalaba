namespace Megalaba_Forms
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
            this.btnRock = new System.Windows.Forms.Button();
            this.btnPaper = new System.Windows.Forms.Button();
            this.btnScissors = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.Label();
            this.roundsText = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.Label();
            this.countDownTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picCPU = new System.Windows.Forms.PictureBox();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRock
            // 
            this.btnRock.Location = new System.Drawing.Point(64, 140);
            this.btnRock.Margin = new System.Windows.Forms.Padding(4);
            this.btnRock.Name = "btnRock";
            this.btnRock.Size = new System.Drawing.Size(100, 34);
            this.btnRock.TabIndex = 0;
            this.btnRock.Text = "Rock";
            this.btnRock.UseVisualStyleBackColor = true;
            this.btnRock.Click += new System.EventHandler(this.btnRock_Click);
            // 
            // btnPaper
            // 
            this.btnPaper.Location = new System.Drawing.Point(64, 224);
            this.btnPaper.Margin = new System.Windows.Forms.Padding(4);
            this.btnPaper.Name = "btnPaper";
            this.btnPaper.Size = new System.Drawing.Size(100, 34);
            this.btnPaper.TabIndex = 0;
            this.btnPaper.Text = "Paper";
            this.btnPaper.UseVisualStyleBackColor = true;
            this.btnPaper.Click += new System.EventHandler(this.btnPaper_Click);
            // 
            // btnScissors
            // 
            this.btnScissors.Location = new System.Drawing.Point(64, 305);
            this.btnScissors.Margin = new System.Windows.Forms.Padding(4);
            this.btnScissors.Name = "btnScissors";
            this.btnScissors.Size = new System.Drawing.Size(100, 34);
            this.btnScissors.TabIndex = 0;
            this.btnScissors.Text = "Scissors";
            this.btnScissors.UseVisualStyleBackColor = true;
            this.btnScissors.Click += new System.EventHandler(this.btnScissors_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.AutoSize = true;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMessage.Location = new System.Drawing.Point(516, 140);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(206, 26);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.Text = "Player: 0 - CPU: 0";
            this.txtMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundsText
            // 
            this.roundsText.AutoSize = true;
            this.roundsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.roundsText.Location = new System.Drawing.Point(564, 455);
            this.roundsText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roundsText.Name = "roundsText";
            this.roundsText.Size = new System.Drawing.Size(113, 26);
            this.roundsText.TabIndex = 2;
            this.roundsText.Text = "Rounds 3";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(920, 529);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 34);
            this.button4.TabIndex = 3;
            this.button4.Text = "Restart";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.restartGame);
            // 
            // txtTime
            // 
            this.txtTime.AutoSize = true;
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTime.Location = new System.Drawing.Point(600, 272);
            this.txtTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(66, 29);
            this.txtTime.TabIndex = 2;
            this.txtTime.Text = "time";
            // 
            // countDownTimer
            // 
            this.countDownTimer.Interval = 1000;
            this.countDownTimer.Tick += new System.EventHandler(this.countDownTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Player";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(895, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "CPU";
            // 
            // picCPU
            // 
            this.picCPU.Image = global::Megalaba_Forms.Properties.Resources.question;
            this.picCPU.Location = new System.Drawing.Point(799, 123);
            this.picCPU.Margin = new System.Windows.Forms.Padding(4);
            this.picCPU.Name = "picCPU";
            this.picCPU.Size = new System.Drawing.Size(221, 244);
            this.picCPU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCPU.TabIndex = 1;
            this.picCPU.TabStop = false;
            // 
            // picPlayer
            // 
            this.picPlayer.Image = global::Megalaba_Forms.Properties.Resources.qq;
            this.picPlayer.Location = new System.Drawing.Point(264, 123);
            this.picPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(221, 244);
            this.picPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayer.TabIndex = 1;
            this.picPlayer.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 588);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.roundsText);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.picCPU);
            this.Controls.Add(this.picPlayer);
            this.Controls.Add(this.btnScissors);
            this.Controls.Add(this.btnPaper);
            this.Controls.Add(this.btnRock);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Rock Paper Scissors ";
            ((System.ComponentModel.ISupportInitialize)(this.picCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRock;
        private System.Windows.Forms.Button btnPaper;
        private System.Windows.Forms.Button btnScissors;
        private System.Windows.Forms.PictureBox picPlayer;
        private System.Windows.Forms.PictureBox picCPU;
        private System.Windows.Forms.Label txtMessage;
        private System.Windows.Forms.Label roundsText;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label txtTime;
        private System.Windows.Forms.Timer countDownTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

