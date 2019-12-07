using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using TabelaFipe.ServicoFipe.Model;

namespace TabelaFipe.ServicoFipe
{
    public class FipeAPI
    {
        private static String buscaMarcas = "http://fipeapi.appspot.com/api/1/carros/marcas.json";
        private static String buscaModelos = "http://fipeapi.appspot.com/api/1/carros/veiculos/{0}.json";
        private static String buscaAnoModelo = "http://fipeapi.appspot.com/api/1/carros/veiculo/{0}/{1}.json";
        private static String buscaVeiculo = "http://fipeapi.appspot.com/api/1/carros/veiculo/{0}/{1}/{2}.json";

        private static List<FipeModel> getFipeModelList(String url)
        {
            WebClient wc = new WebClient();
            String json = wc.DownloadString(url);
            List<FipeModel> fm = JsonConvert.DeserializeObject<List<FipeModel>>(json);
            return fm;
        }

        private static FipeModel getFipeModel(String url)
        {
            WebClient wc = new WebClient();
            String json = wc.DownloadString(url);
            FipeModel fm = JsonConvert.DeserializeObject<FipeModel>(json);
            return fm;
        }

        public static List<FipeModel> buscarMarcas()
        {   
            return getFipeModelList(buscaMarcas);
        }

        public static List<FipeModel> buscarModelos(String idMarca)
        {
            String url = String.Format(buscaModelos, idMarca);
            return getFipeModelList(url);
        }

        public static List<FipeModel> buscarAnoModelo(String idMarca, String idModelo)
        {
            String url = String.Format(buscaAnoModelo, idMarca, idModelo);
            return getFipeModelList(url);
        }

        public static FipeModel buscarVeiculo(String idMarca, String idModelo, String idAnoModelo)
        {
            String url = String.Format(buscaVeiculo, idMarca, idModelo, idAnoModelo);
            return getFipeModel(url);
        }

    }
}
