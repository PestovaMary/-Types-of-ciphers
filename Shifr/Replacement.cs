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
    public partial class Replacement : Form
    {
        public Replacement()
        {
            InitializeComponent();
            start();
        }

        private Dictionary<char, char> alphabetFinal = new Dictionary<char, char>();
        private List<char> alphabetOrig = new List<char>();
        private int alphabetPower;


        private void button5_Click(object sender, EventArgs e) //Ввод алфавита
        {
            alphabetFinal.Clear();
            for (int i = 0; i < textBox3.Text.Length; ++i)
            {
                char position = textBox3.Text.ElementAt(i);
                if (position.Equals(' ')) continue;
                alphabetOrig.Add(position);
                alphabetPower++;
            }
            if (null != textBox3.Text && 0 != textBox3.Text.Length)
            end();
        }

        private void button2_Click(object sender, EventArgs e) //Загрузка текста
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

        private void button3_Click(object sender, EventArgs e) //Сохранение текста
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            System.IO.File.WriteAllText(saveFileDialog1.FileName + ".txt", textBox2.Text, System.Text.Encoding.Default);
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            if (null != textBox1.Text && 0 != textBox1.Text.Length)
            {
                textBox2.Clear();
                alphabetFinal.Clear();

                Random random = new Random();
                List<char> cloneOfOrig = new List<char>(alphabetOrig);
                List<char> alphabetCoded = new List<char>();
                List<char> encodedText = new List<char>();


                while (cloneOfOrig.Count > 0)
                {
                    int index = random.Next(cloneOfOrig.Count);
                    alphabetCoded.Add(cloneOfOrig[index]);
                    cloneOfOrig.RemoveAt(index);
                }

       
                for (int i = 0; i < alphabetCoded.Count; ++i)
                {
                    try
                    {
                        char currentKey = alphabetOrig.ElementAt(i);
                        alphabetFinal.Add(currentKey, (char)alphabetCoded.ElementAt(i));
                    }
                    catch { }
                }

                for (int i = 0; i < textBox1.Text.Length; ++i)
                {
                    char position = textBox1.Text.ElementAt(i);
                    if (coincidence(alphabetFinal, position))
                    {
                        encodedText.Add((char)alphabetFinal[position]);                               
                    }
                    else
                    {
                        encodedText.Add(position);
                    }
                }

                textBox2.Text = String.Join("", encodedText);                                              
                textBox2.Text += Environment.NewLine + String.Join(Environment.NewLine, alphabetFinal);    

            }
        } 
        
        private void button4_Click(object sender, EventArgs e) 
        {
            List<char> decodedText = new List<char>();

            textBox2.Clear();
            var firstElement = alphabetFinal.Keys.First();
            var lastElement = alphabetFinal.Keys.Last();

            for (int i = 0; i < textBox1.Text.Length; ++i)
            {
                char position = textBox1.Text.ElementAt(i);
                if (coincidence(alphabetFinal, position))
                {
                    var getKey = alphabetFinal.FirstOrDefault(x => x.Value == position).Key;
                    decodedText.Add(getKey);
                }
                else
                {
                    decodedText.Add(position);
                }

            }

            textBox2.Text = String.Join("", decodedText);
        }

        private bool coincidence(Dictionary<char, char> searchDic, char element)
        {
            for (int i = 0; i < searchDic.Count; ++i)
            {
                char position = searchDic.Values.ElementAt(i);
                if (position.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        private void start()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            textBox2.Visible = false;           
            textBox1.Visible = false;
            button5.Visible = true;
            textBox3.Visible = true;
        }

        private void end()
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            textBox2.Visible = true;
            textBox1.Visible = true;
            button5.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
        }


    }
}
