namespace Lamberto_Valli_C_Sharp
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBoxSX = new System.Windows.Forms.PictureBox();
            this.pictureBoxDX = new System.Windows.Forms.PictureBox();
            this.progressBarSX = new System.Windows.Forms.ProgressBar();
            this.progressBarDX = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerSX = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDX = new System.ComponentModel.BackgroundWorker();
            this.behaviorMap1 = new EyeXFramework.Forms.BehaviorMap(this.components);
            this.panelSX = new System.Windows.Forms.Panel();
            this.panelDX = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDX)).BeginInit();
            this.panelSX.SuspendLayout();
            this.panelDX.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(276, 444);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBoxSX
            // 
            this.pictureBoxSX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSX.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxSX.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxSX.Name = "pictureBoxSX";
            this.pictureBoxSX.Size = new System.Drawing.Size(389, 404);
            this.pictureBoxSX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSX.TabIndex = 3;
            this.pictureBoxSX.TabStop = false;
            this.pictureBoxSX.Click += new System.EventHandler(this.pictureBoxSX_Click);
            this.pictureBoxSX.MouseEnter += new System.EventHandler(this.pictureBoxSX_MouseEnter);
            this.pictureBoxSX.MouseLeave += new System.EventHandler(this.pictureBoxSX_MouseLeave);
            // 
            // pictureBoxDX
            // 
            this.pictureBoxDX.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxDX.Name = "pictureBoxDX";
            this.pictureBoxDX.Size = new System.Drawing.Size(392, 404);
            this.pictureBoxDX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDX.TabIndex = 4;
            this.pictureBoxDX.TabStop = false;
            this.pictureBoxDX.Click += new System.EventHandler(this.pictureBoxDX_Click);
            this.pictureBoxDX.MouseEnter += new System.EventHandler(this.pictureBoxDX_MouseEnter);
            this.pictureBoxDX.MouseLeave += new System.EventHandler(this.pictureBoxDX_MouseLeave);
            // 
            // progressBarSX
            // 
            this.progressBarSX.Location = new System.Drawing.Point(3, 413);
            this.progressBarSX.Name = "progressBarSX";
            this.progressBarSX.Size = new System.Drawing.Size(389, 23);
            this.progressBarSX.Step = 1;
            this.progressBarSX.TabIndex = 5;
            // 
            // progressBarDX
            // 
            this.progressBarDX.Location = new System.Drawing.Point(3, 413);
            this.progressBarDX.Name = "progressBarDX";
            this.progressBarDX.Size = new System.Drawing.Size(389, 23);
            this.progressBarDX.TabIndex = 6;
            // 
            // backgroundWorkerSX
            // 
            this.backgroundWorkerSX.WorkerReportsProgress = true;
            this.backgroundWorkerSX.WorkerSupportsCancellation = true;
            this.backgroundWorkerSX.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSX_DoWork);
            this.backgroundWorkerSX.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSX_ProgressChanged);
            this.backgroundWorkerSX.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSX_RunWorkerCompleted);
            // 
            // backgroundWorkerDX
            // 
            this.backgroundWorkerDX.WorkerReportsProgress = true;
            this.backgroundWorkerDX.WorkerSupportsCancellation = true;
            this.backgroundWorkerDX.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDX_DoWork);
            this.backgroundWorkerDX.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDX_ProgressChanged);
            this.backgroundWorkerDX.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDX_RunWorkerCompleted);
            // 
            // panelSX
            // 
            this.panelSX.Controls.Add(this.pictureBoxSX);
            this.panelSX.Controls.Add(this.progressBarSX);
            this.panelSX.Location = new System.Drawing.Point(294, 12);
            this.panelSX.Name = "panelSX";
            this.panelSX.Size = new System.Drawing.Size(395, 444);
            this.panelSX.TabIndex = 8;
            // 
            // panelDX
            // 
            this.panelDX.Controls.Add(this.pictureBoxDX);
            this.panelDX.Controls.Add(this.progressBarDX);
            this.panelDX.Location = new System.Drawing.Point(695, 12);
            this.panelDX.Name = "panelDX";
            this.panelDX.Size = new System.Drawing.Size(395, 444);
            this.panelDX.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 531);
            this.Controls.Add(this.panelDX);
            this.Controls.Add(this.panelSX);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Lamberto Valli";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDX)).EndInit();
            this.panelSX.ResumeLayout(false);
            this.panelDX.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBoxSX;
        private System.Windows.Forms.PictureBox pictureBoxDX;
        private System.Windows.Forms.ProgressBar progressBarSX;
        private System.Windows.Forms.ProgressBar progressBarDX;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSX;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDX;
        private EyeXFramework.Forms.BehaviorMap behaviorMap1;
        private System.Windows.Forms.Panel panelSX;
        private System.Windows.Forms.Panel panelDX;
    }
}

