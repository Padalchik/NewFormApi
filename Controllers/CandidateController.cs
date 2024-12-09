using Microsoft.AspNetCore.Mvc;
using WebForm.Contracts.Candidate;
using WebForm.Entity;
using WebForm.Services;

namespace WebForm.Controllers
{
    //TODO потерялось наследование от ControllerBase, почитать и рассказать что это дает
    //TODO имя контроллера не соответсвует конвенции реста, должно заканчиваться на S CandidatesController
    [Route("[controller]")]
    [ApiController]
    public class CandidateController
    {
        private readonly CandidateService _candidatesService;

        public CandidateController(CandidateService candidateService)
        {
            _candidatesService = candidateService;
        }

        //TODO лучше по все методы пробрасывать токен отмены, рассказать почему это важно
        //TODO лучше по конвенции именовать метод Search или List
        [HttpGet]
        public async Task<List<Candidate>> GetAllCandidates()
        {
            var allCandidates = await _candidatesService.GetAllCandidates();

            return allCandidates;
        }

        //TODO лучше по конвенции именовать просто Create, иначе появляетяс не нужная многословность
        //TODO аттрибут FromBody не нужен, так как это поведение по умолчанию
        [HttpPost]
        public async Task<Guid> CreateCandidate([FromBody] CreateCandidateRequest request)
        {
            //TODO собственное
            //плохо? то что связываем сервис с входящей DTO
            var candidateId = await _candidatesService.CreateCandidate(request);

            return candidateId;
        }
    }
}
