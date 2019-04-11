using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Todo
{
	public class MyTodoItemsCS : ContentPage
	{
		ListView listView;

		public MyTodoItemsCS()
		{
			Title = "My Todo List";

            //Creating new toolbarItem with + icon to add Items
			var toolbarItem = new ToolbarItem
			{
				Text = "+",
				Icon = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
			};

            //Handling the Add TodoItem event 
            toolbarItem.Clicked += async (sender, e) =>
			{
                //Calling ItemManager page and passing new TodoItem object to BindingContext
                await Navigation.PushAsync(new ItemManager
                {
					BindingContext = new ItemsEntity()
				});
			};
			ToolbarItems.Add(toolbarItem);

            //Creating our new Listview layout
			listView = new ListView
			{
				Margin = new Thickness(20),
				ItemTemplate = new DataTemplate(() =>
				{
					var label = new Label
					{
						VerticalTextAlignment = TextAlignment.Center,
						HorizontalOptions = LayoutOptions.StartAndExpand
					};
					label.SetBinding(Label.TextProperty, "Name");


                    var stackLayout = new StackLayout
					{
						Margin = new Thickness(20, 0, 0, 0),
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = { label}
					};

					return new ViewCell { View = stackLayout };
				})
			};

			listView.ItemSelected += async (sender, e) =>
			{

                if (e.SelectedItem != null)
                {
                    // Calling ItemManager page and passing the selected TodoItem object to BindingContext
                    await Navigation.PushAsync(new ItemManager
                    {
                        BindingContext = e.SelectedItem as ItemsEntity
                    });
                }
			};

			Content = listView;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			// Reset the id, since we just want to restart here
			((App)App.Current).ResumeAtTodoId = -1;
            //To fill the listview
			listView.ItemsSource = await App.Database.GetItemsAsync();
		}
	}
}
