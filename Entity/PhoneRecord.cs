namespace WebForm.Entity
{
    public class PhoneRecord
    {
        /// <summary>
        /// Id записи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id анкеты, которой принадлежит запись
        /// </summary>
        public Guid ProfileId { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public PhoneType Type { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// Модель
        /// </summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; } = string.Empty;
    }

    public enum PhoneType
    {
        Mobile,
        Work,
        Home
    }
}
