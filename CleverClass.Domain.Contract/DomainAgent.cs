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
    }
}
