using AutoMapper;
using Job_Portal_Website.DTO;
using Job_Portal_Website.Models;

namespace JobPortalBackend.MapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CompanyDTO, Company>().ReverseMap();
            CreateMap<JobPostingDTO, JobPosting>().ReverseMap();
            CreateMap<ApplyforJobDTO, ApplyforJob>().ReverseMap();
            CreateMap<JobSeekerDTO, JobSeeker>().ReverseMap();
        }
    }
}
