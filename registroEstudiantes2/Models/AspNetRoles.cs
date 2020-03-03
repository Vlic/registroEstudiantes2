﻿using System;
using System.Collections.Generic;

namespace registroEstudiantes2.Models
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
