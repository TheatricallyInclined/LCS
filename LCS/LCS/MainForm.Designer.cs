namespace LCS.Gui
{
   /*
    * Partial class of MainForm. The main GUI of this application.
    * This partial class provides only the user interface for the MainForm
    * No logics should be handled in this class
    */
    partial class MainForm
    {
        private Component[] coms;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(System.Drawing.Size formSize)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = formSize;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.BackgroundImage = global::LCS.Properties.Resources.theatre_background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.AutoScroll = true;
        }
        /*
         * System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = formSize;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.BackgroundImage = global::LCS.Properties.Resources.theatre_background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.AutoScroll = true;
         */

        /*
         * Generate components for the main form
         */
        private void generateComponents(int numOfComponents)
        {

            this.coms = new Component[numOfComponents];
            for(int i = 0; i < numOfComponents; i++)
            {
                coms[i] = new Component(this.Controls, i); 
            }
        }

        #endregion
    }
}
