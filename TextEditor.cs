using System;
using System.Drawing;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Lev_TextEditor
{
    public partial class TextEditor : Form
    {
        public TextEditor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, richTextBox.Text);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchText = Microsoft.VisualBasic.Interaction.InputBox("Введите текст для поиска:", "Поиск");
            int index = richTextBox.Text.IndexOf(searchText);
            if (index >= 0)
            {
                richTextBox.Select(index, searchText.Length);
                richTextBox.Focus();
            }
            else
            {
                MessageBox.Show("Текст не найден", "Поиск");
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchText = Microsoft.VisualBasic.Interaction.InputBox("Введите текст для поиска:", "Поиск");
            string replaceText = Microsoft.VisualBasic.Interaction.InputBox("Введите текст для замены:", "Замена");
            richTextBox.Text = richTextBox.Text.Replace(searchText, replaceText);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }

        private void ToggleFontStyle(FontStyle style)
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ style;
                Font newFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                richTextBox.SelectionFont = newFont;
            }
        }
    }
}