using ComplaintSystem.Model;

namespace ComplaintSystem.DbContext
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DataSeeder(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public void Seed()
        {
            if(!_applicationDbContext.complainStatuses.Any())
            {
                var complainstatus = new List<ComplainStatus>()
                {
                    new ComplainStatus()
                    {
                    Status = "Halted"
                    },
                    new ComplainStatus()
                    {
                        Status ="Completed"
                    },
                    new ComplainStatus()
                    {
                        Status ="Pending"
                    }
                };
                _applicationDbContext.complainStatuses.AddRange(complainstatus);
                _applicationDbContext.SaveChanges();
            }
        }

    }
}
