using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;
using GraphQL.Types;

namespace Api.GraphQL.Types
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the Review object");
            Field(x => x.Comment, type: typeof(StringGraphType)).Description("Comment property from the Review object");
        }
    }
}
