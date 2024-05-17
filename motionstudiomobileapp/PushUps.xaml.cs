namespace motionstudiomobileapp;

public partial class PushUps : ContentPage
{
	public PushUps()
	{
		InitializeComponent();
	}

    private async void backBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home());
    }
}