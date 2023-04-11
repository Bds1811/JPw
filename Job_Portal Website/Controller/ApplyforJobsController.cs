﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Job_Portal_Website.Models;
using AutoMapper;
using Job_Portal_Website.DTO;

namespace Job_Portal_Website.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyforJobsController : ControllerBase
    {
        private readonly Job_PortalContext _context;
        private readonly IMapper _automapper;

        public ApplyforJobsController(Job_PortalContext context, IMapper automapper)
        {
            _context = context;
            _automapper = automapper;
        }

        // GET: api/ApplyforJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplyforJob>>> GetApplyforJobs()
        {
            return await _context.ApplyforJobs.ToListAsync();
        }

        // GET: api/ApplyforJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplyforJob>> GetApplyforJob(int id)
        {
         
            var applyforJob = await _context.ApplyforJobs.FindAsync(id);

            if (applyforJob == null)
            {
                return NotFound();
            }

            return applyforJob;
        }

        // PUT: api/ApplyforJobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplyforJob(int id, ApplyforJobDTO applyforJob)
        {
            var userProfile = await _context.ApplyforJobs.FindAsync(id);
            try
            {
                if (userProfile == null)
                {
                    return NotFound();
                }
                _automapper.Map(applyforJob, userProfile);
                _context.Entry(userProfile).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(applyforJob);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplyforJobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        //    if (id != applyforJob.AppliedJobld)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(applyforJob).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!ApplyforJobExists(id))
    //            {
    //                return NotFound();
    //}
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

        // POST: api/ApplyforJobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplyforJob>> PostApplyforJob(ApplyforJobDTO applyforJob)
        {
                var user = _automapper.Map<ApplyforJob>(applyforJob);
                _context.ApplyforJobs.Add(user);
                await _context.SaveChangesAsync();
         
            return CreatedAtAction("GetApplyforJob", new { id = user.AppliedJobld }, user);
        }

        // DELETE: api/ApplyforJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplyforJob(int id)
        {
            if (_context.ApplyforJobs == null)
            {
                return NotFound();
            }
            var applyforJob = await _context.ApplyforJobs.FindAsync(id);
            if (applyforJob == null)
            {
                return NotFound();
            }

            _context.ApplyforJobs.Remove(applyforJob);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplyforJobExists(int id)
        {
            return (_context.ApplyforJobs?.Any(e => e.AppliedJobld == id)).GetValueOrDefault();
        }
    }
}
