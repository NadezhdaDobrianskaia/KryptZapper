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
        // email method variables
        bool isDefaultSet = false;
        string defaultEmailMethod = null;

        //---------------------RSA fields
        private RSACryptoServiceProvider rsa;
        String MyEncryptedText = "";
        private static string _privateKey;
        private static string _publicKey;
        private static UnicodeEncoding _encoder = new UnicodeEncoding();
        
        //-------------------end RSA fields


        //reference for it's parent
        private FormParent formParent;

        // flag to check if user email account is set
        bool isEmailSetup = false;

        string ext = null; //added for the saveAs
        string justSave = null;  //added for the saveAs

        MailAddress fromAddress = new MailAddress("KryptZapper@gmail.com", "From Name");
        MailAddress toAddress = new MailAddress("KryptZapper@gmail.com", "To Name");
        const string fromPassword = "techpro3951";

        public FormChild(FormParent f)
        {
            InitializeComponent();
            formParent = f;
        }

        public FormChild(string path, string file, FormParent f)     //constructor
        {
            InitializeComponent();
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
            saveText.Filter = "Text Files | *.txt";
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
            if (isDefaultSet == false)
            {
                EmailMethodChooseDialog chooseMethod = new EmailMethodChooseDialog();

                ////////////////////////////////////////////////////////////////////////////
                if (chooseMethod.ShowDialog() == DialogResult.OK)
                {
                    if (chooseMethod.Selection == "local")
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = "mailto:?subject=Krypt-Zapper message&body=" + richTextBox1.Text;
                        proc.Start();
                    }
                    else
                    {
                        //-----------------------------------------------------
                        if (isEmailSetup == false)
                        {
                            AccountSetUpDialog accountSet = new AccountSetUpDialog();
                            if (accountSet.ShowDialog() == DialogResult.Cancel)
                            {
                                accountSet.Close();
                            }

                        }
                        //-----------------------------------------------------
                        else if (isEmailSetup == true)
                        {
                            EmailDialog emailSet = new EmailDialog();

                            if (emailSet.ShowDialog() == DialogResult.OK)
                            {
                                var smtp = new SmtpClient
                                {
                                    Host = "smtp.gmail.com",
                                    Port = 587,
                                    EnableSsl = true,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    UseDefaultCredentials = false,
                                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                                };
                                using (var message = new MailMessage(fromAddress, toAddress)
                                {
                                    Subject = "Krypt-Zapper Message",
                                    Body = richTextBox1.Text
                                })
                                {
                                    smtp.Send(message);
                                }
                            }

                        }
                        //----------------------------------------------------------


                    }
                }
                else
                {
                    chooseMethod.Close();
                }
                /////////////////////////////////////////////////////////////////////////////////
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
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString(_privateKey);
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
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
