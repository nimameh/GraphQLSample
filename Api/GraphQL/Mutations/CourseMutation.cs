using Api.Data.Models;
using Api.Data.Repository;
using Api.GraphQL.Types;
using GraphQL;
using GraphQL.Types;

namespace Api.GraphQL.Mutations
{
    public class CourseMutation : ObjectGraphType
    {
        public CourseMutation(CoursesRepository repository)
        {
            Field<CourseType>(
                "addCourse",
                "Is used to add a new course.",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CourseInputType>> { Name = "course", Description = "Course input param" }
                    ),
                resolve: context =>
                {
                    var course = context.GetArgument<Course>("course");
                    return repository.AddCourse(course);
                });

            Field<CourseType>(
                name: "updateCourse",
                description: "Is used to update an existing course",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                        { Name = "id", Description = "Id of the course to be update" },
                    new QueryArgument<NonNullGraphType<CourseInputType>>
                        { Name = "course", Description = "Update course values" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var course = context.GetArgument<Course>("course");
                    return repository.UpdateCourse(id, course);
                });

            Field<CourseType>(
                "deleteCourse",
                "Is used to delete a course",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                        { Name = "id", Description = "Id of the course to be delete" }),
                    resolve: context =>
                    {
                        var id = context.GetArgument<int>("id");
                        repository.DeleteCourse(id);
                        return true;
                    }
                );
        }
    }
}
