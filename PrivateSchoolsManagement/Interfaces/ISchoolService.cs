﻿using PrivateSchoolsManagement.DTOs;
using PrivateSchoolsManagement.Models;

namespace PrivateSchoolsManagement.Interfaces
{
    public interface ISchoolService
    {
        Task CreateSchoolAsync(SchoolDTO schoolDTO);
    }
}