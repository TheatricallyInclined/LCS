using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LCS.Logic;
using System.Drawing;

namespace LCS.Gui
{
    class FixtureNameLabel : Label
    {
        private Service service;

        private Panel panel;

        private Label fixtureName;

        private const int PADDING = 25;

        public FixtureNameLabel(Service service, Panel panel, string name, int id)
        {
            this.service = service;
            this.panel = panel;
            addFixtureName(name, id);
        }

        private void addFixtureName(string name, int id)
        {
            fixtureName = new Label();
            // 
            // display all fixtures
            // 
            //center text
            fixtureName.AutoSize = false;
            fixtureName.TextAlign = ContentAlignment.MiddleCenter;
            fixtureName.Dock = DockStyle.Fill;
            fixtureName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fixtureName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            fixtureName.Name = name;
            fixtureName.TabIndex = 1;
            fixtureName.Text = name;
            fixtureName.BackColor = System.Drawing.SystemColors.ControlDark;
            fixtureName.Location = new Point((this.panel.Size.Width - fixtureName.Size.Width) / 2, id*PADDING + PADDING);
            fixtureName.MouseEnter += new System.EventHandler(this.fixtureName_MouseEnter);
            fixtureName.MouseLeave += new System.EventHandler(this.fixtureName_MouseLeave);
            fixtureName.Click += new System.EventHandler(this.fixtureName_MouseClick);
            this.panel.Controls.Add(fixtureName);
        }

        private void fixtureName_MouseEnter(object sender, System.EventArgs e)
        {
            fixtureName.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void fixtureName_MouseLeave(object sender, System.EventArgs e)
        {
            fixtureName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void fixtureName_MouseClick(object sender, System.EventArgs e)
        {
            
        }
    }
}
