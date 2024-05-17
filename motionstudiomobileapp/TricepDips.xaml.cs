namespace motionstudiomobileapp;

public partial class TricepDips : ContentPage
{
	public TricepDips()
	{
		InitializeComponent();
	}

    private async void backBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home());
    }
}