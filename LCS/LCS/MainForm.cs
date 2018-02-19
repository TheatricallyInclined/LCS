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
            InitializeComponent(service.mainFormSize());
            generateComponents(numOfComponents);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
