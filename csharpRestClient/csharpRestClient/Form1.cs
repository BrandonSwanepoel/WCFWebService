using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace csharpRestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void cmdGO_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            if(txtRestURl.TextLength > 1)
            {
                    rClient.endPoint = txtRestURl.Text;
                    debugOutput("REST Client Created");
                    string strResponse = rClient.makeRequest();
                    debugOutput(strResponse);
            }
            else if((comboBox1.Text == "Select an Excel function" && textBox1.TextLength > 0) || (comboBox1.Text == "None selected" && textBox1.TextLength > 0))
            {
                debugOutput("Choose a function");
            }
            else if (comboBox1.Text == "Count")
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    debugOutput("Input required");
                }
                else
                {
                    rClient.endPoint = "http://localhost:53233/Functions.svc/Count/" + textBox1.Text;
                    debugOutput("Result:");
                    string strResponse = rClient.makeRequest();
                    debugOutput(strResponse);
                }
            }
            else if (comboBox1.Text == "Greatest Common Denominator")
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    debugOutput("Input required");
                }
                else
                {
                    rClient.endPoint = "http://localhost:53233/Functions.svc/GreatestCommonDenominator/" + textBox1.Text;
                    debugOutput("Result:");
                    string strResponse = rClient.makeRequest();
                    debugOutput(strResponse);
                }
            }
            else if (comboBox1.Text == "Least Common Denominator")
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    debugOutput("Input required");
                }
                else
                {
                    rClient.endPoint = "http://localhost:53233/Functions.svc/LeastCommonDenominator/" + textBox1.Text;
                    debugOutput("Result:");
                    string strResponse = rClient.makeRequest();
                    debugOutput(strResponse);
                }
            }
            else if (comboBox1.Text == "Even")
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    debugOutput("Input required");
                }
                else
                {
                    rClient.endPoint = "http://localhost:53233/Functions.svc/Even/" + textBox1.Text;
                    debugOutput("Result:");
                    string strResponse = rClient.makeRequest();
                    debugOutput(strResponse);
                }
            }
            else if (comboBox2.Text == "Get User Details")
            {
                if(comboBox1.Text == "None selected")
                {
                    if (textBox1.Text != null)
                    {
                        rClient.endPoint = "http://localhost:53233/Functions.svc/GetUserDetails";
                        debugOutput("Result:");
                        string strResponse = rClient.makeRequest();
                        debugOutput(strResponse);
                    }
                    else
                    {
                        debugOutput("Input required");
                    }
                }
            }
            else if (comboBox2.Text == "Get Amout of Users")
            {
                if (textBox1.Text != null)
                {
                    rClient.endPoint = "http://localhost:53233/Functions.svc/CountUsers";
                    debugOutput("Result:");
                    string strResponse = rClient.makeRequest();
                    debugOutput(strResponse);
                }
                else
                {
                    debugOutput("Input required");
                }
            }
        }
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
        private void deserialiseJSON(string strJSON)
        {
            try
            {
                object result = JsonConvert.DeserializeObject<dynamic>(strJSON);
                debugOutput(result.ToString());
            }
            catch (Exception ex)
            {
                debugOutput("We had a problem: " + ex.Message.ToString());
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;
        }

    }
}
