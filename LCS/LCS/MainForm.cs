using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

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
            if ("GO!".Equals(this.goButton.Text)){
                //if timed transition is on
                //start timer thread
                //TODO this will cause exception due to cross thread manipulation of sliders
                /*System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 1000;
                timer.Elapsed += switchButton_Click;
                timer.Start();*/
                //change goButton text to STOP
                this.goButton.Text = "STOP";
                //change background color
                this.goButton.BackColor = Color.OrangeRed;
                foreach (Component c in coms)
                {
                    c.componentSwitch(false);
                }
            }
            else
            {
                //if timed transition is off
                //stop the running thread

                //change text to STOP
                this.goButton.Text = "GO!";
                //change background color
                this.goButton.BackColor = Color.LightGreen;
                foreach (Component c in coms)
                {
                    c.componentSwitch(true);
                }
            }
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

        private void switchButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < coms.Length; i+=2)
            {
                string tempData1 = data[i, 0];
                string tempData2 = data[i, 1];
                //set component values in current scene to next scene
                coms[i].setValue(Convert.ToInt32(data[i + 1, 0]), data[i + 1, 1]);
                //set component values in next scene to current scene
                coms[i + 1].setValue(Convert.ToInt32(tempData1), tempData2);
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
