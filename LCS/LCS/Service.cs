using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LCS.Gui;

namespace LCS.Logic
{
    /*
     * Service class.
     * This class provides all logics that is needed in this application
     * 
     */
    public class Service
    {
        /*
         * The input form that is used in this app
         */
        private InputForm inputForm;

        /*
         * The main GUI of this application
         */
        private MainForm mainForm;

        /*
         * The total numbers of channels
         */
        private int numOfChannels;

        /*
         * The maximum possible channels can have in this app
         */
        private const int MAXCHANNELS = 100;

        private const int NUMOFCOMPONENTINONELINE = 15;

        /*
         * Constructor class
         */
        public Service()
        {
            startApp();
        }

        /*
         * Start the application 
         */
        private void startApp()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            inputForm = new InputForm(this);
            Application.Run(inputForm);
        }

        /*
         * Hide the input form and open the main form
         */
        public void startMain(String input) {
            inputForm.Hide();
            mainForm = new Gui.MainForm(this, numOfChannels);
            //when closing the main form, closes the input form
            mainForm.Closed += (s, args) => inputForm.Close();
            mainForm.Show();
        }

        /*
         * Check if the input string is a valid numeric value within 
         * the range of 0 and max channels
         * 
         * set the numOfChannels if the input is valid and return true, 
         * otherwise return false
         */
        public bool setChannels(String inputChannels)
        {
            int channels;
            bool valid = int.TryParse(inputChannels, out channels);
            // check if the input is valid
            if (valid && channels > 0 && MAXCHANNELS >= channels)
            {
                this.numOfChannels = channels;
                return true;
            }
            return false;
        }

        /*
         * Check if the input string is a valid numeric value within 
         * the range of 0 and max channels
         * 
         * set the numOfChannels if the input is valid and return true, 
         * otherwise return false
         */
        public bool checkChannels(String inputChannels)
        {
            int channels;
            bool valid = int.TryParse(inputChannels, out channels);
            // check if the input is valid
            if (valid && channels > 0 && MAXCHANNELS > channels)
            {
                numOfChannels = channels;
                return true;
            }
            return false;
        }

        public System.Drawing.Size mainFormSize()
        {
            int componentNumVertical = (numOfChannels / NUMOFCOMPONENTINONELINE)+1;
            //if number of components is multiple of 15, minus the vertical line by 1
            if(numOfChannels % NUMOFCOMPONENTINONELINE == 0)
            {
                componentNumVertical--;
            }
            int componentNumHorizon = componentNumVertical > 0 ? NUMOFCOMPONENTINONELINE : numOfChannels % NUMOFCOMPONENTINONELINE;
            //the height of one component is 194px, plus 20px padding
            //the width of one component is 56px + 20px padding between two components
            return new System.Drawing.Size((componentNumHorizon * (20+56)) + 15, componentNumVertical * (194) + 20);
        }

        /*
         * getter method for maxChannels
         */
        public int getMaxChannels() => MAXCHANNELS;

    }

}
