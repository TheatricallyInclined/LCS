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
            InitializeComponent();
            generateComponents(numOfComponents);
        }

        private void goButton_Click(object sender, EventArgs e)
        {

        }
        
        private void transitionInputBox_TextChanged(object sender, EventArgs e)
        {
            if (!this.service.setTransitionTime(this.transitionInputBox.Text))
            {
                this.transitionTimeWarningLabel.Visible = true;
            }
            else
            {
                this.transitionTimeWarningLabel.Visible = false;
            
            }
        }

        private void addFixtureButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }


    }
}
