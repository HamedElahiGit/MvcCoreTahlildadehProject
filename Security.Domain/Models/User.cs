using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Models
{
  public  class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public DateTime RegisterDate { get; set; }
        public string VerificationMail { get; set; }
        public bool IsEmailActivated { get; set; }
        public virtual int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public User()
        {
            Role = new Role();
        }
    }
}
