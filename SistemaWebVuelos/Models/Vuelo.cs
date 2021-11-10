using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Models
{
    [Table("Vuelo")]
    public class Vuelo
    {
        [Key]
        public int Id { get; set; }
            
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Destino { get; set; }
        [StringLength(50)]
        [Required]
        public string Origen { get; set; }
        [Range(100, 10000, ErrorMessage = "La matricula tiene que estar entre el rango de 100 y 10000")]
        public int Matricula { get; set; }
    }
}