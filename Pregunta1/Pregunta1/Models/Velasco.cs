using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Pregunta1.Models
{
    public enum Places
    {
        Santa_Cruz = 1,
        Warnes = 2,
        Cotoca = 3,
        Porongo = 4,
        Samaipata = 5
    }
    public class Velasco
    {
        [Key]
        public int VelascoID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24), MinLength(2)]
        public string FriendofVelasco { get; set; }
        [Required]
        public Places place { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Invalido")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Cumpleaños")]
        public DateTime Birthdate { get; set; }

    }
}