namespace WebForm.Dto.PhoneRecord
{
    public record PhoneRecordData
    {
        public PhoneRecordData(Entity.PhoneRecord phoneRecord) 
        {
            Type   = phoneRecord.Type.ToString();
            Number = phoneRecord.Number;
            Model  = phoneRecord.Model;
            Note   = phoneRecord.Note;
        }


        /// <summary>
        /// Тип
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; } = string.Empty;

        /// <summary>
        /// Модель
        /// </summary>
        public string Model { get; } = string.Empty;

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; } = string.Empty;
    }
}
