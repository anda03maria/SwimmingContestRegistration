using System;
using System.Text;

namespace SwimmingModel.contest
{
    public class Race : Entity<int>
    {
        public int Distance { get; set; }
        public SwimmingStyle Style { get; set; }
        public DateTime Date { get; set; }
        
        public Race(int id) : base(id)
        {
        }

        public Race()
        {
        }

        public Race(int id, int distance, SwimmingStyle style, DateTime date) : base(id)
        {
            Distance = distance;
            Style = style;
            Date = date;
        }

        public Race(int distance, SwimmingStyle style, DateTime date) : base()
        {
            Distance = distance;
            Style = style;
            Date = date;
        }

        public string ToString()
        {
            return String.Format("{0} {1} {2} {3}", Id, Distance, Style.ToString(), Date.ToString());

        }
    }
}