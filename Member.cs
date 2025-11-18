using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Member
    {
        public int MemberId {  get; set; }
        public string Name { get; set; }

        public Member(int Id, string name)
        {
            MemberId=Id;
            Name = name;
        }
    }
}
