using P1Tarea2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P1Tarea2.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLista : ContentPage
    {
        public PageLista()
        {
            InitializeComponent();
        }

        private void ListaPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var elemento = e.CurrentSelection;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListaPersonas.ItemsSource = await App.Dbpersonas.ListaEquipos();
        }

        //AGREGAR ITEMS
        private async void toolAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        //ACTUALIZAR ITEMS LIST
        private async void toolActualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Paginas.PageLista());
        }

        //ELIMINAR ITEMS LIST
        private async void toolEliminar_Clicked(object sender, EventArgs e)
        {
            
            try
            {
                if (await DisplayAlert("Confirmacion", "Esta seguro que desea eliminar?", "Si", "No"))
                {
                    await DisplayAlert("Alert", "ENTRO", "OK");
                    var item = (Personas)(sender as ToolbarItem).CommandParameter;
                    var result = await App.Dbpersonas.DeleteEquipo(item);
                    if (result == 1)
                    {
                        await DisplayAlert("Alert", "ELIMINADO", "OK");
                        ListaPersonas.ItemsSource = await App.Dbpersonas.ListaEquipos();
                    }
                    else
                    {
                        await DisplayAlert("Alert", "NO ELIMINADO", "OK");
                    }
                }
            }
            catch(Exception ex) 
            {
                await DisplayAlert("Alert", "ERROR", "OK");
            }

            await Navigation.PushAsync(new Paginas.PageLista());
        }

    }
}