using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datapac_uloha.Models
{
	public class Notice
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vypozicka_id { get; set; }
        [Required]
        public int zakaznik_id { get; set; }
        [Required]
        public int kniha_id { get; set; }
        [Required]
		public DateTime pozicana { get; set; }
        public DateTime vratena { get; set; }
        public String stav { get; set; }
    }
}

