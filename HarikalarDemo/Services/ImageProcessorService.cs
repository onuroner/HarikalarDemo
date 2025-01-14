
using HarikalarDemo.Interfaces;
using ImageMagick;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarikalarDemo.Services
{
    public class ImageProcessorService: IImageProcessor
    {
        public string ProcessImage(string photoPath)
        {
            string framePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\Assets\frame.png");
            string outputFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\Assets\Final");

            if (!Directory.Exists(outputFolderPath))
            {
                // Dizin yoksa oluştur
                Directory.CreateDirectory(outputFolderPath);
            }
            var splittedPath = photoPath.Split("\\");
            var fileName = splittedPath[splittedPath.Length - 1].Split(".")[0] + "_framed." + splittedPath[splittedPath.Length - 1].Split(".")[1];

            string outputImagePath = Path.Combine(outputFolderPath, fileName);

            using (MagickImage inputImage = new MagickImage(photoPath))
            {
                using (MagickImage frameImage = new MagickImage(framePath))
                {

                    using (var mask = new MagickImage(framePath))
                    {
                        
                        mask.ColorFuzz = new ImageMagick.Percentage(0); 
                        mask.Opaque(MagickColors.Black, MagickColors.White);
                        mask.Transparent(MagickColors.White);
                        mask.Trim();
                        inputImage.Resize(mask.Width, mask.Height);

                    }
                    
                    frameImage.Composite(inputImage, Gravity.Center, CompositeOperator.DstOver);

                    frameImage.Write(outputImagePath);
                }
            }

            return outputImagePath;
        }
    }
    
}
