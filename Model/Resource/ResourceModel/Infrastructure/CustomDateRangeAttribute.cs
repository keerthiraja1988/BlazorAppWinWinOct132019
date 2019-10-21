namespace ResourceModel.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CustomDateRangeAttribute : RangeAttribute
    {
        public CustomDateRangeAttribute()
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(-6).ToShortDateString(),
                  DateTime.Now.ToShortDateString())
        {
        }
    }
}