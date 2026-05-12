namespace QRPH_SIMULATOR
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            radioButton1 = new RadioButton();
            BrowseFile = new OpenFileDialog();
            btnSave = new Button();
            rtbSaved = new RichTextBox();
            txtPath = new Label();
            Browse = new Button();
            label = new Label();
            DynamicPanel = new FlowLayoutPanel();
            PowerOn = new Button();
            imageList1 = new ImageList(components);
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // radioButton1
            // 
            radioButton1.Location = new Point(0, 0);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(104, 24);
            radioButton1.TabIndex = 0;
            // 
            // BrowseFile
            // 
            BrowseFile.FileName = ".json";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.BackColor = Color.FromArgb(45, 45, 48);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(40, 520);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(563, 45);
            btnSave.TabIndex = 13;
            btnSave.Text = "SAVE CHANGES";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // rtbSaved
            // 
            rtbSaved.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbSaved.BackColor = Color.FromArgb(30, 30, 30);
            rtbSaved.BorderStyle = BorderStyle.None;
            rtbSaved.Font = new Font("Consolas", 10.2F);
            rtbSaved.ForeColor = Color.FromArgb(200, 200, 200);
            rtbSaved.Location = new Point(631, 85);
            rtbSaved.Name = "rtbSaved";
            rtbSaved.ReadOnly = true;
            rtbSaved.Size = new Size(383, 480);
            rtbSaved.TabIndex = 12;
            rtbSaved.Text = "";
            // 
            // txtPath
            // 
            txtPath.AutoSize = true;
            txtPath.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            txtPath.ForeColor = Color.DarkGray;
            txtPath.Location = new Point(175, 40);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(115, 20);
            txtPath.TabIndex = 11;
            txtPath.Text = "No file selected...";
            // 
            // Browse
            // 
            Browse.BackColor = Color.FromArgb(45, 45, 48);
            Browse.Cursor = Cursors.Hand;
            Browse.FlatAppearance.BorderSize = 0;
            Browse.FlatAppearance.MouseOverBackColor = Color.FromArgb(62, 62, 66);
            Browse.FlatStyle = FlatStyle.Flat;
            Browse.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Browse.ForeColor = Color.White;
            Browse.Location = new Point(40, 30);
            Browse.Name = "Browse";
            Browse.Size = new Size(120, 38);
            Browse.TabIndex = 9;
            Browse.Text = "BROWSE JSON";
            Browse.UseVisualStyleBackColor = false;
            Browse.Click += btnBrowse_Click;
            // 
            // label
            // 
            label.Location = new Point(0, 0);
            label.Name = "label";
            label.Size = new Size(100, 23);
            label.TabIndex = 0;
            // 
            // DynamicPanel
            // 
            DynamicPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            DynamicPanel.AutoScroll = true;
            DynamicPanel.BackColor = Color.FromArgb(30, 30, 30);
            DynamicPanel.FlowDirection = FlowDirection.TopDown;
            DynamicPanel.Location = new Point(40, 85);
            DynamicPanel.Name = "DynamicPanel";
            DynamicPanel.Padding = new Padding(15);
            DynamicPanel.Size = new Size(563, 429);
            DynamicPanel.TabIndex = 8;
            DynamicPanel.WrapContents = false;
            // 
            // PowerOn
            // 
            PowerOn.BackColor = Color.Transparent;
            PowerOn.Cursor = Cursors.Hand;
            PowerOn.FlatAppearance.BorderSize = 0;
            PowerOn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            PowerOn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            PowerOn.FlatStyle = FlatStyle.Flat;
            PowerOn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PowerOn.ForeColor = Color.Black;
            PowerOn.ImageIndex = 0;
            PowerOn.ImageList = imageList1;
            PowerOn.Location = new Point(956, 30);
            PowerOn.Name = "PowerOn";
            PowerOn.RightToLeft = RightToLeft.No;
            PowerOn.Size = new Size(58, 53);
            PowerOn.TabIndex = 14;
            toolTip1.SetToolTip(PowerOn, "Run Server");
            PowerOn.UseVisualStyleBackColor = false;
            PowerOn.Click += btnPowerOn_Click;
            PowerOn.MouseEnter += PowerOn_MouseEnter;
            PowerOn.MouseLeave += PowerOn_MouseLeave;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = SystemColors.GrayText;
            imageList1.Images.SetKeyName(0, "BUT.ico");
            imageList1.Images.SetKeyName(1, "icons8-power-100.ico");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1057, 600);
            Controls.Add(PowerOn);
            Controls.Add(DynamicPanel);
            Controls.Add(btnSave);
            Controls.Add(rtbSaved);
            Controls.Add(txtPath);
            Controls.Add(Browse);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            Name = "Form1";
            Text = "QRPAY Simulator";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RadioButton radioButton1;
        private OpenFileDialog BrowseFile;
        private Button btnSave;
        private RichTextBox rtbSaved;
        private Label txtPath;
        private Button Browse;
        private Label label;
        private FlowLayoutPanel DynamicPanel;
        private Button PowerOn;
        private ImageList imageList1;
        private ToolTip toolTip1;
    }
}