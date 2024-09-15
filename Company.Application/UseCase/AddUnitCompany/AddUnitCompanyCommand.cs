using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Application.UseCase.AddUnitCompany
{
    public class AddUnitCompanyCommand :IRequest<int>
    {
        public string Name { get; set; }
        public string Exchange { get; set; }
        public string Ticker { get; set; }
        public string Isin { get; set; }
        public string? Website { get; set; }

    }
}