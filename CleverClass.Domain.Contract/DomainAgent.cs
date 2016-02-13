using CleverClass.Domain.Contract.Client;
using CleverClass.Domain.Contract.Interface;
using System;

namespace CleverClass.Domain.Contract
{
    public static class DomainAgent
    {
        public static IClassGroupFacade CreateClassGroupRestClient(string uri)
        {
            return new ClassGroupRestClient(new Uri(uri));
        }

        public static ICourseFacade CreateCourseRestClient(string uri)
        {
            return new CourseRestClient(new Uri(uri));
        }

        public static ISkillFacade CreateSkillRestClient(string uri)
        {
            return new SkillRestClient(new Uri(uri));
        }

        public static IStudentFacade CreateStudentRestClient(string uri)
        {
            return new StudentRestClient(new Uri(uri));
        }

        public static ITestFacade CreateTestRestClient(string uri)
        {
            return new TestRestClient(new Uri(uri));
        }
    }
}
