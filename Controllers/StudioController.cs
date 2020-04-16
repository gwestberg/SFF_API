using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF_API.Context;
using SFF_API.Models;
using SFF_API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        #region DBcontext
        readonly IStudioRepository _context;
        public StudioController(IStudioRepository dbContext)
        {
            this._context = dbContext ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion

        #region Biograf-relaterade metoder 

        //Create a studio and return it
        [HttpPost]
        public async Task<ActionResult<Studio>> AddStudio(Studio studio)
        {
            return await _context.AddStudio(studio);
        }

        //Get: api/Studio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studio>>> GetStudios()
        {
            return await _context.GetStudios();
        }

        //GET: api/Studio/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> GetStudio(int id)
        {
            return await _context.GetStudio(id);
        }

        //DELETE: api/Studio/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudio(int id)
        {

            return Ok(await _context.DeleteStudio(id));

        }

        //PUT: api/Studio/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudio(int id, Studio studio)
        {
            if (id != studio.Id)
            {
                return BadRequest();
            }

            if (studio == null)
            {
                return NotFound();
            }

            return Ok(await _context.UpdateStudio(id, studio));
        }

        #endregion

    }
}