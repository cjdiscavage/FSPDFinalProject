using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSPDFinalProject.Data.EF
{
    public class ReservationMetadata
    {
        [Display(Name = "Reservation ID")]
        public int ReservationId { get; set; }

        [Required]
        [Display(Name = "Owner Asset ID")]
        public int OwnerAssetId { get; set; }

        [Required]
        [Display(Name = "Location ID")]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Reservation Date")]
        public DateTime ReservationDate { get; set; }
    }

    [MetadataType(typeof(ReservationMetadata))]
    public partial class Reservation { }
}
