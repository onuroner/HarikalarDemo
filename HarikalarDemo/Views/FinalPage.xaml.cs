namespace HarikalarDemo.Views;

public partial class FinalPage : ContentPage
{
	public FinalPage()
	{
		InitializeComponent();
	}

	private async void RestartButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}