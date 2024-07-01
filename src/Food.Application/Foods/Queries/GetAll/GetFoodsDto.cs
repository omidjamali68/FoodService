using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Foods.Queries.GetAll
{
    public sealed record GetFoodsDto()
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
