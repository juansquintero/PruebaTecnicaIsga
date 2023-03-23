using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
	[Table("ciudad")]
	public class CiudadModel
	{
		[Column("id")]
		public int id { get; set; }
		[Column("descripcion")]
		[Required]
		[StringLength(500)]
		public string descripcion { get; set; }
	}
}
