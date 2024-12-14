namespace WebForm.Entity
{
    public class Profile
    {
        /// <summary>
        /// Id анкеты
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id кандидата, которому принадлежит анкета
        /// </summary>
        public Guid CandidateId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; } = string.Empty;
    }
}
