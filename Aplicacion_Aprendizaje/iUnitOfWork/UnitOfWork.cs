using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Aprendizaje.Models;
using Aplicacion_Aprendizaje.Repositorio;

namespace Aplicacion_Aprendizaje.iUnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        UsuariosEntities context = new UsuariosEntities(); //TKPruebasEntities es el contexto de Entity Framework (Model.Context)

        private RepositoryUsuarios repoUsuarios;

        public RepositoryUsuarios RepoUsuarios
        {
            get
            {

                if (repoUsuarios == null)
                {
                    repoUsuarios = new RepositoryUsuarios(context);
                }
                return repoUsuarios;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public bool LazyLoadingEnabled
        {
            get { return context.Configuration.LazyLoadingEnabled; }
            set { context.Configuration.LazyLoadingEnabled = value; }
        }
public bool ProxyCreationEnabled
        {
            get { return context.Configuration.ProxyCreationEnabled; }
            set { context.Configuration.ProxyCreationEnabled = value; }
        }
        public string ConnectionString
        {
            get { return context.Database.Connection.ConnectionString; }
            set { context.Database.Connection.ConnectionString = value; }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
