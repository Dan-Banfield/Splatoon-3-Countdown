using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Splatoon_3_Countdown
{
    public partial class CountdownForm : Form
    {
        #region Private Variables

        private const string JSON_ENDPOINT = "";

        #endregion

        public CountdownForm()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private async void CountdownForm_Load(object sender, EventArgs e)
        {
            await UpdateViewInformationAsync();
        }

        #endregion

        #region Methods

        private async Task UpdateViewInformationAsync()
        {
            Information information = null;

            if (await Task.Run(() => GetInformation(out information)))
            {
                UpdateControls(information.backgroundURL, information.countdownName, information.countdownFinishedText, information.countdownEndDate);
                return;
            }

            MessageBox.Show("Failed to fetch the latest information! Please connect to the internet and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        private bool GetInformation(out Information information)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage responseMessage = httpClient.GetAsync(JSON_ENDPOINT).Result;
                    string json = responseMessage.Content.ReadAsStringAsync().Result;
                    information = JsonConvert.DeserializeObject<Information>(json);
                    return true;
                }
                catch
                {
                    information = null;
                    return false;
                }
            }
        }

        private void UpdateControls(string backgroundURL, string countdownName, string countdownFinishedText, DateTime countdownEndDate)
        {
            titleLabel.Text = countdownName;
        }

        #endregion
    }

    public class Information
    {
        public string backgroundURL { get; set; }
        public string countdownName { get; set; }
        public string countdownFinishedText { get; set; }
        public DateTime countdownEndDate { get; set; }
    }
}
