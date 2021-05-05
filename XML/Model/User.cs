using System;
namespace XML.Model
{
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string WebSite { get; set; }
        public string Bio { get; set; }
        public bool IsPrivate { get; set; }


    }
}
