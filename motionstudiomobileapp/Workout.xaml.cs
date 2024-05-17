using Newtonsoft.Json;

namespace motionstudiomobileapp;

public partial class Workout : ContentPage
{
	public Workout()
	{
		InitializeComponent();
        
    }
    private async void GymBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Gym());
    }

    private async void HomeBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home());
    }

}