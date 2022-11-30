using System;
using System.Collections.Generic;

#nullable disable

namespace IonHHBETest.DataDB
{
    public partial class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public DateTime Created_dt { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
