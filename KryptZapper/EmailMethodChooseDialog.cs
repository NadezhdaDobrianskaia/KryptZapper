﻿using System;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

    }
}
