using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class UserRequest
    {
        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [StringLength(50, ErrorMessage = "El nombre puede tener maximo 50 caracteres")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es un campo requerido")]
        [StringLength(50, ErrorMessage = "El apellido puede tener maximo 50 caracter")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es un campo requerido")]
        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "El email es un campo requerido")]
        [StringLength(50, ErrorMessage = "El email puede tener como maximo 50 caracteres")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El numero telefonico es un campo requerido")]
        [StringLength(10, ErrorMessage = "El numero de telefono puede tener como maximo 10 caracteres")]
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}