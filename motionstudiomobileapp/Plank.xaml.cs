namespace motionstudiomobileapp;

public partial class Plank : ContentPage
{
	public Plank()
	{
		InitializeComponent();
	}

    private async void backBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home());
    }
}