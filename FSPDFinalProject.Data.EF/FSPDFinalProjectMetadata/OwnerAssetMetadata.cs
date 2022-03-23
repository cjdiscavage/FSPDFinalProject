using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSPDFinalProject.Data.EF
{
    public class OwnerAssetMetadata
    {
        [Display(Name = "Owner Asset ID")]
        public int OwnerAssetId { get; set; }

        [Required]
        [Display(Name = "Asset Name")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        public string AssetName { get; set; }

        [Required]
        [Display(Name = "Owner ID")]
        [StringLength(128, ErrorMessage = "Maximum length is 128 characters.")]
        public string OwnerId { get; set; }

        [Display(Name = "Asset Photo")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        public string AssetPhoto { get; set; }

        [Display(Name = "Special Notes")]
        [StringLength(300, ErrorMessage = "Maximum length is 300 characters.")]
        public string SpecialNotes { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
    }
    
    [MetadataType(typeof(OwnerAssetMetadata))]
    public partial class OwnerAsset { }
}
