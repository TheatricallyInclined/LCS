using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LCS.Lib;
using LCS.Logic;

namespace LCS.Gui
{
    /*
     * Partial class of InputForm
     * This partial class provides the constructor and evenhandlers for all components in this class
     */
    public partial class InputForm : Form
    {
        /*
         * Service class that handles all logics
         */
        private Service service;

        /*
         * Class constructor 
         * service: service class that handles most logic
         */
        public InputForm(Service service)
        {
            this.service = service;
            InitializeInputBox();
        }

        /*
         * Text box Evenhandler
         * hide warning message if text in the box changed.
         */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.nameWarningLabel.Visible = false;
        }

        /*
         * Text box Evenhandler
         * hide warning message if text in the box changed.
         */
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.addressWarningLabel.Visible = false;
        }

        /*
         * Text box Evenhandler
         * hide warning message if text in the box changed.
         */
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.channelWarningLabel.Visible = false;
        }

        /*
         * Onclick method for input form
         * hide warning message if clicked on anywhere of this form.
         */
        private void InputForm_Click(object sender, EventArgs e)
        {
            this.channelWarningLabel.Visible = false;
            this.nameWarningLabel.Visible = false;
            this.addressWarningLabel.Visible = false;
        }
        /*
         * index change handler method for drop down list in input form
         */
        private void dropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fixtureName.Text = dropDown.Text;
            this.channels.Text = ((string[])LightLibrary.lights[dropDown.Text]).Length.ToString();
        }

        /*
         * Onclick method for input button.
         * 
         * when the button is clicked, check if the input channel is valid
         * if input is valid, hide input form, display main form, if not, display warning msg
         */
        private void inputButton_Click(object sender, EventArgs e)
        {
            if (!service.setName(this.fixtureName.Text))
            {
                this.nameWarningLabel.Visible = true;
            }

            if (!service.setAddress(this.startAddress.Text))
            {
                this.addressWarningLabel.Visible = true;
            }

            if (!service.setChannels(this.channels.Text))
            {
                this.channelWarningLabel.Visible = true;
            }
            service.startMain(dropDown.Text);
        }
    }
}
