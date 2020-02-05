using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Model
{
   public class ContactPerson
    {
        public int ContactPersonId { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public PositionCategory Position { get; set; }
    }
}
