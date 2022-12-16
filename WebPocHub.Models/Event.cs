using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPocHub.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [MaxLength(6)]
        public string EventCode { get; set; } = string.Empty;

        [MaxLength(100)]
        public string EventName { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Column(TypeName = "Decimal(18,2)")]
        public decimal Fees { get; set; }

        public int SeatsFilled { get; set; }

        [MaxLength(200)]
        public string Logo { get; set; } = string.Empty;
    }
}
