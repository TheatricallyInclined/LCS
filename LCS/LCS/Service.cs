using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LCS.Gui;
using System.Collections;

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
        private int numOfChannels = -1;

        /*
         * The maximum possible channels can have in this device
         */
        private const int MAX_CHANNELS = 50;

        private const int NUM_OF_COMPONENTS_IN_LINE = 12;

        /*
         * Starting address of this application
         */
        private int startAddress = -1;

        /*
         * Maxinum address can the device have
         */
        private const int MAX_ADDRESS = 512;

        /*
         * Fixture name
         */
        private String fixtureName = null;

        /*
         * Transition time between two scenes in ms
         */
        private int transitionTime;

        /*
         * A list that stores all fixtures
         */
        private ArrayList fixtureList;

        /*
         * Constructor class
         */
        public Service()
        {
            this.fixtureList = new ArrayList();
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
        public void startMain() {
            if(this.fixtureName == null || this.startAddress == -1 || this.numOfChannels == -1)
            {
                //if any input is not valid, return
                return;
            }
            //if all inputs are valid
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
            if (valid && channels > 0 && MAX_CHANNELS >= channels)
            {
                this.numOfChannels = channels;
                return true;
            }
            return false;
        }

        /*
         * Check if the input string is a valid start address
         * 
         * set the start address if the input is valid and return true, 
         * otherwise return false
         */
        public bool setAddress(String inputAddress)
        {
            int address;
            bool valid = int.TryParse(inputAddress, out address);
            // check if the input is valid
            if (valid && address > 0 && MAX_ADDRESS >= address)
            {
                this.startAddress = address;
                return true;
            }
            return false;
        }

        /*
        * Check if the input string is a valid name
        * 
        * set the fixture name if the input is valid and return true, 
        * otherwise return false
        */
        public bool setName(String name)
        {
            if(name != "")
            {
                this.fixtureName = name;
                return true;
            }
            return false;
        }

        /*
         * Check if the input string is a valid number
         * 
         * set the transition time if the input is valid and return true,
         * otherwise return false
         */
        public bool setTransitionTime(String time)
        {
            int transitionTime;
            bool valid = int.TryParse(time, out transitionTime);
            // check if the input is valid
            if (valid)
            {
                this.transitionTime = transitionTime;
                return true;
            }
            return false;
        }

        /*
         * Calculates the main form size by number of channels that user input
         */
        public System.Drawing.Size mainFormSize()
        {
            int componentsInLine = numOfChannels < NUM_OF_COMPONENTS_IN_LINE ? numOfChannels : NUM_OF_COMPONENTS_IN_LINE;
            //the height of one component is 194px, plus 20px padding
            //the width of one component is 56px + 20px padding between two components
            return new System.Drawing.Size(componentsInLine * (56 + 20) + 20 + 220, 510);
        }

        /*
         * Calculates scene panel width according to number of channels
         */
        public int scenePanelWidth()
        {
            int componentsInLine = numOfChannels < NUM_OF_COMPONENTS_IN_LINE ? numOfChannels : NUM_OF_COMPONENTS_IN_LINE;
            return componentsInLine * (56 + 20) + 20;
        }

        public void addData(string[,] data)
        {
            this.fixtureList.Add(data);
        }


        /*
         * getter method for maxChannels
         */
        public int getMaxChannels() => MAX_CHANNELS;

        public int getMaxAddress() => MAX_ADDRESS;

        public int nextFixtureId() => this.fixtureList.Count;

        public string getFxitureName() => fixtureName;

        public ArrayList getFixtureList() => this.fixtureList;

        public string getStartAddressAsString() => this.startAddress.ToString();
    }

}
