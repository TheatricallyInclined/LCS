namespace LCS.Gui
{

   /*
    * Partial class of InputForm. The input window for this application
    * This partial class provides only the user interface for the InputForm
    * No logics should be handled in this class
    */
    partial class InputForm
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
        private void InitializeInputBox()
        {
            this.input = new System.Windows.Forms.TextBox();
            this.inputLabel = new System.Windows.Forms.Label();
            this.inputButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.input.BackColor = System.Drawing.Color.WhiteSmoke;
            this.input.Location = new System.Drawing.Point(145, 70);
            this.input.MaxLength = 3;
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(80, 22);
            this.input.TabIndex = 0;
            this.input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.AcceptButton = inputButton;
            // 
            // input button
            // 
            this.inputButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputButton.Location = new System.Drawing.Point(255, 69);
            this.inputButton.Name = "button1";
            this.inputButton.Size = new System.Drawing.Size(80, 28);
            this.inputButton.TabIndex = 0;
            this.inputButton.Text = "Enter";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inputLabel.Location = new System.Drawing.Point(20, 20);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(423, 30);
            this.inputLabel.TabIndex = 1;
            this.inputLabel.Text = "Please enter the number of channels you need: ";
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(90, 105);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(273, 30);
            this.warningLabel.TabIndex = 1;
            this.warningLabel.Text = "Please enter a valid number between 0 and " + service.getMaxChannels().ToString();
            this.warningLabel.Visible = false;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(475, 135);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.input);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.warningLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Click += new System.EventHandler(this.InputForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.Label warningLabel;
    }
}