using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace Api.GraphQL.Types
{
    public class CourseInputType : InputObjectGraphType
    {
        public CourseInputType()
        {
            Name = "CourseInputType";
            Field<StringGraphType>("Description");
            Field<StringGraphType>("Name");
            Field<IntGraphType>("Review");
            Field<DateTimeGraphType>("DateAdded");
            Field<DateTimeGraphType>("DateUpdated");
        }
    }
}
