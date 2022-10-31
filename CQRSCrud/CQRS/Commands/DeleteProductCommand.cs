using CQRSCrud.DemoContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSCrud.CQRS.Commands
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private MyContext context;
            public DeleteProductByIdCommandHandler(MyContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await context.Product.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                context.Product.Remove(product);
                await context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
