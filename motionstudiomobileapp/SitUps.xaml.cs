namespace motionstudiomobileapp;

public partial class SitUps : ContentPage
{
	public SitUps()
	{
		InitializeComponent();
	}

    private async void backBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home());
    }
}