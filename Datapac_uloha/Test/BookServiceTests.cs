using System;
using Datapac_uloha.Data;
using Datapac_uloha.Models;
using Datapac_uloha.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Datapac_uloha.Test
{
	public class BookServiceTests
	{
        [Fact]
        public async Task GetBookByIdAsync_BookNotFound_ThrowsException()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var service = new BookService(mockContext.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await service.GetBookByIdAsync(999));
        }


        [Fact]
        public async Task DeleteBookAsync_BookExists_ReturnsTrue()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var service = new BookService(mockContext.Object);

                // Act
                var result = await service.DeleteBookAsync(1);

                // Assert
                Assert.True(result);
        }
    }
}

