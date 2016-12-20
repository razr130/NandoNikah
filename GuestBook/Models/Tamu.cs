namespace GuestBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Tamu")]
    public partial class Tamu
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        
        public string pesan { get; set; }
    }
}
