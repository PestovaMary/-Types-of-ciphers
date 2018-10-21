using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shifr
{
    public partial class XOR : Form
    {
        public XOR()
        {
            InitializeComponent();
        }

        private string stringKey;
        private byte[] encodedText;

        private void button3_Click(object sender, EventArgs e)
        {
            stringKey = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream loadStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Clear();
                try
                {
                    if ((loadStream = openFileDialog1.OpenFile()) != null) { }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("The file could not be read. Error: " + exception.Message);
                }
            }
            textBox1.Text = File.ReadAllText(openFileDialog1.FileName, System.Text.Encoding.Default);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            System.IO.File.WriteAllText(saveFileDialog1.FileName + ".txt", textBox2.Text, System.Text.Encoding.Default);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] txt = Encoding.Default.GetBytes(textBox1.Text);
            byte[] key = Encoding.Default.GetBytes(stringKey);
            byte[] res = new byte[textBox1.Text.Length];

            for (int i = 0; i < txt.Length; ++i)
            {
                res[i] = (byte)(txt[i] ^ key[i % key.Length]);
            }

            textBox2.Text = String.Join(" ", Encoding.UTF8.GetString(encodedText));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] res = new byte[textBox1.Text.Length];
            byte[] key = Encoding.Default.GetBytes(stringKey);

            for (int i = 0; i < textBox1.Text.Length; ++i)
            {
                res[i] = (byte)(textBox1.Text[i] ^ key[i % key.Length]);
            }

            textBox2.Text = String.Join(" ", encodedText);
        }
    }
}
