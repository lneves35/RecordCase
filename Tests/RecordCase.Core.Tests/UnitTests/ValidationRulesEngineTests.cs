using System;
using System.Collections.Generic;
using System.Linq;
using LinqKit;
using NUnit.Framework;
using RecordCase.Core.Validation;

namespace RecordCase.Core.Tests.UnitTests
{
    [TestFixture]
    public class ValidationRulesEngineTests
    {
        private ValidationRulesEngine valEngine;

        [SetUp]
        public void Setup()
        {
            valEngine = new ValidationRulesEngine();
        }

        [Test]
        public void CheckValidationRule_ThrowsValidationException()
        {
            //Arrange
            var falsePredicate = PredicateBuilder.False<object>();
            string errMsg = "Predicate returned false";
            object o = new object();

            //Act
            valEngine.AddValidation<object>(falsePredicate, errMsg);

            //Assert
            Assert.Throws(typeof (ValidationException), () => valEngine.ValidateOrThrow(o));
        }

        [Test]
        public void CheckValidationRule_DoesntThrowValidationException()
        {
            //Arrange
            var truePredicate = PredicateBuilder.True<object>();
            string errMsg = "Predicate returned false";
            object o = new object();

            //Act
            valEngine.AddValidation(truePredicate, errMsg);

            //Assert
            Assert.DoesNotThrow( () => valEngine.ValidateOrThrow(o));
        }


        [Test]
        public void CheckValidationRules_ReturnsMultipleErrorMessages()
        {
            //Arrange
            var falsePredicate1 = PredicateBuilder.False<object>();
            var falsePredicate2 = PredicateBuilder.False<object>();
            var truePredicate = PredicateBuilder.True<object>();
            string errMsg1 = "Predicate1 returned false";
            string errMsg2 = "Predicate2 returned false";
            string errMsg3 = "True predicate returned false";

            valEngine.AddValidation(falsePredicate1, errMsg1);
            valEngine.AddValidation(falsePredicate2, errMsg2);
            valEngine.AddValidation(truePredicate, errMsg3);

            object o = new object();

            //Act
            var errors = valEngine.Validate(o);

            //Assert
            Assert.IsTrue(errors.Contains(errMsg1) && errors.Contains(errMsg2));
        }


        [Test]
        public void HasValidationRules_ReturnsTrue()
        {
            //Arrange
            var falsePredicate1 = PredicateBuilder.False<object>();
            string errMsg1 = "Predicate1 returned false";
            valEngine.AddValidation(falsePredicate1, errMsg1);
            object o = new object();

            //Act
            bool hasValRules = valEngine.HasValidationRules<object>();

            //Assert
            Assert.IsTrue(hasValRules);
        }


        [Test]
        public void HasValidationRules_ReturnsFalse()
        {
            //Arrange
            object o = new object();

            //Act
            bool hasValRules = valEngine.HasValidationRules<object>();

            //Assert
            Assert.IsFalse(hasValRules);
        }


        [Test]
        public void HasValidationRules_CheckDerivedObjects()
        {            
            //Arrange
            var falsePredicate1 = PredicateBuilder.False<object>();
            string errMsg1 = "Predicate1 returned false";
            valEngine.AddValidation(falsePredicate1, errMsg1);

            string a = "";

            //Act
            var errors = valEngine.Validate(a);

            //Assert
            Assert.IsTrue(errors.Count() == 1);
        }
    }
}
