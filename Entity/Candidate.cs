namespace WebForm.Entity
{
    public class Candidate
    {
        //TODO для чего пустые строки по умолчанию выставляются, почему замещается налл?
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
    }
}
