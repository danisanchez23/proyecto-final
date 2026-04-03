using System;
using System.Collections.Generic;
using System.Text;

namespace ListadoProductos.Services
{
    public class AlertaServicio
    {
        public async Task Informar(string titulo, string mensaje)
        {
            await App.Current!.MainPage!.DisplayAlert(titulo, mensaje, "Aceptar");
        }

        public async Task<bool> Confirmar(string titulo, string mensaje)
        {
            return await App.Current!.MainPage!.DisplayAlert(titulo, mensaje, "Sí", "No");
        }
    }
}
