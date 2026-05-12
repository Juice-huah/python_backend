using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using QRCoder;

namespace INTEROP_SIMULATOR
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        });

        public Form1()
        {
            InitializeComponent();
            btnAccept.Enabled = false;
            btnDecline.Enabled = false;
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            var payload = new
            {
                MerchantID = txtMerchantID.Text,
                BillNumber = txtBillNumber.Text,
                TerminalID = txtTerminalID.Text,
                ReferenceNumber = txtReferenceNumber.Text,
                CreditMID = txtCreditMID.Text,
                Amount = txtAmount.Text,
                MerchantKey = txtMerchantKey.Text
            };

            string json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("http://127.0.0.1:8000/sim/Interop-Generate-QR", content);
                string result = await response.Content.ReadAsStringAsync();
                rtbResponse.Text = result;

                var data = JsonConvert.DeserializeObject<dynamic>(result);
                btnAccept.Enabled = true;
                btnDecline.Enabled = true;
                btnGenerate.Enabled = false;

                string imageUrl = (string)data!.CodeImgUrl!;
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    picQRCode.Load(imageUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }
        private async void btnAccept_Click(object sender, EventArgs e)
        {
            string refNo = txtReferenceNumber.Text;
            string amt = txtAmount.Text;
            string trace = txtBillNumber.Text; // Using Bill Number as the Trace
            string date = DateTime.Now.ToString("dd-MM-yyyy");

            //creates its own URL for the process_payment endpoint
            string fullUrl = $"http://127.0.0.1:8000/sim/Interop-Payment-Response" +
                             $"amount={amt}&" +
                             $"status=Approved&" +
                             $"transaction-date={date}&" +
                             $"trace-number={trace}";

            try
            {
                var response = await client.GetAsync(fullUrl);
                string result = await response.Content.ReadAsStringAsync();

                rtbResponse.Text = result;

                btnGenerate.Enabled = true;
                btnAccept.Enabled = false;
                btnDecline.Enabled = false;

                txtMerchantID.Clear();
                txtBillNumber.Clear();
                txtTerminalID.Clear();
                txtReferenceNumber.Clear();
                txtCreditMID.Clear();
                txtAmount.Clear();
                txtMerchantKey.Clear();
                picQRCode.Image = null;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }
        private async void btnDecline_Click(object sender, EventArgs e)
        {
            string refNo = txtReferenceNumber.Text;
            string amt = txtAmount.Text;
            string trace = txtBillNumber.Text;
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

                btnGenerate.Enabled = true;
                btnDecline.Enabled = false;

                txtMerchantID.Clear();
                txtBillNumber.Clear();
                txtTerminalID.Clear();
                txtReferenceNumber.Clear();
                txtCreditMID.Clear();
                txtAmount.Clear();
                txtMerchantKey.Clear();
                picQRCode.Image = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }
    }
}