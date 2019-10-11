using System;
using System.Collections.Generic;
using System.Text;

namespace IService
{
    public interface IQueryHandler<in TQuery, out TResult>
    {
        TResult Handle(TQuery query);
    }
}
