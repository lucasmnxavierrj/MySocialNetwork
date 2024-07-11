namespace MySocialNetwork.Api.Contracts.UserProfiles.Responses
{
    public record BasicInfoDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; } // Talvez transformar em Value Object
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrentCity { get; set; }
    }
}
