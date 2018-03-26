using System;
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
        /*
         * stores slider values and names
         * data[*][0] stores value and data[*][1] stores name
         */
        private string[,] data;

        /*
         * Components in main form
         */
        private Component[] coms;

        private Panel currentScenePanel;

        private Panel nextScenePanel;

        private Panel goPanel;

        private Panel namePanel;

        private Panel addressPanel;

        private TextBox transitionInputBox;

        private Label transitionTimeWarningLabel;

        private Button goButton;

        private Button switchSceneButton;

        private Label connectionWarningLabel;

        private const int PADDING = 20;

        private int scenePanelWidth;

        private int SCENE_PANEL_HEIGHT = 225;

        private const int OTHER_PANEL_WIDTH = 220;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SuspendLayout();
            // 
            // MainForm
            // 
            //this.ClientSize = new System.Drawing.Size(1000, 510);
            this.ClientSize = this.service.mainFormSize();
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            //this.BackgroundImage = global::LCS.Properties.Resources.theatre_background1;
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
            this.scenePanelWidth = this.service.scenePanelWidth();
            this.data = new string[numOfComponents * 2, 2];
            this.coms = new Component[numOfComponents * 2];
            //generate main form
            generateCurrentScenePanel();
            generateNextScenePanel();
            generateGoPanel();
            generateNamePanel();
            generateAddressPanel();
            generateAddFixtureButton();
            generateExitButton();
            int id = 0;
            //generate components in current and next panel
            for (int i = 0; i < numOfComponents; i++)
            {
                coms[id] = new Component(data, this.currentScenePanel.Controls, id++);
                coms[id] = new Component(data, this.nextScenePanel.Controls, id++);
            }
            new FixtureNameLabel(service, this.namePanel, service.getFxitureName(), service.nextFixtureId());
            addStartAddress(service.getStartAddressAsString(), service.nextFixtureId());
            //add data into fixture list
            this.service.addData(data);
        }

        private void generateCurrentScenePanel()
        {
            generateSceneTextPanel(new System.Drawing.Point(0, 0), "Current Scene");
            this.currentScenePanel = new System.Windows.Forms.Panel();
            this.currentScenePanel.SuspendLayout();
            //this.currentScenePanel.BackgroundImage = global::LCS.Properties.Resources.theatre_background1;
            //this.currentScenePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            this.currentScenePanel.Location = new System.Drawing.Point(0, 30);
            this.currentScenePanel.Name = "currentScenePanel";
            this.currentScenePanel.Size = new System.Drawing.Size(scenePanelWidth, SCENE_PANEL_HEIGHT);
            this.currentScenePanel.TabIndex = 0;
            this.currentScenePanel.ResumeLayout(false);
            this.Controls.Add(currentScenePanel);
        }

        private void generateNextScenePanel()
        {
            generateSceneTextPanel(new System.Drawing.Point(0, 255), "Next Scene");
            this.nextScenePanel = new System.Windows.Forms.Panel();
            this.nextScenePanel.SuspendLayout();

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
            this.nextScenePanel.Location = new System.Drawing.Point(0, 285);
            this.nextScenePanel.Name = "nextScenePanel";
            this.nextScenePanel.Size = new System.Drawing.Size(scenePanelWidth, SCENE_PANEL_HEIGHT);
            this.nextScenePanel.TabIndex = 0;

            this.nextScenePanel.ResumeLayout(false);
            this.Controls.Add(nextScenePanel);
        }

        private void generateGoPanel()
        {
            this.goPanel = new Panel();
            this.goPanel.SuspendLayout();
            goButton = new Button();
            switchSceneButton = new Button();
            Label transitionLabel = new Label();
            this.transitionInputBox = new TextBox();
            Label secLabel = new Label();
            this.transitionTimeWarningLabel = new Label();
            this.connectionWarningLabel = new Label();
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
            this.goPanel.Location = new System.Drawing.Point(scenePanelWidth, 0);
            this.goPanel.Name = "goPanel";
            this.goPanel.Size = new System.Drawing.Size(OTHER_PANEL_WIDTH, 210);
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
            this.goButton.BackColor = Color.LightGreen;
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
            switchSceneButton.Click += new System.EventHandler(this.switchButton_Click);
            // 
            // Transition time label
            // 
            transitionLabel.AutoSize = true;
            transitionLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            transitionLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            transitionLabel.Location = new System.Drawing.Point(110, 130);
            transitionLabel.Name = "transitionLabel";
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
            // Transition time warningLabel
            // 
            transitionTimeWarningLabel.AutoSize = true;
            transitionTimeWarningLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            transitionTimeWarningLabel.ForeColor = System.Drawing.Color.Red;
            transitionTimeWarningLabel.Location = new System.Drawing.Point(100, 170);
            transitionTimeWarningLabel.Name = "transitionTimeWarningLabel";
            transitionTimeWarningLabel.TabIndex = 1;
            transitionTimeWarningLabel.Text = "Invalid Transition Time";
            transitionTimeWarningLabel.Visible = false;
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
            // 
            // Connection warningLabel
            // 
            connectionWarningLabel.AutoSize = true;
            connectionWarningLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            connectionWarningLabel.ForeColor = System.Drawing.Color.Red;
            connectionWarningLabel.Location = new System.Drawing.Point(48, 10);
            connectionWarningLabel.Name = "connectionWarningLabel";
            connectionWarningLabel.TabIndex = 1;
            connectionWarningLabel.Text = "No DMX lights connected";

            connectionWarningLabel.Visible = false;

            this.goPanel.Controls.Add(goButton);
            this.goPanel.Controls.Add(switchSceneButton);
            this.goPanel.Controls.Add(transitionLabel);
            this.goPanel.Controls.Add(transitionInputBox);
            this.goPanel.Controls.Add(transitionTimeWarningLabel);
            this.goPanel.Controls.Add(secLabel);
            this.goPanel.Controls.Add(connectionWarningLabel);
            this.Controls.Add(goPanel);
            
        }

        private void generateNamePanel()
        {
            this.namePanel = new Panel();
            this.namePanel.SuspendLayout();
            Label fixtureName = new Label();
            // 
            // namePanel
            // 
            //horizontal scroll only
            this.namePanel.AutoScroll = true;

            this.namePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.namePanel.Location = new System.Drawing.Point(scenePanelWidth, 210);
            this.namePanel.Name = "namePanel";
            this.namePanel.Size = new System.Drawing.Size(110, 270);
            this.namePanel.TabIndex = 0;

            // 
            // fixture name label
            // 
            fixtureName.AutoSize = true;
            fixtureName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fixtureName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            fixtureName.Location = new System.Drawing.Point(13, 5);
            fixtureName.Name = "fixtureName";
            fixtureName.TabIndex = 1;
            fixtureName.Text = "Fixture Name";

            this.namePanel.Controls.Add(fixtureName);
            this.Controls.Add(namePanel);
        }

        private void generateAddressPanel()
        {
            this.addressPanel = new Panel();
            this.addressPanel.SuspendLayout();
            Label startAddressLabel = new Label(); 
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
            this.addressPanel.Location = new System.Drawing.Point(this.scenePanelWidth + 110, 210);
            this.addressPanel.Name = "startAddressLabel";
            this.addressPanel.Size = new System.Drawing.Size(110, 270);
            this.addressPanel.TabIndex = 0;

            // 
            // second label
            // 
            startAddressLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            startAddressLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            startAddressLabel.AutoSize = false;
            startAddressLabel.TextAlign = ContentAlignment.MiddleCenter;
            startAddressLabel.Dock = DockStyle.Fill;
            startAddressLabel.Name = "startAddress";
            startAddressLabel.TabIndex = 1;
            startAddressLabel.Text = "Start Address";

            this.addressPanel.Controls.Add(startAddressLabel);
            this.Controls.Add(addressPanel);
        }

        private void generateAddFixtureButton()
        {
            Button addFixture = new Button();
            // 
            // add fixture button
            // 
            addFixture.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            addFixture.Location = new System.Drawing.Point(scenePanelWidth, 480);
            addFixture.Name = "addFixtureButton";
            addFixture.Size = new System.Drawing.Size(110, 30);
            addFixture.TabIndex = 0;
            addFixture.Text = "Add Fixture";
            addFixture.UseVisualStyleBackColor = true;
            addFixture.Click += new System.EventHandler(this.addFixtureButton_Click);
            addFixture.Enabled = false;
            this.Controls.Add(addFixture);
        }

        private void generateExitButton()
        {
            Button exit = new Button();
            // 
            // add fixture button
            // 
            exit.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            exit.Location = new System.Drawing.Point(this.addressPanel.Location.X, 480);
            exit.Name = "exitButton";
            exit.Size = new System.Drawing.Size(110, 30);
            exit.TabIndex = 0;
            exit.Text = "Exit";
            exit.UseVisualStyleBackColor = true;
            exit.Click += new System.EventHandler(this.exitButton_Click);
            this.Controls.Add(exit);
        }

        private void generateSceneTextPanel(Point location, string text)
        {
            Panel SceneTextPanel = new Panel();
            Label SceneLabel = new Label();

            SceneTextPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SceneTextPanel.Location = location;
            SceneTextPanel.Name = "currentScenePanel";
            SceneTextPanel.Size = new System.Drawing.Size(scenePanelWidth, 30);
            SceneTextPanel.TabIndex = 0;
            // 
            // Current Scene Label
            // 
            SceneLabel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SceneLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            SceneLabel.Name = "currentSceneLabel";
            SceneLabel.TabIndex = 1;
            SceneLabel.Text = text;
            SceneLabel.AutoSize = false;
            SceneLabel.TextAlign = ContentAlignment.MiddleCenter;
            SceneLabel.Dock = DockStyle.Fill;
            SceneTextPanel.Controls.Add(SceneLabel);
            this.Controls.Add(SceneTextPanel);
        }

        private void addStartAddress(string address, int fixtureNameId)
        {
            Label startAddress = new Label();
            // 
            // display all fixtures
            // 
            //center text
            startAddress.AutoSize = false;
            startAddress.TextAlign = ContentAlignment.MiddleCenter;
            startAddress.Dock = DockStyle.Fill;
            startAddress.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            startAddress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            startAddress.Name = "startAddress";
            startAddress.TabIndex = 1;
            startAddress.Text = address;
            startAddress.BackColor = System.Drawing.SystemColors.ControlDark;
            startAddress.Location = new Point((this.addressPanel.Size.Width - startAddress.Size.Width) / 2, fixtureNameId * 25 + 25);
            this.addressPanel.Controls.Add(startAddress);
        }

        /*
         * Get fixture name panel
         */
        public Panel getNamePanel() => this.namePanel;

        /*
         * Get address panel
         */
        public Panel getAddressPanel() => this.addressPanel;

        public string[,] getData() => this.data;


        public Label getConnectionWarningLabel() => this.connectionWarningLabel;
        #endregion
    }
}
