using Microsoft.AspNetCore.Mvc;
using WebForm.Contracts.Candidate;
using WebForm.Entity;
using WebForm.Services;

namespace WebForm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateService _candidatesService;

        public CandidatesController(CandidateService candidateService)
        {
            _candidatesService = candidateService;
        }

        /// <summary>
        /// Возвращает всех кандидатов
        /// </summary>
        /// <returns>Список кандидатов.</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _candidatesService.GetAll();

            if (result.IsFailed)
                return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);

            return Ok(result.Value);
        }

        /// <summary>
        /// Создание нового кандидата
        /// </summary>
        /// <param name="request">Данные для создания кандидата</param>
        /// <returns>Id созданного кандидата.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCandidateRequest request)
        {
            var result = await _candidatesService.Create(request);

            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }
    }
}
