namespace WebForm.Contracts.Candidate
{
    //TODO для дтошек запросов лучше использовать record https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
    //TODO комментарии ко всем полям, всем классам и методам
    public class CreateCandidateRequest
    {
        public string FirstName { get; set; }  = string.Empty;
        public string LastName { get; set; }   = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
    }
}
