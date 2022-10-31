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
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private MyContext context;
            public GetProductByIdQueryHandler(MyContext context)
            {
                this.context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await context.Product.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                return product;
            }
        }
    }
}
