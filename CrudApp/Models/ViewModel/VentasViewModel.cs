namespace CrudApp.Models.ViewModel
{
    public class VentasViewModel
    {
        public int? id { get; set; }
        public int? id_producto { get; set; }
        public int? id_cliente { get; set; }
        public int? cantidad { get; set; }
	    public decimal? ValorTotal { get; set; }
    }

    public class VentasRelacionViewModel
    {
        public int? id { get; set; }
        public string cliente { get; set; }
        public string producto { get; set; }
        public int? cantidad { get; set; }
        public decimal? ValorTotal { get; set; }
    }
}