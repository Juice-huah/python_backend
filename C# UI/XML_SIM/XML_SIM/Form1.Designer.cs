namespace XML_SIM // <--- Updated to match your new project!
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            BrowseFile = new OpenFileDialog();
            btnSave = new Button();
            rtbSaved = new RichTextBox();
            txtPath = new Label();
            Browse = new Button();
            DynamicPanel = new FlowLayoutPanel();
            button1 = new Button();
            SuspendLayout();
            // 
            // BrowseFile
            // 
            BrowseFile.FileName = ".xml";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.BackColor = Color.Gainsboro;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.DimGray;
            btnSave.Location = new Point(40, 520);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(545, 45);
            btnSave.TabIndex = 13;
            btnSave.Text = "SAVE CHANGES";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // rtbSaved
            // 
            rtbSaved.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbSaved.BackColor = Color.Gainsboro;
            rtbSaved.BorderStyle = BorderStyle.None;
            rtbSaved.Font = new Font("Consolas", 10.2F);
            rtbSaved.ForeColor = Color.DimGray;
            rtbSaved.Location = new Point(603, 85);
            rtbSaved.Name = "rtbSaved";
            rtbSaved.Size = new Size(419, 480);
            rtbSaved.TabIndex = 12;
            rtbSaved.Text = "";
            // 
            // txtPath
            // 
            txtPath.AutoSize = true;
            txtPath.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            txtPath.ForeColor = Color.DimGray;
            txtPath.Location = new Point(175, 40);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(115, 20);
            txtPath.TabIndex = 11;
            txtPath.Text = "No file selected...";
            // 
            // Browse
            // 
            Browse.BackColor = Color.Gainsboro;
            Browse.Cursor = Cursors.Hand;
            Browse.FlatAppearance.BorderSize = 0;
            Browse.FlatAppearance.MouseOverBackColor = Color.FromArgb(62, 62, 66);
            Browse.FlatStyle = FlatStyle.Flat;
            Browse.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Browse.ForeColor = Color.DimGray;
            Browse.Location = new Point(40, 30);
            Browse.Name = "Browse";
            Browse.Size = new Size(120, 38);
            Browse.TabIndex = 9;
            Browse.Text = "BROWSE";
            Browse.UseVisualStyleBackColor = false;
            Browse.Click += btnBrowse_Click;
            // 
            // DynamicPanel
            // 
            DynamicPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            DynamicPanel.AutoScroll = true;
            DynamicPanel.BackColor = Color.Gainsboro;
            DynamicPanel.FlowDirection = FlowDirection.TopDown;
            DynamicPanel.ForeColor = Color.DimGray;
            DynamicPanel.Location = new Point(40, 85);
            DynamicPanel.Name = "DynamicPanel";
            DynamicPanel.Padding = new Padding(15);
            DynamicPanel.Size = new Size(545, 420);
            DynamicPanel.TabIndex = 8;
            DynamicPanel.WrapContents = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Gainsboro;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(62, 62, 66);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.DimGray;
            button1.Location = new Point(902, 30);
            button1.Name = "button1";
            button1.Size = new Size(120, 38);
            button1.TabIndex = 14;
            button1.Text = "POWER ON";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnPowerOn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1062, 600);
            Controls.Add(button1);
            Controls.Add(btnSave);
            Controls.Add(rtbSaved);
            Controls.Add(txtPath);
            Controls.Add(Browse);
            Controls.Add(DynamicPanel);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            Name = "Form1";
            Text = "XML Simulator";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.OpenFileDialog BrowseFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rtbSaved;
        private System.Windows.Forms.Label txtPath;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.FlowLayoutPanel DynamicPanel;
        private Button button1;
    }
}