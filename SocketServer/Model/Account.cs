namespace SocketServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(20)]
        public string StudentCode { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public bool? Sex { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
