using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.DtoLayer.DTOs.UIServiceDtos
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        public string SmallImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
