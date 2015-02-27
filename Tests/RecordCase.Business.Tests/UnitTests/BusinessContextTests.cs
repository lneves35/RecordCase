using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RecordCase.Common.Exceptions;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Locations;

namespace RecordCase.Business.Tests.UnitTests
{
    
    public class BusinessContextTests : BaseBusinessUnitTests
    {
        [Test]
        public void AddLocation_ThrowsRecordCaseValidation()
        {
            //Arrange
            Location locationVinyl = new LocationVinylSide();

            //Assert
            var ex = Assert.Throws(typeof(RecordCaseValidationException),() => businessContext.AddLocation(locationVinyl));
            Console.WriteLine(ex.Message);
        }

    }
}
