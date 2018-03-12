using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**
    Each component will consist a trackbar and a corresponding numericUpDown
*/
namespace LCS.Gui
{
    class Component : Panel
    {
        /*
         * data array that stores all slider value
         * 
         */
        private string[,] data;

        private System.Windows.Forms.TrackBar trackBar;

        private System.Windows.Forms.NumericUpDown numericUpDown;

        private TextBox name;

        private Control.ControlCollection control;

        private Point trackBarPoint;

        private Point numericUpDownPoint;

        private Point namePoint;

        private int id;

        private const int PADDING = 20;

        private const int TRACKBARHEIGHT = 125;

        private const int TRACKBARWIDTH = 56;

        private const int NUMERICUPDOWNHEIGHT = 22;

        private const int NUMERICUPDOWNWIDTH = 45;

        private const int NAMEWIDTH = 45;

        private const int TICKPADDING_X = 25;

        private const int TICKPADDING_Y = 7;

        private const int TICKSPACING = 33;

        /*
         * Constructor method
         * 
         * control: control object that was passed in by MainForm
         * id: the specific id for this component. Uses to determine component location
         */
        public Component(string[,] data,Control.ControlCollection control, int id)
        {
            this.data = data;
            this.control = control;
            this.id = id;
            calculatePoints();
            generateComponent();
        }

        /*
         * Generate all parts for this component 
         */
        private void generateComponent()
        {
            generateTrackBar();
            generateNumericUpDown();
            generateInputBox();
        }

        private void generateTickValues()
        {
            for(int i = 0; i < 4; i++)
            {
                Label tickValue = new Label();
                // 
                // tick value for track bar
                // 
                if(i > 1)
                {

                }
                tickValue.AutoSize = true;
                tickValue.Location = new Point(this.trackBarPoint.X + TICKPADDING_X, this.trackBarPoint.Y + TICKPADDING_Y + i * TICKSPACING);
                tickValue.Font = new System.Drawing.Font("Times New Roman", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tickValue.ForeColor = System.Drawing.SystemColors.WindowText;
                tickValue.BackColor = System.Drawing.SystemColors.ControlDark;
                tickValue.Name = "tickLabel1";
                tickValue.BorderStyle = BorderStyle.None;
                tickValue.Size = new System.Drawing.Size(16, 17);
                tickValue.TabIndex = 3;
                tickValue.Text = Convert.ToString(255 - (i * 85));
                tickValue.Parent = this.trackBar;

                this.control.Add(tickValue);
            }
        }

        /*
          initialize trackBar and assign value to it
        */
        private void generateTrackBar()
        {
            this.generateTickValues();
            this.trackBar = new TrackBar();
            //start initialization
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            //initialize track bar
            this.trackBar.LargeChange = 10;
            this.trackBar.Location = trackBarPoint;
            this.trackBar.Margin = new Padding(2);
            this.trackBar.Minimum = 0;
            this.trackBar.Maximum = 255;
            this.trackBar.Name = "trackBar";
            this.trackBar.Orientation = Orientation.Vertical;
            this.trackBar.Size = new Size(TRACKBARWIDTH, TRACKBARHEIGHT);
            this.trackBar.TabIndex = 0;
            this.trackBar.TickFrequency = 85;
            this.trackBar.Scroll += new EventHandler(this.trackBar1_Scroll);
            this.trackBar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.control.Add(this.trackBar);
            //end initialization
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
        }

        /*
         * Event handler for track bar.
         * When the track bar is scrolled, auto update the value in numericUpDown
         */
        private void trackBar_Scroll(object sender, System.EventArgs e)
        {
            numericUpDown.Value = trackBar.Value;
            this.Refresh();
        }

        /*
         * initialize numbericUpDown and assign value to it
         */
        private void generateNumericUpDown()
        {
            this.numericUpDown = new NumericUpDown();
            //start initialization
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            //initialize numericUpDown
            this.numericUpDown.Location = numericUpDownPoint;
            this.numericUpDown.Maximum = new decimal(new int[] {
               255,
                0,
                0,
             0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numericUpDown.BackColor = System.Drawing.SystemColors.ControlDark;
            this.numericUpDown.BorderStyle = BorderStyle.None;
            this.numericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown.Size = new System.Drawing.Size(NUMERICUPDOWNWIDTH, NUMERICUPDOWNHEIGHT);
            this.numericUpDown.TabIndex = 1;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            this.data[id, 0] = trackBar.Value.ToString();
            this.control.Add(this.numericUpDown);
            //start initialization
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
        }

        /*
         * Generate input box for user. User can name track bars
         */
        private void generateInputBox()
        {
            name = new System.Windows.Forms.TextBox();
            this.name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.name.Location = namePoint;
            this.name.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.name.MaxLength = 3;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(NAMEWIDTH, 22);
            this.name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.name.BackColor = System.Drawing.SystemColors.ControlDark;
            this.name.TabIndex = 0;
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.name.Text = "CH " + Convert.ToString(id/2 + 1);
            this.data[id, 1] = this.name.Text;
            this.name.TextChanged += new System.EventHandler(name_ValueChanged);
            this.control.Add(name);
        }

        /*
         * update numericUpDown while track bar scrolled
         *
         */
        private void trackBar1_Scroll(object sender, System.EventArgs e)
        {
            //update numericUpDown
            numericUpDown.Value = trackBar.Value;
            storeData();
            this.Refresh();
        }


        /*
         * update track bar while value of numericUpDown changed
         */
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //update track bar
            trackBar.Value = (int)numericUpDown.Value;
            storeData();
            this.Refresh();
        }

        /*
         * update numericUpDown while track bar scrolled
         *
         */
        private void name_ValueChanged(object sender, System.EventArgs e)
        {
            data[id, 1] = this.name.Text;
        }

        private void storeData()
        {
            data[id, 0] = trackBar.Value.ToString();
        }

        /*
         * Calculate the location of all parts in this component
         */
        private void calculatePoints()
        {
            int locationIndex = (id / 2);
            //calculate location of the trackBarPoint according to their id
            this.trackBarPoint = new Point((locationIndex + 1) * PADDING + locationIndex * TRACKBARWIDTH, PADDING);
            this.numericUpDownPoint = new Point(trackBarPoint.X, trackBarPoint.Y + 1 + TRACKBARHEIGHT);
            this.namePoint = new Point(numericUpDownPoint.X, numericUpDownPoint.Y + NUMERICUPDOWNHEIGHT + 5);
        }

        /*
         * Sets the value of track bar, numberic up down, and channel name
         */
        public void setValue(int value, string name)
        {
            this.trackBar.Value = value;
            this.numericUpDown.Value = value;
            this.name.Text = name;
            this.Refresh();
        }

        /*
         * This method enables/disables the components in this class
         * Will only be called when it is on/off transition
         */
        public void componentSwitch(Boolean swit)
        {
            this.trackBar.Enabled = swit;
            this.numericUpDown.Enabled = swit;
            this.name.Enabled = swit;
        }
    }
}
