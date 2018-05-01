using System.Collections;
using System.Windows.Forms;
using LCS.Lib;

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
            this.fixtureName = new System.Windows.Forms.TextBox();
            this.startAddress = new System.Windows.Forms.TextBox();
            this.channels = new System.Windows.Forms.TextBox();
            this.inputLabel1 = new System.Windows.Forms.Label();
            this.inputLabel2 = new System.Windows.Forms.Label();
            this.inputLabel3 = new System.Windows.Forms.Label();
            this.inputLabel4 = new System.Windows.Forms.Label();
            this.inputButton = new System.Windows.Forms.Button();
            this.channelWarningLabel = new System.Windows.Forms.Label();
            this.nameWarningLabel = new System.Windows.Forms.Label();
            this.addressWarningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fixture name inputBox
            // 
            this.fixtureName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fixtureName.Location = new System.Drawing.Point(264, 65);
            this.fixtureName.Name = "fixtureName";
            this.fixtureName.Size = new System.Drawing.Size(80, 22);
            this.fixtureName.TabIndex = 0;
            this.fixtureName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fixtureName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // startAddress inputBox
            // 
            this.startAddress.BackColor = System.Drawing.Color.WhiteSmoke;
            this.startAddress.Location = new System.Drawing.Point(270, 115);
            this.startAddress.MaxLength = 3;
            this.startAddress.Name = "fixtureName";
            this.startAddress.Size = new System.Drawing.Size(80, 22);
            this.startAddress.TabIndex = 0;
            this.startAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startAddress.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // channels inputBox
            // 
            this.channels.BackColor = System.Drawing.Color.WhiteSmoke;
            this.channels.Location = new System.Drawing.Point(300, 165);
            this.channels.MaxLength = 3;
            this.channels.Name = "fixtureName";
            this.channels.Size = new System.Drawing.Size(80, 22);
            this.channels.TabIndex = 0;
            this.channels.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.channels.TextChanged += new System.EventHandler(this.textBox3_TextChanged);

            // 
            // input button
            // 
            this.inputButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputButton.Location = new System.Drawing.Point(180, 215);
            this.inputButton.Name = "button1";
            this.inputButton.Size = new System.Drawing.Size(100, 35);
            this.inputButton.TabIndex = 0;
            this.inputButton.Text = "Enter";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            this.AcceptButton = inputButton;
            // 
            // inputLabel1
            // 
            this.inputLabel1.AutoSize = true;
            this.inputLabel1.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inputLabel1.Location = new System.Drawing.Point(107, 65);
            this.inputLabel1.Name = "inputLabel1";
            this.inputLabel1.Size = new System.Drawing.Size(200, 30);
            this.inputLabel1.TabIndex = 1;
            this.inputLabel1.Text = "Fixture name: ";

            // 
            // inputLabel2
            // 
            this.inputLabel2.AutoSize = true;
            this.inputLabel2.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inputLabel2.Location = new System.Drawing.Point(100, 115);
            this.inputLabel2.Name = "inputLabel2";
            this.inputLabel2.Size = new System.Drawing.Size(200, 30);
            this.inputLabel2.TabIndex = 1;
            this.inputLabel2.Text = "Start address: ";

            // 
            // inputLabel3
            // 
            this.inputLabel3.AutoSize = true;
            this.inputLabel3.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inputLabel3.Location = new System.Drawing.Point(80, 165);
            this.inputLabel3.Name = "inputLabel3";
            this.inputLabel3.Size = new System.Drawing.Size(200, 30);
            this.inputLabel3.TabIndex = 1;
            this.inputLabel3.Text = "Number of channels: ";

            // 
            // channel warningLabel
            // 
            this.channelWarningLabel.AutoSize = true;
            this.channelWarningLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.channelWarningLabel.Location = new System.Drawing.Point(88, 195);
            this.channelWarningLabel.Name = "channelWarningLabel";
            this.channelWarningLabel.Size = new System.Drawing.Size(273, 30);
            this.channelWarningLabel.TabIndex = 1;
            this.channelWarningLabel.Text = "Please enter a valid number between 1 and " + service.getMaxChannels().ToString();
            this.channelWarningLabel.Visible = false;
            // 
            // name warningLabel
            // 
            this.nameWarningLabel.AutoSize = true;
            this.nameWarningLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.nameWarningLabel.Location = new System.Drawing.Point(125, 95);
            this.nameWarningLabel.Name = "nameWarningLabel";
            this.nameWarningLabel.Size = new System.Drawing.Size(273, 30);
            this.nameWarningLabel.TabIndex = 1;
            this.nameWarningLabel.Text = "Please enter a valid fixture name";
            this.nameWarningLabel.Visible = false;
            // 
            // address warningLabel
            // 
            this.addressWarningLabel.AutoSize = true;
            this.addressWarningLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.addressWarningLabel.Location = new System.Drawing.Point(88, 145);
            this.addressWarningLabel.Name = "addressWarningLabel";
            this.addressWarningLabel.Size = new System.Drawing.Size(273, 30);
            this.addressWarningLabel.TabIndex = 1;
            this.addressWarningLabel.Text = "Please enter a valid address between 1 and " + service.getMaxAddress().ToString();
            this.addressWarningLabel.Visible = false;
            // 
            // Light Model label
            // 
            this.inputLabel4.AutoSize = true;
            this.inputLabel4.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputLabel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inputLabel4.Location = new System.Drawing.Point(107, 15);
            this.inputLabel4.Name = "inputLabel4";
            this.inputLabel4.Size = new System.Drawing.Size(100, 22);
            this.inputLabel4.TabIndex = 1;
            this.inputLabel4.Text = "Light Model:";
            //
            //drop down list
            //
            this.dropDown = new System.Windows.Forms.ComboBox();
            ICollection coll = LightLibrary.lights.Keys;
            string[] lightModels = new string[coll.Count];
            coll.CopyTo(lightModels, 0);
            dropDown.Items.AddRange(lightModels);
            this.dropDown.Location = new System.Drawing.Point(264, 15);
            this.dropDown.IntegralHeight = false;
            this.dropDown.MaxDropDownItems = 5;
            this.dropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dropDown.Name = "ComboBox1";
            this.dropDown.Size = new System.Drawing.Size(210, 50);
            this.dropDown.TabIndex = 0;
            this.dropDown.SelectedIndexChanged += new System.EventHandler(dropDown_SelectedIndexChanged);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(475, 265);
            this.Controls.Add(this.inputLabel1);
            this.Controls.Add(this.inputLabel2);
            this.Controls.Add(this.inputLabel3);
            this.Controls.Add(this.inputLabel4);
            this.Controls.Add(this.dropDown);
            this.Controls.Add(this.fixtureName);
            this.Controls.Add(this.startAddress);
            this.Controls.Add(this.channels);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.channelWarningLabel);
            this.Controls.Add(this.nameWarningLabel);
            this.Controls.Add(this.addressWarningLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputForm";
            this.Click += new System.EventHandler(this.InputForm_Click);
            this.ResumeLayout(false);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fixtureName;
        private System.Windows.Forms.TextBox startAddress;
        private System.Windows.Forms.TextBox channels;
        private System.Windows.Forms.Label inputLabel1;
        private System.Windows.Forms.Label inputLabel2;
        private System.Windows.Forms.Label inputLabel3;
        private System.Windows.Forms.Label inputLabel4;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.Label channelWarningLabel;
        private System.Windows.Forms.Label nameWarningLabel;
        private System.Windows.Forms.Label addressWarningLabel;
        private System.Windows.Forms.ComboBox dropDown;
    }
}
