namespace Job_Portal_Website.DTO
{
    public class JobSeekerDTO
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? Skills { get; set; }
        public string Password { get; set; } = null!;
    }
}
