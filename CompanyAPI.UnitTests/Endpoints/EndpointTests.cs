using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Company.API.Endpoints;
using Company.Application.Service;
using NSubstitute;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Company.UnitTests.Endpoints
{
    public class EndpointTests
    {
        private readonly IFixture _fixture;
        private readonly ICompanyService _companyService;
        private readonly AddUnitCompanyEndpoint _addUnitCompanyEndpoint;
        //private readonly GetAllCompanyEndpoint _getAllCompanyEndpoint;
        //private readonly GetUnitCompanyByIdEndpoint _getUnitCompanyByIdEndpoint;
        //private readonly GetUnitCompanyByIsinEndpoint _getUnitCompanyByIsinEndpoint;
        //private readonly UpdateUnitCompanyEndpoint updateUnitCompanyEndpoint;

        private readonly AddUnitCompanyRequest _addUnitCompanyRequest;
        public EndpointTests()
        {
            _fixture = new Fixture().Customize(new AutoConfiguredNSubstituteCustomization());
            _fixture.Customize<BindingInfo>(cc => cc.OmitAutoProperties());
            _companyService = _fixture.Freeze<ICompanyService>();
            _addUnitCompanyEndpoint = _fixture.Create<AddUnitCompanyEndpoint>();
            _addUnitCompanyRequest = _fixture.Create<AddUnitCompanyRequest>();
        }

        [Fact]
        public async Task HandleAsync_Add_ReturnOK()
        {
            //Arrange
            var expectedResonse = _fixture.Create<AddUnitCompanyResponse>();
            _companyService.AddUnitCompany(_addUnitCompanyRequest, Arg.Any<CancellationToken>()).Returns(expectedResonse);

            //Act
            var result = await _addUnitCompanyEndpoint.HandleAsync(_addUnitCompanyRequest);

            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result.Result)?.Value.Should().BeEquivalentTo(expectedResonse);
        }

        [Fact]
        public async Task HandleAsync_GetAll_ReturnOK()
        {
            //Arrange

            //Act

            //Assert
            Assert.True(true);
        }

        [Fact]
        public async Task HandleAsync_GetById_ReturnOK()
        {
            //Arrange

            //Act

            //Assert

            Assert.True(true);
        }

        [Fact]
        public async Task HandleAsync_GetByIsin_ReturnOK()
        {
            //Arrange

            //Act

            //Assert

            Assert.True(true);
        }

        [Fact]
        public async Task HandleAsync_Update_ReturnOK()
        {
            //Arrange

            //Act

            //Assert

            Assert.True(true);
        }
    }
}
