using System;
using System.Collections.Generic;
using System.Text;
using SFF_API.Context;
using SFF_API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SFF_API.Repositories
{
    public class TriviaRepository : ITriviaRepository
    {
        #region DBcontext
        readonly RentalServiceContext _context;
        public TriviaRepository(RentalServiceContext dbContext)
        {
            this._context = dbContext ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion

        public async Task<Trivia> AddTrivia(Trivia trivia)
        {
            try
            {
                await _context.Trivias.AddAsync(trivia);
            }
            catch (Exception e)
            {
                throw e;
            }
            await _context.SaveChangesAsync();
            return trivia;
        }

        public async Task<IEnumerable<Trivia>> GetTrivias()
        {
            return await _context.Trivias
                                .Include(r => r.Movie)
                                .Include(s => s.Studio)
                                .ToListAsync();
        }
        
        public async Task<IEnumerable<Trivia>> GetTrivia(int id)
        {
            return await _context.Trivias
                                .Where(r => r.Id == id)
                                .Include(r => r.Movie)
                                .Include(s => s.Studio)
                                .ToListAsync();
        }
        
        public async Task<IEnumerable<Trivia>> GetTriviaByMovieId(int id)
        {
                return await _context.Trivias
                                .Where(r => r.Movie.Id == id)
                                .Include(r => r.Movie)
                                .ToListAsync();
        }
       
        public async Task<Trivia> UpdateTrivia(int id, Trivia trivia)
        {
            _context.Entry(trivia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return trivia;
        }
        
        public async Task<Trivia> DeleteTrivia(int id)
        {
            var dbTrivia = await _context.Trivias.FindAsync(id);
            _context.Entry(dbTrivia).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return dbTrivia;
        }

    }
}