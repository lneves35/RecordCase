using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RecordCase.Core.System;
using RecordCase.Core.System.WMI.Entities;

namespace RecordCase.Core.Tests.IntegrationTests.System
{
    [TestFixture]
    public class ComputerManagerTests
    {
        [Test]
        public void GetComputerSystemTest_ReturnsTrue()
        {
            //Assert
            Assert.IsNotNull(ComputerManager.ComputerSystem);
        }
    }
}
