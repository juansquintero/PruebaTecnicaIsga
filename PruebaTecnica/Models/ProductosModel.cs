using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
	[Table("productos")]
	public class ProductosModel
	{
		[Column("id")]
		public int id { get; set; }
		[Column("nombre")]
		[Required]
		[StringLength(500)]
		public string nombre { get; set; }
		[Column("cantidad")]
		public int cantidad { get; set;}
		[Column("ciudad")]
		public int ciudad { get; set;}
	}
}
