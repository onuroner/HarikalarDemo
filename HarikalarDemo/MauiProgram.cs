using CommunityToolkit.Maui;
using HarikalarDemo.Interfaces;
using HarikalarDemo.Services;
using HarikalarDemo.Views;
using Microsoft.Extensions.Logging;

namespace HarikalarDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitCamera()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
                    fonts.AddFont("Rubik-SemiBold.ttf", "RubikSemiBold");
                });

            
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<WebcamPage>();
            builder.Services.AddSingleton<PhotoResultPage>();
            builder.Services.AddSingleton<FinalPage>();

            builder.Services.AddSingleton<IImageProcessor, ImageProcessorService>();
            builder.Services.AddSingleton<IEmailSender, EmailSenderService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            
            return builder.Build();
        }
    }
}
