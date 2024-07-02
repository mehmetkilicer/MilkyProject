using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class Member
    {
        public int MemberID { get; set; }
        public string? ImageUrl { get; set; }
        public string? NameSurname { get; set; }
        public string? Title { get; set; }
    }
}
