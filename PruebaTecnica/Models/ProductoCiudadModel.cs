using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    [Table("productociudad")]
    public class ProductoCiudadModel
    {
        [Column("id")]
        public int id { get; set; }
        [Column("idproducto")]
        public int idproducto { get; set; }
        [Column("idciudad")]
        public int idciudad { get; set; }
    }
}
