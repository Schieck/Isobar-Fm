using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoMapper;
using Isobar.Fm.Core.Interfaces;
using Isobar.Fm.Infrastructure.Interfaces;
using Moq;
using System.Threading.Tasks;

namespace Isobar.Fm.Tests.Units.Services
{
    public class BandsService
    {
        IBandsService _sut;
        Mock<IMapper> _mapper;
        Mock<IBandsApiDataAdapter> _bandsApiDataAdapter;

        public BandsService()
        {            
            _mapper = new Mock<IMapper>();
            _bandsApiDataAdapter = new Mock<IBandsApiDataAdapter>();
            _sut = new Core.Services.BandsService(_bandsApiDataAdapter.Object,_mapper.Object);
            
        }

        [Fact]
        public void GetBands_WhenAlways_ShouldCallRepository()
        {
            // Arrange
            _bandsApiDataAdapter.Setup(x => x.GetBandsAsync());

            // Act
            _sut.GetBands();

            // Assert
            _bandsApiDataAdapter.Verify(x => x.GetBandsAsync());
        }

        [Fact]
        public void GetBands_WhenAlways_ShouldMapBands()
        {
            // Arrange
            IEnumerable<Infrastructure.Models.Band> bandList = new List<Infrastructure.Models.Band>();
            _bandsApiDataAdapter.Setup(x => x.GetBandsAsync()).ReturnsAsync(bandList);
            _mapper.Setup(x => x.Map<IEnumerable<Core.Models.Band>>(bandList));

            // Act
            _sut.GetBands();

            // Assert
            _mapper.Verify(x => x.Map<IEnumerable<Core.Models.Band>>(bandList));
        }

    }
}
