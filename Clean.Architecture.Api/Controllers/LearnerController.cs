using Microsoft.AspNetCore.Mvc;
using Clean.Architecture.Application.Services.ActiveLearners;
using Clean.Architecture.Application.Services.ArchivedLearners;
using Clean.Architecture.Domain.Entities;

namespace Clean.Architecture.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LearnersController : ControllerBase
    {
        private readonly ILearnerService _learnerService;
        private readonly IArchivedLearnerService _archivedLearnerService;

        public LearnersController(ILearnerService learnerService, IArchivedLearnerService archivedLearnerService)
        {
            _learnerService = learnerService;
            _archivedLearnerService = archivedLearnerService;
        }

        [HttpGet("{id}", Name = "GetLearnerById")]
        public async Task<ActionResult<Learner>> GetLearnerById(int id)
        {
           var result = await _learnerService.GetLearner(id);

           return result != null? Ok(result) : NotFound("Learner Not Found");
        }

        [HttpGet("archived/{id}", Name = "GetArchivedLearnerById")]
        public async Task<ActionResult<Learner>> GetArchivedLearnerById(int id)
        {
            var result = await _archivedLearnerService.GetArchivedLearnerFromArchive(id);

            return result != null ? Ok(result) : NotFound("Archived Learner Not Found");
        }
    }
}
