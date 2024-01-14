using ProiectMobile.Models;
using System.Collections.Generic;

namespace ProiectMobile
{
    public partial class ProgramareListPage : ContentPage
    {
        public ProgramareListPage()
        {
            InitializeComponent();
            LoadProgramari();
        }

        private async void LoadProgramari()
        {
            programariListView.ItemsSource = await App.Database.GetProgramariAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadProgramari();
        }
    }
}
