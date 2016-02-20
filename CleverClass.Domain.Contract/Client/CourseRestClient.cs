using CleverClass.Common;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Client
{
    public class CourseRestClient : RestClient, ICourseFacade
    {
        public CourseRestClient(Uri baseUri) : base(baseUri)
        {

        }

        public IEnumerable<CourseDto> GetAll()
        {
            return Get<IEnumerable<CourseDto>>("api/course");
        }

        public CourseDto Get(int id)
        {
            return Get<CourseDto>(string.Format("api/course/{0}", id));
        }

        public CourseDto Create(CourseDto course)
        {
            return Post<CourseDto, CourseDto>("api/course", course);
        }

        public CourseDto Update(CourseDto course)
        {
            return Put<CourseDto, CourseDto>("api/course", course);
        }

        public void Delete(int id)
        {
            Delete(string.Format("api/course/{0}", id));
        }
    }
}