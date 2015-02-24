using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecordCase.Core.Exceptions;

namespace RecordCase.Core.Database.Exceptions
{
    public class RecordCaseDatabaseException: RecordCaseException
    {
        public RecordCaseDatabaseException(string msg) : base(msg)
        {

        }
    }
}
