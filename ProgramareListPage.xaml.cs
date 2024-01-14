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

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var programare = button?.CommandParameter as Programare;
            if (programare != null)
            {
                await App.Database.DeleteProgramareAsync(programare);
                programariListView.ItemsSource = await App.Database.GetProgramariAsync();
            }
        }

    }
}
