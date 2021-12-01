using System;
using System.IO;
using RecipeApp.Models;
using Xamarin.Forms;

namespace RecipeApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class RecipeEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public RecipeEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Recipe();
        }

        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Recipe note = await App.Database.GetRecipeAsync(id);
                BindingContext = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load Recipe.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Recipe)BindingContext;
            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.Database.SaveRecipeAsync(note);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Recipe)BindingContext;
            await App.Database.DeleteRecipeAsync(note);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}