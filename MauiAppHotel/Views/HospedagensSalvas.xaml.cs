using MauiAppHotel.Data;
using Microsoft.EntityFrameworkCore;

namespace MauiAppHotel.Views;

public partial class HospedagensSalvas : ContentPage
{
    public HospedagensSalvas()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        using var db = new HotelDbContext();

        var hospedagens = await db.Hospedagens
            .ToListAsync();

        listaHospedagens.ItemsSource = hospedagens;
    }
}