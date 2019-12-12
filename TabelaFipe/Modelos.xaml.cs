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
        public Modelos(FipeModel fipeModel)
        {
            InitializeComponent();
            buscarModelos(fipeModel);
        }

        private void buscarModelos(FipeModel fipeModel)
        {
            MainPage.selecao.marcaSelec = fipeModel.id;
            var lista = FipeAPI.buscarModelos(fipeModel.id);
            if (lista != null)
                lstModelos.ItemsSource = lista;
            else
                lblMsg.Text = @"Serviço indisponível";
        }

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null || e.SelectedItem == null)
            {
                return;
            }
            var anoModelos = new AnosModelo(e.SelectedItem as FipeModel);
            lstModelos.SelectedItem = null;
            Navigation.PushModalAsync(anoModelos);
        }

    }
}