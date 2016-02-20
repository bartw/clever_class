using CleverClass.Common;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Client
{
    public class StudentRestClient : RestClient, IStudentFacade
    {
        public StudentRestClient(Uri baseUri) : base(baseUri)
        {

        }

        public IEnumerable<StudentDto> GetAll()
        {
            return Get<IEnumerable<StudentDto>>("api/student");
        }

        public StudentDto Get(int id)
        {
            return Get<StudentDto>(string.Format("api/student/{0}", id));
        }

        public StudentDto Create(StudentDto student)
        {
            return Post<StudentDto, StudentDto>("api/student", student);
        }

        public StudentDto Update(StudentDto student)
        {
            return Put<StudentDto, StudentDto>("api/student", student);
        }

        public void Delete(int id)
        {
            Delete(string.Format("api/student/{0}", id));
        }
    }
}