using System.ComponentModel.DataAnnotations;

namespace PracticeCoreWebApi.Model
{
    public class SignupDetail
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "First Name should be minimum 3 characters and a maximum of 50 characters")]
        public string Firstname { get; set; }=string.Empty;

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 50 characters")]
        public string Lastname { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} is required")]
        public string  Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string  Useremail { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string  Userphone { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]       
        public string Password { get; set; } = string.Empty;
    }

    public class LogInRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class Login
    {
        public Login()
        {
            CommonResponseStatus = new CommonResponseStatus();
        }
        public CommonResponseStatus CommonResponseStatus { get; set; }
        public string token { get; set; }=string.Empty;
    }
}
