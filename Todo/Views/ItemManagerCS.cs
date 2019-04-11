using Xamarin.Forms;

namespace Todo
{
	public class ItemManagerCS : ContentPage
	{
		public ItemManagerCS()
		{
			Title = "Todo Item";

            //Creating an empty entry variable
			var nameEntry = new Entry(); //xamarin.Forms.Entry
            //Binding the text of Name entry to the Name value in Databse
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            //Creating an empty switch variable
            var doneSwitch = new Switch();
            //Binding the boolean value of DONE swith cotrol to the boolean Done value in Databse
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            //Creating a new save button variable
            var saveButton = new Button { Text = "Save" };
            //To handle Save button event
            saveButton.Clicked += async (sender, e) =>
			{
                //Binding the current Todo Item in new Todo Item object
                var todoItem = (ItemsEntity)BindingContext;
                //Saving the object i the todoItem table
                await App.Database.SaveItemAsync(todoItem);
                //Removing the current page from the stack and back to the previus page
                await Navigation.PopAsync();
			};

            //Creating a new Delete button variable
            var deleteButton = new Button { Text = "Delete" };
            //To handle the event of button Delete click
            deleteButton.Clicked += async (sender, e) =>
			{
                //Binding the current Todo Item in new Todo Item object
                var todoItem = (ItemsEntity)BindingContext;
                //Deleting the object i the todoItem table
                await App.Database.DeleteItemAsync(todoItem);
                //Removing the current page from the stack and back to the previus page
                await Navigation.PopAsync();
			};

            //Creating a new Cancel button variable
            var cancelButton = new Button { Text = "Cancel" };
            //To handle the event of button Cancel click
            cancelButton.Clicked += async (sender, e) =>
			{
                //Doing nothing thing but Removing the current page from the stack and back to the previus page
                await Navigation.PopAsync();
			};

			//Sets and Gets page content layout
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children =
				{
					new Label { Text = "Name" },
					nameEntry,
					new Label { Text = "Done" },
					doneSwitch,
					saveButton,
					deleteButton,
					cancelButton
				}
			};
		}
	}
}
