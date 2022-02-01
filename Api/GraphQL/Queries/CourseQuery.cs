using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Repository;
using Api.GraphQL.Types;
using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;

namespace Api.GraphQL.Queries
{
    public class CourseQuery : ObjectGraphType
    {
        public CourseQuery(CoursesRepository repository)
        {
            Field<ListGraphType<CourseType>>(
                "course",
                "Returns list of courses",
                resolve:context=>repository.GetAll());

            Field<CourseType>(
                "course",
                "Returns single course by id",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                                {
                                    Name = "id", Description = "Course Id"
                                }),
                resolve: context => repository.GetCourseById(context.GetArgument("id",int.MinValue))
                );
        }
    }
}
