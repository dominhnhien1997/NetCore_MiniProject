using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activitíe
{
    public class List
    {
        //public class Query : IRequest<List<Student>> { }

        //public class Handler : IRequestHandler<Query, List<Student>>
        //{
        //    private readonly DataContext dataContext;
        //    public Handler(DataContext context)
        //    {
        //        dataContext = context;
        //    }
        //    public async Task<List<Student>> Handle(Query request, CancellationToken cancellationToken)
        //    {
        //        var activities = await dataContext.Activity.ToListAsync();
        //        return activities;
        //    }
        //}
    }
}
