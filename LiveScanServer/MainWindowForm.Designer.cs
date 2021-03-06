﻿namespace KinectServer
{
    partial class MainWindowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btStart = new System.Windows.Forms.Button();
            this.btCalibrate = new System.Windows.Forms.Button();
            this.btRecord = new System.Windows.Forms.Button();
            this.lClientListBox = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.recordingWorker = new System.ComponentModel.BackgroundWorker();
            this.txtSeqName = new System.Windows.Forms.TextBox();
            this.btRefineCalib = new System.Windows.Forms.Button();
            this.OpenGLWorker = new System.ComponentModel.BackgroundWorker();
            this.savingWorker = new System.ComponentModel.BackgroundWorker();
            this.updateWorker = new System.ComponentModel.BackgroundWorker();
            this.btShowLive = new System.Windows.Forms.Button();
            this.btSettings = new System.Windows.Forms.Button();
            this.refineWorker = new System.ComponentModel.BackgroundWorker();
            this.lbSeqName = new System.Windows.Forms.Label();
            this.btStartStreaming = new System.Windows.Forms.Button();
            this.streamWithSpout = new System.Windows.Forms.CheckBox();
            this.spoutSettingsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textureWidth = new System.Windows.Forms.NumericUpDown();
            this.textureHeight = new System.Windows.Forms.NumericUpDown();
            this.textureDelim = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textureWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textureHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(28, 27);
            this.btStart.Margin = new System.Windows.Forms.Padding(7);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(222, 51);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Start server";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btCalibrate
            // 
            this.btCalibrate.Location = new System.Drawing.Point(28, 156);
            this.btCalibrate.Margin = new System.Windows.Forms.Padding(7);
            this.btCalibrate.Name = "btCalibrate";
            this.btCalibrate.Size = new System.Drawing.Size(222, 51);
            this.btCalibrate.TabIndex = 2;
            this.btCalibrate.Text = "Calibrate";
            this.btCalibrate.UseVisualStyleBackColor = true;
            this.btCalibrate.Click += new System.EventHandler(this.btCalibrate_Click);
            // 
            // btRecord
            // 
            this.btRecord.Location = new System.Drawing.Point(287, 344);
            this.btRecord.Margin = new System.Windows.Forms.Padding(7);
            this.btRecord.Name = "btRecord";
            this.btRecord.Size = new System.Drawing.Size(222, 51);
            this.btRecord.TabIndex = 4;
            this.btRecord.Text = "Start recording";
            this.btRecord.UseVisualStyleBackColor = true;
            this.btRecord.Click += new System.EventHandler(this.btRecord_Click);
            // 
            // lClientListBox
            // 
            this.lClientListBox.FormattingEnabled = true;
            this.lClientListBox.HorizontalScrollbar = true;
            this.lClientListBox.ItemHeight = 29;
            this.lClientListBox.Location = new System.Drawing.Point(264, 27);
            this.lClientListBox.Margin = new System.Windows.Forms.Padding(7);
            this.lClientListBox.Name = "lClientListBox";
            this.lClientListBox.Size = new System.Drawing.Size(506, 236);
            this.lClientListBox.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 663);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 33, 0);
            this.statusStrip1.Size = new System.Drawing.Size(803, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 11);
            // 
            // recordingWorker
            // 
            this.recordingWorker.WorkerSupportsCancellation = true;
            this.recordingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.recordingWorker_DoWork);
            this.recordingWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.recordingWorker_RunWorkerCompleted);
            // 
            // txtSeqName
            // 
            this.txtSeqName.Location = new System.Drawing.Point(523, 350);
            this.txtSeqName.Margin = new System.Windows.Forms.Padding(7);
            this.txtSeqName.MaxLength = 40;
            this.txtSeqName.Name = "txtSeqName";
            this.txtSeqName.Size = new System.Drawing.Size(242, 35);
            this.txtSeqName.TabIndex = 7;
            this.txtSeqName.Text = "noname";
            // 
            // btRefineCalib
            // 
            this.btRefineCalib.Location = new System.Drawing.Point(28, 216);
            this.btRefineCalib.Margin = new System.Windows.Forms.Padding(7);
            this.btRefineCalib.Name = "btRefineCalib";
            this.btRefineCalib.Size = new System.Drawing.Size(222, 51);
            this.btRefineCalib.TabIndex = 11;
            this.btRefineCalib.Text = "Refine calib";
            this.btRefineCalib.UseVisualStyleBackColor = true;
            this.btRefineCalib.Click += new System.EventHandler(this.btRefineCalib_Click);
            // 
            // OpenGLWorker
            // 
            this.OpenGLWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OpenGLWorker_DoWork);
            this.OpenGLWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OpenGLWorker_RunWorkerCompleted);
            // 
            // savingWorker
            // 
            this.savingWorker.WorkerSupportsCancellation = true;
            this.savingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.savingWorker_DoWork);
            this.savingWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.savingWorker_RunWorkerCompleted);
            // 
            // updateWorker
            // 
            this.updateWorker.WorkerSupportsCancellation = true;
            this.updateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateWorker_DoWork);
            // 
            // btShowLive
            // 
            this.btShowLive.Location = new System.Drawing.Point(28, 344);
            this.btShowLive.Margin = new System.Windows.Forms.Padding(7);
            this.btShowLive.Name = "btShowLive";
            this.btShowLive.Size = new System.Drawing.Size(222, 51);
            this.btShowLive.TabIndex = 12;
            this.btShowLive.Text = "Show live";
            this.btShowLive.UseVisualStyleBackColor = true;
            this.btShowLive.Click += new System.EventHandler(this.btShowLive_Click);
            // 
            // btSettings
            // 
            this.btSettings.Location = new System.Drawing.Point(28, 91);
            this.btSettings.Margin = new System.Windows.Forms.Padding(7);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(222, 51);
            this.btSettings.TabIndex = 13;
            this.btSettings.Text = "Settings";
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // refineWorker
            // 
            this.refineWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.refineWorker_DoWork);
            this.refineWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.refineWorker_RunWorkerCompleted);
            // 
            // lbSeqName
            // 
            this.lbSeqName.AutoSize = true;
            this.lbSeqName.Location = new System.Drawing.Point(523, 308);
            this.lbSeqName.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbSeqName.Name = "lbSeqName";
            this.lbSeqName.Size = new System.Drawing.Size(195, 29);
            this.lbSeqName.TabIndex = 14;
            this.lbSeqName.Text = "Sequence name:";
            // 
            // btStartStreaming
            // 
            this.btStartStreaming.Location = new System.Drawing.Point(28, 281);
            this.btStartStreaming.Margin = new System.Windows.Forms.Padding(7);
            this.btStartStreaming.Name = "btStartStreaming";
            this.btStartStreaming.Size = new System.Drawing.Size(222, 51);
            this.btStartStreaming.TabIndex = 12;
            this.btStartStreaming.Text = "Start streaming";
            this.btStartStreaming.UseVisualStyleBackColor = true;
            this.btStartStreaming.Click += new System.EventHandler(this.btStartStreaming_Click);
            // 
            // streamWithSpout
            // 
            this.streamWithSpout.AutoSize = true;
            this.streamWithSpout.Checked = true;
            this.streamWithSpout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.streamWithSpout.Location = new System.Drawing.Point(28, 494);
            this.streamWithSpout.Name = "streamWithSpout";
            this.streamWithSpout.Size = new System.Drawing.Size(281, 33);
            this.streamWithSpout.TabIndex = 15;
            this.streamWithSpout.Text = "Spout stream enabled";
            this.streamWithSpout.UseVisualStyleBackColor = true;
            this.streamWithSpout.CheckedChanged += new System.EventHandler(this.streamWithSpout_CheckedChanged);
            // 
            // spoutSettingsLabel
            // 
            this.spoutSettingsLabel.AutoSize = true;
            this.spoutSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spoutSettingsLabel.Location = new System.Drawing.Point(23, 436);
            this.spoutSettingsLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.spoutSettingsLabel.Name = "spoutSettingsLabel";
            this.spoutSettingsLabel.Size = new System.Drawing.Size(179, 29);
            this.spoutSettingsLabel.TabIndex = 16;
            this.spoutSettingsLabel.Text = "Spout settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(440, 602);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Transfer threads:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(645, 596);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 35);
            this.numericUpDown1.TabIndex = 20;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // textureWidth
            // 
            this.textureWidth.Increment = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.textureWidth.Location = new System.Drawing.Point(28, 596);
            this.textureWidth.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.textureWidth.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.textureWidth.Name = "textureWidth";
            this.textureWidth.Size = new System.Drawing.Size(120, 35);
            this.textureWidth.TabIndex = 21;
            this.textureWidth.Value = new decimal(new int[] {
            648,
            0,
            0,
            0});
            this.textureWidth.ValueChanged += new System.EventHandler(this.textureWidth_ValueChanged);
            // 
            // textureHeight
            // 
            this.textureHeight.Location = new System.Drawing.Point(192, 596);
            this.textureHeight.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.textureHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textureHeight.Name = "textureHeight";
            this.textureHeight.Size = new System.Drawing.Size(120, 35);
            this.textureHeight.TabIndex = 22;
            this.textureHeight.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.textureHeight.ValueChanged += new System.EventHandler(this.textureHeight_ValueChanged);
            // 
            // textureDelim
            // 
            this.textureDelim.AutoSize = true;
            this.textureDelim.Location = new System.Drawing.Point(158, 602);
            this.textureDelim.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.textureDelim.Name = "textureDelim";
            this.textureDelim.Size = new System.Drawing.Size(24, 29);
            this.textureDelim.TabIndex = 23;
            this.textureDelim.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 553);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 29);
            this.label2.TabIndex = 24;
            this.label2.Text = "Texture size:";
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 685);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textureDelim);
            this.Controls.Add(this.textureHeight);
            this.Controls.Add(this.textureWidth);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spoutSettingsLabel);
            this.Controls.Add(this.streamWithSpout);
            this.Controls.Add(this.lbSeqName);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.btStartStreaming);
            this.Controls.Add(this.btShowLive);
            this.Controls.Add(this.btRefineCalib);
            this.Controls.Add(this.txtSeqName);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lClientListBox);
            this.Controls.Add(this.btRecord);
            this.Controls.Add(this.btCalibrate);
            this.Controls.Add(this.btStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "MainWindowForm";
            this.Text = "LiveScanServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textureWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textureHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btCalibrate;
        private System.Windows.Forms.Button btRecord;
        private System.Windows.Forms.ListBox lClientListBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker recordingWorker;
        private System.Windows.Forms.TextBox txtSeqName;
        private System.Windows.Forms.Button btRefineCalib;
        private System.ComponentModel.BackgroundWorker OpenGLWorker;
        private System.ComponentModel.BackgroundWorker savingWorker;
        private System.ComponentModel.BackgroundWorker updateWorker;
        private System.Windows.Forms.Button btShowLive;
        private System.Windows.Forms.Button btSettings;
        private System.ComponentModel.BackgroundWorker refineWorker;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label lbSeqName;
        private System.Windows.Forms.Button btStartStreaming;
        private System.Windows.Forms.CheckBox streamWithSpout;
        private System.Windows.Forms.Label spoutSettingsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown textureWidth;
        private System.Windows.Forms.NumericUpDown textureHeight;
        private System.Windows.Forms.Label textureDelim;
        private System.Windows.Forms.Label label2;
    }
}

