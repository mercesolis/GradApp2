using System;
using GRADAPP.APIModels;
using GRADAPP.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GRADAPP.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class FamilyController : Controller
        {
            private readonly IActivityRepository _activityRepository;

            public FamilyController(IActivityRepository activityRepository)
            {
                _activityRepository = activityRepository;
            }



            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_activityRepository);

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
