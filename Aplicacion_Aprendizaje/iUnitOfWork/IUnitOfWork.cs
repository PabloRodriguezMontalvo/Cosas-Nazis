using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion_Aprendizaje.iUnitOfWork
{
    public interface IUnitOfWork
    {

        void Commit();
        bool LazyLoadingEnabled { get; set; }
        bool ProxyCreationEnabled { get; set; }
        string ConnectionString { get; set; }
    }
}
