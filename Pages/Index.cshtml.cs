using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using ResultsSummary.services;
using ResultsSummary.ViewModels;

namespace ResultsSummary.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ResultsRepository _resultsRepository;

        public IndexModel(
            ApplicationDbContext applicationDbContext,
            IMapper mapper,
            ResultsRepository resultsRepository)
        {
            _applicationDbContext = applicationDbContext;
            this._mapper = mapper;
            this._resultsRepository = resultsRepository;
            Model = DefaultModel;
        }
        [BindProperty]
        public  ResultViewModel? Model { get; set; }

        private ResultViewModel DefaultModel { get; set; } = new ResultViewModel
        {
            Id = 0,
            ReactionScore = 80,
            PercentOfPeople = 65,
            MemoryScore = 27,
            VerbalScore = 75,
            VisualScore = 42,
            AverageScore = 43
        };

        
        public async Task<IActionResult> OnGetAsync([FromQuery]int? id)
        {
            if (!id.HasValue)
            {

                return Page();
            }

            var result = await _applicationDbContext.Results.FirstOrDefaultAsync(r => r.Id == id);

            if(result == null)
            {
                return Page();
            }

            Model = _mapper.Map<ResultViewModel>(result);

            var percentage = await _resultsRepository.GetPercentage(id.Value);

            Model.PercentOfPeople = (int)percentage;

            return Page();

        }
    }
}