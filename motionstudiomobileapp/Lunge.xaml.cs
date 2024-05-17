namespace motionstudiomobileapp;

public partial class Lunge : ContentPage
{
	public Lunge()
	{
		InitializeComponent();
	}

    private async void backBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home());
    }
}