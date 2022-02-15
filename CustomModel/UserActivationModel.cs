using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class UserActivationModel
    {
        public int id { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public string VerificationCode { get; set; }
        public bool IsVarified { get; set; }
        public DateTime IsVarified_at { get; set; }
        public DateTime Created_at { get; set; }
    }
}
