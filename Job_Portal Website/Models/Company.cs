using System;
using System.Collections.Generic;

namespace Job_Portal_Website.Models
{
    public partial class Company
    {
        public Company()
        {
            ApplyforJobs = new HashSet<ApplyforJob>();
            JobPostings = new HashSet<JobPosting>();
        }

        public int Companyld { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyEmail { get; set; }
        public string? Companyphone { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyDescription { get; set; }
        public string Password { get; set; } = null!;

        public virtual ICollection<ApplyforJob> ApplyforJobs { get; set; }
        public virtual ICollection<JobPosting> JobPostings { get; set; }
    }
}
