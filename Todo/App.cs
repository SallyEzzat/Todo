using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
	public class App : Application
	{
		static TodoItemsDB database;

        //Adjusting App layout
		public App()
		{
			Resources = new ResourceDictionary();
			Resources.Add("primaryGreen", Color.FromHex("91CA47"));
			Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            //Creating navigationpage object from MyTodoItems Page
            var nav = new NavigationPage(new MyTodoItems());
			nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
			nav.BarTextColor = Color.White;

			MainPage = nav;
		}

        //Function returns a local file path for storing the database:
        public static TodoItemsDB Database
		{
			get
			{
				if (database == null)
				{
                    database = new TodoItemsDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
				}
				return database;
			}
		}

		public int ResumeAtTodoId { get; set; }

		protected override void OnStart()
		{
			
		}

		protected override void OnSleep()
		{
			
		}

		protected override void OnResume()
		{
			
		}
	}
}

