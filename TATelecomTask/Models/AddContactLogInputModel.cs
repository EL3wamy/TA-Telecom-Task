using System.ComponentModel.DataAnnotations;

namespace TATelecomTask.Models
{
    public class AddContactLogInputModel
    {
        [Required(ErrorMessage ="shoud insert message")]
        public string Message { get; set; }
    }
}
