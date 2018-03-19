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

        /*
         * Go button onclick listener
         */
        private void goButton_Click(object sender, EventArgs e)
        {
            /*
             * If the transition time is empty, display the label and return without start the transition
             */
            if (service.getTransitionTime() == -1)
            {
                this.transitionTimeWarningLabel.Visible = true;
                return;
            }
            if (!service.isInTransition()){
                //if timed transition is on
                //change goButton text to STOP
                this.goButton.Text = "STOP";
                //change background color
                this.goButton.BackColor = Color.OrangeRed;
                //disable current, next scene panel, transition input box and switch scene panel
                currentScenePanel.Enabled = false;
                nextScenePanel.Enabled = false;
                transitionInputBox.Enabled = false;
                switchSceneButton.Enabled = false;
                service.setInTransition(true);
                //set current and next scene values
                service.setSceneValue(data);
                //stop the running thread
                service.timer.Stop();
                service.timer.Dispose();
                service.calculateTransition();
                //start timer thread
                service.timer = new System.Timers.Timer(service.getPhraseTime());
                service.timer.Elapsed += service.transitionControl;
                service.timer.Start();
            }
            else
            {
                //if timed transition is off
                //change text to STOP
                this.goButton.Text = "GO!";
                //change background color
                this.goButton.BackColor = Color.LightGreen;
                //enable current, next scene panel, transition input box and switch scene panel
                currentScenePanel.Enabled = true;
                nextScenePanel.Enabled = true;
                transitionInputBox.Enabled = true;
                switchSceneButton.Enabled = true;
                service.setInTransition(false);
                //stop the running timer
                service.timer.Stop();
                service.timer.Dispose();
                //start new timer
                service.timer = new System.Timers.Timer(200);
                service.timer.Elapsed += service.liveControl;
                service.timer.Start();
            }
        }

        /*
         * InputBox text change listener
         */
        private void transitionInputBox_TextChanged(object sender, EventArgs e)
        {
            /*
             * If it's in transition, don't allow user to make any modifications
             */
            if (service.isInTransition())
            {
                return;
            }
            if (!this.service.setTransitionTime(this.transitionInputBox.Text))
            {
                this.transitionTimeWarningLabel.Visible = true;
            }
            else
            {
                this.transitionTimeWarningLabel.Visible = false;
            
            }
        }

        /*
         * Switch button onclick listener
         */
        private void switchButton_Click(object sender, EventArgs e)
        {
            /*
             * If it's in transition, don't allow user to make any modifications
             */
            if (service.isInTransition())
            {
                return;
            }
            for (int i = 0; i < coms.Length; i+=2)
            {
                string tempData1 = data[i, 0];
                string tempData2 = data[i, 1];
                //set component values in current scene to next scene
                coms[i].setValue(Convert.ToInt32(data[i + 1, 0]), data[i + 1, 1]);
                //set component values in next scene to current scene
                coms[i + 1].setValue(Convert.ToInt32(tempData1), tempData2);
            }
        }

        /*
         * Add fixture button onclick listener
         */
        private void addFixtureButton_Click(object sender, EventArgs e)
        {

        }

        /*
         * exit button onclick listener
         */
        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }


    }
}
