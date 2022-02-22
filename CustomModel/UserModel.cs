using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class UserModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Email is Requirde")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        [Display(Name = "Email ID")]
        public string Email_id { get; set; }
        public string token { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
        public int TenantID { get; set; }
        public int TenantTypeId { get; set; }
    }
}
