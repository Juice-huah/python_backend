using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XML_SIM
{
    public partial class Form1 : Form
    {
        private string path = string.Empty;
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        });

        public Form1()
        {
            InitializeComponent();

            Browse.Text = "BROWSE XML";

            DynamicPanel.AutoScrollMargin = new Size(0, 20);
        }

        private void BuildDynamicUI(string fullPath)
        {
            DynamicPanel.Controls.Clear();

            try
            {
                XDocument doc = XDocument.Load(fullPath);

                XElement? targetNode = doc.Descendants("item").LastOrDefault() ?? doc.Root;

                DynamicPanel.Tag = fullPath;

                if (targetNode != null)
                {
                    foreach (XElement element in targetNode.Elements())
                    {
                        if (element.HasElements) continue;

                        Panel rowPanel = new Panel();
                        rowPanel.Width = 520;
                        rowPanel.Height = 35;
                        rowPanel.Margin = new Padding(0, 0, 0, 20);

                        rowPanel.Tag = element.Name.LocalName;

                        TextBox keyBox = new TextBox();
                        keyBox.Text = element.Name.LocalName;
                        keyBox.Width = 250;
                        keyBox.Location = new Point(0, 0);
                        keyBox.Name = "keyBox";

                        keyBox.BackColor = Color.FromArgb(45, 45, 48);
                        keyBox.ForeColor = Color.LightGray;
                        keyBox.BorderStyle = BorderStyle.FixedSingle;

                        TextBox valBox = new TextBox();
                        valBox.Text = element.Value;
                        valBox.Width = 250;
                        valBox.Location = new Point(260, 0);
                        valBox.Name = "valBox";

                        valBox.BackColor = Color.FromArgb(45, 45, 48);
                        valBox.ForeColor = Color.White;
                        valBox.BorderStyle = BorderStyle.FixedSingle;

                        rowPanel.Controls.Add(keyBox);
                        rowPanel.Controls.Add(valBox);
                        DynamicPanel.Controls.Add(rowPanel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid XML: " + ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // filter so it only looks for XML files
            BrowseFile.InitialDirectory = @"C:\Python\data";
            BrowseFile.Title = "Choose XML File.";
            BrowseFile.Filter = "XML Files (*.xml)|*.xml";

            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                path = BrowseFile.FileName;
                BuildDynamicUI(path);
                txtPath.Text = path;

                rtbSaved.Text = string.Empty;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path)) return;

            try
            {

                XDocument doc = XDocument.Load(path);

                XElement? targetNode = doc.Descendants("item").LastOrDefault() ?? doc.Root;

                if (targetNode != null)
                {
                    foreach (Control ctrl in DynamicPanel.Controls)
                    {
                        if (ctrl is Panel rowPanel && rowPanel.Tag is string oldTagName)
                        {
                            TextBox? keyBox = rowPanel.Controls.Find("keyBox", false).FirstOrDefault() as TextBox;
                            TextBox? valBox = rowPanel.Controls.Find("valBox", false).FirstOrDefault() as TextBox;

                            if (keyBox != null && valBox != null && !string.IsNullOrWhiteSpace(keyBox.Text))
                            {
                                XElement? el = targetNode.Element(oldTagName);

                                if (el != null)
                                {
                                    el.Name = keyBox.Text.Trim();
                                    el.Value = valBox.Text;
                                }
                            }
                        }
                    }

                    doc.Save(path);

                    rtbSaved.Text = doc.ToString();
                    MessageBox.Show("XML File Updated! 🌹");

                    DynamicPanel.Controls.Clear();
                    BrowseFile.FileName = string.Empty;
                    txtPath.Text = string.Empty;
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving XML: " + ex.Message);
            }
        }
        private void btnPowerOn_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Python\xml_sim.bat";
            string folderPath = @"C:\Python";

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = filePath;
                startInfo.WorkingDirectory = folderPath;

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred trying to run the batch file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}