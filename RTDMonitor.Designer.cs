namespace RollTheDice
{
    partial class RTDMonitor
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
            this.components = new System.ComponentModel.Container();
            GlacialComponents.Controls.GLColumn glColumn8 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn9 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn10 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLItem glItem4 = new GlacialComponents.Controls.GLItem();
            GlacialComponents.Controls.GLSubItem glSubItem10 = new GlacialComponents.Controls.GLSubItem();
            GlacialComponents.Controls.GLSubItem glSubItem11 = new GlacialComponents.Controls.GLSubItem();
            GlacialComponents.Controls.GLSubItem glSubItem12 = new GlacialComponents.Controls.GLSubItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RTDMonitor));
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn7 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLItem glItem3 = new GlacialComponents.Controls.GLItem();
            GlacialComponents.Controls.GLSubItem glSubItem7 = new GlacialComponents.Controls.GLSubItem();
            GlacialComponents.Controls.GLSubItem glSubItem8 = new GlacialComponents.Controls.GLSubItem();
            GlacialComponents.Controls.GLSubItem glSubItem9 = new GlacialComponents.Controls.GLSubItem();
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLItem glItem1 = new GlacialComponents.Controls.GLItem();
            GlacialComponents.Controls.GLSubItem glSubItem1 = new GlacialComponents.Controls.GLSubItem();
            GlacialComponents.Controls.GLSubItem glSubItem2 = new GlacialComponents.Controls.GLSubItem();
            GlacialComponents.Controls.GLSubItem glSubItem3 = new GlacialComponents.Controls.GLSubItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.glacialList1 = new GlacialComponents.Controls.GlacialList();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.glacialList2 = new GlacialComponents.Controls.GlacialList();
            this.glacialList3 = new GlacialComponents.Controls.GlacialList();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active Rolls:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Active Roll Threads:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(129, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(129, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Loaded Rolls:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(129, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.glacialList2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(446, 261);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Loaded rolls";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.glacialList3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(446, 261);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Active threads";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.glacialList1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(446, 261);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Active rolls";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 71);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(454, 287);
            this.tabControl1.TabIndex = 7;
            // 
            // glacialList1
            // 
            this.glacialList1.AllowColumnResize = true;
            this.glacialList1.AllowMultiselect = false;
            this.glacialList1.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.glacialList1.AlternatingColors = false;
            this.glacialList1.AutoHeight = true;
            this.glacialList1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.glacialList1.BackgroundStretchToFit = true;
            glColumn8.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn8.CheckBoxes = false;
            glColumn8.ImageIndex = -1;
            glColumn8.Name = "Column1";
            glColumn8.NumericSort = false;
            glColumn8.Text = "Roll";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 190;
            glColumn9.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn9.CheckBoxes = false;
            glColumn9.ImageIndex = -1;
            glColumn9.Name = "Column2";
            glColumn9.NumericSort = false;
            glColumn9.Text = "User";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn9.Width = 200;
            glColumn10.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn10.CheckBoxes = false;
            glColumn10.ImageIndex = -1;
            glColumn10.Name = "Column3";
            glColumn10.NumericSort = false;
            glColumn10.Text = "Good";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn10.Width = 50;
            this.glacialList1.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn8,
            glColumn9,
            glColumn10});
            this.glacialList1.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.glacialList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glacialList1.FullRowSelect = true;
            this.glacialList1.GridColor = System.Drawing.Color.LightGray;
            this.glacialList1.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.glacialList1.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.glacialList1.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.glacialList1.HeaderHeight = 22;
            this.glacialList1.HeaderVisible = true;
            this.glacialList1.HeaderWordWrap = false;
            this.glacialList1.HotColumnTracking = false;
            this.glacialList1.HotItemTracking = false;
            this.glacialList1.HotTrackingColor = System.Drawing.Color.LightGray;
            this.glacialList1.HoverEvents = false;
            this.glacialList1.HoverTime = 1;
            this.glacialList1.ImageList = this.imageList1;
            this.glacialList1.ItemHeight = 20;
            glItem4.BackColor = System.Drawing.Color.White;
            glItem4.ForeColor = System.Drawing.Color.Black;
            glItem4.RowBorderColor = System.Drawing.Color.Black;
            glItem4.RowBorderSize = 0;
            glSubItem10.BackColor = System.Drawing.Color.Empty;
            glSubItem10.Checked = false;
            glSubItem10.ForceText = false;
            glSubItem10.ForeColor = System.Drawing.Color.Black;
            glSubItem10.ImageAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            glSubItem10.ImageIndex = -1;
            glSubItem10.Text = "This is dog";
            glSubItem11.BackColor = System.Drawing.Color.Empty;
            glSubItem11.Checked = false;
            glSubItem11.ForceText = false;
            glSubItem11.ForeColor = System.Drawing.Color.Black;
            glSubItem11.ImageAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            glSubItem11.ImageIndex = -1;
            glSubItem11.Text = "JariZ";
            glSubItem12.BackColor = System.Drawing.Color.Empty;
            glSubItem12.Checked = false;
            glSubItem12.ForceText = false;
            glSubItem12.ForeColor = System.Drawing.Color.Black;
            glSubItem12.ImageAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            glSubItem12.ImageIndex = 1;
            glSubItem12.Text = "";
            glItem4.SubItems.AddRange(new GlacialComponents.Controls.GLSubItem[] {
            glSubItem10,
            glSubItem11,
            glSubItem12});
            glItem4.Text = "This is dog";
            this.glacialList1.Items.AddRange(new GlacialComponents.Controls.GLItem[] {
            glItem4});
            this.glacialList1.ItemWordWrap = false;
            this.glacialList1.Location = new System.Drawing.Point(3, 3);
            this.glacialList1.Name = "glacialList1";
            this.glacialList1.Selectable = true;
            this.glacialList1.SelectedTextColor = System.Drawing.Color.White;
            this.glacialList1.SelectionColor = System.Drawing.Color.DarkBlue;
            this.glacialList1.ShowBorder = false;
            this.glacialList1.ShowFocusRect = false;
            this.glacialList1.Size = new System.Drawing.Size(440, 255);
            this.glacialList1.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.glacialList1.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.glacialList1.TabIndex = 0;
            this.glacialList1.Text = "glacialList1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "accept.png");
            this.imageList1.Images.SetKeyName(1, "cancel.png");
            // 
            // glacialList2
            // 
            this.glacialList2.AllowColumnResize = true;
            this.glacialList2.AllowMultiselect = false;
            this.glacialList2.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.glacialList2.AlternatingColors = false;
            this.glacialList2.AutoHeight = true;
            this.glacialList2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.glacialList2.BackgroundStretchToFit = true;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column1";
            glColumn5.NumericSort = false;
            glColumn5.Text = "Roll";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 190;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column2";
            glColumn6.NumericSort = false;
            glColumn6.Text = "Description";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 200;
            glColumn7.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn7.CheckBoxes = false;
            glColumn7.ImageIndex = -1;
            glColumn7.Name = "Column3";
            glColumn7.NumericSort = false;
            glColumn7.Text = "Good";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 50;
            this.glacialList2.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn5,
            glColumn6,
            glColumn7});
            this.glacialList2.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.glacialList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glacialList2.FullRowSelect = true;
            this.glacialList2.GridColor = System.Drawing.Color.LightGray;
            this.glacialList2.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.glacialList2.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.glacialList2.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.glacialList2.HeaderHeight = 22;
            this.glacialList2.HeaderVisible = true;
            this.glacialList2.HeaderWordWrap = false;
            this.glacialList2.HotColumnTracking = false;
            this.glacialList2.HotItemTracking = false;
            this.glacialList2.HotTrackingColor = System.Drawing.Color.LightGray;
            this.glacialList2.HoverEvents = false;
            this.glacialList2.HoverTime = 1;
            this.glacialList2.ImageList = this.imageList1;
            this.glacialList2.ItemHeight = 20;
            glItem3.BackColor = System.Drawing.Color.White;
            glItem3.ForeColor = System.Drawing.Color.Black;
            glItem3.RowBorderColor = System.Drawing.Color.Black;
            glItem3.RowBorderSize = 0;
            glSubItem7.BackColor = System.Drawing.Color.Empty;
            glSubItem7.Checked = false;
            glSubItem7.ForceText = false;
            glSubItem7.ForeColor = System.Drawing.Color.Black;
            glSubItem7.ImageAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            glSubItem7.ImageIndex = -1;
            glSubItem7.Text = "This is dog";
            glSubItem8.BackColor = System.Drawing.Color.Empty;
            glSubItem8.Checked = false;
            glSubItem8.ForceText = false;
            glSubItem8.ForeColor = System.Drawing.Color.Black;
            glSubItem8.ImageAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            glSubItem8.ImageIndex = -1;
            glSubItem8.Text = "JariZ";
            glSubItem9.BackColor = System.Drawing.Color.Empty;
            glSubItem9.Checked = false;
            glSubItem9.ForceText = false;
            glSubItem9.ForeColor = System.Drawing.Color.Black;
            glSubItem9.ImageAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            glSubItem9.ImageIndex = 1;
            glSubItem9.Text = "";
            glItem3.SubItems.AddRange(new GlacialComponents.Controls.GLSubItem[] {
            glSubItem7,
            glSubItem8,
            glSubItem9});
            glItem3.Text = "This is dog";
            this.glacialList2.Items.AddRange(new GlacialComponents.Controls.GLItem[] {
            glItem3});
            this.glacialList2.ItemWordWrap = false;
            this.glacialList2.Location = new System.Drawing.Point(3, 3);
            this.glacialList2.Name = "glacialList2";
            this.glacialList2.Selectable = true;
            this.glacialList2.SelectedTextColor = System.Drawing.Color.White;
            this.glacialList2.SelectionColor = System.Drawing.Color.DarkBlue;
            this.glacialList2.ShowBorder = false;
            this.glacialList2.ShowFocusRect = false;
            this.glacialList2.Size = new System.Drawing.Size(440, 255);
            this.glacialList2.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.glacialList2.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.glacialList2.TabIndex = 1;
            this.glacialList2.Text = "glacialList2";
            // 
            // glacialList3
            // 
            this.glacialList3.AllowColumnResize = true;
            this.glacialList3.AllowMultiselect = false;
            this.glacialList3.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.glacialList3.AlternatingColors = false;
            this.glacialList3.AutoHeight = true;
            this.glacialList3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.glacialList3.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "Void";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 440;
            this.glacialList3.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1});
            this.glacialList3.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.glacialList3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glacialList3.FullRowSelect = true;
            this.glacialList3.GridColor = System.Drawing.Color.LightGray;
            this.glacialList3.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.glacialList3.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.glacialList3.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.glacialList3.HeaderHeight = 22;
            this.glacialList3.HeaderVisible = true;
            this.glacialList3.HeaderWordWrap = false;
            this.glacialList3.HotColumnTracking = false;
            this.glacialList3.HotItemTracking = false;
            this.glacialList3.HotTrackingColor = System.Drawing.Color.LightGray;
            this.glacialList3.HoverEvents = false;
            this.glacialList3.HoverTime = 1;
            this.glacialList3.ImageList = this.imageList1;
            this.glacialList3.ItemHeight = 20;
            glItem1.BackColor = System.Drawing.Color.White;
            glItem1.ForeColor = System.Drawing.Color.Black;
            glItem1.RowBorderColor = System.Drawing.Color.Black;
            glItem1.RowBorderSize = 0;
            glSubItem1.BackColor = System.Drawing.Color.Empty;
            glSubItem1.Checked = false;
            glSubItem1.ForceText = false;
            glSubItem1.ForeColor = System.Drawing.Color.Black;
            glSubItem1.ImageAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            glSubItem1.ImageIndex = -1;
            glSubItem1.Text = "This is dog";
            glSubItem2.BackColor = System.Drawing.Color.Empty;
            glSubItem2.Checked = false;
            glSubItem2.ForceText = false;
            glSubItem2.ForeColor = System.Drawing.Color.Black;
            glSubItem2.ImageAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            glSubItem2.ImageIndex = -1;
            glSubItem2.Text = "JariZ";
            glSubItem3.BackColor = System.Drawing.Color.Empty;
            glSubItem3.Checked = false;
            glSubItem3.ForceText = false;
            glSubItem3.ForeColor = System.Drawing.Color.Black;
            glSubItem3.ImageAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            glSubItem3.ImageIndex = 1;
            glSubItem3.Text = "";
            glItem1.SubItems.AddRange(new GlacialComponents.Controls.GLSubItem[] {
            glSubItem1,
            glSubItem2,
            glSubItem3});
            glItem1.Text = "This is dog";
            this.glacialList3.Items.AddRange(new GlacialComponents.Controls.GLItem[] {
            glItem1});
            this.glacialList3.ItemWordWrap = false;
            this.glacialList3.Location = new System.Drawing.Point(3, 3);
            this.glacialList3.Name = "glacialList3";
            this.glacialList3.Selectable = true;
            this.glacialList3.SelectedTextColor = System.Drawing.Color.White;
            this.glacialList3.SelectionColor = System.Drawing.Color.DarkBlue;
            this.glacialList3.ShowBorder = false;
            this.glacialList3.ShowFocusRect = false;
            this.glacialList3.Size = new System.Drawing.Size(440, 255);
            this.glacialList3.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.glacialList3.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.glacialList3.TabIndex = 2;
            this.glacialList3.Text = "glacialList3";
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // RTDMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 365);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RTDMonitor";
            this.Text = "RTDMonitor";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RTDMonitor_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage3;
        private GlacialComponents.Controls.GlacialList glacialList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage2;
        private GlacialComponents.Controls.GlacialList glacialList3;
        private System.Windows.Forms.TabPage tabPage1;
        private GlacialComponents.Controls.GlacialList glacialList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Timer timer2;

    }
}