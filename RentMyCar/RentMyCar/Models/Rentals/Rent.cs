using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Rent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Car Car { get; set; }
        public long CarId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        public Adress Adress { get; set; }
    }
}
