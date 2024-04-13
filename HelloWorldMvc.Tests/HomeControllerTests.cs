using HelloWorldMvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq; // Add this using statement for Moq
using Xunit;

namespace HelloWorldMvc.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>(); // Create a mock ILogger instance
            var controller = new HomeController(loggerMock.Object); // Pass the mock ILogger instance to HomeController

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
