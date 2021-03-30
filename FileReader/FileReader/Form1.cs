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

namespace FileReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|Text files(*.rtf)|*.rtf|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|Text files(*.rtf)|*.rtf|All files(*.*)|*.*";
            button1.Text = "File";
            button2.Text = "Edit";
            button3.Text = "Help";
            button4.Text = "Change";
            CreateMenuFile();
            CreateMenuEdit();
            CreateMenuHelp();
        }
        private void Form1_Update(object sender, EventArgs e)
        {
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedItem)
            {
                case "Open":
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        label1.Text = $@"{openFileDialog1.FileName}";
                        richTextBox1.Text = File.ReadAllText(@label1.Text);
                    }
                    break;
                case "Save":
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                        MessageBox.Show("File successfully saved");
                    }
                    break;
                case "Close":
                    DialogResult dialogResult = MessageBox.Show("Do u want to save your document?", "Closing", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                            MessageBox.Show("File successfully saved");
                            richTextBox1.Text = "";
                        }
                        break;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        richTextBox1.Text = "";
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == false)
                listBox1.Visible = true;
            else
                listBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.Visible == false)
                listBox2.Visible = true;
            else
                listBox2.Visible = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox2.SelectedItem)
            {
                case "Copy":
                    Clipboard.SetText(richTextBox1.SelectedText, TextDataFormat.UnicodeText);
                    break;
                case "Cut":
                    Clipboard.SetText(richTextBox1.SelectedText, TextDataFormat.UnicodeText);
                    richTextBox1.SelectedText = "";
                    break;
                case "Paste":
                    richTextBox1.SelectedText = Clipboard.GetData(DataFormats.Text).ToString();
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox3.Visible == false)
                listBox3.Visible = true;
            else
                listBox3.Visible = false;
        }
        private void CreateMenuFile()
        {
            string[] menu = {"Open", "Save", "Close"};
            foreach (string a in menu)
            {
                listBox1.Items.Add(a);
            }
        }
        private void CreateMenuEdit()
        {
            string[] menu = {"Copy", "Cut", "Paste"};
            foreach (string a in menu)
            {
                listBox2.Items.Add(a);
            }
        }
        private void CreateMenuHelp()
        {
            string[] menu = { "About"};
            foreach (string a in menu)
            {
                listBox3.Items.Add(a);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox3.SelectedItem)
            {
                case "About":
                    MessageBox.Show("© 2020 Semeniuk Denys.  All rights reserved.", "About");
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Wrong input", "Eror");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                newFontStyle = FontStyle.Regular;
                if (textBox2.Text == "Bold")
                    newFontStyle = FontStyle.Bold;
                else if (textBox2.Text == "Italic")
                    newFontStyle = FontStyle.Italic;
                else if (textBox2.Text == "Underline")
                    newFontStyle = FontStyle.Underline;
                var size = Convert.ToInt32(textBox1.Text);
                var fontFamily = textBox3.Text;
                richTextBox1.SelectionFont = new Font(
                   fontFamily,
                   size,
                   newFontStyle
                );
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
