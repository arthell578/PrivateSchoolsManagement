using PrivateSchoolsManagement.DTOs;
using PrivateSchoolsManagement.Models;

namespace PrivateSchoolsManagement.Interfaces
{
    public interface ISchoolService
    {
        Task CreateSchoolAsync(SchoolDTO schoolDTO);
        Task<List<SchoolDTO>> GetAllSchoolsAsync();
        Task<SchoolDTO> GetSchoolByIdAsync(int id);
        Task UpdateSchoolAsync(int id, SchoolDTO schoolDTO);
    }
}