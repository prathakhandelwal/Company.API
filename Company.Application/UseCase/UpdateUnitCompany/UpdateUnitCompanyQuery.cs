using MediatR;

namespace Company.Application.UseCase.UpdateUnitCompany
{
    public class UpdateUnitCompanyQuery :IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; }
        public string Ticker { get; set; }
        public string Isin { get; set; }
        public string? Website { get; set; }
    }
}
