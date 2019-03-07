using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class ForumPost
    {
        [Required (ErrorMessage = "*")]
        [MaxLength (20, ErrorMessage = "Username needs to be less than 20 characters")]
        public string Username { get; set; }


        public DateTime PostDate { get; set; }

        [Required(ErrorMessage = "*")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "*")]
        [MinLength(2, ErrorMessage = "Message needs to be more than 2 characters")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}