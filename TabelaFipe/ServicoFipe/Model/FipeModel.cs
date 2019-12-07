namespace TabelaFipe.ServicoFipe.Model
{
	public class FipeModel
    {
		public string name { get; set; }
		public string fipe_name { get; set; }
		public string fipe_marca { get; set; }
		public int order { get; set; }
		public string key { get; set; }
		public string id { get; set; }
		public string marca { get; set; }
		public string fipe_codigo { get; set; }
		public string veiculo { get; set; }
		public string combustivel { get; set; }
		public string ano_modelo { get; set; }
		public string preco { get; set; }
		public string referencia { get; set; }
		public double time { get; set; }

		public string getAno_modelo()
		{
			return !ano_modelo.Equals("32000") ? ano_modelo : "Zero KM";
		}

	}
}
