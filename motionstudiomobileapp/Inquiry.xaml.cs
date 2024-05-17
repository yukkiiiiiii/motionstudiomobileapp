

using motionstudiomobileapp.NewFolder;

namespace motionstudiomobileapp;

public partial class Inquiry : ContentPage
{
	public Inquiry()
	{
		InitializeComponent();
        submitButton.Clicked += OnSubmitButtonClicked;
    }
    private void OnSubmitButtonClicked(object sender, EventArgs e)
    {
        // Get inquiry text from Entry
        string inquiryText = inquiryEntry.Text;

        // Call the SendMessage method from GmailServiceHelper
        string toEmail = "tristanmesina27@gmail.com"; // Specify recipient email address
        string subject = "New Inquiry";
        GmailServiceHelper.SendMessage(toEmail, subject, inquiryText);

        // Optionally, display a message to the user indicating success
        DisplayAlert("Success", "Your inquiry has been submitted.", "OK");

        // Clear the Entry after submission
        inquiryEntry.Text = string.Empty;
    }

}