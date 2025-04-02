namespace WebForm.Contracts.Candidate
{
    public record CreateCandidateRequest
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }  = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }   = string.Empty;

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; } = string.Empty;
    }
}
