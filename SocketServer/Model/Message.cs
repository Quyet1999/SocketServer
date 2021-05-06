namespace SocketServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Message { get; set; }

        public int Sender { get; set; }

        public int Receive { get; set; }

        [Column("Message")]
        [StringLength(200)]
        public string Message1 { get; set; }

        public int Type_Message { get; set; }

        public DateTime TimeSend { get; set; }
    }
}
