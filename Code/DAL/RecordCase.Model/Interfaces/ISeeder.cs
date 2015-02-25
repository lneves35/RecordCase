using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Model.Interfaces
{
    public interface ISeeder
    {
        void Seed(RecordCaseContext ctx);
    }
}
