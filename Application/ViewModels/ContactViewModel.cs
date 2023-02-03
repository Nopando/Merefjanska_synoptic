using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MobileNo { get; set; }
        public string PicturePath { get; set; }
    }
}
