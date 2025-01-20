using Microsoft.AspNetCore.Mvc;
using WebForm.Contracts.PhoneRecord;
using WebForm.Services;

namespace WebForm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhoneRecordController : ControllerBase
    {
        private readonly PhoneRecordService _phoneRecordService;

        public PhoneRecordController(PhoneRecordService phoneRecordService)
        {
            _phoneRecordService = phoneRecordService;
        }

        /// <summary>
        /// Создаёт запись о телефоне
        /// </summary>
        /// <param name="request">Данные для создания записи о телефоне</param>
        /// <returns>Id созданной записи</returns>
        [HttpPost]
        public async Task<Guid> Create(CreatePhoneRecordRequest request)
        {
            var phoneRecordId = await _phoneRecordService.Create(request);
            return phoneRecordId;
        }
    }
}
