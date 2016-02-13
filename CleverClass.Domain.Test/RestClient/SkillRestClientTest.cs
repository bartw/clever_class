using CleverClass.Common.Test;
using CleverClass.Domain.Contract;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleverClass.Domain.Test.RestClient
{
    public class SkillRestClientTest : INeedTestHttpServer
    {
        private readonly TestHttpServer<Startup> _server;
        private readonly ISkillFacade _skillFacade;

        public SkillRestClientTest(TestHttpServer<Startup> server)
        {
            _server = server;
            _skillFacade = Substitute.For<ISkillFacade>();
        }

        [Fact]
        public void CanGetAll()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_skillFacade);

                _skillFacade.GetAll().ReturnsForAnyArgs(new List<SkillDto>
                {
                    new SkillDto { Id = 1, Name = "Bakken" },
                    new SkillDto { Id = 2, Name = "Snijden" }
                });

                var skills = DomainAgent.CreateSkillRestClient(baseUri).GetAll();

                _skillFacade.Received().GetAll();
                Assert.NotNull(skills);
                Assert.Equal(2, skills.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_skillFacade);

                var skill = new SkillDto { Id = 1, Name = "Snijden" };

                _skillFacade.Get(skill.Id).ReturnsForAnyArgs(skill);

                var foundSkill = DomainAgent.CreateSkillRestClient(baseUri).Get(skill.Id);

                _skillFacade.Received().Get(skill.Id);
                Assert.NotNull(foundSkill);
                Assert.Equal(skill.Id, foundSkill.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_skillFacade);

                var skillToCreateDto = new SkillDto { Name = "Bakken" };
                var createdSkillDto = new SkillDto { Id = 1, Name = skillToCreateDto.Name };

                _skillFacade.Create(Arg.Any<SkillDto>()).ReturnsForAnyArgs(createdSkillDto);

                var skill = DomainAgent.CreateSkillRestClient(baseUri).Create(skillToCreateDto);

                _skillFacade.Received().Create(Arg.Any<SkillDto>());
                Assert.NotNull(skill);
                Assert.True(skill.Id > 0);
                Assert.Equal(skillToCreateDto.Name, skill.Name);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_skillFacade);

                var skillToUpdateDto = new SkillDto { Id = 1, Name = "Bakken" };

                _skillFacade.Update(Arg.Any<SkillDto>()).ReturnsForAnyArgs(skillToUpdateDto);

                var skill = DomainAgent.CreateSkillRestClient(baseUri).Update(skillToUpdateDto);

                _skillFacade.Received().Update(Arg.Any<SkillDto>());
                Assert.NotNull(skill);
                Assert.Equal(skillToUpdateDto.Id, skill.Id);
                Assert.Equal(skillToUpdateDto.Name, skill.Name);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_skillFacade);

                var id = 1;

                DomainAgent.CreateSkillRestClient(baseUri).Delete(id);

                _skillFacade.Received().Delete(id);
            });
        }
    }
}
