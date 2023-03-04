using AutoMapper;
using PrivateSchoolsManagement.DTOs;
using PrivateSchoolsManagement.Interfaces;
using PrivateSchoolsManagement.Models;

namespace PrivateSchoolsManagement.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly SchoolsManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public SchoolService(SchoolsManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateSchoolAsync(SchoolDTO schoolDTO)
        {
            var school = _mapper.Map<School>(schoolDTO);
            await _dbContext.Schools.AddAsync(school);
            await _dbContext.SaveChangesAsync();
        }
    }
}
