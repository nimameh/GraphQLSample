using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.GraphQL.Mutations;
using Api.GraphQL.Queries;
using GraphQL.Types;

namespace Api.GraphQL
{
    public class AppSchema : Schema
    {
        public AppSchema(CourseQuery query, CourseMutation courseMutation)
        {
            this.Query = query;
            this.Mutation = courseMutation;
        }
    }
}
