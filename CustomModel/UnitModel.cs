using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class UnitModel
    {
        public string Id { get; set; }
        [Display(Name = "Unit No")]
        public int UnitNo { get; set; }
        [Display(Name = "Community Id")]
        public int CommunityId { get; set; }
        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }
        
    }
}
