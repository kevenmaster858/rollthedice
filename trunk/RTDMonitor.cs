using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RollTheDice
{
    public partial class RTDMonitor : Form
    {
        public RTDMonitor()
        {
            InitializeComponent();
        }

        private void RTDMonitor_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(RollManager.RegisteredRolls.Count);
            label5.Text = Convert.ToString(Core.RollThreads.Count);
            label6.Text = Convert.ToString(RollManager.Rolls.Count);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
