using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity;
using Owin;
using System;

namespace CleverClass.Common.Test
{
    public abstract class TestHttpServerStartup
    {
        public abstract void Configuration(IAppBuilder appBuilder);
        public abstract IUnityContainer UnityContainer { get;  }
        public void RegisterInstance<T>(T instance)
        {
            UnityContainer.RegisterInstance<T>(instance);
        }
    }

    public class TestHttpServer<T> : IDisposable where T : TestHttpServerStartup, new()
    {
        private string _baseUri;
        private IDisposable _server;
        private readonly T _startup;

        public TestHttpServer()
        {
            _startup = new T();
            CreateServer(new Random());
        }

        private void CreateServer(Random random, int retries = 5)
        {
            try
            {
                var port = random.Next(10000, 19999);
                _baseUri = string.Format("http://localhost:{0}", port);
                _server = WebApp.Start(_baseUri, builder => _startup.Configuration(builder));
            }
            catch (Exception)
            {
                if (retries <= 0)
                {
                    throw;
                }
                CreateServer(random, retries = retries - 1);
            }
        }

        public void Run(Action<string, T> test)
        {
            test(_baseUri, _startup);
        }

        public void Dispose()
        {
            _server.Dispose();
        }
    }
}
