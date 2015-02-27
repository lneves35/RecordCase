using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Core.Validation
{
    public class ValidationRule<T>
    {
        public Expression<Func<T, bool>> Expression { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationRule(Expression<Func<T, bool>> expression, string errorMessage)
        {
            Expression = expression;
            ErrorMessage = errorMessage;
        }
    }
}
