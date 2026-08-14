using MauiAppHotel.Models;
using MauiAppHotel.Data;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                NomeQuarto = ((Quarto)pck_quarto.SelectedItem).Descricao,
                QtdAdultos = Convert.ToInt32(stp_adultos.Value),
                QtdCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date.Value,
                DataCheckOut = dtpck_checkout.Date.Value,
            };

            using (var db = new HotelDbContext())
            {
                db.Hospedagens.Add(h);

                await db.SaveChangesAsync();
            }

            await DisplayAlertAsync(
            "Sucesso",
            "Hospedagem salva no banco de dados!",
            "OK");

            await Navigation.PushAsync(
            new HospedagemContratada()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync(
            "Ops",
            ex.Message,
            "OK");
        }

    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date.Value;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}