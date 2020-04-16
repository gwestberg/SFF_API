using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SFF_API.Models;

namespace SFF_API.Repositories
{
    public interface IStudioRepository
    {
        Task <Studio> AddStudio(Studio studio);
        Task<ActionResult<IEnumerable<Studio>>> GetStudios();
        Task <Studio> GetStudio(int id);
        Task <Studio> UpdateStudio(int Id,Studio studio);
        Task<Studio> DeleteStudio(int Id);
    }
}
