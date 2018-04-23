using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Religions.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Religions.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReligionsListPage : ContentPage
	{
        private ReligionsListViewModel viewModel;

        public ReligionsListPage ()
		{
			InitializeComponent ();
            this.viewModel = new ReligionsListViewModel();
            this.BindingContext = this.viewModel;
		}

        private void Add_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddReligionsPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.viewModel.LoadData();
        }
    }
}