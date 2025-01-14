using CommunityToolkit.Maui.Views;
using HarikalarDemo.Interfaces;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Diagnostics;
using System.Reflection;
using System.Timers;

namespace HarikalarDemo.Views;

public partial class WebcamPage : ContentPage
{
    private IImageProcessor? _imageProcessor;
    public WebcamPage()
	{
		InitializeComponent();
        HandlerChanged += OnHandlerChanged;
    }

    void OnHandlerChanged(object sender, EventArgs e)
    {
        _imageProcessor = Handler.MauiContext.Services.GetService<IImageProcessor>();
    }

    string filePath = string.Empty;

    private async void CaptureButtonClicked(object sender, EventArgs e)
    {
        captureButton.IsVisible = false;
        CountdownCircle.IsVisible = true;
        for (int i = Convert.ToInt32(CountdownLabel.Text); i >= 0; i--)
        {
            CountdownLabel.Text = i.ToString();
            await Task.Delay(1000);
        }
        await webcamPreview.CaptureImage(CancellationToken.None);
        captureButton.IsVisible = true;
        CountdownCircle.IsVisible = false;
        CountdownLabel.Text = "5";

        var processedPath =_imageProcessor.ProcessImage(filePath);

        await Navigation.PushAsync(new PhotoResultPage(processedPath));
    }

    private async void  WebcamPreview_MediaCaptured(object sender, MediaCapturedEventArgs e)
    {
        using var stream = e.Media;
        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        stream.Position = 0;
        memoryStream.Position = 0;
        
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string capturedFolderPath = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\..\Assets\Captured"));

        if (!Directory.Exists(capturedFolderPath))
        {
            // Dizin yoksa oluþtur
            Directory.CreateDirectory(capturedFolderPath);
        }

        var fileName = Guid.NewGuid().ToString() + ".jpg";
        var filePath = Path.Combine(capturedFolderPath, fileName);
        this.filePath = filePath;
        System.IO.File.WriteAllBytes(filePath, memoryStream.ToArray());
        

    }
}