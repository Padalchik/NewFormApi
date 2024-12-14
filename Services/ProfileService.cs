using Microsoft.EntityFrameworkCore;
using WebForm.Entity;

namespace WebForm.Services
{
    public class ProfileService
    {
        private readonly ApplicationDBContext _dbContext;

        public ProfileService(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Возвращает список всех анкет
        /// </summary>
        /// <returns>Список анкет.</returns>
        public async Task<List<Profile>> GetProfiles()
        {
            var profiles = await _dbContext.Profiles.ToListAsync();
            return profiles;
        }
    }
}
