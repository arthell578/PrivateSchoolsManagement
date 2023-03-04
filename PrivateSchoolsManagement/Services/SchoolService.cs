using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrivateSchoolsManagement.DTOs;
using PrivateSchoolsManagement.Exceptions;
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

        public async Task<List<SchoolDTO>> GetAllSchoolsAsync()
        {
            var schools = await _dbContext.Schools.ToListAsync();
            return _mapper.Map<List<SchoolDTO>>(schools);
        }

        public async Task<SchoolDTO> GetSchoolByIdAsync(int id)
        {
            var school = await _dbContext.Schools.FindAsync(id);
            return _mapper.Map<SchoolDTO>(school);
        }

        public async Task UpdateSchoolAsync(int id, SchoolDTO schoolDTO)
        {
            var school = await _dbContext.Schools.FindAsync(id);

            if (school == null)
            {
                throw new NotFoundException($"School with id {id} not found");
            }

            _mapper.Map(schoolDTO, school);

            await _dbContext.SaveChangesAsync();
        }
    }
}
