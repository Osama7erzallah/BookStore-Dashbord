using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace project1.ViewModel
{
    public class AutherFormVM
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        [MaxLength(30, ErrorMessage = "Max length is 30")]
        //[Remote("checkName", null, ErrorMessage = "Name already Exists")]
        [Remote(action: "checkName", controller: "Author", ErrorMessage = "Name already exists")]
        public string Name { get; set; }
    }
}
