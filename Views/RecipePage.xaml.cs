using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RecipeApp.Models;
using Xamarin.Forms;

namespace RecipeApp.Views
{
    public partial class RecipePage : ContentPage
    {
        public RecipePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            collectionView.ItemsSource = await App.Database.GetRecipeAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(RecipeEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Recipe note = (Recipe)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(RecipeEntryPage)}?{nameof(RecipeEntryPage.ItemId)}={note.ID.ToString()}");
            }
        }
    }
}