using System.Collections.Generic;

namespace WebForm.Entity
{
    public class Profile
    {
        /// <summary>
        /// Id анкеты
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Id кандидата, которому принадлежит анкета
        /// </summary>
        public Guid CandidateId { get; private set; }

        /// <summary>
        /// Объект кандидат, которому принадлежит анкета
        /// </summary>
        public Candidate? Candidate { get; private set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; private set; }

        public Profile(string lastName, string firstName, string middleName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Имя не может быть пустым", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Фамилия не может быть пустой", nameof(lastName));

            FirstName   = firstName;
            LastName    = lastName;
            MiddleName  = middleName;
        }

        /// <summary>
        /// Данные о телефонах
        /// </summary>
        private readonly List<PhoneRecord> _phoneRecords = [];

        public IReadOnlyList<PhoneRecord> PhoneRecords => _phoneRecords.AsReadOnly();
        
        /// <summary>
        /// Добавление данных о телефоне
        /// </summary>
        /// <param name="record"></param>
        public void AddPhoneRecord(PhoneRecord record)
        {
            _phoneRecords.Add(record);
        }

        /// <summary>
        /// Удаление данных о телефоне
        /// </summary>
        /// <param name="record"></param>
        public void RemoveRecord(PhoneRecord record)
        {
            _phoneRecords.Remove(record);
        }

        /// <summary>
        /// Присваиваем кандидата
        /// </summary>
        /// <param name="candidate"></param>
        public void SetCandidate(Candidate candidate)
        {
            CandidateId = candidate.Id;
            Candidate   = candidate;
        }
    }
}
