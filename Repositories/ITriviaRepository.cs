using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SFF_API.Models;

namespace SFF_API.Repositories
{
    public interface ITriviaRepository
    {
        Task <Trivia> AddTrivia(Trivia trivia);
        Task<IEnumerable<Trivia>> GetTrivias();
        Task<IEnumerable<Trivia>> GetTrivia(int id);
        Task<IEnumerable<Trivia>> GetTriviaByMovieId(int id);
        Task<Trivia> UpdateTrivia(int id, Trivia trivia);
        Task<Trivia> DeleteTrivia(int id);
    }
}