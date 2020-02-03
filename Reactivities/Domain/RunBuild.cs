using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RunBuild
    {
        public Guid Id { get; set; }
        public DateTime RunFirst { get; set; }

        public DateTime Run { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool IsEnbale { get; set; }
    }
}
