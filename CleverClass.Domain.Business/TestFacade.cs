using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CleverClass.Domain.Business
{
    public class TestFacade : ITestFacade
    {
        private readonly ITestRepository _testRepository;

        public TestFacade(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public IEnumerable<TestDto> GetAll()
        {
            return _testRepository.GetAll().Select(t => new TestDto
            {
                Id = t.Id,
                Name = t.Name,
                Date = t.Date,
                MaximumScore = t.MaximumScore,
                Weight = t.Weight
            });
        }

        public TestDto Get(int id)
        {
            var test = _testRepository.Get(id);

            if (test == null)
            {
                return null;
            }

            return new TestDto
            {
                Id = test.Id,
                Name = test.Name,
                Date = test.Date,
                MaximumScore = test.MaximumScore,
                Weight = test.Weight
            };
        }

        public TestDto Create(TestDto test)
        {
            var createdClassGroup = _testRepository.Create(new Test
            {
                Id = test.Id,
                Name = test.Name,
                Date = test.Date,
                MaximumScore = test.MaximumScore,
                Weight = test.Weight
            });

            if (createdClassGroup == null)
            {
                return null;
            }

            return new TestDto
            {
                Id = createdClassGroup.Id,
                Name = createdClassGroup.Name,
                Date = createdClassGroup.Date,
                MaximumScore = createdClassGroup.MaximumScore,
                Weight = createdClassGroup.Weight
            };
        }

        public TestDto Update(TestDto test)
        {
            var updatedTest = _testRepository.Update(new Test
            {
                Id = test.Id,
                Name = test.Name,
                Date = test.Date,
                MaximumScore = test.MaximumScore,
                Weight = test.Weight
            });

            if (updatedTest == null)
            {
                return null;
            }

            return new TestDto
            {
                Id = updatedTest.Id,
                Name = updatedTest.Name,
                Date = updatedTest.Date,
                MaximumScore = updatedTest.MaximumScore,
                Weight = updatedTest.Weight
            };
        }

        public void Delete(int id)
        {
            _testRepository.Delete(id);
        }
    }
}