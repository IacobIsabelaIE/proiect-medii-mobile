using ProiectMobile.Models;
using System.Collections.Generic;

namespace ProiectMobile
{
    public partial class ProgramarePage : ContentPage
    {
        List<Serviciu> services;

        public ProgramarePage()
        {
            InitializeComponent();
            BindingContext = new Programare();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            services = await App.Database.GetServiciuListsAsync();
            serviciuCollectionView.ItemsSource = services;
        }

        private void OnServiciuSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var selectedServiciu = e.CurrentSelection[0] as Serviciu;
                if (selectedServiciu != null)
                {
                    var programare = (Programare)BindingContext;
                    programare.serviciu = selectedServiciu;
                    programare.ServiciuId = selectedServiciu.ID;
                }
            }
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var programare = (Programare)BindingContext;
            programare.DataProgramare = datePicker.Date;

            if (programare.serviciu == null || programare.ServiciuId == 0)
            {
                await DisplayAlert("EROARE", "Selecteaza un serviciu", "OK");
                return;
            }

            await App.Database.SaveProgamareAsync(programare);
            await DisplayAlert("Succes", "Programarea a fost creeata cu succes!", "OK");

            BindingContext = new Programare();
            datePicker.Date = DateTime.Now;
        }


        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var programare = (Programare)BindingContext;
            await App.Database.DeleteProgramareAsync(programare);
            await Navigation.PopAsync();
        }
    }
}
