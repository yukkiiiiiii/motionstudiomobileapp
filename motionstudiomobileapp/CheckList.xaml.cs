using Newtonsoft.Json;

namespace motionstudiomobileapp;

public partial class CheckList : ContentPage
{
    private const string EntryKeyPrefix = "CheckListEntryText_";
    private const string CheckBoxKeyPrefix = "CheckListCheckBox_";
    public CheckList()
	{
		InitializeComponent();      
    }

    //Save for user input
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Restore text and CheckBox state for all Entry elements
        foreach (var stackLayout in mainStackLayout.Children)
        {
            if (stackLayout is StackLayout entryStackLayout)
            {
                var entry = entryStackLayout.Children.OfType<Entry>().FirstOrDefault();
                var checkBox = entryStackLayout.Children.OfType<CheckBox>().FirstOrDefault();
                if (entry != null)
                {
                    var entryKey = EntryKeyPrefix + mainStackLayout.Children.IndexOf(stackLayout);
                    if (Preferences.ContainsKey(entryKey))
                    {
                        var entryText = Preferences.Get(entryKey, "");
                        entry.Text = entryText;
                    }
                }
                if (checkBox != null)
                {
                    var checkBoxKey = CheckBoxKeyPrefix + mainStackLayout.Children.IndexOf(stackLayout);
                    if (Preferences.ContainsKey(checkBoxKey))
                    {
                        var checkBoxState = Preferences.Get(checkBoxKey, false);
                        checkBox.IsChecked = checkBoxState;
                    }
                }
            }
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Save text and CheckBox state for all Entry elements
        foreach (var stackLayout in mainStackLayout.Children)
        {
            if (stackLayout is StackLayout entryStackLayout)
            {
                var entry = entryStackLayout.Children.OfType<Entry>().FirstOrDefault();
                var checkBox = entryStackLayout.Children.OfType<CheckBox>().FirstOrDefault();
                if (entry != null)
                {
                    var entryKey = EntryKeyPrefix + mainStackLayout.Children.IndexOf(stackLayout);
                    var entryText = entry.Text;
                    Preferences.Set(entryKey, entryText);
                }
                if (checkBox != null)
                {
                    var checkBoxKey = CheckBoxKeyPrefix + mainStackLayout.Children.IndexOf(stackLayout);
                    var checkBoxState = checkBox.IsChecked;
                    Preferences.Set(checkBoxKey, checkBoxState);
                }
            }
        }
    }
    //Add elements. Specifically Entry and Checkbox
    private void AddNewItemButton_Clicked(object sender, EventArgs e)
    {

        var newCheckBox = new CheckBox
        {
            Margin = new Thickness(20, 0, 0, 0),
            Color = Color.FromArgb("#FFBD59"),
            HorizontalOptions = LayoutOptions.Start
        };

        var newEntry = new Entry
        {
            Placeholder = "Enter Item",
            Margin = new Thickness(10, 0, 0, 0),
            TextColor = Color.FromArgb("FFF")
        };

        var newStackLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };
        newStackLayout.Children.Add(newCheckBox);
        newStackLayout.Children.Add(newEntry);
        
        mainStackLayout.Children.Add(newStackLayout);
    }

    



}