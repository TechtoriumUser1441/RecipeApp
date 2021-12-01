using RecipeApp.Views;
using Xamarin.Forms;

namespace RecipeApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RecipeEntryPage), typeof(RecipeEntryPage));
        }
    }
}