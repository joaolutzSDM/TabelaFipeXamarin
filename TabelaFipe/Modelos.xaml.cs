using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabelaFipe.ServicoFipe;
using TabelaFipe.ServicoFipe.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabelaFipe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modelos : ContentPage
    {
        public Modelos()
        {
            InitializeComponent();
            buscarModelos();
        }

        private void buscarModelos()
        {
            FipeModel fm = BindingContext as FipeModel;
            var lista = FipeAPI.buscarModelos(fm.id);
            if (lista != null)
                lstModelos.ItemsSource = lista;
            else
                lblMsg.Text = @"Serviço indisponível";
        }

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            var anoModelos = new AnosModelo();
            anoModelos.BindingContext = e.SelectedItem as FipeModel;
            Navigation.PushModalAsync(anoModelos);
        }

    }
}