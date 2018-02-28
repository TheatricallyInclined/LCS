using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCS.Gui
{
    /*
     * Partial class of MainForm
     * This partial class provides the constructor and evenhandlers for all components in this class
     */
    public partial class MainForm : Form
    {
        LCS.Logic.Service service;

        public MainForm(LCS.Logic.Service service, int numOfComponents)
        {
            this.service = service;
            InitializeComponent(service.mainFormSize());
            generateComponents(numOfComponents);
        }

        private void goButton_Click(object sender, EventArgs e)
        {

        }
        
        private void transitionInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addFixtureButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        private void scroll_Click(object sender, EventArgs e)
        {
            this.currentSceneLabel.Location = new Point(200 + this.AutoScrollPosition.X, 20 + this.AutoScrollPosition.Y);
            //this.currentSceneLabel.BringToFront();
            this.currentScenePanel.Refresh();
        }

        
    }
}
