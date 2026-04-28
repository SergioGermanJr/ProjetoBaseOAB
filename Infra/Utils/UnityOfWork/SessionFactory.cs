using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace Infra.Utils.UnityOfWork
{
    public static class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory CriarSessionFactory()
        {
            if (_sessionFactory != null)
                return _sessionFactory;

            var configuration = new Configuration();
            configuration.Configure(); 
            _sessionFactory = configuration.BuildSessionFactory();

            return _sessionFactory;
        }

        public static ISession AbrirSessao()
        {
            return CriarSessionFactory().OpenSession();
        }
    }
}
