using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OATools2018.FamilyTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isProcessRunning = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (isProcessRunning)
            {
                MessageBox.Show("A process is already running.");
                return;
            }

            Thread backgroundThread = new Thread(
                new ThreadStart(() =>
                {
                    isProcessRunning = true;

                    for (int n = 0; n < 100; n++)
                    {
                        Thread.Sleep(50);
                        progressBar1.BeginInvoke(
                            new Action(() =>
                            {
                                progressBar1.Value = n;
                            }
                        ));
                    }

                    MessageBox.Show("Thread completed!");
                    progressBar1.BeginInvoke(
                            new Action(() =>
                            {
                                progressBar1.Value = 0;
                            }
                    ));

                    isProcessRunning = false;
                }
            ));
            backgroundThread.Start();
        }
    }
}
