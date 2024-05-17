
using motionstudiomobileapp.NewFolder;
using Newtonsoft.Json;

namespace motionstudiomobileapp;

public partial class Dashboard : ContentPage
{
	
	public Dashboard()
	{
		InitializeComponent();
		GetProfileInfo();
		BindingContext = new DashboardModel(Navigation);
	}

    private void GetProfileInfo()
    {
		var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
		UserEmail.Text = userInfo.User.Email;
    }

 	private async void settingsBtn(object sender, EventArgs e) 
	{
		await Navigation.PushAsync(new Settings());
	}

    private async void workoutBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Workout());
    }

    private async void mealsBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Meals());
    }

    private async void inquiryBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Inquiry());
    }

    private async void calendarBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Calendar());
    }

    private async void checklistBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CheckList());
    }

}