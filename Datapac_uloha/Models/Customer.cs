using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datapac_uloha
{
	public class Customer
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customer_id { get; set; }
        [Required]
        public String meno { get; set; }
        [Required]
        public String priezvisko { get; set; }
        public String ulica { get; set; }
        public String psc { get; set; }
        public String obec { get; set; }
    }
}

