using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shifr
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Replacement replacement = new Replacement();
            replacement.Show();
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            XOR xor = new XOR();
            xor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Caesar caesar = new Caesar();
            caesar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BlockCipherDecode blockCipherDecode = new BlockCipherDecode();
            blockCipherDecode.Show();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
