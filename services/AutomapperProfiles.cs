using AutoMapper;

using ResultsSummary.Models;
using ResultsSummary.ViewModels;

namespace ResultsSummary.services
{
    public class AutomapperProfiles : Profile
    {

        public AutomapperProfiles()
        {
            CreateMap<Result, ResultViewModel>();
        }
    }
}
