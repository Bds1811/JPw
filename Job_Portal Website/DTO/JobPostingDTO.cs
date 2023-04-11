namespace Job_Portal_Website.DTO
{
    public class JobPostingDTO
    {
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? JobExperienceLevel { get; set; }
        public string? JobSkillSet { get; set; }
        public string? JobPayScale { get; set; }
        public string? IpLocation { get; set; }
        public string? JobStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Companyld { get; set; }

    }
}
