namespace INTEROP_SIMULATOR
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMerchantID = new TextBox();
            txtBillNumber = new TextBox();
            txtTerminalID = new TextBox();
            txtReferenceNumber = new TextBox();
            txtCreditMID = new TextBox();
            txtAmount = new TextBox();
            btnGenerate = new Button();
            rtbResponse = new RichTextBox();
            picQRCode = new PictureBox();
            btnAccept = new Button();
            btnDecline = new Button();
            radioButton1 = new RadioButton();
            label7 = new Label();
            txtMerchantKey = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picQRCode).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 9F);
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(62, 197);
            label1.Name = "label1";
            label1.Size = new Size(91, 18);
            label1.TabIndex = 0;
            label1.Text = "Terminal ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9F);
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new Point(62, 53);
            label2.Name = "label2";
            label2.Size = new Size(95, 18);
            label2.TabIndex = 1;
            label2.Text = "Merchant ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9F);
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(62, 124);
            label3.Name = "label3";
            label3.Size = new Size(90, 18);
            label3.TabIndex = 2;
            label3.Text = "Bill Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 9F);
            label4.ForeColor = SystemColors.Desktop;
            label4.Location = new Point(62, 267);
            label4.Name = "label4";
            label4.Size = new Size(134, 18);
            label4.TabIndex = 3;
            label4.Text = "Reference Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 9F);
            label5.ForeColor = SystemColors.Desktop;
            label5.Location = new Point(62, 339);
            label5.Name = "label5";
            label5.Size = new Size(84, 18);
            label5.TabIndex = 4;
            label5.Text = "Credit MID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 9F);
            label6.ForeColor = SystemColors.Desktop;
            label6.Location = new Point(62, 409);
            label6.Name = "label6";
            label6.Size = new Size(63, 18);
            label6.TabIndex = 5;
            label6.Text = "Amount";
            // 
            // txtMerchantID
            // 
            txtMerchantID.Location = new Point(62, 74);
            txtMerchantID.Name = "txtMerchantID";
            txtMerchantID.Size = new Size(367, 25);
            txtMerchantID.TabIndex = 6;
            // 
            // txtBillNumber
            // 
            txtBillNumber.Location = new Point(62, 145);
            txtBillNumber.Name = "txtBillNumber";
            txtBillNumber.Size = new Size(367, 25);
            txtBillNumber.TabIndex = 7;
            // 
            // txtTerminalID
            // 
            txtTerminalID.Location = new Point(62, 218);
            txtTerminalID.Name = "txtTerminalID";
            txtTerminalID.Size = new Size(367, 25);
            txtTerminalID.TabIndex = 8;
            // 
            // txtReferenceNumber
            // 
            txtReferenceNumber.Location = new Point(62, 288);
            txtReferenceNumber.Name = "txtReferenceNumber";
            txtReferenceNumber.Size = new Size(367, 25);
            txtReferenceNumber.TabIndex = 9;
            // 
            // txtCreditMID
            // 
            txtCreditMID.Location = new Point(62, 360);
            txtCreditMID.Name = "txtCreditMID";
            txtCreditMID.Size = new Size(367, 25);
            txtCreditMID.TabIndex = 10;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(62, 430);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(367, 25);
            txtAmount.TabIndex = 11;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(178, 553);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(120, 31);
            btnGenerate.TabIndex = 12;
            btnGenerate.Text = "Generate QR";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // rtbResponse
            // 
            rtbResponse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbResponse.BorderStyle = BorderStyle.None;
            rtbResponse.Location = new Point(508, 317);
            rtbResponse.Name = "rtbResponse";
            rtbResponse.Size = new Size(411, 267);
            rtbResponse.TabIndex = 13;
            rtbResponse.Text = "";
            // 
            // picQRCode
            // 
            picQRCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picQRCode.BackColor = SystemColors.ActiveBorder;
            picQRCode.ImageLocation = "";
            picQRCode.InitialImage = null;
            picQRCode.Location = new Point(538, 50);
            picQRCode.Name = "picQRCode";
            picQRCode.Size = new Size(250, 250);
            picQRCode.TabIndex = 14;
            picQRCode.TabStop = false;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.Location = new Point(794, 131);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(106, 26);
            btnAccept.TabIndex = 15;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnDecline
            // 
            btnDecline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDecline.Location = new Point(794, 177);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(106, 26);
            btnDecline.TabIndex = 16;
            btnDecline.Text = "Decline";
            btnDecline.UseVisualStyleBackColor = true;
            btnDecline.Click += btnDecline_Click;
            // 
            // radioButton1
            // 
            radioButton1.Location = new Point(0, 0);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(104, 24);
            radioButton1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(62, 476);
            label7.Name = "label7";
            label7.Size = new Size(102, 18);
            label7.TabIndex = 17;
            label7.Text = "Merchant Key";
            // 
            // txtMerchantKey
            // 
            txtMerchantKey.Location = new Point(62, 497);
            txtMerchantKey.Name = "txtMerchantKey";
            txtMerchantKey.Size = new Size(367, 25);
            txtMerchantKey.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 633);
            Controls.Add(txtMerchantKey);
            Controls.Add(label7);
            Controls.Add(btnDecline);
            Controls.Add(btnAccept);
            Controls.Add(picQRCode);
            Controls.Add(rtbResponse);
            Controls.Add(btnGenerate);
            Controls.Add(txtAmount);
            Controls.Add(txtCreditMID);
            Controls.Add(txtReferenceNumber);
            Controls.Add(txtTerminalID);
            Controls.Add(txtBillNumber);
            Controls.Add(txtMerchantID);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Georgia", 9F);
            ForeColor = SystemColors.Desktop;
            Name = "Form1";
            Text = " ";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)picQRCode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMerchantID;
        private TextBox txtBillNumber;
        private TextBox txtTerminalID;
        private TextBox txtReferenceNumber;
        private TextBox txtCreditMID;
        private TextBox txtAmount;
        private Button btnGenerate;
        private RichTextBox rtbResponse;
        private PictureBox picQRCode;
        private Button btnAccept;
        private Button btnDecline;
        private RadioButton radioButton1;
        private Label label7;
        private TextBox txtMerchantKey;
    }
}
