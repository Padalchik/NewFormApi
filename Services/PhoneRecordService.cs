using Microsoft.EntityFrameworkCore;
using WebForm.Contracts.PhoneRecord;
using WebForm.Entity;

namespace WebForm.Services
{
    public class PhoneRecordService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ProfileService _profileService;

        public PhoneRecordService(ApplicationDBContext context, ProfileService profileService)
        {
            _dbContext = context;
            _profileService = profileService;
        }

        /// <summary>
        /// Создание данных о телефонах
        /// </summary>
        /// <param name="request">Входные данные для телефона</param>
        /// <returns></returns>
        public async Task<Guid> Create(CreatePhoneRecordRequest request)
        {
            var profile = _profileService.GetById(request.ProfileId).Result;

            var phoneRecord = new PhoneRecord
            {
                ProfileId = request.ProfileId,
                Type = request.Type,
                Model = request.Model,
                Number = request.Number,
                Note = request.Note
            };

            //нужно ли тут помещать в Profile.PhoneRecordList ???
            await _dbContext.PhoneRecords.AddAsync(phoneRecord);
            await _dbContext.SaveChangesAsync();

            return phoneRecord.Id;
        }
    }
}
