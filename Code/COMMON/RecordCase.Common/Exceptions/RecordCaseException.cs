using System;

namespace RecordCase.Common.Exceptions
{
    public class RecordCaseException: Exception
    {
        public RecordCaseException(string msg, Exception inner) : base(msg, inner)
        {

        }

        public RecordCaseException(string msg)
            : base(msg)
        {

        }
    }
}
