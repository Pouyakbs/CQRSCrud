using CQRSCrud.DemoContext;
using CQRSCrud.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSCrud.CQRS.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
        {
            private MyContext context;
            public GetAllProductQueryHandler(MyContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
            {
                var productList = await context.Product.ToListAsync();
                return productList;
            }
        }
    }
}
