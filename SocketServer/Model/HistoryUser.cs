namespace SocketServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HistoryUser")]
    public partial class HistoryUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HistoryID { get; set; }

        public int? ComputerID { get; set; }

        public int? AccountID { get; set; }

        public DateTime? TimeStart { get; set; }

        public DateTime? TimeClose { get; set; }
    }
}
