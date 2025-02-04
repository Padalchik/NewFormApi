using Microsoft.AspNetCore.Mvc;
using WebForm.Contracts.PhoneRecord;
using WebForm.Services;

namespace WebForm.Controllers
{
    [ApiController]
    [Route("profiles/{profileId}/phones")]
    public class PhoneRecordsController : ControllerBase
    {
        private readonly PhoneRecordService _phoneRecordService;

        public PhoneRecordsController(PhoneRecordService phoneRecordService)
        {
            _phoneRecordService = phoneRecordService;
        }

        /// <summary>
        /// Создаёт запись о телефоне
        /// </summary>
        /// <param name="request">Данные для создания записи о телефоне</param>
        /// <returns>Id созданной записи</returns>
        [HttpPost]
        public async Task<Guid> Create(Guid profileId, CreatePhoneRecordRequest request)
        {
            var phoneRecordId = await _phoneRecordService.Create(profileId, request);
            return phoneRecordId;
        }
    }
}
