using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using EyeXFramework;

namespace Lamberto_Valli_C_Sharp
{
    public partial class Form1 : Form
    {
        private int baudRate = 9600;
        private int delayTime = 40;
        private string portName = "";
        private string selected = "";
        private const string simolsFolderName = "simboli";
        // TODO chenge folder name "/immagini" to avoid misunderstand with system folder 
        private String folderPath = Application.StartupPath + "/" + simolsFolderName;
        
        # region Initialization
        public Form1()
        {
            InitializeComponent();

            // Add eye-gaze interaction behaviors to the panels on the form
            Program.EyeXHost.Connect(behaviorMap1);
            behaviorMap1.Add(panelSX, new GazeAwareBehavior(OnGaze));
            behaviorMap1.Add(panelDX, new GazeAwareBehavior(OnGaze));
            //behaviorMap1.Add(panel3, new GazeAwareBehavior(OnGaze) { DelayMilliseconds = 500 });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateFoldersList();
            ScanComPort();
        }

        // Arduino "usual" use the port with highest index
        // TODO: recognize Arduino COM port
        private void ScanComPort()
        {
            foreach (string item in System.IO.Ports.SerialPort.GetPortNames())
            {
                portName = item;
            }
            if  (portName != "")
            {
                serialPort1.PortName = portName;
                serialPort1.BaudRate = baudRate;
            }
            else
            {
                MessageBox.Show("La scatola di controllo non è stata collegata");
            }
        }
                
        private void PopulateFoldersList()
        {
            // check if folder exists, otherwise create it
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            
            DirectoryInfo dinfo = new DirectoryInfo(folderPath);
            foreach (DirectoryInfo dir in dinfo.GetDirectories())
            {
                foldersList.Items.Add(dir.Name);
            }

            // if listbox not empty, select first item
            if (foldersList.Items.Count > 0)
            {
                foldersList.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Mancano le cartelle delle immagini in " + folderPath);
            }
        }
        #endregion


        # region Arduino and comunication

        // Write "as is" to the COM port
        void SendCommands(String commands)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.Write(commands);
                    serialPort1.Close();
                }
                catch
                {
                    MessageBox.Show("La scatola di controllo non è stata collegata");
                }
            }
        }
        
        private void checkForCommand(string imageName)
        {
            if (imageName.StartsWith("+")) SendCommands("on\r");
            if (imageName.StartsWith("-")) SendCommands("off\r");
        }
        #endregion


        # region Test purpose
        // Usefull for test purpose
        private void pictureBoxSX_Click(object sender, EventArgs e)
        {
            selected_SX();
        }
                
        private void pictureBoxDX_Click(object sender, EventArgs e)
        {
            selected_DX();
        }

        private void pictureBoxSX_MouseEnter(object sender, EventArgs e)
        {
            aim(pictureBoxSX.Tag.ToString(), progressBarSX, backgroundWorkerSX);
        }

        private void pictureBoxSX_MouseLeave(object sender, EventArgs e)
        {
            leave(backgroundWorkerSX,progressBarSX);
        }

        private void pictureBoxDX_MouseEnter(object sender, EventArgs e)
        {
            aim(pictureBoxDX.Tag.ToString(), progressBarDX, backgroundWorkerDX);
        }
        
        private void pictureBoxDX_MouseLeave(object sender, EventArgs e)
        {
            leave(backgroundWorkerDX, progressBarDX);
        }
        # endregion


        # region Business logic

        private void foldersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateImages();
        }

        // TODO: improve robustness, manage missed pictures and so on
        private void UpdateImages()
        {
            string folderName = foldersList.SelectedItem.ToString();
            string folderSelected = folderPath + "\\" + folderName;
            DirectoryInfo dinfo = new DirectoryInfo(folderSelected);
            FileInfo[] Files = dinfo.GetFiles("*.*");
            pictureBoxSX.Tag = "";
            pictureBoxDX.Tag = "";
            pictureBoxSX.Image = null;
            pictureBoxDX.Image = null;
            try
            {
                pictureBoxSX.Image = Image.FromFile(Files[0].FullName);
                pictureBoxSX.Tag = Files[0].Name;
                pictureBoxDX.Image = Image.FromFile(Files[1].FullName);
                pictureBoxDX.Tag = Files[1].Name;
            }
            catch
            {
                MessageBox.Show("La cartella " + folderName + " non contiene 2 immagini in \n" + folderSelected,
                    "Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void selected_SX()
        {
            checkForCommand(pictureBoxSX.Tag.ToString());
        }
        
        private void selected_DX()
        {
            checkForCommand(pictureBoxDX.Tag.ToString());
            
        }
        
        private void aim(string actualSelected, ProgressBar pb, BackgroundWorker bgw)
        {
            selected = actualSelected;
            pb.Maximum = 100;
            pb.Step = 1;
            pb.Value = 0;
            if (!bgw.IsBusy) bgw.RunWorkerAsync();   
        }
        
        private void leave(BackgroundWorker bgw,ProgressBar pb)
        {
            selected = "";
            //Check if background worker is doing anything and send a cancellation if it is
            if (bgw.IsBusy)
            {
                bgw.CancelAsync();
            }
            pb.Value = 0;
        }
        

        private void OnGaze(object sender, GazeAwareEventArgs e)
        {
            var panel = sender as Panel;
            if (panel != null)
            {
                if (e.HasGaze)
                {
                    //aim
                     panel.BorderStyle = BorderStyle.FixedSingle;
                    if (panel.Name == "panelSX")
                    {
                        aim(pictureBoxSX.Tag.ToString(), progressBarSX, backgroundWorkerSX);
                        leave(backgroundWorkerDX, progressBarDX);
                    }
                    if (panel.Name == "panelDX")
                    {
                        aim(pictureBoxDX.Tag.ToString(), progressBarDX, backgroundWorkerDX);
                        leave(backgroundWorkerSX, progressBarSX);
                    }
                }
                else
                {
                    //leaved
                    panel.BorderStyle = BorderStyle.None;
                    if (panel.Name == "panelSX")
                    {
                        leave(backgroundWorkerSX, progressBarSX);
                    }
                    if (panel.Name == "panelDX")
                    {
                        leave(backgroundWorkerDX, progressBarDX);
                    }
                }
            }
        }
        # endregion


        # region Progressbar

        private void backgroundWorkerSX_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBarSX.Value = e.ProgressPercentage;
        }
        
        private void backgroundWorkerSX_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //lblStatus.Text = "Process was cancelled";
            }
            else if (e.Error != null)
            {
                //lblStatus.Text = "There was an error running the process. The thread aborted";
            }
            else
            {
                //lblStatus.Text = "Process was completed";
                selected_SX();
            }
        }
        
        private void backgroundWorkerDX_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //lblStatus.Text = "Process was cancelled";
            }
            else if (e.Error != null)
            {
                //lblStatus.Text = "There was an error running the process. The thread aborted";
            }
            else
            {
                //lblStatus.Text = "Process was completed";
                selected_DX();
            }
        }

        private void backgroundWorkerDX_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarDX.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerDX_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(delayTime);
                backgroundWorkerDX.ReportProgress(i);
                //Check if there is a request to cancel the process
                if (backgroundWorkerDX.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorkerDX.ReportProgress(0);
                    return;
                }
            }
            //If the process exits the loop, ensure that progress is set to 100%
            //Remember in the loop we set i < 100 so in theory the process will complete at 99%
            backgroundWorkerDX.ReportProgress(100);
        }
        
        private void backgroundWorkerSX_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(delayTime);
                backgroundWorkerSX.ReportProgress(i);
                //Check if there is a request to cancel the process
                if (backgroundWorkerSX.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorkerSX.ReportProgress(0);
                    return;
                }
            }
            //If the process exits the loop, ensure that progress is set to 100%
            //Remember in the loop we set i < 100 so in theory the process will complete at 99%
            backgroundWorkerSX.ReportProgress(100);
        }
        # endregion
    }
}
