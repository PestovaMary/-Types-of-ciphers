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
    public partial class BlockCipherDecode : Form
    {
        public BlockCipherDecode()
        {
            InitializeComponent();
        }

        private Dictionary<char, char> alphabetFinal = new Dictionary<char, char>();
        private List<char> alphabetOrig = new List<char>();

        private void button1_Click(object sender, EventArgs e) //Загрузка текста
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

        private void button2_Click(object sender, EventArgs e) // Сохранение текста
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            System.IO.File.WriteAllText(saveFileDialog1.FileName + ".txt", textBox2.Text, System.Text.Encoding.Default);
        }

        private void button3_Click(object sender, EventArgs e) //Шифровка
        {
            textBox2.Clear();
            alphabetFinal.Clear();

            Random random = new Random();
            List<string> listOfStrings = new List<string>();
            string originalText = textBox1.Text;
            string temp = "";


            int key = 4;
            while (originalText.Length % key != 0)
            {
                originalText += "#";
            }

            originalText += " ";

            for (int i = 0; i < originalText.Length; ++i)
            {
                char position = originalText.ElementAt(i);
                if (i % key == 0 && i != 0)
                {
                    listOfStrings.Add(temp);
                    temp = "";
                }
                temp += position;
            }

            List<string> shuffledList = new List<string>();

            while (listOfStrings.Count > 0)
            {
                int index = random.Next(listOfStrings.Count);
                shuffledList.Add(listOfStrings[index]);
                listOfStrings.RemoveAt(index);
            }
            textBox2.Text = String.Join(" ", shuffledList);
        }


    }
}
