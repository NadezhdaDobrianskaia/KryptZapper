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
    public partial class EmailDialog : Form
    {

        private string emailTo;

        public EmailDialog()
        {
            InitializeComponent();
        }

        public string EmailTo
        {
            get
            {
                emailTo = emailRecipientText.Text;
                return emailTo;
            }
        }

    
    }
}
