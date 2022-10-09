using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class UserResponse
    {
        [JsonProperty("idUser")]
        public long IdUser { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        public static UserResponse FromEntity(User user)
        {
            UserResponse userResponse = new UserResponse();

            userResponse.IdUser = user.IdUser;
            userResponse.FirstName = user.FirstName;
            userResponse.LastName = user.LastName;
            userResponse.BirthDate = user.BirthDate;
            userResponse.Email = user.Email;
            userResponse.PhoneNumber = user.PhoneNumber;

            return userResponse;
        }
    }
}