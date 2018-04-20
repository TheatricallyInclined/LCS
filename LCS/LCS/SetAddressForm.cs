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
    public partial class SetAddressForm : Form
    {
        private Logic.Service service;
        
        public SetAddressForm(Logic.Service service)
        {
            InitializeComponent();
            this.service = service;
        }
        

        private void setButton_Click(object sender, MouseEventArgs e)
        {
            if (this.service.setAddress(this.textBox1.Text))
            {
                System.Console.WriteLine(this.textBox1.Text);
                service.hideSetAddressForm();
                service.startMain();
            }
        }

        private void SetAddressForm_Load(object sender, EventArgs e)
        {

        }
    }
    

    
}
