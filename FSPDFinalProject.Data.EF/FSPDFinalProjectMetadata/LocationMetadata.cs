using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSPDFinalProject.Data.EF
{
    public class LocationMetadata
    {
        [Display(Name = "Location ID")]
        public int LocationID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Maximum length is 100 characters.")]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Maximum length is 100 characters.")]
        public string City { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "Must be 2 characters.")]
        public string State { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "Must be 5 characters.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Reservation Limit")]
        public byte ReservationLimit { get; set; }
    }

    [MetadataType(typeof(LocationMetadata))]
    public partial class Location { }
}
