using motionstudiomobileapp.NewFolder;

namespace motionstudiomobileapp;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
		BindingContext = new RegisterModel(Navigation);
	}
}