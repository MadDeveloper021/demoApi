using System;
using System.Collections.Generic;

namespace DemoApi.Models
{
    public partial class HackRegistration
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? Dob { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
