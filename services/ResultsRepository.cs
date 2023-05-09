using Microsoft.EntityFrameworkCore;

using ResultsSummary.Models;


namespace ResultsSummary.services
{
    public class ResultsRepository
    {
        private readonly IServiceProvider _serviceProvider;

        public ResultsRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<Result> ResultsCache = new List<Result>();
        public DateTime? LastUpdate { get; set; }
        public async Task FillResults()
        {
            using var scope = _serviceProvider.CreateScope();
            using var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

            var results = await dbContext.Results.ToListAsync();

            results = results.OrderBy(r => r.AverageScore).ToList();

            ResultsCache = results;
            LastUpdate = DateTime.UtcNow;
        }


        public bool IsExpired()
        {
            return LastUpdate ==null ||  ResultsCache.Count == 0 ||  LastUpdate?.AddMinutes(5 ) < DateTime.UtcNow;
        }

        
        public async Task<double> GetPercentage(int id)
        {
            if (IsExpired())
            {
                await  FillResults();
            }

            var totalCount = ResultsCache.Count;

            var result = ResultsCache.FirstOrDefault(r => r.Id == id);

            if(result == null)
            {
                return 0;
            }

            int indexOf = ResultsCache.LastIndexOf(result);

            if (indexOf == -1)
            {
                return 0;
            }

            return (indexOf / ((double)totalCount - 1))*100;


        }
         
    }
}
