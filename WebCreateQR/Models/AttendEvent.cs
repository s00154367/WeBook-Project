using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebCreateQR.Models
{
    [Table("AttendEvent")]
    public class AttendEvent
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int memberId { get; set; }
        [Key, Column(Order = 2)]
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public virtual Event Events { get; set; }
        public string email { get; set; }
        public int ticketCount { get; set; }
    }
}