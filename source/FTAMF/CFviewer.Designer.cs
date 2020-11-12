namespace FTAMF
{
    partial class CFviewer
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.txtClsID = new System.Windows.Forms.Label();
			this.txtLastAccess = new System.Windows.Forms.Label();
			this.txtCreationDate = new System.Windows.Forms.Label();
			this.txtModifyDate = new System.Windows.Forms.Label();
			this.txtSize = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.Label();
			this.lblClaseID = new System.Windows.Forms.Label();
			this.lblFechaUltAcceso = new System.Windows.Forms.Label();
			this.lblFechaCreacion = new System.Windows.Forms.Label();
			this.lblFechaUltMod = new System.Windows.Forms.Label();
			this.lblTamaño = new System.Windows.Forms.Label();
			this.lblNombre = new System.Windows.Forms.Label();
			this.tabHexViewer = new System.Windows.Forms.TabPage();
			this.tabTextViewer = new System.Windows.Forms.TabPage();
			this.RtfViewer = new System.Windows.Forms.RichTextBox();
			this.tabImageViewer = new System.Windows.Forms.TabPage();
			this.TxtDimensions = new System.Windows.Forms.Label();
			this.TxtResolution = new System.Windows.Forms.Label();
			this.BtnSaveImage = new System.Windows.Forms.Button();
			this.ImageViewer = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabTextViewer.SuspendLayout();
			this.tabImageViewer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.ImageViewer).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.treeView1);
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Size = new System.Drawing.Size(664, 365);
			this.splitContainer1.SplitterDistance = 220;
			this.splitContainer1.TabIndex = 0;
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.treeView1.HideSelection = false;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(220, 365);
			this.treeView1.TabIndex = 6;
			this.treeView1.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeCollapse);
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeExpand);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
			this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseDoubleClick);
			this.tabControl1.Controls.Add(this.tabGeneral);
			this.tabControl1.Controls.Add(this.tabHexViewer);
			this.tabControl1.Controls.Add(this.tabTextViewer);
			this.tabControl1.Controls.Add(this.tabImageViewer);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(440, 365);
			this.tabControl1.TabIndex = 1;
			this.tabGeneral.Controls.Add(this.txtClsID);
			this.tabGeneral.Controls.Add(this.txtLastAccess);
			this.tabGeneral.Controls.Add(this.txtCreationDate);
			this.tabGeneral.Controls.Add(this.txtModifyDate);
			this.tabGeneral.Controls.Add(this.txtSize);
			this.tabGeneral.Controls.Add(this.txtName);
			this.tabGeneral.Controls.Add(this.lblClaseID);
			this.tabGeneral.Controls.Add(this.lblFechaUltAcceso);
			this.tabGeneral.Controls.Add(this.lblFechaCreacion);
			this.tabGeneral.Controls.Add(this.lblFechaUltMod);
			this.tabGeneral.Controls.Add(this.lblTamaño);
			this.tabGeneral.Controls.Add(this.lblNombre);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(432, 339);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "General";
			this.tabGeneral.UseVisualStyleBackColor = true;
			this.txtClsID.AutoSize = true;
			this.txtClsID.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtClsID.Location = new System.Drawing.Point(190, 153);
			this.txtClsID.Name = "txtClsID";
			this.txtClsID.Size = new System.Drawing.Size(22, 15);
			this.txtClsID.TabIndex = 21;
			this.txtClsID.Text = "???";
			this.txtLastAccess.AutoSize = true;
			this.txtLastAccess.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtLastAccess.Location = new System.Drawing.Point(190, 123);
			this.txtLastAccess.Name = "txtLastAccess";
			this.txtLastAccess.Size = new System.Drawing.Size(22, 15);
			this.txtLastAccess.TabIndex = 19;
			this.txtLastAccess.Text = "???";
			this.txtCreationDate.AutoSize = true;
			this.txtCreationDate.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtCreationDate.Location = new System.Drawing.Point(190, 108);
			this.txtCreationDate.Name = "txtCreationDate";
			this.txtCreationDate.Size = new System.Drawing.Size(22, 15);
			this.txtCreationDate.TabIndex = 18;
			this.txtCreationDate.Text = "???";
			this.txtModifyDate.AutoSize = true;
			this.txtModifyDate.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtModifyDate.Location = new System.Drawing.Point(190, 93);
			this.txtModifyDate.Name = "txtModifyDate";
			this.txtModifyDate.Size = new System.Drawing.Size(22, 15);
			this.txtModifyDate.TabIndex = 17;
			this.txtModifyDate.Text = "???";
			this.txtSize.AutoSize = true;
			this.txtSize.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtSize.Location = new System.Drawing.Point(190, 48);
			this.txtSize.Name = "txtSize";
			this.txtSize.Size = new System.Drawing.Size(22, 15);
			this.txtSize.TabIndex = 14;
			this.txtSize.Text = "???";
			this.txtName.AutoSize = true;
			this.txtName.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtName.Location = new System.Drawing.Point(190, 18);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(22, 15);
			this.txtName.TabIndex = 12;
			this.txtName.Text = "???";
			this.lblClaseID.AutoSize = true;
			this.lblClaseID.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblClaseID.Location = new System.Drawing.Point(21, 153);
			this.lblClaseID.Name = "lblClaseID";
			this.lblClaseID.Size = new System.Drawing.Size(47, 15);
			this.lblClaseID.TabIndex = 9;
			this.lblClaseID.Text = "Class Id";
			this.lblFechaUltAcceso.AutoSize = true;
			this.lblFechaUltAcceso.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblFechaUltAcceso.Location = new System.Drawing.Point(21, 123);
			this.lblFechaUltAcceso.Name = "lblFechaUltAcceso";
			this.lblFechaUltAcceso.Size = new System.Drawing.Size(68, 15);
			this.lblFechaUltAcceso.TabIndex = 7;
			this.lblFechaUltAcceso.Text = "Last access:";
			this.lblFechaCreacion.AutoSize = true;
			this.lblFechaCreacion.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblFechaCreacion.Location = new System.Drawing.Point(21, 108);
			this.lblFechaCreacion.Name = "lblFechaCreacion";
			this.lblFechaCreacion.Size = new System.Drawing.Size(51, 15);
			this.lblFechaCreacion.TabIndex = 6;
			this.lblFechaCreacion.Text = "Created:";
			this.lblFechaUltMod.AutoSize = true;
			this.lblFechaUltMod.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblFechaUltMod.Location = new System.Drawing.Point(21, 93);
			this.lblFechaUltMod.Name = "lblFechaUltMod";
			this.lblFechaUltMod.Size = new System.Drawing.Size(58, 15);
			this.lblFechaUltMod.TabIndex = 5;
			this.lblFechaUltMod.Text = "Modified:";
			this.lblTamaño.AutoSize = true;
			this.lblTamaño.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblTamaño.Location = new System.Drawing.Point(21, 48);
			this.lblTamaño.Name = "lblTamaño";
			this.lblTamaño.Size = new System.Drawing.Size(30, 15);
			this.lblTamaño.TabIndex = 2;
			this.lblTamaño.Text = "Size:";
			this.lblNombre.AutoSize = true;
			this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblNombre.Location = new System.Drawing.Point(21, 18);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(42, 15);
			this.lblNombre.TabIndex = 0;
			this.lblNombre.Text = "Name:";
			this.tabHexViewer.Location = new System.Drawing.Point(4, 22);
			this.tabHexViewer.Name = "tabHexViewer";
			this.tabHexViewer.Padding = new System.Windows.Forms.Padding(3);
			this.tabHexViewer.Size = new System.Drawing.Size(432, 339);
			this.tabHexViewer.TabIndex = 1;
			this.tabHexViewer.Text = "Hex";
			this.tabHexViewer.UseVisualStyleBackColor = true;
			this.tabTextViewer.Controls.Add(this.RtfViewer);
			this.tabTextViewer.Location = new System.Drawing.Point(4, 22);
			this.tabTextViewer.Name = "tabTextViewer";
			this.tabTextViewer.Padding = new System.Windows.Forms.Padding(3);
			this.tabTextViewer.Size = new System.Drawing.Size(432, 339);
			this.tabTextViewer.TabIndex = 2;
			this.tabTextViewer.Text = "Text";
			this.tabTextViewer.UseVisualStyleBackColor = true;
			this.RtfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RtfViewer.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.RtfViewer.Location = new System.Drawing.Point(3, 3);
			this.RtfViewer.Name = "RtfViewer";
			this.RtfViewer.ReadOnly = true;
			this.RtfViewer.Size = new System.Drawing.Size(426, 333);
			this.RtfViewer.TabIndex = 1;
			this.RtfViewer.Text = "";
			this.tabImageViewer.Controls.Add(this.TxtDimensions);
			this.tabImageViewer.Controls.Add(this.TxtResolution);
			this.tabImageViewer.Controls.Add(this.BtnSaveImage);
			this.tabImageViewer.Controls.Add(this.ImageViewer);
			this.tabImageViewer.Location = new System.Drawing.Point(4, 22);
			this.tabImageViewer.Name = "tabImageViewer";
			this.tabImageViewer.Padding = new System.Windows.Forms.Padding(3);
			this.tabImageViewer.Size = new System.Drawing.Size(432, 339);
			this.tabImageViewer.TabIndex = 3;
			this.tabImageViewer.Text = "Image";
			this.tabImageViewer.UseVisualStyleBackColor = true;
			this.TxtDimensions.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.TxtDimensions.AutoSize = true;
			this.TxtDimensions.Location = new System.Drawing.Point(21, 293);
			this.TxtDimensions.Name = "TxtDimensions";
			this.TxtDimensions.Size = new System.Drawing.Size(76, 13);
			this.TxtDimensions.TabIndex = 3;
			this.TxtDimensions.Text = "Dimensions: ...";
			this.TxtResolution.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.TxtResolution.AutoSize = true;
			this.TxtResolution.Location = new System.Drawing.Point(21, 314);
			this.TxtResolution.Name = "TxtResolution";
			this.TxtResolution.Size = new System.Drawing.Size(72, 13);
			this.TxtResolution.TabIndex = 2;
			this.TxtResolution.Text = "Resolution: ...";
			this.BtnSaveImage.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.BtnSaveImage.Location = new System.Drawing.Point(339, 287);
			this.BtnSaveImage.Name = "BtnSaveImage";
			this.BtnSaveImage.Size = new System.Drawing.Size(75, 23);
			this.BtnSaveImage.TabIndex = 1;
			this.BtnSaveImage.Text = "Save";
			this.BtnSaveImage.UseVisualStyleBackColor = true;
			this.BtnSaveImage.Click += new System.EventHandler(this.BtnSaveImage_Click);
			this.ImageViewer.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.ImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ImageViewer.Location = new System.Drawing.Point(6, 6);
			this.ImageViewer.Name = "ImageViewer";
			this.ImageViewer.Size = new System.Drawing.Size(423, 275);
			this.ImageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.ImageViewer.TabIndex = 0;
			this.ImageViewer.TabStop = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(664, 365);
			base.Controls.Add(this.splitContainer1);
			base.Name = "CFviewer";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabGeneral.PerformLayout();
			this.tabTextViewer.ResumeLayout(false);
			this.tabImageViewer.ResumeLayout(false);
			this.tabImageViewer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.ImageViewer).EndInit();
			base.ResumeLayout(false);
		}

		#endregion



		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.Label txtClsID;
		private System.Windows.Forms.Label txtLastAccess;
		private System.Windows.Forms.Label txtCreationDate;
		private System.Windows.Forms.Label txtModifyDate;
		private System.Windows.Forms.Label txtSize;
		private System.Windows.Forms.Label txtName;
		private System.Windows.Forms.Label lblClaseID;
		private System.Windows.Forms.Label lblFechaUltAcceso;
		private System.Windows.Forms.Label lblFechaCreacion;
		private System.Windows.Forms.Label lblFechaUltMod;
		private System.Windows.Forms.Label lblTamaño;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.TabPage tabHexViewer;
		private System.Windows.Forms.TabPage tabTextViewer;
		private System.Windows.Forms.RichTextBox RtfViewer;
		private System.Windows.Forms.TabPage tabImageViewer;
		private System.Windows.Forms.Label TxtDimensions;
		private System.Windows.Forms.Label TxtResolution;
		private System.Windows.Forms.Button BtnSaveImage;
		private System.Windows.Forms.PictureBox ImageViewer;
	}
}