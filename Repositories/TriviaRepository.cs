using System;
using System.Collections.Generic;
using System.Text;
using SFF_API.Context;
using SFF_API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SFF_API.Repositories
{
    public class TriviaRepository : ITriviaRepository
    {
        #region DBcontext
        readonly RentalServiceContext db;
        public TriviaRepository(RentalServiceContext dbContext)
        {
            this.db = dbContext ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion


    }
}