using FluentResults;
using Microsoft.AspNetCore.Mvc;
using WebForm.Dto.PhoneRecord;
using WebForm.Entity;
using WebForm.Services;

namespace WebForm.Controllers
{
    [ApiController]
    [Route("profiles/{profileId}/phoneRecords")]
    public class PhoneRecordsController : ControllerBase
    {
        private readonly PhoneRecordService _phoneRecordService;

        public PhoneRecordsController(PhoneRecordService phoneRecordService)
        {
            _phoneRecordService = phoneRecordService;
        }

        /// <summary>
        /// Возвращает список данных о телефонах для указанной анкеты
        /// </summary>
        /// <param name="profileId">Id анкеты</param>
        /// <returns>Список данных о телефонах</returns>
        [HttpGet]
        public async Task<IActionResult> List(Guid profileId)
        {
            var phoneRecords = await _phoneRecordService.GetAllByProfileId(profileId);
            return Ok(phoneRecords);
        }

        /// <summary>
        /// Возвращает информацию о телефоне по Id
        /// </summary>
        /// <param name="phoneId">Id записи о телефоне</param>
        /// <returns></returns>
        [HttpGet("{phoneRecordId}")]
        public async Task<IActionResult> Get(Guid phoneRecordId)
        {
            var result = await _phoneRecordService.GetById(phoneRecordId);

            if (result.IsFailed)
                return NotFound($"Данные о телефоне с ID '{phoneRecordId}' не найдена");

            return Ok(result.Value);
        }

        /// <summary>
        /// Создаёт запись о телефоне для указанной анкеты
        /// </summary>
        /// <param name="profileId">Id анкеты</param>
        /// <param name="request">Данные для создания записи о телефоне</param>
        /// <returns>Id созданной записи</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Guid profileId, CreatePhoneRecordRequest request)
        {
            if (request == null)
                return BadRequest("Некорректные данные для создания записи о телефоне.");

            var result = await _phoneRecordService.Create(profileId, request);

            if (result.IsFailed)
                return NotFound(result.Errors.First().Message);

            return CreatedAtAction(nameof(Get), new { profileId, phoneRecordId = result.Value }, result.Value);
        }
    }
}
