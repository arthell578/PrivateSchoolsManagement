using PrivateSchoolsManagement.Models;

namespace PrivateSchoolsManagement.Services
{
    public class SchoolService
    {
        private readonly SchoolsManagementDbContext _dbContext;

        public SchoolService(SchoolsManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateSchoolAsync(School school)
        {
            await _dbContext.Schools.AddAsync(school);
            await _dbContext.SaveChangesAsync();
        }
    }
}
