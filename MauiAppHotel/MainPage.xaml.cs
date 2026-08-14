using MauiAppHotel.Services;

namespace MauiAppHotel;

public partial class MainPage : ContentPage
{
    private readonly ClimaService _climaService;

    public MainPage()
    {
        InitializeComponent();

        _climaService = new ClimaService();
    }

    private async void OnConsultarClimaClicked(object sender, EventArgs e)
    {
        lblClima.Text = "Consultando API...";

        string clima = await _climaService.ObterClimaAsync();

        lblClima.Text = clima;
    }

    private async void OnContratarHospedagemClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.ContratacaoHospedagem());
    }

    private async void OnHospedagensSalvasClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.HospedagensSalvas());
    }
}