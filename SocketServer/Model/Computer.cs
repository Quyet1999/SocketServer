namespace SocketServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Computer")]
    public partial class Computer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ComputerID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Mac_Address { get; set; }

        [StringLength(50)]
        public string IP_Address { get; set; }

        public bool Status { get; set; }

        public int? StudentID { get; set; }

        public DateTime? TimeStart { get; set; }
    }
}
