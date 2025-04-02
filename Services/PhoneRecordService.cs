using FluentResults;
using Microsoft.EntityFrameworkCore;
using WebForm.Dto.PhoneRecord;
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
        /// Получение всех данных о телефонах
        /// </summary>
        /// <returns></returns>
        public async Task<List<PhoneRecord>> GetAllByProfileId(Guid profileId)
        {
            var phoneRecords = await _dbContext.PhoneRecords.Where(o => o.ProfileId == profileId).ToListAsync();
            return phoneRecords;
        }

        /// <summary>
        /// Получение одних данных о телефоне
        /// </summary>
        /// <param name="phoneRecordId"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<Result<PhoneRecordData>> GetById(Guid phoneRecordId)
        {
            var phoneRecord = await _dbContext.PhoneRecords.FirstOrDefaultAsync(c => c.Id == phoneRecordId);

            if (phoneRecord == null)
                return Result.Fail($"Запись о телефоне с ID '{phoneRecordId}' не найдена");

            return Result.Ok(new PhoneRecordData(phoneRecord));
        }

        /// <summary>
        /// Создание данных о телефонах
        /// </summary>
        /// <param name="request">Входные данные для телефона</param>
        /// <returns></returns>
        public async Task<Result<Guid>> Create(Guid profileId, CreatePhoneRecordRequest request)
        {
            var result = await _profileService.GetById(profileId);

            if (result.IsFailed)
                return Result.Fail($"Анкета с ID '{profileId}' не найдена");

            var phoneRecord = new PhoneRecord
            {
                ProfileId = profileId,
                Type      = request.Type,
                Model     = request.Model,
                Number    = request.Number,
                Note      = request.Note
            };

            Profile profile = result.Value;
            profile.AddPhoneRecord(phoneRecord);
            await _dbContext.SaveChangesAsync();

            return Result.Ok(phoneRecord.Id);
        }
    }
}
