namespace NQueensProblem
{
    partial class FormMain
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
            this.buttonBacktracking = new System.Windows.Forms.Button();
            this.buttonForwardChecking = new System.Windows.Forms.Button();
            this.textBoxGreenDelay = new System.Windows.Forms.TextBox();
            this.buttonPlusGreenDelay = new System.Windows.Forms.Button();
            this.buttonMinusGreenDelay = new System.Windows.Forms.Button();
            this.labelGreenDelayTime = new System.Windows.Forms.Label();
            this.labelRedDelayTime = new System.Windows.Forms.Label();
            this.buttonMinusRedDelay = new System.Windows.Forms.Button();
            this.buttonPlusRedDelay = new System.Windows.Forms.Button();
            this.textBoxRedDelay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGenerationsNumber = new System.Windows.Forms.TextBox();
            this.labelGenerationsTime = new System.Windows.Forms.Label();
            this.textBoxResultTime = new System.Windows.Forms.TextBox();
            this.labelFinished = new System.Windows.Forms.Label();
            this.buttonStartFullAnalization = new System.Windows.Forms.Button();
            this.textBoxEvents = new System.Windows.Forms.TextBox();
            this.buttonSquareBack = new System.Windows.Forms.Button();
            this.buttonSquareForward = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBacktracking
            // 
            this.buttonBacktracking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBacktracking.Location = new System.Drawing.Point(1324, 30);
            this.buttonBacktracking.Name = "buttonBacktracking";
            this.buttonBacktracking.Size = new System.Drawing.Size(128, 65);
            this.buttonBacktracking.TabIndex = 2;
            this.buttonBacktracking.Text = "Backtracking";
            this.buttonBacktracking.UseVisualStyleBackColor = true;
            this.buttonBacktracking.Click += new System.EventHandler(this.buttonBacktracking_Click);
            // 
            // buttonForwardChecking
            // 
            this.buttonForwardChecking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonForwardChecking.Location = new System.Drawing.Point(1472, 30);
            this.buttonForwardChecking.Name = "buttonForwardChecking";
            this.buttonForwardChecking.Size = new System.Drawing.Size(128, 65);
            this.buttonForwardChecking.TabIndex = 4;
            this.buttonForwardChecking.Text = "Forward checking";
            this.buttonForwardChecking.UseVisualStyleBackColor = true;
            this.buttonForwardChecking.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxGreenDelay
            // 
            this.textBoxGreenDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGreenDelay.Location = new System.Drawing.Point(1480, 166);
            this.textBoxGreenDelay.Name = "textBoxGreenDelay";
            this.textBoxGreenDelay.Size = new System.Drawing.Size(125, 22);
            this.textBoxGreenDelay.TabIndex = 5;
            this.textBoxGreenDelay.Text = "2000";
            // 
            // buttonPlusGreenDelay
            // 
            this.buttonPlusGreenDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlusGreenDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlusGreenDelay.Location = new System.Drawing.Point(1563, 194);
            this.buttonPlusGreenDelay.Name = "buttonPlusGreenDelay";
            this.buttonPlusGreenDelay.Size = new System.Drawing.Size(42, 28);
            this.buttonPlusGreenDelay.TabIndex = 6;
            this.buttonPlusGreenDelay.Text = "+";
            this.buttonPlusGreenDelay.UseVisualStyleBackColor = true;
            this.buttonPlusGreenDelay.Click += new System.EventHandler(this.buttonPlusDelay_Click);
            // 
            // buttonMinusGreenDelay
            // 
            this.buttonMinusGreenDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinusGreenDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinusGreenDelay.Location = new System.Drawing.Point(1480, 194);
            this.buttonMinusGreenDelay.Name = "buttonMinusGreenDelay";
            this.buttonMinusGreenDelay.Size = new System.Drawing.Size(42, 28);
            this.buttonMinusGreenDelay.TabIndex = 7;
            this.buttonMinusGreenDelay.Text = "-";
            this.buttonMinusGreenDelay.UseVisualStyleBackColor = true;
            this.buttonMinusGreenDelay.Click += new System.EventHandler(this.buttonMinusDelay_Click);
            // 
            // labelGreenDelayTime
            // 
            this.labelGreenDelayTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGreenDelayTime.AutoSize = true;
            this.labelGreenDelayTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGreenDelayTime.Location = new System.Drawing.Point(1472, 131);
            this.labelGreenDelayTime.Name = "labelGreenDelayTime";
            this.labelGreenDelayTime.Size = new System.Drawing.Size(141, 20);
            this.labelGreenDelayTime.TabIndex = 8;
            this.labelGreenDelayTime.Text = "Green delay time ";
            // 
            // labelRedDelayTime
            // 
            this.labelRedDelayTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRedDelayTime.AutoSize = true;
            this.labelRedDelayTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRedDelayTime.Location = new System.Drawing.Point(1327, 131);
            this.labelRedDelayTime.Name = "labelRedDelayTime";
            this.labelRedDelayTime.Size = new System.Drawing.Size(125, 20);
            this.labelRedDelayTime.TabIndex = 12;
            this.labelRedDelayTime.Text = "Red delay time ";
            // 
            // buttonMinusRedDelay
            // 
            this.buttonMinusRedDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinusRedDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinusRedDelay.Location = new System.Drawing.Point(1327, 194);
            this.buttonMinusRedDelay.Name = "buttonMinusRedDelay";
            this.buttonMinusRedDelay.Size = new System.Drawing.Size(42, 28);
            this.buttonMinusRedDelay.TabIndex = 11;
            this.buttonMinusRedDelay.Text = "-";
            this.buttonMinusRedDelay.UseVisualStyleBackColor = true;
            // 
            // buttonPlusRedDelay
            // 
            this.buttonPlusRedDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlusRedDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlusRedDelay.Location = new System.Drawing.Point(1410, 194);
            this.buttonPlusRedDelay.Name = "buttonPlusRedDelay";
            this.buttonPlusRedDelay.Size = new System.Drawing.Size(42, 28);
            this.buttonPlusRedDelay.TabIndex = 10;
            this.buttonPlusRedDelay.Text = "+";
            this.buttonPlusRedDelay.UseVisualStyleBackColor = true;
            // 
            // textBoxRedDelay
            // 
            this.textBoxRedDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRedDelay.Location = new System.Drawing.Point(1327, 166);
            this.textBoxRedDelay.Name = "textBoxRedDelay";
            this.textBoxRedDelay.Size = new System.Drawing.Size(125, 22);
            this.textBoxRedDelay.TabIndex = 9;
            this.textBoxRedDelay.Text = "1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1433, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Number of generations";
            // 
            // textBoxGenerationsNumber
            // 
            this.textBoxGenerationsNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGenerationsNumber.Location = new System.Drawing.Point(1460, 300);
            this.textBoxGenerationsNumber.Name = "textBoxGenerationsNumber";
            this.textBoxGenerationsNumber.Size = new System.Drawing.Size(125, 22);
            this.textBoxGenerationsNumber.TabIndex = 13;
            this.textBoxGenerationsNumber.Text = "100";
            // 
            // labelGenerationsTime
            // 
            this.labelGenerationsTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGenerationsTime.AutoSize = true;
            this.labelGenerationsTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGenerationsTime.Location = new System.Drawing.Point(1433, 371);
            this.labelGenerationsTime.Name = "labelGenerationsTime";
            this.labelGenerationsTime.Size = new System.Drawing.Size(177, 20);
            this.labelGenerationsTime.TabIndex = 16;
            this.labelGenerationsTime.Text = "Generations time (ms)";
            // 
            // textBoxResultTime
            // 
            this.textBoxResultTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResultTime.Location = new System.Drawing.Point(1449, 394);
            this.textBoxResultTime.Name = "textBoxResultTime";
            this.textBoxResultTime.Size = new System.Drawing.Size(147, 22);
            this.textBoxResultTime.TabIndex = 15;
            this.textBoxResultTime.Text = "Result time will be here";
            // 
            // labelFinished
            // 
            this.labelFinished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFinished.AutoSize = true;
            this.labelFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFinished.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelFinished.Location = new System.Drawing.Point(1445, 419);
            this.labelFinished.Name = "labelFinished";
            this.labelFinished.Size = new System.Drawing.Size(155, 39);
            this.labelFinished.TabIndex = 17;
            this.labelFinished.Text = "Finished";
            this.labelFinished.Visible = false;
            // 
            // buttonStartFullAnalization
            // 
            this.buttonStartFullAnalization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartFullAnalization.Location = new System.Drawing.Point(1324, 551);
            this.buttonStartFullAnalization.Name = "buttonStartFullAnalization";
            this.buttonStartFullAnalization.Size = new System.Drawing.Size(276, 61);
            this.buttonStartFullAnalization.TabIndex = 18;
            this.buttonStartFullAnalization.Text = "Start full analization";
            this.buttonStartFullAnalization.UseVisualStyleBackColor = true;
            this.buttonStartFullAnalization.Click += new System.EventHandler(this.buttonStartFullAnalization_Click);
            // 
            // textBoxEvents
            // 
            this.textBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEvents.Location = new System.Drawing.Point(989, 30);
            this.textBoxEvents.Multiline = true;
            this.textBoxEvents.Name = "textBoxEvents";
            this.textBoxEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEvents.Size = new System.Drawing.Size(320, 575);
            this.textBoxEvents.TabIndex = 19;
            // 
            // buttonSquareBack
            // 
            this.buttonSquareBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSquareBack.Location = new System.Drawing.Point(836, 30);
            this.buttonSquareBack.Name = "buttonSquareBack";
            this.buttonSquareBack.Size = new System.Drawing.Size(128, 65);
            this.buttonSquareBack.TabIndex = 20;
            this.buttonSquareBack.Text = "Square back";
            this.buttonSquareBack.UseVisualStyleBackColor = true;
            this.buttonSquareBack.Click += new System.EventHandler(this.buttonSquareBack_Click);
            // 
            // buttonSquareForward
            // 
            this.buttonSquareForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSquareForward.Location = new System.Drawing.Point(836, 131);
            this.buttonSquareForward.Name = "buttonSquareForward";
            this.buttonSquareForward.Size = new System.Drawing.Size(128, 65);
            this.buttonSquareForward.TabIndex = 21;
            this.buttonSquareForward.Text = "Square forward";
            this.buttonSquareForward.UseVisualStyleBackColor = true;
            this.buttonSquareForward.Click += new System.EventHandler(this.buttonSquareForward_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1630, 632);
            this.Controls.Add(this.buttonSquareForward);
            this.Controls.Add(this.buttonSquareBack);
            this.Controls.Add(this.textBoxEvents);
            this.Controls.Add(this.buttonStartFullAnalization);
            this.Controls.Add(this.labelFinished);
            this.Controls.Add(this.labelGenerationsTime);
            this.Controls.Add(this.textBoxResultTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxGenerationsNumber);
            this.Controls.Add(this.labelRedDelayTime);
            this.Controls.Add(this.buttonMinusRedDelay);
            this.Controls.Add(this.buttonPlusRedDelay);
            this.Controls.Add(this.textBoxRedDelay);
            this.Controls.Add(this.labelGreenDelayTime);
            this.Controls.Add(this.buttonMinusGreenDelay);
            this.Controls.Add(this.buttonPlusGreenDelay);
            this.Controls.Add(this.textBoxGreenDelay);
            this.Controls.Add(this.buttonForwardChecking);
            this.Controls.Add(this.buttonBacktracking);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonBacktracking;
        private System.Windows.Forms.Button buttonForwardChecking;
        private System.Windows.Forms.TextBox textBoxGreenDelay;
        private System.Windows.Forms.Button buttonPlusGreenDelay;
        private System.Windows.Forms.Button buttonMinusGreenDelay;
        private System.Windows.Forms.Label labelGreenDelayTime;
        private System.Windows.Forms.Label labelRedDelayTime;
        private System.Windows.Forms.Button buttonMinusRedDelay;
        private System.Windows.Forms.Button buttonPlusRedDelay;
        private System.Windows.Forms.TextBox textBoxRedDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGenerationsNumber;
        private System.Windows.Forms.Label labelGenerationsTime;
        private System.Windows.Forms.TextBox textBoxResultTime;
        private System.Windows.Forms.Label labelFinished;
        private System.Windows.Forms.Button buttonStartFullAnalization;
        private System.Windows.Forms.TextBox textBoxEvents;
        private System.Windows.Forms.Button buttonSquareBack;
        private System.Windows.Forms.Button buttonSquareForward;
    }
}

