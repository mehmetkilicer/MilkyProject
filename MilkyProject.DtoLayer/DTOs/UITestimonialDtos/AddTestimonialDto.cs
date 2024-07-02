using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.DtoLayer.DTOs.UITestimonialDtos
{
    public class AddTestimonialDto
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
