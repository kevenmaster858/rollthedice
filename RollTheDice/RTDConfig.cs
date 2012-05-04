using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RollTheDice
{
    public partial class RTDConfig : Form
    {
        public RTDConfig()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        private void RTDConfig_Load(object sender, EventArgs e)
        {
            foreach (Roll roll in RollManager.AbsoluteRolls)
            {
                string aa = Core.Owner.GetServerCFG("RTDROLLS", RollManager.ToINI(roll.Name), "False").ToLower();
                if(aa != "false")
                {
                    checkedListBox1.Items.Add(roll.Name, true);
                }
                else checkedListBox1.Items.Add(roll.Name);
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == 0)
            {
                Core.Owner.SetServerCFG("RTDROLLS", RollManager.ToINI((string)checkedListBox1.Items[e.Index]), "False");
                //MessageBox.Show(checkedListBox1.Items[e.Index] + " = 0");
            }
            else
            {
                //MessageBox.Show(checkedListBox1.Items[e.Index] + " = 1");
                Core.Owner.SetServerCFG("RTDROLLS", RollManager.ToINI((string)checkedListBox1.Items[e.Index]), "True");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RollManager.Initialize(false);
        }
    }
}
