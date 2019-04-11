using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Todo
{
	public partial class MyTodoItems : ContentPage
	{
		public MyTodoItems()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
            //To make the data immediatly visible in the page
			base.OnAppearing();
			// Reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtTodoId = -1;
            //Binding listview itemsource to the  Dtabase TodoItems
            listView.ItemsSource = await App.Database.GetItemsAsync();
		}

        //Handling the Add TodoItem event 
		async void OnItemAdded(object sender, EventArgs e)
		{
            //Calling ItemManager page and passing new TodoItem object to BindingContext
            await Navigation.PushAsync(new ItemManager
            {
				BindingContext = new ItemsEntity()
			});
		}

        //Handling the event of selectiong Todo item from the list
		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
           
            if (e.SelectedItem != null)
            {
                //Calling ItemManager page and passing the selected TodoItem object to BindingContext
                await Navigation.PushAsync(new ItemManager
                {
                    BindingContext = e.SelectedItem as ItemsEntity
                });
            }
		}
	}
}
