using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayerForm
{
    public partial class Form1 : Form
    {
        private SoundPlayer player = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "wavファイルを選択してください";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "wav ファイル|*.wav*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowHelp = true;
            openFileDialog1.ShowReadOnly = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.Dispose();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = (openFileDialog1.FileName);
            }
            openFileDialog1.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                PlaySound(textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StopSound(); // コールしても曲が止まらないので、中身の処理に問題あり
        }

        private void PlaySound(String waveFile)
        {
            if (player != null)
            {
                StopSound();
            }
            player = new SoundPlayer(waveFile);
            if (checkBox1.Checked)
            {
                player.PlayLooping();
                return;
            }
            player.Play();
        }

        private void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }
    }
}
