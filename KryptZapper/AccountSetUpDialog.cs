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
    public partial class AccountSetUpDialog : Form
    {

        string emailHost;               // holds the users email host
        string emailPort;                  // holds the email port
        string emailPassword;           // holds the users email password
        string fromEmail;               // holds the users email

        public AccountSetUpDialog()
        {
            InitializeComponent();
        }

        public string EmailHost
        {
            get
            {
                emailHost = setupHostText.Text;
                return emailHost;
            }
        }

        public string EmailPort
        {
            get
            {
                emailPort = setupPortText.Text;
                return emailPort;
            }
        }

        public string EmailPassword
        {
            get
            {
                emailPassword = setupPasswordText.Text;
                return emailPassword;
            }
        }

        public string FromEmail
        {
            get
            {
                fromEmail = setupUsernameText.Text;
                return fromEmail;
            }
        }


        
    }
}
