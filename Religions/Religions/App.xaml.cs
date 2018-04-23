using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Religions.Backend.DataAccess.Database;
using Religions.DependencyServices;
using Religions.Views;
using Xamarin.Forms;

namespace Religions
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new ReligionsListPage());
            DatabaseConfig.Database = new SQLiteAsyncConnection(DependencyService.Get<IInternalFileManager>().GetAbsolutePath(DatabaseConfig.DatabaseName));
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
