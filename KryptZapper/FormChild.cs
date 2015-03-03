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


namespace KryptZapper
{
    public partial class FormChild : Form
    {
        string ext = null; //added for the saveAs
        string justSave = null; //added for the saveAs

        //*****DESCryptoServiceProvider is based on a symmetric encryption algorithm.  
        //*****Symmetric encryption requires a key and an initialization vector(IV) to encrypt the data
        //*****To decrypt the data you must use the same key and save IV.
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


        public void close()
        {
            if (justSave == null)
                saveAs();
            else
                save();
            this.Dispose();
        }

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
        public void EncryptChild()
        {
            string text = richTextBox1.Text;
            MyEncryptedText = Encrypt(text);
            richTextBox1.Text = MyEncryptedText;
        }

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
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write); //CryptoStream class is designed to encrypt or to decrypt content as it is streamed out to a file
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            byte[] inArray = stream.ToArray();
            stream.Close();
            stream2.Close();
            return Convert.ToBase64String(inArray);
        }

        public void DecryptChild()
        {
            string text = richTextBox1.Text;
            MyEncryptedText = Decrypt(text);
            richTextBox1.Text = MyEncryptedText;
        }
        private string Decrypt(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(this.initVector);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(this.saltValue);
            byte[] buffer = Convert.FromBase64String(data);
            byte[] rgbKey = new PasswordDeriveBytes(this.passPhrase, rgbSalt, this.hashAlgorithm, this.passwordIterations).GetBytes(this.keySize / 8);
            RijndaelManaged managed = new RijndaelManaged();
            managed.Mode = CipherMode.CBC;
            ICryptoTransform transform = managed.CreateDecryptor(rgbKey, bytes);
            MemoryStream stream = new MemoryStream(buffer);
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            byte[] buffer5 = new byte[buffer.Length];
            int count = stream2.Read(buffer5, 0, buffer5.Length);
            stream.Close();
            stream2.Close();
            return Encoding.UTF8.GetString(buffer5, 0, count);
        }
    }
}
