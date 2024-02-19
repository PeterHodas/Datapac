using System;
using Datapac_uloha.Data;
using Datapac_uloha.Service;
using Xunit;
using Moq;

namespace Datapac_uloha.Test
{
	public class NoticeServiceTest
	{
        [Fact]
        public void CreateNotice_ValidInput_ReturnsSuccessMessage()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var service = new NoticeService(mockContext.Object);
            int zakaznik_id = 1;
            int kniha_id = 1;
            DateTime vratena = DateTime.Now;
            string stav = "Pozicana";

            // Act
            var result = service.CreateNotice(zakaznik_id, kniha_id, vratena, stav);

            // Assert
            Assert.Equal("Nová zápožička bola úspešne vytvorená.", result);
        }

        [Fact]
        public async Task UpdateNotice_NotFound_ReturnsFalse()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var service = new NoticeService(mockContext.Object);

            // Act
            var result = await service.UpdateNotice(999); // Neprejdúci ID

                // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task UpdateNotice_Found_ReturnsTrue()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var service = new NoticeService(mockContext.Object);

            // Act
            var result = await service.UpdateNotice(1); // Platné ID

            // Assert
            Assert.True(result);
           
        }
    }
}

