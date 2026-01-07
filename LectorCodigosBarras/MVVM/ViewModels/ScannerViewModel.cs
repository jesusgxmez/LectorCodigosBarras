using LectorCodigosBarras.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace LectorCodigosBarras.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ScannerViewModel
    {
        public ObservableCollection<Producto> ListaHistorial { get; set; } = new();

        public string CodigoDetectado { get; set; } = "Esperando código...";
        public string NombreInput { get; set; }
        public string DescripcionInput { get; set; }
        public bool IsScanning { get; set; } = true;

        public string EstadoVoz { get; set; } = "Listo";
        public bool EstaEscuchando { get; set; } = false;

        public ICommand GuardarCommand => new Command(async () =>
        {
            if (string.IsNullOrEmpty(NombreInput)) return;

            ListaHistorial.Insert(0, new Producto
            {
                Codigo = CodigoDetectado,
                Nombre = NombreInput,
                Descripcion = DescripcionInput
            });

            NombreInput = string.Empty;
            DescripcionInput = string.Empty;
            CodigoDetectado = "Esperando código...";
            IsScanning = true;

            await Application.Current.MainPage.DisplayAlertAsync("Perfecto", "Producto guardado", "Ok");
        });

        public ICommand DictarCommand => new Command<string>(async (campo) =>
        {
            EstadoVoz = "Escuchando... hable ahora";
            EstaEscuchando = true;

            var servicioVoz = new LectorCodigosBarras.Services.VozWindowsService();
            string resultado = await servicioVoz.DictarAsync();

            if (!string.IsNullOrEmpty(resultado))
            {
                if (campo == "Nombre") NombreInput = resultado;
                else if (campo == "Descripcion") DescripcionInput = resultado;
                EstadoVoz = "¡Entendido!";
            }
            else
            {
                EstadoVoz = "No se detectó voz o se canceló.";
            }

            EstaEscuchando = false;

            await Task.Delay(2000);
            EstadoVoz = "Listo";
        });

        public ICommand ReiniciarEscaneoCommand => new Command(() =>
        {
            CodigoDetectado = "Esperando código...";
            NombreInput = string.Empty;
            DescripcionInput = string.Empty;
            IsScanning = true; 
            EstadoVoz = "Listo";
        });
    }
}
