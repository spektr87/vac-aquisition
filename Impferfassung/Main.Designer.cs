
namespace Impferfassung
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbToolsRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssiAbout = new System.Windows.Forms.ToolStripSplitButton();
            this.dgvVaccinationSlots = new System.Windows.Forms.DataGridView();
            this.cmsVaccinationSlots = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiVacSlotsNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVacSlotsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVacSlotsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSplitter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVaccinees = new System.Windows.Forms.DataGridView();
            this.tboSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinationSlots)).BeginInit();
            this.cmsVaccinationSlots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinees)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbToolsRefresh,
            this.toolStripButton1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsbToolsRefresh
            // 
            this.tsbToolsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbToolsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbToolsRefresh.Image")));
            this.tsbToolsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToolsRefresh.Name = "tsbToolsRefresh";
            this.tsbToolsRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbToolsRefresh.Text = "Aktualisieren";
            this.tsbToolsRefresh.Click += new System.EventHandler(this.TsbToolsRefresh_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tssiAbout});
            this.statusStrip.Location = new System.Drawing.Point(0, 615);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Impftag:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(1080, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // tssiAbout
            // 
            this.tssiAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssiAbout.DropDownButtonWidth = 0;
            this.tssiAbout.Image = ((System.Drawing.Image)(resources.GetObject("tssiAbout.Image")));
            this.tssiAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssiAbout.Name = "tssiAbout";
            this.tssiAbout.Size = new System.Drawing.Size(37, 20);
            this.tssiAbout.Text = "Über";
            this.tssiAbout.ButtonClick += new System.EventHandler(this.TssiAbout_ButtonClick);
            // 
            // dgvVaccinationSlots
            // 
            this.dgvVaccinationSlots.AllowUserToAddRows = false;
            this.dgvVaccinationSlots.AllowUserToDeleteRows = false;
            this.dgvVaccinationSlots.AllowUserToResizeRows = false;
            this.dgvVaccinationSlots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvVaccinationSlots.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvVaccinationSlots.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVaccinationSlots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccinationSlots.ContextMenuStrip = this.cmsVaccinationSlots;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVaccinationSlots.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVaccinationSlots.Location = new System.Drawing.Point(10, 50);
            this.dgvVaccinationSlots.MultiSelect = false;
            this.dgvVaccinationSlots.Name = "dgvVaccinationSlots";
            this.dgvVaccinationSlots.RowHeadersVisible = false;
            this.dgvVaccinationSlots.RowTemplate.Height = 25;
            this.dgvVaccinationSlots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVaccinationSlots.Size = new System.Drawing.Size(206, 550);
            this.dgvVaccinationSlots.TabIndex = 3;
            this.dgvVaccinationSlots.SelectionChanged += new System.EventHandler(this.DgvVaccinationSlots_SelectionChanged);
            this.dgvVaccinationSlots.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvVaccinationSlots_MouseDown);
            // 
            // cmsVaccinationSlots
            // 
            this.cmsVaccinationSlots.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVacSlotsNew,
            this.tsmiVacSlotsEdit,
            this.tsmiVacSlotsDelete});
            this.cmsVaccinationSlots.Name = "cmsVaccinationSlots";
            this.cmsVaccinationSlots.Size = new System.Drawing.Size(140, 70);
            // 
            // tsmiVacSlotsNew
            // 
            this.tsmiVacSlotsNew.Name = "tsmiVacSlotsNew";
            this.tsmiVacSlotsNew.Size = new System.Drawing.Size(139, 22);
            this.tsmiVacSlotsNew.Text = "Neu...";
            this.tsmiVacSlotsNew.Click += new System.EventHandler(this.TsmiVacSlotsNew_Click);
            // 
            // tsmiVacSlotsEdit
            // 
            this.tsmiVacSlotsEdit.Name = "tsmiVacSlotsEdit";
            this.tsmiVacSlotsEdit.Size = new System.Drawing.Size(139, 22);
            this.tsmiVacSlotsEdit.Text = "Bearbeiten...";
            this.tsmiVacSlotsEdit.Click += new System.EventHandler(this.TsmiVacSlotsEdit_Click);
            // 
            // tsmiVacSlotsDelete
            // 
            this.tsmiVacSlotsDelete.Name = "tsmiVacSlotsDelete";
            this.tsmiVacSlotsDelete.Size = new System.Drawing.Size(139, 22);
            this.tsmiVacSlotsDelete.Text = "Löschen";
            this.tsmiVacSlotsDelete.Click += new System.EventHandler(this.TsmiVacSlotsDelete_Click);
            // 
            // pnlSplitter
            // 
            this.pnlSplitter.BackColor = System.Drawing.Color.Black;
            this.pnlSplitter.Location = new System.Drawing.Point(230, 45);
            this.pnlSplitter.Name = "pnlSplitter";
            this.pnlSplitter.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pnlSplitter.Size = new System.Drawing.Size(1, 560);
            this.pnlSplitter.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Impfslots";
            // 
            // dgvVaccinees
            // 
            this.dgvVaccinees.AllowUserToAddRows = false;
            this.dgvVaccinees.AllowUserToDeleteRows = false;
            this.dgvVaccinees.AllowUserToResizeRows = false;
            this.dgvVaccinees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVaccinees.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvVaccinees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVaccinees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccinees.ContextMenuStrip = this.cmsVaccinationSlots;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVaccinees.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVaccinees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvVaccinees.Location = new System.Drawing.Point(243, 50);
            this.dgvVaccinees.Name = "dgvVaccinees";
            this.dgvVaccinees.RowHeadersVisible = false;
            this.dgvVaccinees.RowTemplate.Height = 25;
            this.dgvVaccinees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvVaccinees.Size = new System.Drawing.Size(929, 550);
            this.dgvVaccinees.TabIndex = 6;
            this.dgvVaccinees.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVaccinees_CellValueChanged);
            this.dgvVaccinees.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvVaccinees_DataBindingComplete);
            this.dgvVaccinees.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvVaccinees_DataError);
            // 
            // tboSearch
            // 
            this.tboSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tboSearch.Location = new System.Drawing.Point(1003, 12);
            this.tboSearch.Name = "tboSearch";
            this.tboSearch.Size = new System.Drawing.Size(169, 23);
            this.tboSearch.TabIndex = 7;
            this.tboSearch.TextChanged += new System.EventHandler(this.TboSearch_TextChanged);
            this.tboSearch.Enter += new System.EventHandler(this.TboSearch_Enter);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(955, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 15);
            this.lblSearch.TabIndex = 8;
            this.lblSearch.Text = "Suche:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 637);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.tboSearch);
            this.Controls.Add(this.dgvVaccinees);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlSplitter);
            this.Controls.Add(this.dgvVaccinationSlots);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "THW COVID19 Helfererfassung";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinationSlots)).EndInit();
            this.cmsVaccinationSlots.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.DataGridView dgvVaccinationSlots;
        private System.Windows.Forms.ToolStripButton tsbToolsRefresh;
        private System.Windows.Forms.Panel pnlSplitter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsVaccinationSlots;
        private System.Windows.Forms.ToolStripMenuItem tsmiVacSlotsNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiVacSlotsEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiVacSlotsDelete;
        private System.Windows.Forms.DataGridView dgvVaccinees;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripSplitButton tssiAbout;
        private System.Windows.Forms.TextBox tboSearch;
        private System.Windows.Forms.Label lblSearch;
    }
}

