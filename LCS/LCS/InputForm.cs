using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            this.warningLabel.Visible = false;
        }

        /*
         * Onclick method for input form
         * hide warning message if clicked on anywhere of this form.
         */
        private void InputForm_Click(object sender, EventArgs e)
        {
            this.warningLabel.Visible = false;
        }

        /*
         * Onclick method for input button.
         * 
         * when the button is clicked, check if the input channel is valid
         * if input is valid, hide input form, display main form, if not, display warning msg
         */
        private void inputButton_Click(object sender, EventArgs e)
        {
            //check and set channels
            if (service.setChannels(this.input.Text))
            {
                service.startMain(this.input.Text);
            }
            else
            {
                this.warningLabel.Visible = true;
            }
        }
    }
}
