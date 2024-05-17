namespace motionstudiomobileapp;
using Microsoft.Maui.Controls;

public partial class Gym : ContentPage
{
    private const string ProgressKey = "WorkoutProgress";
    private int progress = 0;
	public Gym()
	{
        
		InitializeComponent();
        if (Preferences.ContainsKey(ProgressKey))
        {
            progress = Preferences.Get(ProgressKey, 0);
            UpdateProgressBar(); 
        }

        Device.StartTimer(TimeSpan.FromMinutes(1), () =>
        {
            CheckAndResetProgressBar();
            return true; 
        });
    }

    private void CheckAndResetProgressBar()
    {
        // Check if it's midnight and the progress bar hasn't been reset today
        if (DateTime.Now.TimeOfDay == TimeSpan.Zero && DateTime.Today != Preferences.Get("ResetDate", DateTime.MinValue))
        {
            progress = 0;           
            Preferences.Set(ProgressKey, progress);
            Preferences.Set("ResetDate", DateTime.Today);
            UpdateProgressBar();
        }
    }

    private async void barbellrowsBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BarbellRows());
        progress += 10;
        UpdateProgressBar();
        Preferences.Set(ProgressKey, progress);

    }
    private async void singlearmBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DumBellSingleArm());
        progress += 50;
        UpdateProgressBar();
        Preferences.Set(ProgressKey, progress);
    }
    private async void hammercurlsBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HammerCurls());
        progress += 10;
        UpdateProgressBar();
        Preferences.Set(ProgressKey, progress);
    }
    private async void pecflyBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PecFly());
        progress += 10;
        UpdateProgressBar();
        Preferences.Set(ProgressKey, progress);
    }
    private async void seatedlateralBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SeatedLateral());
        progress += 10;
        UpdateProgressBar();
        Preferences.Set(ProgressKey, progress);
    }
    private async void cablelateralBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CableLateral());
        progress += 10;
        UpdateProgressBar();
        Preferences.Set(ProgressKey, progress);
    }

    private void UpdateProgressBar() 
    {
        progress = Math.Min(100, Math.Max(0, progress));

        progressBar.WidthRequest = progress * 2;
        if (progress >= 100)
        {
            progressBar.BackgroundColor = Color.FromArgb("#ffbd59");
        }
        else
        {
            
            progressBar.BackgroundColor = Color.FromArgb("#fff");
        }

      
    }
}