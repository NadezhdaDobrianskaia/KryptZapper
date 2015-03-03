using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KryptZapper
{
    public partial class FormChild : Form
    {
        string ext = null; //added for the saveAs
        string justSave = null; //added for the saveAs

        //For Encryption
        string passPhrase = "Pasword";        // can be any string
        string saltValue = "sALtValue";        // can be any string
        string hashAlgorithm = "SHA1";             // can be "MD5"
        int passwordIterations = 7;                  // can be any number
        string initVector = "~1B2c3D4e5F6g7H8"; // must be 16 bytes
        int keySize = 256;                // can be 192 or 128
        //---end for Encryption


        public FormChild()
        {
            InitializeComponent();
        }

        public FormChild(string path, string file)     //constructor
        {
            InitializeComponent();
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
            }
        }

        String MyEncryptedText;

        /// <summary>
        /// grabs text from MDI child and stores it in a string
        /// </summary>
        public void EncryptChild()
        {
            string text = richTextBox1.Text;
            MyEncryptedText = Encrypt(text);
            richTextBox1.Text = MyEncryptedText;
        }

        /// <summary>
        /// encrypts messages
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Encrypt(string data)
        {
            MessageBox.Show("Trying to Encrypt");
            
            byte[] bytes = Encoding.ASCII.GetBytes(this.initVector);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(this.saltValue);
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            byte[] rgbKey = new PasswordDeriveBytes(this.passPhrase, rgbSalt, this.hashAlgorithm, this.passwordIterations).GetBytes(this.keySize / 8);
            RijndaelManaged managed = new RijndaelManaged();
            managed.Mode = CipherMode.CBC;
            ICryptoTransform transform = managed.CreateEncryptor(rgbKey, bytes);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            byte[] inArray = stream.ToArray();
            stream.Close();
            stream2.Close();
            return Convert.ToBase64String(inArray);
        }
    }
}
