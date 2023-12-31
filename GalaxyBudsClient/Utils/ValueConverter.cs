using System;
using System.Globalization;
using System.Reflection;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace GalaxyBudsClient.Utils
{
    public class BitmapAssetValueConverter : IValueConverter
    {
        public static BitmapAssetValueConverter Instance = new BitmapAssetValueConverter();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            switch (value)
            {
                case null:
                    return null;
                case string rawUri when targetType == typeof(IBitmap):
                {
                    Uri uri;

                    // Allow for assembly overrides
                    if (rawUri.StartsWith("avares://"))
                    {
                        uri = new Uri(rawUri);
                    }
                    else
                    {
                        var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
                        uri = new Uri($"avares://{assemblyName}{rawUri}");
                    }

                    var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
                    var asset = assets?.Open(uri);
                    return asset == null ? null : new Bitmap(asset);
                }
                default:
                    throw new NotSupportedException();
            }
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}