// AlexeyQwake Qwake

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Models
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext context;

        public RequestRepository(BlogContext context)
        {
            this.context = context;
        }
        public async Task LogRequest(Request request)
        {
            request.Id = Guid.NewGuid();
            request.Date = DateTime.Now;
            
            var entry = context.Entry(request);
            if (entry.State == EntityState.Detached)
                await context.Requests.AddAsync(request);
            
            await context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            return await context.Requests.ToArrayAsync();
        }
    }
}