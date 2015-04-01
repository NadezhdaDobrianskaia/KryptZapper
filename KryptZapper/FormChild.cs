using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography; //provides variety of tools to help with encryption and with decryption
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace KryptZapper
{
    public partial class FormChild : Form
    {
        // ----------------------------- email method variables
        

        public static string accountHost;               // holds the users email host
        public static int accountPort;                  // holds the email port
        public static string accountPassword;           // holds the users email password
        public static string accountEmailFrom;               // holds the users email

        //---------------------RSA fields
        private RSACryptoServiceProvider rsa;
        String MyEncryptedText = "";
        private static string _privateKey;
        private static string _publicKey;
        private static UnicodeEncoding _encoder = new UnicodeEncoding();
        
        //-------------------end RSA fields

        // store the file type for this file
        private string fileExt = "";

        MailAddress fromAddress;
        private const String FromName = "From Name";
        private const String ToName = "To Name";

        //reference for it's parent
        private FormParent formParent;

        // flag to check if user email account is set
        bool isEmailSetup = false;

        string ext = null; //added for the saveAs
        string justSave = null;  //added for the saveAs

        const string fromPassword = "techpro3951";

        public FormChild(FormParent f)
        {
            InitializeComponent();
            formParent = f;
            fileExt = "Text Files | *.txt";
        }

        public FormChild(string path, string file, FormParent f)     //constructor
        {
            InitializeComponent();
            String ext = path.Substring(path.IndexOf(".", 0) + 1, 3);

            // if it is already encrypted
            if (ext.CompareTo("kpt") == 0)
            {
                nadiaUserControl1.ButtonEncrypted = true;
                nadiaUserControl1.ButtonActivated = false;
                fileExt = "Krypt-Zapper Files | *.kpt";
            }
            else
            {
                fileExt = "Text Files | *.txt";
            }

            formParent = f;
            richTextBox1.Text = file;
            MessageBox.Show("I opened a file");
            justSave = path;
            MessageBox.Show(file);
        }

        /// <summary>
        /// Saving text in the Child Form
        /// </summary>
        public void saveAs()
        {
            SaveFileDialog saveText = new SaveFileDialog();
            saveText.Filter = fileExt;
            string text = richTextBox1.Text;

            if (saveText.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.Stream fileStream = saveText.OpenFile();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();
                justSave = saveText.FileName;
                MessageBox.Show(justSave);
            }
        }

        /// <summary>
        /// When clicking save. test to see if file exists.  If it does overwrite it
        /// otherwise call saveAs.
        /// </summary>
        public void save()
        {
            string text = richTextBox1.Text;
            MessageBox.Show("SaveWasPressed");
            if (System.IO.File.Exists(justSave))
            {
                System.IO.File.WriteAllText(justSave, text);
                MessageBox.Show("FileExists");
                MessageBox.Show(justSave);
            }
            else
            {
                MessageBox.Show("File did not Exist");
                saveAs();
            }
        }

        /// <summary>
        /// executes closing protocols
        /// </summary>
        public void close()
        {
            if (justSave == null)
                saveAs();
            else
                save();
            this.Dispose();
            formParent.updateControls();
        }

        /// <summary>
        /// handles closing events for child forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClosingChildForm(object sender, FormClosingEventArgs e)
        {
            DialogSaveChild close = new DialogSaveChild();
            if (close.ShowDialog() == DialogResult.OK)
            {
                this.close();
            }
            else
            {
                this.Dispose();
                formParent.updateControls();
            }
        }


        public void EmailChild()
        {
            if (formParent.getDefaultSet() == false)
            {
                EmailMethodChooseDialog chooseMethod = new EmailMethodChooseDialog();
                

                ////////////////////////////////////////////////////////////////////////////
                if (chooseMethod.ShowDialog() == DialogResult.OK)
                {
                    if (chooseMethod.Selection == "local")
                    {
                        formParent.setDefault(chooseMethod.DefaultChosen);
                        sendEmail("local");
                    }
                    else
                    {
                        formParent.setDefault(chooseMethod.DefaultChosen);
                        sendEmail("account");


                    }
                }
                else
                {
                    chooseMethod.Close();
                }
                /////////////////////////////////////////////////////////////////////////////////
            }
            else
            {
                sendEmail(formParent.getDefaultEmailMethod());
            }


        }

        public void sendEmail(string method)
        {
            if (method.CompareTo("local") == 0)
            {
                formParent.setDefaultEmailMethod("local");
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = "mailto:?subject=Krypt-Zapper message&body=" + richTextBox1.Text;
                proc.Start();
            }
            else
            {
                formParent.setDefaultEmailMethod("account");

                //-----------------------------------------------------
                if (isEmailSetup == false)
                {
                    AccountSetUpDialog accountSet = new AccountSetUpDialog();
                    if (accountSet.ShowDialog() == DialogResult.Cancel)
                    {
                        accountSet.Close();
                    }
                    else //(accountSet.ShowDialog() == DialogResult.OK)
                    {
                        accountHost = accountSet.EmailHost;
                        accountPort = int.Parse(accountSet.EmailPort);
                        accountPassword = accountSet.EmailPassword;
                        accountEmailFrom = accountSet.FromEmail;

                        fromAddress = new MailAddress(accountEmailFrom, "From Name");


                        isEmailSetup = true;

                        sendEmailFromAccountChooseTo();
                    }

                }
                //-----------------------------------------------------
                else if (isEmailSetup == true)
                {
                    sendEmailFromAccountChooseTo();

                }
                //----------------------------------------------------------
            }
        }


        public void sendEmailFromAccountChooseTo()
        {
            // show to email dialog
            EmailDialog emailSet = new EmailDialog();

            if (emailSet.ShowDialog() == DialogResult.OK)
            {
                String accountEmailTo = emailSet.EmailTo;  // holds where user wants to send the mail             
                MailAddress toAddress = new MailAddress(accountEmailTo, "To Name");
                var smtp = new SmtpClient
                {

                    Host = accountHost,
                    Port = accountPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    // hardcoded email subject
                    Subject = "Krypt-Zapper Message",

                    // pulls text from textbox to send in email
                    Body = richTextBox1.Text

                })
                {
                    smtp.Send(message);
                }
            }
        }


///////--------------------------RSA Encryption / Decryption
        /// <summary>
        /// encrypts messages
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Encrypt(string data)
        {
            fileExt = "Krypt-Zapper Files | *.kpt";
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(_publicKey);
            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
            var length = encryptedByteArray.Count();
            var item = 0;
            var sb = new StringBuilder();
            foreach (var x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }

        /// <summary>
        /// grabs text from MDI child and stores it in a string
        /// </summary>
        public void EncryptChild(object sender, EventArgs e)
        {

            if(nadiaUserControl1.ButtonEncryptedClick)
                nadiaUserControl1_NadiaEncryption_Click(sender, e);
           /* string text = richTextBox1.Text;
            MyEncryptedText = Encrypt(text);
            richTextBox1.Text = MyEncryptedText;*/
        }

        public void DecryptChild(object sender, EventArgs e)
        {
            if(nadiaUserControl1.ButtonDecryptedClick)
                nadiaUserControl1_NadiaDecryption_Click(sender, e);
            /*string text = richTextBox1.Text;
            MyEncryptedText = Decrypt(text);
            richTextBox1.Text = MyEncryptedText;
            */
        }
        private string Decrypt(string data)
        {
            fileExt = "Text Files | *.txt";
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }
            try
            {
                rsa.FromXmlString(_privateKey);
                var decryptedByte = rsa.Decrypt(dataByte, false);
                return _encoder.GetString(decryptedByte);
            }
            catch
            {
                MessageBox.Show("Exception caught");
            }

        }

        private void nadiaUserControl1_NadiaDecryption_Click(object sender, EventArgs e)
        {
            //DecryptChild();
            _privateKey = nadiaUserControl1.PrivateKey;
            string text = richTextBox1.Text;
            MyEncryptedText = Decrypt(text);
            richTextBox1.Text = MyEncryptedText;
        }

        private void nadiaUserControl1_NadiaEncryption_Click(object sender, EventArgs e)
        {
            
           // _privateKey = nadiaUserControl1.PrivateKey;
            _publicKey = nadiaUserControl1.PublicKey;
            string text = richTextBox1.Text;
            MessageBox.Show("RSA // Text to encrypt: " + text);
            MyEncryptedText = Encrypt(text);
            richTextBox1.Text = MyEncryptedText;

        }
//--------------------------------------end RSA Encryptiion /Decryption
    }
}
