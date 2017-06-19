using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelerTask.Models
{
    public class UserProfile
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string image { get; set; }

        public int NationalityId { get; set; }

        public int MartialStatusId { get; set; }

        public string DOB { get; set; }
        
        public bool Gender { get; set; }

        public string Email { get; set; }

        public string phone { get; set; }

        public bool IsActive { get; set; }
    }

    public class UserProfileList
    {
        public List<UserProfile> userprofilelist { get; set; }
    }
}
