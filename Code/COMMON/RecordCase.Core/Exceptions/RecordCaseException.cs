using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecordCase.Core.Exceptions
{
    public class RecordCaseException: Exception
    {
        public RecordCaseException(string msg) : base(msg)
        {
        }
    }
}
