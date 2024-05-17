using motionstudiomobileapp.NewFolder;

namespace motionstudiomobileapp
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LogInModel(Navigation);
           
        }

       
    }

}
