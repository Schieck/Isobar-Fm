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
            _sut = new Core.Services.BandsService(_bandsApiDataAdapter.Object, _mapper.Object);

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

        [Fact]
        public void GetBand_WhenAlways_ShouldCallRepository()
        {
            // Arrange
            string id = "akjsdh1u23917y189hj";
            _bandsApiDataAdapter.Setup(x => x.GetBandAsync(id));

            // Act
            _sut.GetBand(id);

            // Assert
            _bandsApiDataAdapter.Verify(x => x.GetBandAsync(id));
        }

        [Fact]
        public void GetBand_WhenAlways_ShouldMapBand()
        {
            // Arrange
            string id = "asldho128398192837";
            Infrastructure.Models.Band band = new Infrastructure.Models.Band()
            {
                Id = id
            };

            _bandsApiDataAdapter.Setup(x => x.GetBandAsync(id)).ReturnsAsync(band);
            _mapper.Setup(x => x.Map<Core.Models.Band>(band));

            // Act
            _sut.GetBand(id);

            // Assert
            _mapper.Verify(x => x.Map<Core.Models.Band>(band));
        }

        [Fact]
        public void CreateBand_WhenAlways_ShouldCallRepository()
        {
            // Arrange
            string id = "akjsdh1u23917y189hj";

            Core.Models.Band bandCore = new Core.Models.Band()
            {
                Id = id
            };

            Infrastructure.Models.Band bandInfra = new Infrastructure.Models.Band()
            {
                Id = id
            };

            _mapper.Setup(x => x.Map<Infrastructure.Models.Band>(bandCore)).Returns(bandInfra);
            _bandsApiDataAdapter.Setup(x => x.CreateBand(bandInfra));

            // Act
            _sut.CreateBand(bandCore);

            // Assert
            _bandsApiDataAdapter.Verify(x => x.CreateBand(bandInfra));
        }

        [Fact]
        public void CreateBand_WhenAlways_ShouldMapBand()
        {
            // Arrange
            string id = "akjsdh1u23917y189hj";

            Core.Models.Band bandCore = new Core.Models.Band()
            {
                Id = id
            };

            _mapper.Setup(x => x.Map<Infrastructure.Models.Band>(bandCore));

            // Act
            _sut.CreateBand(bandCore);

            // Assert
            _mapper.Verify(x => x.Map<Infrastructure.Models.Band>(bandCore));
        }

        [Fact]
        public void UpdateBand_WhenAlways_ShouldCallRepository()
        {
            // Arrange
            string id = "akjsdh1u23917y189hj";

            Core.Models.Band bandCore = new Core.Models.Band()
            {
                Id = id
            };

            Infrastructure.Models.Band bandInfra = new Infrastructure.Models.Band()
            {
                Id = id
            };

            _mapper.Setup(x => x.Map<Infrastructure.Models.Band>(bandCore)).Returns(bandInfra);
            _bandsApiDataAdapter.Setup(x => x.UpdateBand(id, bandInfra));

            // Act
            _sut.UpdateBand(id, bandCore);

            // Assert
            _bandsApiDataAdapter.Verify(x => x.UpdateBand(id, bandInfra));
        }

        [Fact]
        public void UpdateBand_WhenAlways_ShouldMapBand()
        {
            // Arrange
            string id = "akjsdh1u23917y189hj";

            Core.Models.Band bandCore = new Core.Models.Band()
            {
                Id = id
            };

            _mapper.Setup(x => x.Map<Infrastructure.Models.Band>(bandCore));

            // Act
            _sut.UpdateBand(id, bandCore);

            // Assert
            _mapper.Verify(x => x.Map<Infrastructure.Models.Band>(bandCore));
        }

        [Fact]
        public void DeleteBand_WhenAlways_ShouldCallRepository()
        {
            // Arrange
            var id = "asdkju19823189";

            // Act
            _sut.DeleteBand(id);

            // Assert
            _bandsApiDataAdapter.Verify(x => x.DeleteBand(id));
        }
    }
}
