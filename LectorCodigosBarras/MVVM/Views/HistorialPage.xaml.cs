using LectorCodigosBarras.MVVM.ViewModels;

namespace LectorCodigosBarras.MVVM.Views;

public partial class HistorialPage : ContentPage
{
    public HistorialPage(ScannerViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}