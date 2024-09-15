using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Company.Application.Service;
using Company.Application.UseCase.AddUnitCompany;
using FluentAssertions;
using MediatR;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.UnitTests.Services
{
    public class CompanyServiceTests
    {
        private readonly IFixture _fixture;
        private readonly ICompanyService _companyService;
        private readonly IMediator _mediator;

        public CompanyServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoConfiguredNSubstituteCustomization());
            _companyService = _fixture.Create<ICompanyService>();
            _mediator = _fixture.Freeze<IMediator>();
        }

        [Fact]
        public async Task AddUnitCompany_Sucess()
        {
            //Arrange
            var request = _fixture.Create<AddUnitCompanyRequest>();

            //Act
            var response = await _companyService.AddUnitCompany(request, CancellationToken.None);

            //Assert
            response.Id.Should().BeOfType(typeof(int));
        }

    }
}
