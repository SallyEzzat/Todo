using System;
using Xamarin.Forms;

namespace Todo
{
	public partial class ItemManager : ContentPage
	{
		public ItemManager()
		{
			InitializeComponent();
		}

        //To handle the event of button SAVE click
		async void OnSaveClicked(object sender, EventArgs e)
		{
            //Binding the current Todo Item in new Todo Item object
			var todoItem = (ItemsEntity)BindingContext;
            //Saving the object i the todoItem table
			await App.Database.SaveItemAsync(todoItem);
            //Removing the current page from the stack and back to the previus page
			await Navigation.PopAsync();
		}

       
        //To handle the event of button Cancel click
        async void OnCancelClicked(object sender, EventArgs e)
		{
            //Doing nothing thing but Removing the current page from the stack and back to the previus page
            await Navigation.PopAsync();
		}

        //To handle the event of button Delete click
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            //Binding the current Todo Item in new Todo Item object
            var todoItem = (ItemsEntity)BindingContext;
            //Deleting the object i the todoItem table
            await App.Database.DeleteItemAsync(todoItem);
            //Removing the current page from the stack and back to the previus page
            await Navigation.PopAsync();
        }


    }
}
