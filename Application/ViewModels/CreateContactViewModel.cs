using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels
{
    public class CreateContactViewModel
    {
        //public List<CategoryViewModel> Categories { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be blank!")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname cannot be blank!")]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile number cannot be blank!")]
        [Display(Name = "Mobile number")]
        public string MobileNo { get; set; }

        [Display(Name = "Picture")]
        public string PicturePath { get; set; }
    }
}
