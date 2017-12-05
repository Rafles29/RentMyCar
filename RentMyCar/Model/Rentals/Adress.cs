using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Adress
    {
        public long AdressId { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(30)]
        public string StreetName { get; set; }
        [Required]
        public int StreetNumber { get; set; }

        public Rent Rent { get; set; }
        public long RentId { get; set; }

    }
}
