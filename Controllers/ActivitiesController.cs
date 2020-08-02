using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GRADAPP.Core.Services;
using GRADAPP.APIModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GRADAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : Controller
    {
        private readonly IActivityRepository _activityRepository;

        public ActivitiesController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }



        [HttpGet]
        public IActionResult Get()
        {
            var activities = _activityRepository.GetAll().ToList();
            return Ok(activities.ToApiModel());

        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            
            return Ok(_activityRepository);
        }

        // create a new activity
        // POST api/activities
        [HttpPost]
        public IActionResult Post([FromBody] ActivityModel newActivity)
        {
            try
            {
                // TODO: convert the newAuthor to a domain model
                // add the new author
                _activityRepository.Add(newActivity.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddActivity", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            // return a 201 Created status. This will also add a "location" header
            // with the URI of the new author. E.g., /api/authors/99, if the new is 99
            return CreatedAtAction("Get", new { Id = newActivity.Id }, newActivity);
        }

        // TODO: update an existing author
        // PUT api/authors/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActivityModel updatedActivity)
        {
            // TODO: convert updatedAuthor to a domain model
            var activity = _activityRepository.Update(updatedActivity.ToDomainModel());
            if (activity == null) return NotFound();
            return Ok(activity);
        }

        // TODO: delete an existing author
        // DELETE api/authors/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var activity = _activityRepository.Get(Id);
            if (activity == null) return NotFound();
            _activityRepository.Remove(activity);
            return NoContent();
        }
    }




}

