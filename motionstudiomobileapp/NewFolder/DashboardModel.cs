using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motionstudiomobileapp.NewFolder
{
    internal class DashboardModel
    {
        private INavigation _navigation;
        private Command settingsBtn;

        public DashboardModel(INavigation navigation) 
        {
            this._navigation = navigation;
            settingsBtn = new Command(settingsBtnTappedAsync);
        }

        private async void settingsBtnTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new Settings());
        }
    }
}
