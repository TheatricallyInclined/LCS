using System.Drawing;
using System.Windows.Forms;


namespace LCS.Gui
{
   /*
    * Partial class of MainForm. The main GUI of this application.
    * This partial class provides only the user interface for the MainForm
    * No logics should be handled in this class
    */
    partial class MainForm
    {

        private Panel currentScenePanel;

        private Panel nextScenePanel;

        private Panel goPanel;

        private Panel namePanel;

        private Panel addressPanel;

        private const int PADDING = 20;

        private Label currentSceneLabel;

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
        private void InitializeComponent(System.Drawing.Size formSize)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 510);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.BackgroundImage = global::LCS.Properties.Resources.theatre_background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.AutoScroll = true;
            this.MaximizeBox = false;

        }
        /*
         * System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = formSize;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.BackgroundImage = global::LCS.Properties.Resources.theatre_background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.AutoScroll = true;
         */

        /*
         * Generate components for the main form
         */
        private void generateComponents(int numOfComponents)
        {
            generateCurrentScenePanel();
            generateNextScenePanel();
            generateGoPanel();
            generateNamePanel();
            generateAddressPanel();
            generateAddFixtureButton();
            generateExitButton();
            //this.coms = new Component[numOfComponents];
            for(int i = 0; i < numOfComponents; i++)
            {
                new Component(this.currentScenePanel.Controls, i);
                new Component(this.nextScenePanel.Controls, i);
            }
        }

        private void generateCurrentScenePanel()
        {
            this.currentScenePanel = new System.Windows.Forms.Panel();
            this.currentScenePanel.SuspendLayout();
            this.currentSceneLabel = new Label();

            // 
            // current scene panel
            // 
            //horizontal scroll only
            this.currentScenePanel.AutoScroll = false;
            this.currentScenePanel.VerticalScroll.Enabled = false;
            this.currentScenePanel.VerticalScroll.Visible = false;
            this.currentScenePanel.VerticalScroll.Maximum = 0;
            this.currentScenePanel.AutoScroll = true;

            this.currentScenePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentScenePanel.Location = new System.Drawing.Point(0, 0);
            this.currentScenePanel.Name = "currentScenePanel";
            this.currentScenePanel.Size = new System.Drawing.Size(780, 255);
            this.currentScenePanel.TabIndex = 0;
            this.currentScenePanel.Click += new System.EventHandler(this.scroll_Click);
            // 
            // Current Scene Label
            // 
            currentSceneLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            currentSceneLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            currentSceneLabel.Location = new System.Drawing.Point(200, 20);
            currentSceneLabel.Name = "currentSceneLabel";
            currentSceneLabel.Size = new System.Drawing.Size(200, 30);
            currentSceneLabel.TabIndex = 1;
            currentSceneLabel.Text = "Current Scene";
            this.currentScenePanel.ResumeLayout(false);
            this.currentScenePanel.Controls.Add(currentSceneLabel);
            this.Controls.Add(currentScenePanel);
        }

        private void generateNextScenePanel()
        {
            this.nextScenePanel = new System.Windows.Forms.Panel();
            this.nextScenePanel.SuspendLayout();
            Label nextSceneLabel = new Label();

            // 
            // current scene panel
            // 
            //horizontal scroll only
            this.nextScenePanel.AutoScroll = false;
            this.nextScenePanel.VerticalScroll.Enabled = false;
            this.nextScenePanel.VerticalScroll.Visible = false;
            this.nextScenePanel.VerticalScroll.Maximum = 0;
            this.nextScenePanel.AutoScroll = true;

            this.nextScenePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextScenePanel.Location = new System.Drawing.Point(0, 255);
            this.nextScenePanel.Name = "nextScenePanel";
            this.nextScenePanel.Size = new System.Drawing.Size(780, 255);
            this.nextScenePanel.TabIndex = 0;
            // 
            // Next Scene Label
            // 
            nextSceneLabel.AutoSize = true;
            nextSceneLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nextSceneLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            nextSceneLabel.Location = new System.Drawing.Point(200, 20);
            nextSceneLabel.Name = "nextSceneLabel";
            nextSceneLabel.Size = new System.Drawing.Size(200, 30);
            nextSceneLabel.TabIndex = 1;
            nextSceneLabel.Text = "Next Scene";

            this.nextScenePanel.ResumeLayout(false);
            this.nextScenePanel.Controls.Add(nextSceneLabel);
            this.Controls.Add(nextScenePanel);
        }

        private void generateGoPanel()
        {
            this.goPanel = new Panel();
            this.goPanel.SuspendLayout();
            Button goButton = new Button();
            Button switchSceneButton = new Button();
            Label transitionLabel = new Label();
            TextBox transitionInputBox = new TextBox();
            Label secLabel = new Label();
            
            // 
            // go panel
            // 
            //horizontal scroll only
            this.goPanel.AutoScroll = false;
            this.goPanel.VerticalScroll.Enabled = false;
            this.goPanel.VerticalScroll.Visible = false;
            this.goPanel.VerticalScroll.Maximum = 0;
            this.goPanel.AutoScroll = true;

            this.goPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.goPanel.Location = new System.Drawing.Point(780, 0);
            this.goPanel.Name = "goPanel";
            this.goPanel.Size = new System.Drawing.Size(220, 210);
            this.goPanel.TabIndex = 0;
            // 
            // Go button
            // 
            goButton.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            goButton.Location = new System.Drawing.Point(PADDING, PADDING + 10);
            goButton.Name = "goButton";
            goButton.Size = new System.Drawing.Size(180, 80);
            goButton.TabIndex = 0;
            goButton.Text = "GO!";
            goButton.UseVisualStyleBackColor = true;
            goButton.Click += new System.EventHandler(this.goButton_Click);
            this.AcceptButton = goButton;
            // 
            // switch scene button
            // 
            switchSceneButton.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            switchSceneButton.Location = new System.Drawing.Point(PADDING, 130);
            switchSceneButton.Name = "switchSceneButton";
            switchSceneButton.Size = new System.Drawing.Size(80, 50);
            switchSceneButton.TabIndex = 0;
            switchSceneButton.Text = "Switch Scene";
            switchSceneButton.UseVisualStyleBackColor = true;
            switchSceneButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // Transition time label
            // 
            transitionLabel.AutoSize = true;
            transitionLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            transitionLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            transitionLabel.Location = new System.Drawing.Point(110, 130);
            transitionLabel.Name = "nextSceneLabel";
            transitionLabel.Size = new System.Drawing.Size(200, 30);
            transitionLabel.TabIndex = 1;
            transitionLabel.Text = "Transition Time: ";
            // 
            // Transition time inputBox
            // 
            transitionInputBox.BackColor = System.Drawing.Color.WhiteSmoke;
            transitionInputBox.Location = new System.Drawing.Point(115, 150);
            transitionInputBox.Name = "transitionInputBox";
            transitionInputBox.Size = new System.Drawing.Size(60, 22);
            transitionInputBox.TabIndex = 0;
            transitionInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            transitionInputBox.TextChanged += new System.EventHandler(this.transitionInputBox_TextChanged);
            // 
            // second label
            // 
            secLabel.AutoSize = true;
            secLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            secLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            secLabel.Location = new System.Drawing.Point(175, 153);
            secLabel.Name = "secLabel";
            secLabel.Size = new System.Drawing.Size(20, 22);
            secLabel.TabIndex = 1;
            secLabel.Text = "ms";

            this.goPanel.Controls.Add(goButton);
            this.goPanel.Controls.Add(switchSceneButton);
            this.goPanel.Controls.Add(transitionLabel);
            this.goPanel.Controls.Add(transitionInputBox);
            this.goPanel.Controls.Add(secLabel);
            this.Controls.Add(goPanel);
            
        }

        private void generateNamePanel()
        {
            this.namePanel = new Panel();
            this.namePanel.SuspendLayout();
            // 
            // namePanel
            // 
            //horizontal scroll only
            this.namePanel.AutoScroll = false;
            this.namePanel.VerticalScroll.Enabled = false;
            this.namePanel.VerticalScroll.Visible = false;
            this.namePanel.VerticalScroll.Maximum = 0;
            this.namePanel.AutoScroll = true;

            this.namePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.namePanel.Location = new System.Drawing.Point(780, 210);
            this.namePanel.Name = "nextScenePanel";
            this.namePanel.Size = new System.Drawing.Size(110, 270);
            this.namePanel.TabIndex = 0;

            this.Controls.Add(namePanel);
        }

        private void generateAddressPanel()
        {
            this.addressPanel = new Panel();
            this.addressPanel.SuspendLayout();
            // 
            // namePanel
            // 
            //horizontal scroll only
            this.addressPanel.AutoScroll = false;
            this.addressPanel.VerticalScroll.Enabled = false;
            this.addressPanel.VerticalScroll.Visible = false;
            this.addressPanel.VerticalScroll.Maximum = 0;
            this.addressPanel.AutoScroll = true;

            this.addressPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressPanel.Location = new System.Drawing.Point(890, 210);
            this.addressPanel.Name = "nextScenePanel";
            this.addressPanel.Size = new System.Drawing.Size(110, 270);
            this.addressPanel.TabIndex = 0;

            this.Controls.Add(addressPanel);
        }

        private void generateAddFixtureButton()
        {
            Button addFixture = new Button();
            // 
            // add fixture button
            // 
            addFixture.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            addFixture.Location = new System.Drawing.Point(780, 480);
            addFixture.Name = "addFixtureButton";
            addFixture.Size = new System.Drawing.Size(110, 30);
            addFixture.TabIndex = 0;
            addFixture.Text = "Add Fixture";
            addFixture.UseVisualStyleBackColor = true;
            addFixture.Click += new System.EventHandler(this.addFixtureButton_Click);
            this.Controls.Add(addFixture);
        }

        private void generateExitButton()
        {
            Button exit = new Button();
            // 
            // add fixture button
            // 
            exit.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            exit.Location = new System.Drawing.Point(890, 480);
            exit.Name = "exitButton";
            exit.Size = new System.Drawing.Size(110, 30);
            exit.TabIndex = 0;
            exit.Text = "Exit";
            exit.UseVisualStyleBackColor = true;
            exit.Click += new System.EventHandler(this.exitButton_Click);
            this.Controls.Add(exit);
        }

        #endregion
    }
}
