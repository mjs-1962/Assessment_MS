using System.ComponentModel.DataAnnotations;

namespace Assessment_MS.Models
{
    public class SurveyRecord : IOutsideLightingQuestions, IHomeowner
    {
        public SurveyRecord()
        {
            Id = Guid.NewGuid().ToString();
        }

        public SurveyRecord(string fullName,
                            string emailAddress,
                            bool? brightnessAcceptance,
                            int? brightnessLevel,
                            string addressLine1,
                            string addressLine2,
                            string town,
                            string county,
                            string postcode)
        {
            Id = Guid.NewGuid().ToString();
            FullName = fullName;
            EmailAddress = emailAddress;
            BrightnessAcceptance = brightnessAcceptance;
            BrightnessLevel = brightnessLevel;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Town = town;
            County = county;
            Postcode = postcode;
        }

        public SurveyRecord(string id,
                            string fullName,
                            string emailAddress,
                            bool? brightnessAcceptance,
                            int? brightnessLevel,
                            string addressLine1,
                            string addressLine2,
                            string town,
                            string county,
                            string postcode)
        {
            Id = id;
            FullName = fullName;
            EmailAddress = emailAddress;
            BrightnessAcceptance = brightnessAcceptance;
            BrightnessLevel = brightnessLevel;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Town = town;
            County = county;
            Postcode = postcode;
        }

        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string? AddressLine1 { get; set; }

        [StringLength(50)]
        public string? AddressLine2 { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string? Town { get; set; }

        [StringLength(50)]
        public string? County { get; set; } = "";

        [Required]
        [StringLength(10)]
        public string? Postcode { get; set; }

        [Required]
        public bool? BrightnessAcceptance { get; set; }

        [Required]
        [Range(1, 10)]
        public int? BrightnessLevel { get; set; }
    }

}