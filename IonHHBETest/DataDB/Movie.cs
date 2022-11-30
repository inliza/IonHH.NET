using System;
using System.Collections.Generic;

#nullable disable

namespace IonHHBETest.DataDB
{
    public partial class Movie
    {
        public Movie()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public Boolean Disabled { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
