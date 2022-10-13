using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Mark
    {
        private int markValue;
        private DateTime dateTime;
        private Course course;

        public Mark(int markValue, DateTime dateTime,Course course)
        {
            this.markValue = markValue;
            this.dateTime = dateTime;
            this.course = course;
        }

        public int MarkValue { get => markValue; set => markValue = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public Course Course { get => course; set => course = value; }

        public override String ToString()
        {
            return String.Format("Value : {0}, DateTime : {1}, Course : {2}\n\t", markValue, dateTime, course);
        }
    }
}
