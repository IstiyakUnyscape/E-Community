using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class MenuModel
    {
        public string Id { get; set; }
       
        [Display(Name = "Menu Display Name")]
        public string Menu_Display_Name { get; set; }
        [Display(Name = "Logical Name")]
        public string Logical_Name { get; set; }
        [Display(Name = "ParentID")]
        public string ParentID { get; set; }
        [Display(Name = "Controller Name")]
        public string Controller_Name { get; set; }
        [Display(Name = "Action Name")]
        public string ActionName { get; set; }
        [Display(Name = "Http Method")]
        public string Http_Method { get; set; }
        [Display(Name = "Optional RouteValues")]
        public string Optional_RouteValues { get; set; }
        public string CreatedBy { get; set; }        
        public string ModifiedBy { get; set; }

    }
}
