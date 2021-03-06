﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeDiary {
    public partial class FormMain : Form {

        string fileName = null;

        public FormMain() {
            InitializeComponent();
            fileName = System.IO.Directory.GetCurrentDirectory() + "\\CodeDiary.txt";
            try {
                textBoxHistory.Text = System.IO.File.ReadAllText(fileName);
            } catch {
            }
        }

        private void FormMain_Load(object sender, EventArgs e) {
            textBoxInput.KeyUp += textBoxInput_KeyUp;
        }

        void textBoxInput_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Control) {
                Submit();
            }
        }

        private void Submit() {
            if (!String.IsNullOrEmpty(textBoxInput.Text.Trim())) {
                string newContent = "--" + DateTime.Now.ToString() + "--\r\n";
                newContent += textBoxInput.Text + "\r\n";
                textBoxHistory.AppendText(newContent);

                if (!string.IsNullOrEmpty(fileName)) {
                    System.IO.File.WriteAllText(fileName, textBoxHistory.Text);
                } else {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                        this.fileName = saveFileDialog.FileName;
                        System.IO.File.WriteAllText(saveFileDialog.FileName, textBoxHistory.Text);
                    }
                }
            }
            textBoxInput.Clear();
        }
    }
}
