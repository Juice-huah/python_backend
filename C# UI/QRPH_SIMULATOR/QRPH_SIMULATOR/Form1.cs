using Newtonsoft.Json;
using QRCoder;
using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace QRPH_SIMULATOR
{
    public partial class Form1 : Form
    {
        private string path = string.Empty;
        private bool isPoweredOn = false;
        private Process? serverProcess = null;
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        });

        public Form1()
        {
            InitializeComponent();
            //IntAccept.Enabled = false;
            //PHQRSave.Enabled = false;

        }

        /*private async void PHQRLoad_Click(object sender, EventArgs e)
        {
            string jsonText = System.IO.File.ReadAllText(@"C:\Python\data\QRPH_payment_response.json");

            dynamic? data = JsonConvert.DeserializeObject<dynamic>(jsonText);

            PHQRInvoiceNumber.Text = data?.InvoiceNumber;
            PHQRReferenceNumber.Text = data?.ReferenceNumber;
            PHQRAmount.Text = data?.Amount;
            PHQRDate.Text = data?.Date;
            PHQRTime.Text = data?.Time;
            PHQRCardNumber.Text = data?.CardNumber;
            PHQRTraceNumber.Text = data?.TraceNumber;
            PHQRApprovalCode.Text = data?.ApprovalCode;
            PHQRStatus.Text = data?.Status;
            PHQRReason.Text = data?.Reason;

            PHQRLoad.Enabled = false;
            PHQRSave.Enabled = true;
            rtbResponse.Clear();
        }
        private async void PHQRSave_Click(object sender, EventArgs e)
        {
            var dataToSave = new
            {
                InvoiceNumber = PHQRInvoiceNumber.Text,
                ReferenceNumber = PHQRReferenceNumber.Text,
                Amount = PHQRAmount.Text,
                Date = PHQRDate.Text,
                Time = PHQRTime.Text,
                CardNumber = PHQRCardNumber.Text,
                TraceNumber = PHQRTraceNumber.Text,
                ApprovalCode = PHQRApprovalCode.Text,
                Status = PHQRStatus.Text,
                Reason = PHQRReason.Text
            };



            string jsonString = JsonConvert.SerializeObject(dataToSave, Formatting.Indented);

            string filePath = @"C:\Python\data\QRPH_payment_response.json";
            System.IO.File.WriteAllText(filePath, jsonString);
            string uwuArt = @"
              (づ｡◕‿‿◕｡)づ
               SUCCESS !!
            ";
            MessageBox.Show("File rewritten!\n" + uwuArt + "🌹⛓️🌹⛓️");

            string jsonText = System.IO.File.ReadAllText(@"C:\Python\data\QRPH_payment_response.json");

            rtbResponse.Text = jsonText;

            PHQRInvoiceNumber.Clear();
            PHQRReferenceNumber.Clear();
            PHQRAmount.Clear();
            PHQRDate.Clear();
            PHQRTime.Clear();
            PHQRCardNumber.Clear();
            PHQRTraceNumber.Clear();
            PHQRApprovalCode.Clear();
            PHQRStatus.Clear();
            PHQRReason.Clear();

            PHQRSave.Enabled = false;
            PHQRLoad.Enabled = true;

        }
        private async void IntGenerateQR_Click(object sender, EventArgs e)
        {
            var payload = new
            {
                MerchantID = IntMerchantID.Text,
                BillNumber = IntBillNumber.Text,
                TerminalID = IntTerminalID.Text,
                ReferenceNumber = IntReferenceNumber.Text,
                CreditMID = IntCreditMID.Text,
                Amount = IntAmount.Text,
                MerchantKey = IntMerchantKey.Text
            };

            string json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("http://127.0.0.1:8000/sim/Interop-Generate-QR", content);
                string result = await response.Content.ReadAsStringAsync();
                IntRTB.Text = result;

                var data = JsonConvert.DeserializeObject<dynamic>(result);
                IntAccept.Enabled = true;
                IntDecline.Enabled = true;
                IntGenerate.Enabled = false;

                string imageUrl = (string)data!.CodeImgUrl!;
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    IntQRCode.Load(imageUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }
        private async void IntAccept_Click(object sender, EventArgs e)
        {
            string refNo = IntReferenceNumber.Text;
            string amt = IntAmount.Text;
            string trace = IntBillNumber.Text;
            string date = DateTime.Now.ToString("dd-MM-yyyy");

            string fullUrl = $"http://127.0.0.1:8000/sim/Interop-Payment-Response" +
                             $"amount={amt}&" +
                             $"status=Approved&" +
                             $"transaction-date={date}&" +
                             $"trace-number={trace}";

            try
            {
                var response = await client.GetAsync(fullUrl);
                string result = await response.Content.ReadAsStringAsync();

                IntRTB.Text = result;

                IntGenerate.Enabled = true;
                IntAccept.Enabled = false;
                IntDecline.Enabled = false;

                IntMerchantID.Clear();
                IntBillNumber.Clear();
                IntTerminalID.Clear();
                IntReferenceNumber.Clear();
                IntCreditMID.Clear();
                IntAmount.Clear();
                IntMerchantKey.Clear();
                IntQRCode.Image = null;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }
        private async void IntDecline_Click(object sender, EventArgs e)
        {
            string refNo = IntReferenceNumber.Text;
            string amt = IntAmount.Text;
            string trace = IntBillNumber.Text;
            string date = DateTime.Now.ToString("dd-MM-yyyy");

            string fullUrl = $"http://127.0.0.1:8000/sim/Interop-Payment-Response" +
                             $"amount={amt}&" +
                             $"status=Decline&" +
                             $"transaction-date={date}&" +
                             $"trace-number={trace}";

            try
            {
                var response = await client.GetAsync(fullUrl);
                string result = await response.Content.ReadAsStringAsync();

                rtbResponse.Text = result;

                IntGenerate.Enabled = true;
                IntDecline.Enabled = false;
                IntAccept.Enabled = false;

                IntMerchantID.Clear();
                IntBillNumber.Clear();
                IntTerminalID.Clear();
                IntReferenceNumber.Clear();
                IntCreditMID.Clear();
                IntAmount.Clear();
                IntMerchantKey.Clear();
                IntQRCode.Image = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        } */
        private void BuildDynamicUI(string fullPath)
        {
            DynamicPanel.Controls.Clear();

            try
            {
                string jsonText = System.IO.File.ReadAllText(fullPath);
                JObject jobj = JObject.Parse(jsonText);

                DynamicPanel.Tag = fullPath;

                foreach (JProperty property in jobj.Properties())
                {
                    Panel rowPanel = new Panel();
                    rowPanel.Width = 520;
                    rowPanel.Height = 35;
                    rowPanel.Margin = new Padding(0, 0, 0, 20);

                    TextBox lbl = new TextBox();
                    lbl.Text = property.Name.ToString();
                    lbl.Width = 250;
                    lbl.Location = new Point(0, 0);
                    lbl.Name = "keyBox";

                    lbl.BackColor = Color.FromArgb(45, 45, 48);
                    lbl.ForeColor = Color.LightGray;
                    lbl.BorderStyle = BorderStyle.FixedSingle;

                    TextBox txt = new TextBox();
                    txt.Text = property.Value.ToString();
                    txt.Width = 250;
                    txt.Location = new Point(260, 0);
                    txt.Name = "valBox";

                    txt.BackColor = Color.FromArgb(45, 45, 48);
                    txt.ForeColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;

                    rowPanel.Controls.Add(lbl);
                    rowPanel.Controls.Add(txt);
                    DynamicPanel.Controls.Add(rowPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid JSON: " + ex.Message);
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            BrowseFile.InitialDirectory = "C:Python";
            BrowseFile.Title = "Choose JSON File.";
            BrowseFile.ShowDialog();

            path = BrowseFile.FileName;

            BuildDynamicUI(path);

            txtPath.Text = path;
            rtbSaved.Text = string.Empty;
            btnSave.Enabled = true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path)) return;

            JObject updatedJson = new JObject();

            foreach (Control ctrl in DynamicPanel.Controls)
            {
                if (ctrl is Panel rowPanel)
                {
                    TextBox? keyBox = rowPanel.Controls.Find("keyBox", false).FirstOrDefault() as TextBox;
                    TextBox? valBox = rowPanel.Controls.Find("valBox", false).FirstOrDefault() as TextBox;

                    if (keyBox != null && valBox != null && !string.IsNullOrWhiteSpace(keyBox.Text))
                    {
                        updatedJson[keyBox.Text] = valBox.Text;
                    }
                }
            }

            System.IO.File.WriteAllText(path, updatedJson.ToString(Newtonsoft.Json.Formatting.Indented));

            rtbSaved.Text = updatedJson.ToString();

            MessageBox.Show("Saved to: " + path);

            DynamicPanel.Controls.Clear();
            BrowseFile.FileName = string.Empty;
            txtPath.Text = string.Empty;
            btnSave.Enabled = false;
        }
        private void btnPowerOn_Click(object sender, EventArgs e)
        {
            isPoweredOn = !isPoweredOn;

            if (isPoweredOn)
            {
                PowerOn.ImageIndex = 1;

                try
                {
                    string filePath = @"C:\Python\run.bat";
                    string folderPath = @"C:\Python";

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = filePath;
                    startInfo.WorkingDirectory = folderPath;

                    serverProcess = Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred trying to run the batch file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isPoweredOn = false;
                    PowerOn.ImageIndex = 0;
                }
            }
            else
            {
                PowerOn.ImageIndex = 0;

                try
                {
                    ProcessStartInfo killInfo = new ProcessStartInfo
                    {
                        FileName = "taskkill",
                        Arguments = $"/T /F /PID {serverProcess?.Id}",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    };

                    Process.Start(killInfo)?.WaitForExit();

                    serverProcess?.Dispose();
                    serverProcess = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred trying to stop the server process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void PowerOn_MouseEnter(object sender, EventArgs e)
        {
            if (!isPoweredOn)
            {
                PowerOn.ImageIndex = 1;
            }
        }
        private void PowerOn_MouseLeave(object sender, EventArgs e)
        {
            if (!isPoweredOn)
            {
                PowerOn.ImageIndex = 0;
            }
        }
    }
}