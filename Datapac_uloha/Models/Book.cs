using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datapac_uloha.Models
{
	public class Book
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kniha_id { get; set; }
        [Required]
        public String nazov { get; set; }
        [Required]
        public String autor { get; set; }
        public String isbn { get; set; }
    }
}

