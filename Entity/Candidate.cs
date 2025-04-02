namespace WebForm.Entity
{
    public class Candidate
    {
        /// <summary>
        /// Конструктор для создания кандидата (с валидацией)
        /// </summary>
        public Candidate(string firstName, string lastName, string middleName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Имя кандидата не может быть пустым.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Фамилия кандидата не может быть пустой.", nameof(lastName));

            FirstName  = firstName;
            LastName   = lastName;
            MiddleName = middleName;
        }

        /// <summary>
        /// Id кандидата
        /// </summary>
        public Guid Id { get; init; } = Guid.NewGuid();

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; protected set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; protected set; } = string.Empty;

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; protected set; } = string.Empty;

        /// <summary>
        /// Анкеты кандидата
        /// </summary>
        public List<Profile> Profiles { get; protected set; } = new();

        /// <summary>
        /// Добавляет анкету к кандидату
        /// </summary>
        public void AddProfile(Profile profile)
        {
            Profiles.Add(profile);
        }
    }
}
