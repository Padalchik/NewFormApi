namespace WebForm.Contracts.Profile
{
    public record CreateProfileRequest
    {
        /// <summary>
        /// Id кандидата, которому принадлежит анкета
        /// </summary>
        public Guid CandidateId { get; set; }
    }
}
