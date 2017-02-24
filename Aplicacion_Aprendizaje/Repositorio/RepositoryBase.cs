using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Aplicacion_Aprendizaje.IViewModel;


namespace Aplicacion_Aprendizaje.Repositorio
{
    public class RepositoryBase<T> :IRepositoryBase<T> where T:class 
    {
        private DbContext context;
        private DbSet<T> dbSet;

        public RepositoryBase(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }


        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> filter = null)
        {

            var query = filter != null ? Fetch().Where(filter) : Fetch();

            return query;
        }

        public virtual IQueryable<T> FindAll(out int totalRows, Expression<Func<T, bool>> filter = null, int skip = 0, int take = 10)
        {
            IQueryable<T> query = FindAll(filter);


            totalRows = query.Count();

            query = query.Skip(skip * take).Take(take);


            return query;
        }


        public virtual T FindOne(Expression<Func<T, bool>> filter)
        {

            return Fetch().FirstOrDefault(filter);
        }

        public virtual IQueryable<T> Fetch()
        {
            IQueryable<T> query = dbSet;

            return query.AsQueryable();
        }

        public DbContext InternalContext
        {
            get { return this.context; }
        }
    }
    //public class Repositorio<TModelo, TViewModel> :
    //   IRepositorio<TModelo, TViewModel>
    //    where TModelo : class
    //    where TViewModel : IViewModel<TModelo>, new()
    //{
    //    private DbContext context;

    //    protected virtual DbSet<TModelo> DbSet
    //    {
    //        get
    //        {
    //            return context.Set<TModelo>();
    //        }
    //    }

    //    public Repositorio(DbContext context)
    //    {
    //        this.context = context;
    //    }


    //    public virtual int Actualizar(TViewModel model)
    //    {
    //        var obj = DbSet.Find(model.GetKeys());

    //        model.UpdateBaseDatos(obj);

    //        try
    //        {
    //            return context.SaveChanges();
    //        }
    //        catch (Exception e)
    //        {
    //            return 0;
    //        }

    //    }

    //    public virtual TViewModel Add(TViewModel model)
    //    {
    //        var m = model.ToBaseDatos();
    //        DbSet.Add(m);

    //        try
    //        {
    //            context.SaveChanges();
    //            model.FromBaseDatos(m);
    //            return model;
    //        }
    //        catch (Exception e)
    //        {

    //            return default(TViewModel);
    //        }
    //    }

    //    public virtual int Borrar(Expression<Func<TModelo, bool>> consulta)
    //    {
    //        var data = DbSet.Where(consulta);
    //        DbSet.RemoveRange(data);

    //        try
    //        {
    //            return context.SaveChanges();
    //        }
    //        catch (Exception e)
    //        {
    //            return 0;
    //        }
    //    }

    //    public virtual int Borrar(TViewModel model)
    //    {
    //        var obj = DbSet.Find(model.GetKeys());
    //        DbSet.Remove(obj);
    //        try
    //        {
    //            return context.SaveChanges();
    //        }
    //        catch (Exception e)
    //        {
    //            return 0;
    //        }
    //    }

    //    public virtual ICollection<TViewModel> Get()
    //    {
    //        var data = new List<TViewModel>();
    //        foreach (var modelo in DbSet)
    //        {
    //            TViewModel obj = new TViewModel();
    //            obj.FromBaseDatos(modelo);
    //            data.Add(obj);
    //        }
    //        return data;
    //    }

    //    public virtual ICollection<TViewModel> Get(Expression<Func<TModelo, bool>> consulta)
    //    {
    //        var datosO = DbSet.Where(consulta);
    //        var data = new List<TViewModel>();

    //        foreach (var modelo in datosO)
    //        {
    //            TViewModel obj = new TViewModel();
    //            obj.FromBaseDatos(modelo);
    //            data.Add(obj);
    //        }

    //        return data;
    //    }

    //    public virtual TViewModel Get(params object[] keys)
    //    {
    //        var dato = DbSet.Find(keys);
    //        var retorno = new TViewModel();
    //        retorno.FromBaseDatos(dato);

    //        return retorno;

    //    }
    //}
}