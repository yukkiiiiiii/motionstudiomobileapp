namespace motionstudiomobileapp;

public partial class Meals : ContentPage
{
	public Meals()
	{
		InitializeComponent();
	}

    private async void SpagBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Spaghetti());
    }
    private async void TunaBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TunaOme());
    }
    private async void bananaBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BananaProteinShake());
    }

    private async void tinolaBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChickenTinola());
    }

    private async void adoboBtn(object sender, EventArgs e) 
    {
        await Navigation.PushAsync(new Adobo());
    }

    private async void stirfryBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShrimpStirFry());
    }
}