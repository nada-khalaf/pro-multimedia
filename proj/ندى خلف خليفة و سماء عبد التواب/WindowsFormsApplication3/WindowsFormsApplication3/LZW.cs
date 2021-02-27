using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class LZW : Form
    {
        public LZW()
        {
            InitializeComponent();
        }
        List<String> outputs = new List<string>();
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            if (textBox1.Text=="")
            {
                return;
            }
            outputs.Clear();
            dictionary.Clear();
            // add charachter to the Dictionary
            int j = 1;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (!dictionary.ContainsKey(textBox1.Text[i].ToString()))
                {
                    dictionary[textBox1.Text[i].ToString()] = j;
                    j++;
                }
            }

            //ABABBABCABABBA

            string prefix = dictionary.ElementAt(0).Key;
            int codeword = j ;

            for (int i = 1; i < textBox1.Text.Length; i++)
            {
                char _char = textBox1.Text[i];
                string prefix_char = "";
                prefix_char += prefix;
                prefix_char += _char;
                if (dictionary.ContainsKey(prefix_char))
                {
                    prefix = prefix + _char.ToString();
                }
                else
                {
                    outputs.Add(dictionary[prefix].ToString());
                    label1.Text += dictionary[prefix].ToString() + "|";//output
                    dictionary[prefix_char] = codeword;
                    codeword++;
                    prefix = _char.ToString();
                }
            }
            outputs.Add(dictionary[prefix].ToString());
            label1.Text += dictionary[prefix].ToString() + "|";//output
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int PreviousCodeWord = int.Parse(outputs[0]);
            label2.Text = "";
            Dictionary<string, int> dictionary1 = new Dictionary<string, int>();
            int j = 1;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (!dictionary1.ContainsKey(textBox1.Text[i].ToString()))
                {
                    dictionary1[textBox1.Text[i].ToString()] = j;
                    j++;
                }
            }


            String myKey = dictionary1.FirstOrDefault(x => x.Value == int.Parse(outputs[0])).Key;

            label2.Text += myKey;

            String _char = outputs[0];

            String _string = "";
            int CodeWord = j;

            for (int i = 1; i < outputs.Count; i++)
            {
                int CurrentCodeWord = int.Parse(outputs[i]);
                String thekey = dictionary1.FirstOrDefault(x => x.Value == int.Parse(outputs[i])).Key;
                //String   thekey = dictionary1.FirstOrDefault(x => x.Value == PreviousCodeWord).Key + _char;


                if (thekey != null)// if exist in dictionart
                {
                    _string = thekey;
                }
                else
                {
                    thekey = dictionary1.FirstOrDefault(x => x.Value == PreviousCodeWord).Key + _char; // string(previous_code)+char
                    _string = thekey;
                }
                label2.Text += _string;
                _char = _string[0].ToString();
                thekey = dictionary1.FirstOrDefault(x => x.Value == PreviousCodeWord).Key + _char; // string(previous_code) + char

                dictionary1[thekey] = CodeWord;

                PreviousCodeWord = CurrentCodeWord;
                CodeWord++;
                //dictionary1[
            }
        }
    }
}
