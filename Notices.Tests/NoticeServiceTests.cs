using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Notices.Core.Services;
using Notices.Infrastructure.Entities;
using Notices.Infrastructure.Repository;
using Xunit;

namespace Notices.Tests;

public class NoticeServiceTests
{
    [Fact]
    public async Task GetTheMostExpensiveNoticeAsync_ShouldReturnNull_WhenNoticesCollectionIsNull()
    {
        var sut = new NoticeService(Mock.Of<INoticeRepository>(), Mock.Of<IRecipientRepository>(),
            Mock.Of<IAddressService>());

        var result = await sut.GetMostExpensiveNoticeAsync();
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetTheMostExpensiveNoticeAsync_ShouldReturnTheMostExpensiveNotice()
    {
        var notices = new List<Notice>()
        {
            new()
            {
                Address = new Address()
                {
                    City = "Gdańsk",
                    Country = "Polska",
                    Street = "Wielkopolska",
                    ApartmentNumber = "73",
                    BuildingNumber = "46",
                    ZipCode = "80-180",
                },
                Salary = 7500,
                Description = "Witam mam do wyremontowania łazienke",
                TypesOfTileSize = 1,
                TileSize = 80,
                SquareMeters = 5,
                IsWalkIn = true,
                IsLinearDrain = true,
                IsMixerForConcealedInstallation = true,
                IsBidet = true,
                IsFlushMountedFrameWc = true,
            },
            new()
            {
                Address = new Address()
                {
                    City = "Gdańsk",
                    Country = "Polska",
                    Street = "Tenisowa",
                    ApartmentNumber = "",
                    BuildingNumber = "90",
                    ZipCode = "80-180"
                },
                Salary = 12000,
                Description = "Kompleksowy remont łazienki",
                TypesOfTileSize = 2,
                TileSize = 60,
                SquareMeters = 10,
                IsWalkIn = true,
                IsLinearDrain = true,
                IsMixerForConcealedInstallation = true,
                IsBidet = false,
                IsFlushMountedFrameWc = false
            }
        };

        var noticeRepositoryMock = new Moq.Mock<INoticeRepository>();
        noticeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(notices);

        var sut = new NoticeService(noticeRepositoryMock.Object, Mock.Of<IRecipientRepository>(),
            Mock.Of<IAddressService>());

        var result = await sut.GetMostExpensiveNoticeAsync();
        
        result.Should().NotBeNull();
        result.City.Should().Be("Gdańsk");
        result.Street.Should().Be("Tenisowa");
        result.ApartmentNumber.Should().Be("");
        result.BuildingNumber.Should().Be("90");
        result.ZipCode.Should().Be("80-180");
        result.Salary.Should().Be(12000);
        result.Description.Should().Be("Kompleksowy remont łazienki");
        result.TypesOfTileSize.Should().Be(2);
        result.TileSize.Should().Be(60);
        result.SquareMeters.Should().Be(10);
        result.IsWalkIn.Should().BeTrue();
        result.IsLinearDrain.Should().BeTrue();
        result.IsMixerForConcealedInstallation.Should().BeTrue();
        result.IsBidet.Should().BeFalse();
        result.IsFlushMountedFrameWc.Should().BeFalse();
    }
}