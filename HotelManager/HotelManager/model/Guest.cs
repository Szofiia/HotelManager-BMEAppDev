using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManager.model
{
    public class Guest
    {

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public bool IsChild { get; set; }

        // Only for testing purpose
        public Guest(long id, string firstName, string lastName, string birthDate, bool isChild)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            IsChild = isChild;
        }

        public Guest()
        {
        }
    }
}
