using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HackRegistration.Models
{
    public class Hacks
    {

        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [JsonIgnore]
        [Compare("EmailAddress")]
        [Required]
        [EmailAddress]
        public string ConfirmEmailAddress { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public string AreaCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime? CreatedOn { get; set; }

        [JsonIgnore]
        public string ProfileName { get => FirstName + " " + LastName; }
    }
}
