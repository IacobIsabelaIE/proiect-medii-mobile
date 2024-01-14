using ProiectMobile.Models;

namespace ProiectMobile
{
    public partial class ProgramarePage : ContentPage
    {
        public ProgramarePage()
        {
            InitializeComponent();
            BindingContext = new Programare();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var programare = (Programare)BindingContext;
            programare.DataProgramare = datePicker.Date;

            await App.Database.SaveProgamareAsync(programare);
            await Navigation.PushAsync(new ProgramareListPage());
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var programare = (Programare)BindingContext;
            await App.Database.DeleteProgramareAsync(programare);
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
