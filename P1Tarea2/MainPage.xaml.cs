using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace P1Tarea2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ClearControls()
        {
            nombre.Text = "";
            apellido.Text = "";
            edad.Text = "";
            correo.Text = "";
            direccion.Text = "";

        }
        // LLAMAR A LA PAGINA EQUIPO
        private async void btnLimpiar_Clicked(object sender, EventArgs e)
        {
            ClearControls();
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            var equi = new Models.Personas
            {
                Nombre = nombre.Text,
                Apellidos = apellido.Text,
                Edad = edad.Text,
                Correo = correo.Text,
                Direccion = direccion.Text
            };

            if (await App.Dbpersonas.StoreEquipo(equi) > 0)
            {
                await DisplayAlert("AVISO", "Persona Ingresado con Exito", "OK");
                ClearControls();
            }
            else
            {
                await DisplayAlert("AVISO", "Los Datos No Se Pudieron Ingresar", "OK");
            }

        }

        // LLAMAR A LA PAGINA EQUIPO
        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Paginas.PageLista());
        }
    }
}
