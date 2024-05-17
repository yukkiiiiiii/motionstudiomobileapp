namespace motionstudiomobileapp;

public partial class Home : ContentPage
{
    private const string ProgressKeys = "WorkoutProgress"; 
    private const string ResetDateKey = "ResetDate";
    private int progressbar = 0;
    public Home()
    {
        InitializeComponent();
        if (Preferences.ContainsKey(ProgressKeys))
        {
            progressbar = Preferences.Get(ProgressKeys, 0);
            UpdateProgressBars();
        }
        Device.StartTimer(TimeSpan.FromMinutes(1), () =>
        {
            CheckAndResetProgressBar();
            return true; // Repeat timer
        });
    }
    private void CheckAndResetProgressBar()
    {
        var lastResetDate = Preferences.Get(ResetDateKey, DateTime.MinValue).Date;
        var currentDate = DateTime.Today;

        // Check if the current date is different from the last reset date
        if (currentDate != lastResetDate)
        {
            progressbar = 0;
            Preferences.Set(ProgressKeys, progressbar);
            Preferences.Set(ResetDateKey, currentDate);
            UpdateProgressBars();
        }
    }

    private async void SitupsBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SitUps());
        progressbar += 10;
        UpdateProgressBars();
        Preferences.Set(ProgressKeys, progressbar);
    }

    private async void pushupsBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PushUps());
        progressbar += 10;
        UpdateProgressBars();
        Preferences.Set(ProgressKeys, progressbar);
    }

    private async void legraiseBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LegRaise());
        progressbar += 10;
        UpdateProgressBars();
        Preferences.Set(ProgressKeys, progressbar);
    }
    private async void lungeBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Lunge());
        progressbar += 10;
        UpdateProgressBars();
        Preferences.Set(ProgressKeys, progressbar);
    }
    private async void tricepdipsBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TricepDips());
        progressbar += 10;
        UpdateProgressBars();
        Preferences.Set(ProgressKeys, progressbar);
    }
    private async void plankBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Plank());
        progressbar += 10;
        UpdateProgressBars();
        Preferences.Set(ProgressKeys, progressbar);
    }

    private void UpdateProgress(int increment)
    {
        progressbar += increment;
        Preferences.Set(ProgressKeys, progressbar);
        UpdateProgressBars();
    }

    private void UpdateProgressBars()
    {
        progressbar = Math.Min(100, Math.Max(0, progressbar));

        progressBars.WidthRequest = progressbar * 2;
        if (progressbar >= 100)
        {
            progressBars.BackgroundColor = Color.FromArgb("#ffbd59");
        }
        else
        {

            progressBars.BackgroundColor = Color.FromArgb("#ffbd59");
        }
    }
}