using System;
using System.Collections.Generic;
using System.Text;
using SFF_API.Context;
using SFF_API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SFF_API.Repositories
{
    public class StudioRepository: IStudioRepository
    {
        #region DBcontext
        readonly RentalServiceContext _context;
        public StudioRepository(RentalServiceContext dbContext)
        {
            this._context = dbContext ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion

        public async Task<Studio> AddStudio(Studio studio)
        {
            try
            {
                await _context.Studios.AddAsync(studio);
            }
            catch (Exception e)
            {
                throw e;
            }
            await _context.SaveChangesAsync();
            return studio;
        }

        public async Task<ActionResult<IEnumerable<Studio>>> GetStudios()
        {
            return await _context.Studios.ToListAsync();
        }

        public async Task<Studio> GetStudio(int id)
        {
            var studio = await _context.Studios.FindAsync(id);
            return studio;
        }

        public async Task<Studio> DeleteStudio(int id)
        {
            var dbstudio = await _context.Studios.FindAsync(id);
            _context.Entry(dbstudio).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return dbstudio;

        }
        public async Task<Studio> UpdateStudio(int id, Studio studio)
        {
             _context.Entry(studio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return studio;
        }

    }
}