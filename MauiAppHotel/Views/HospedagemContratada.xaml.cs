namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
	public HospedagemContratada()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PopAsync();
		} 
		catch (Exception ex) 
		{
			DisplayAlertAsync("Erro", ex.Message, "OK");
        }

    }
}