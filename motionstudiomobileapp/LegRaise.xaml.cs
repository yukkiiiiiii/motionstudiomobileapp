namespace motionstudiomobileapp;

public partial class LegRaise : ContentPage
{
	public LegRaise()
	{
		InitializeComponent();
	}

    private async void backBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home());
    }
}