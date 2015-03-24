using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KryptZapper
{
    public partial class EmailMethodChooseDialog : Form
    {
        private string radioSelect;

        public EmailMethodChooseDialog()
        {
            InitializeComponent();
        }

        public string Selection
        {
            get
            {
                if(localEmailClientRadio.Checked)
                {
                    return "local";
                }
                else
                {
                    return "account";
                }
            }
        }

        private void linkToSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountSetUpDialog setup = new AccountSetUpDialog();
            setup.ShowDialog();
        }

    }
}
