using System;
using System.Collections.Generic;

namespace Job_Portal_Website.Models
{
    public partial class ApplyforJob
    {
        public int AppliedJobld { get; set; }
        public int? JobSeekerId { get; set; }
        public int? Jobld { get; set; }
        public string? Status { get; set; }
        public string? Resume { get; set; }
        public int? Companyld { get; set; }

        public virtual Company? CompanyldNavigation { get; set; }
        public virtual JobSeeker? JobSeeker { get; set; }
        public virtual JobPosting? JobldNavigation { get; set; }
    }
}
