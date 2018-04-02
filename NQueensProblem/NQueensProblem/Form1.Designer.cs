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
            this.labelIsFound = new System.Windows.Forms.Label();
            this.buttonBacktracking = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonForwardChecking = new System.Windows.Forms.Button();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.buttonPlusDelay = new System.Windows.Forms.Button();
            this.buttonMinusDelay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIsFound
            // 
            this.labelIsFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIsFound.AutoSize = true;
            this.labelIsFound.Location = new System.Drawing.Point(951, 109);
            this.labelIsFound.Name = "labelIsFound";
            this.labelIsFound.Size = new System.Drawing.Size(134, 17);
            this.labelIsFound.TabIndex = 1;
            this.labelIsFound.Text = "TRUE OR FALSE ? ";
            // 
            // buttonBacktracking
            // 
            this.buttonBacktracking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBacktracking.Location = new System.Drawing.Point(960, 269);
            this.buttonBacktracking.Name = "buttonBacktracking";
            this.buttonBacktracking.Size = new System.Drawing.Size(128, 65);
            this.buttonBacktracking.TabIndex = 2;
            this.buttonBacktracking.Text = "Backtracking";
            this.buttonBacktracking.UseVisualStyleBackColor = true;
            this.buttonBacktracking.Click += new System.EventHandler(this.buttonBacktracking_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(960, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 65);
            this.button1.TabIndex = 3;
            this.button1.Text = "Found safe?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonForwardChecking
            // 
            this.buttonForwardChecking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonForwardChecking.Location = new System.Drawing.Point(960, 163);
            this.buttonForwardChecking.Name = "buttonForwardChecking";
            this.buttonForwardChecking.Size = new System.Drawing.Size(128, 65);
            this.buttonForwardChecking.TabIndex = 4;
            this.buttonForwardChecking.Text = "Forward checking";
            this.buttonForwardChecking.UseVisualStyleBackColor = true;
            this.buttonForwardChecking.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDelay.Location = new System.Drawing.Point(960, 477);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(125, 22);
            this.textBoxDelay.TabIndex = 5;
            this.textBoxDelay.Text = "1";
            // 
            // buttonPlusDelay
            // 
            this.buttonPlusDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlusDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlusDelay.Location = new System.Drawing.Point(1043, 505);
            this.buttonPlusDelay.Name = "buttonPlusDelay";
            this.buttonPlusDelay.Size = new System.Drawing.Size(42, 28);
            this.buttonPlusDelay.TabIndex = 6;
            this.buttonPlusDelay.Text = "+";
            this.buttonPlusDelay.UseVisualStyleBackColor = true;
            this.buttonPlusDelay.Click += new System.EventHandler(this.buttonPlusDelay_Click);
            // 
            // buttonMinusDelay
            // 
            this.buttonMinusDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinusDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinusDelay.Location = new System.Drawing.Point(960, 505);
            this.buttonMinusDelay.Name = "buttonMinusDelay";
            this.buttonMinusDelay.Size = new System.Drawing.Size(42, 28);
            this.buttonMinusDelay.TabIndex = 7;
            this.buttonMinusDelay.Text = "-";
            this.buttonMinusDelay.UseVisualStyleBackColor = true;
            this.buttonMinusDelay.Click += new System.EventHandler(this.buttonMinusDelay_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 674);
            this.Controls.Add(this.buttonMinusDelay);
            this.Controls.Add(this.buttonPlusDelay);
            this.Controls.Add(this.textBoxDelay);
            this.Controls.Add(this.buttonForwardChecking);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonBacktracking);
            this.Controls.Add(this.labelIsFound);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelIsFound;
        private System.Windows.Forms.Button buttonBacktracking;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonForwardChecking;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Button buttonPlusDelay;
        private System.Windows.Forms.Button buttonMinusDelay;
    }
}

