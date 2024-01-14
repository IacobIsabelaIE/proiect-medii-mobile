using ProiectMobile.Models;
using System;

namespace ProiectMobile;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        serviciu.DurataServiciu = new DateTime(datePicker.Date.Year, datePicker.Date.Month, datePicker.Date.Day, timePicker.Time.Hours, timePicker.Time.Minutes, 0);
        await App.Database.SaveServiciuAsync(serviciu);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        await App.Database.DeleteServiciuAsync(serviciu);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        var selectedServiciu = (Serviciu)this.BindingContext;
        await Navigation.PushAsync(new ProgramarePage
        {
            BindingContext = new Programare { serviciu = selectedServiciu }
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetServiciuListsAsync();
    }
}
