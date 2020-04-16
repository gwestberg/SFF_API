using System;
using System.Collections.Generic;
using System.Text;

namespace SFF_API.Models
{
   public  class Review
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; }

    public bool GradeWithinRange(Review review)
    {
        if (review.Grade < 5 && review.Grade > 0)
            return true;
        else return false;
    }
    }
}
