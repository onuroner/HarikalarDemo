using HarikalarDemo.Interfaces;
using ImageMagick;
using System.Net.Mail;

namespace HarikalarDemo.Views;

public partial class PhotoResultPage : ContentPage
{
    private IEmailSender? _emailSender;
    string photoUrl;
    public PhotoResultPage(string photoPath)
    {
        InitializeComponent();
        imagePreview.Source = ImageSource.FromFile(photoPath);
        photoUrl = photoPath;
        HandlerChanged += OnHandlerChanged;

    }

    void OnHandlerChanged(object sender, EventArgs e)
    {
        _emailSender = Handler.MauiContext.Services.GetService<IEmailSender>();
    }

    private async void MailButtonClicked(object sender, EventArgs e)
    {
        try
        {
            MailAddress m = new MailAddress(mailEntry.Text);
            _emailSender.SendEmail(m.Address, photoUrl);
            await Navigation.PushAsync(new FinalPage());
        }
        catch (FormatException ex)
        {
            DisplayAlert("Error", "Invalid email address", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", "An error occured.", "OK");
        }

        

    }

    
}