﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<Candidate>> List()
        {
            var allCandidates = await _candidatesService.GetAll();
            return allCandidates;
        }

        /// <summary>
        /// Создание нового кандидата
        /// </summary>
        /// <param name="request">Данные для создания кандидата</param>
        /// <returns>Id созданного кандидата.</returns>
        [HttpPost]
        public async Task<Guid> Create(CreateCandidateRequest request)
        {
            //TODO собственное
            //плохо? то что связываем сервис с входящей DTO
            var candidateId = await _candidatesService.Create(request);
            return candidateId;
        }
    }
}
