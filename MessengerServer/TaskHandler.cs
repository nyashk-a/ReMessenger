using Microsoft.EntityFrameworkCore;
using NetDriver.AE;
using Shared.Source.USC;

namespace MessengerServer
{
    internal class TaskHandler
    {
        private readonly IDbContextFactory<AppDbContext> _context;
        public TaskHandler(IDbContextFactory<AppDbContext> contextFactory)
        {
            _context = contextFactory;
        }

        public async Task Executor(ResultContent content)
        {
            switch(content.type)
            {

            }
        }
    }
}
