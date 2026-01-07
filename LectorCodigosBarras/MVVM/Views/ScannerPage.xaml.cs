using LectorCodigosBarras.MVVM.ViewModels;
using ZXing.Net.Maui;

namespace LectorCodigosBarras.MVVM.Views;

public partial class ScannerPage : ContentPage
{
    ScannerViewModel vm;

    public ScannerPage()
    {
        InitializeComponent();
        vm = new ScannerViewModel();
        BindingContext = vm;
    }

    private void OnBarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var primero = e.Results.FirstOrDefault();
        if (primero != null)
        {
            Dispatcher.Dispatch(() => {
                vm.CodigoDetectado = primero.Value;
                vm.IsScanning = false;
            });
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorialPage(vm));
    }
}