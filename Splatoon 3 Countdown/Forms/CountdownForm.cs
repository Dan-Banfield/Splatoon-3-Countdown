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

        private const string JSON_ENDPOINT = "https://pastebin.com/raw/7bA37KWH";

        private DateTime countdownEndDate;

        private Timer countdownTimer;
        private string countdownFinishedText = string.Empty;

        #endregion

        public CountdownForm()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        #region Event Handlers

        private async void CountdownForm_Load(object sender, EventArgs e)
        {
            await UpdateViewInformationAsync();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CheckForCountdownEnd())
                return;

            TimeSpan timeSpan = countdownEndDate.Subtract(DateTime.Now);
            countdownLabel.Text = timeSpan.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
        }

        #endregion

        #region Methods

        private async Task UpdateViewInformationAsync()
        {
            Information information = null;

            if (await Task.Run(() => GetInformation(out information)))
            {
                UpdateControls(information.backgroundURL, information.countdownFinishedText, information.countdownEndDate);
                return;
            }

            ShowDataErrorMessage();
        }

        private void ShowDataErrorMessage()
        {
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

        private void UpdateControls(string backgroundURL, string countdownFinishedText, DateTime countdownEndDate)
        {
            backgroundPictureBox.LoadAsync(backgroundURL);
            this.countdownEndDate = countdownEndDate;

            StartCountdown(countdownFinishedText);
        }

        private void StartCountdown(string finishedText)
        {
            this.countdownFinishedText = finishedText;

            #region Timer Initialization

            countdownTimer = new Timer();
            countdownTimer.Interval = 500;
            countdownTimer.Tick += Timer_Tick;
            countdownTimer.Start();

            #endregion
        }

        private bool CheckForCountdownEnd()
        {
            if (DateTime.Now >= countdownEndDate)
            {
                countdownTimer.Stop();
                countdownLabel.Text = countdownFinishedText;
                return true;
            }
            return false;
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
