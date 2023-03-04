using PrivateSchoolsManagement.Models;

namespace PrivateSchoolsManagement.Interfaces
{
    public interface ISchoolService
    {
        Task CreateSchoolAsync(School school);
    }
}