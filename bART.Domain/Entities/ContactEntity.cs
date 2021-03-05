namespace bART.Domain.Entities
{
    public class ContactEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string AccountName { get; set; }
        public AccountEntity Account { get; set; }
    }
}
