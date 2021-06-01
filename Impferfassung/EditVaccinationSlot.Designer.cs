
namespace Impferfassung
{
    partial class EditVaccinationSlot
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
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.lblDurationMinutes = new System.Windows.Forms.Label();
            this.lblPlannedVaccinees = new System.Windows.Forms.Label();
            this.nudPlannedVaccinees = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlannedVaccinees)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(12, 37);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(101, 23);
            this.dtpStartTime.TabIndex = 0;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.DtpStartTime_ValueChanged);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(12, 19);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(74, 15);
            this.lblStartTime.TabIndex = 1;
            this.lblStartTime.Text = "Start Uhrzeit:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 75);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(41, 15);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Dauer:";
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(12, 93);
            this.nudDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(71, 23);
            this.nudDuration.TabIndex = 2;
            this.nudDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration.ValueChanged += new System.EventHandler(this.NudDuration_ValueChanged);
            // 
            // lblDurationMinutes
            // 
            this.lblDurationMinutes.AutoSize = true;
            this.lblDurationMinutes.Location = new System.Drawing.Point(89, 97);
            this.lblDurationMinutes.Name = "lblDurationMinutes";
            this.lblDurationMinutes.Size = new System.Drawing.Size(52, 15);
            this.lblDurationMinutes.TabIndex = 4;
            this.lblDurationMinutes.Text = "Minuten";
            // 
            // lblPlannedVaccinees
            // 
            this.lblPlannedVaccinees.AutoSize = true;
            this.lblPlannedVaccinees.Location = new System.Drawing.Point(12, 140);
            this.lblPlannedVaccinees.Name = "lblPlannedVaccinees";
            this.lblPlannedVaccinees.Size = new System.Drawing.Size(205, 15);
            this.lblPlannedVaccinees.TabIndex = 5;
            this.lblPlannedVaccinees.Text = "Anzahl zu impfender Helfer (geplant):";
            // 
            // nudPlannedVaccinees
            // 
            this.nudPlannedVaccinees.Location = new System.Drawing.Point(12, 158);
            this.nudPlannedVaccinees.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPlannedVaccinees.Name = "nudPlannedVaccinees";
            this.nudPlannedVaccinees.Size = new System.Drawing.Size(71, 23);
            this.nudPlannedVaccinees.TabIndex = 3;
            this.nudPlannedVaccinees.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPlannedVaccinees.ValueChanged += new System.EventHandler(this.NudPlannedVaccinees_ValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(148, 251);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(229, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm";
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(166, 37);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(101, 23);
            this.dtpEndTime.TabIndex = 1;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(166, 19);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(76, 15);
            this.lblEndTime.TabIndex = 10;
            this.lblEndTime.Text = "Ende Uhrzeit:";
            // 
            // EditVaccinationSlot
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(316, 286);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudPlannedVaccinees);
            this.Controls.Add(this.lblPlannedVaccinees);
            this.Controls.Add(this.lblDurationMinutes);
            this.Controls.Add(this.nudDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.dtpStartTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditVaccinationSlot";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Impfslot bearbeiten";
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlannedVaccinees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.Label lblDurationMinutes;
        private System.Windows.Forms.Label lblPlannedVaccinees;
        private System.Windows.Forms.NumericUpDown nudPlannedVaccinees;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblEndTime;
    }
}