using WebForm.Definitions;

namespace WebForm.Dto.PhoneRecord
{
    public record CreatePhoneRecordRequest
    {
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
}
