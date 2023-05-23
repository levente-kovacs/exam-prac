using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SuliVerseny.Controllers;
using SuliVerseny.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace SuliVersenyTest.Controllers
{
    [ExcludeFromCodeCoverage]
    public class FelhasznalokTests
    {
        private FelhasznalokController _felhasznalokController;

        private Mock<IGet> _getMock;
        public FelhasznalokTests()
        {
            _felhasznalokController = new FelhasznalokController();
            _getMock = new Mock<IGet>();
        }

        [Theory]
        [InlineData("ff3ea660-0095-47e4-8781-93f6288b539b")]
        [InlineData("a2aa0016-2177-4ccb-9777-16cb37abb680")]
        [InlineData("fcad0579-ba88-422c-8ea2-e7fc1535caf4")]
        public void Get_ReturnIActionResult(string value)
        {
            // Arrange
            var uId = value;

            // Act
            var result = _felhasznalokController.Get(uId);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBe(null);
                result.Should().BeOfType<BadRequestObjectResult>();
            }
        }

        [Fact]
        public void Get_Should()
        {
            // Arrange
            var returnValue = new BadRequestObjectResult("Nincs bejelentkezve/jogosultsága!");
            _getMock.Setup(x => x.Get(It.IsAny<string>())).Returns(returnValue);

            // Act
            var result = _getMock.Object.Get(Guid.NewGuid().ToString());

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBe(null);
                result.Should().BeOfType<BadRequestObjectResult>();
            }
        }
    }
}
