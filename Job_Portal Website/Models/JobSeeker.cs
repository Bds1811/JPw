using System;
using System.Collections.Generic;

namespace Job_Portal_Website.Models
{
    public partial class JobSeeker
    {
        public JobSeeker()
        {
            ApplyforJobs = new HashSet<ApplyforJob>();
        }

        public int JobSeekerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? Skills { get; set; }
        public string Password { get; set; } = null!;

        public virtual ICollection<ApplyforJob> ApplyforJobs { get; set; }
    }
}
