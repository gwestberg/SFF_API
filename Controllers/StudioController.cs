using Microsoft.AspNetCore.Mvc;
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
            var studios = await _context.AddStudio(studio);
            if (studios == null)
            {
                NotFound();
            }
            return Ok(studios);
        }

        //Get: api/Studio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studio>>> GetStudios()
        {
            var studios = await _context.GetStudios();
            if (studios == null)
            {
                NotFound();
            }
            return Ok(studios);
        }

        //GET: api/Studio/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> GetStudio(int id)
        {
            var studios = await _context.GetStudios();
            if (studios == null)
            {
                NotFound();
            }
            return Ok(studios);
        }

        //DELETE: api/Studio/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudio(int id)
        {
            var studios = await _context.DeleteStudio(id);
            if (studios == null)
            {
                NotFound();
            }
            return Ok(studios);
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