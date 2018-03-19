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
        private int transitionTime = -1;

        /*
         * Time for each phrases of transition
         * Calculate by transitionTimer/TRANSITION_PHRASE
         */
        private int phraseTime;

        /*
         * A list that stores all fixtures
         */
        private List<string[,]> fixtureList;

        /*
         * An int array that stores the current scene value
         */
        private int[] currentSceneValue;

        /*
         * An int array that stores the next scene value
         */
        private int[] nextSceneValue;

        /*
         * Total number of phrases during one transition
         */
        private const int TRANSITION_PHRASE = 4;

        /*
         * An list that stores data for all phrases used in transition
         */
        private List<int[]> transitionData;

        /*
         * Timer object used both for live control mode and transition mode
         */
        public System.Timers.Timer timer;

        /*
         * Keeps track of current phrase during the transition
         */
        private int currentPhrase;

        /*
         * True if the app is in time transition mode
         */
        private bool inTransition = false;
        

        /*
         * Constructor class
         */
        public Service()
        {
            this.fixtureList = new List<string[,]>();
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
         * Hide the input form, open the main form and initialize values for main form
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
            this.transitionData = new List<int[]>(TRANSITION_PHRASE);
            this.currentSceneValue = new int[numOfChannels];
            this.nextSceneValue = new int[numOfChannels];
            this.control();
        }

        /*
         * This method controls the light by periodically invoking a method with a timer
         */
        private void control()
        {
            //start a new timer
            timer = new System.Timers.Timer(100);
            timer.Elapsed += liveControl;
            timer.Start();
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
         * this method sets both currentSceneValue and nextSceneValue arrays using the values in data array
         * will only be called when needed
         */
        public void setSceneValue(string[,] data)
        {
            for(int i = 0; i < currentSceneValue.Length; i++)
            {
                //convert the current scene value in data to int and store in currentSceneValue
                //i >> 1 calculates the exact index of current scene value in data array
                currentSceneValue[i] = Convert.ToInt32(data[i << 1, 0]);
                //convert the next scene value in data to int and store in currentSceneValue
                //(i >> 1)+1 calculates the exact index of next scene value in data array
                nextSceneValue[i] = Convert.ToInt32(data[(i << 1) + 1, 0]);
            }
        }

        /*
         * This method will control the light lively with current scene values
         */
        public void liveControl(object sender, EventArgs e)
        {
            //update data
            this.setSceneValue(this.mainForm.getData());
            //TODO control the light by passing currentSceneValue array like example below
            //someMethod(currentSceneValue)
            Console.WriteLine(System.DateTime.Now);
            Console.WriteLine(currentSceneValue[0] + "---" + currentSceneValue[1]
                + "---" + currentSceneValue[2] + "---" + currentSceneValue[3] + "---" + currentSceneValue[4]);
        }

        public void transitionControl(object sender, EventArgs e)
        {
            //invoke method and pass in data to control light
            /*  invoke the light controller method like this:
                    someMethod(transitionData[currentPhrase]);
                whereas currentPhrase is the current phrase of the transition and 
                transitionData is a list contains int array int[] of all values
            */
            Console.WriteLine(currentPhrase+"---"+transitionData[currentPhrase][0] + "---" + transitionData[currentPhrase][1]
                + "---" + transitionData[currentPhrase][2] + "---" + transitionData[currentPhrase][3] + "---" + transitionData[currentPhrase][4]);
            //update current transition phrase
            this.nextPhrase();

            Console.WriteLine(System.DateTime.Now);
        }

        /*
         * Update current phrase of the transition to next phrase
         */
        public void nextPhrase()
        {
            currentPhrase++;
            if(currentPhrase >= TRANSITION_PHRASE)
            {
                currentPhrase = 0;
            }
        }

        /*
         * calculates and updates the data that uses for transition mode
         */
        public void calculateTransition()
        {
            //calculate phraseTime
            this.phraseTime = transitionTime / TRANSITION_PHRASE;
            //reset current phrase
            this.currentPhrase = 0;
            //phrases during one transition
            for(int i = 0; i < TRANSITION_PHRASE; i++)
            {
                int[] phrase = new int[numOfChannels];
                transitionData.Add(phrase);
            }
            for (int i = 0; i < numOfChannels; i++)
            {
                int currValue = currentSceneValue[i];
                int nextValue = nextSceneValue[i];
                int change = (int)Math.Round((nextValue - currValue) / (double)(TRANSITION_PHRASE-1), 0);
                //calculate and store all data for all phrases in transitionData
                for (int j = 0; j < TRANSITION_PHRASE; j++)
                {
                    if(j == TRANSITION_PHRASE - 1)
                    {
                        transitionData[j][i] = nextValue;
                        break;
                    }
                    transitionData[j][i] = currValue + (change * j);
                }
            }
        }

        public void setInTransition(bool inTransition)
        {
            this.inTransition = inTransition;
        }

        /*
         * Bunch of getter method for private fields in this class
         */
        public int getMaxChannels() => MAX_CHANNELS;

        public int getMaxAddress() => MAX_ADDRESS;

        public int nextFixtureId() => this.fixtureList.Count;

        public string getFxitureName() => fixtureName;

        public List<string[,]> getFixtureList() => this.fixtureList;

        public string getStartAddressAsString() => this.startAddress.ToString();

        public int[] getCurrentSceneValue() => this.currentSceneValue;

        public int[] getNextSceneValue() => this.nextSceneValue;

        public int getTransitionTime() => this.transitionTime;

        public int getPhraseTime() => this.phraseTime;

        public bool isInTransition() => this.inTransition;
    }

}
