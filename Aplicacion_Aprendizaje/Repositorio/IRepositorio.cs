using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Aplicacion_Aprendizaje.IViewModel;

namespace Aplicacion_Aprendizaje.Repositorio
{
    //public interface IRepositoryBase<T> where T : class
    //{
    //    T GetByID(object id);
    //    void Insert(T entity);
    //    void Delete(object id);
    //    void Delete(T entityToDelete);
    //    void Update(T entityToUpdate);
    //    IQueryable<T> FindAll(Expression<Func<T, bool>> filter = null);
    //    IQueryable<T> FindAll(out int totalRows, Expression<Func<T, bool>> filter = null, int skip = 0, int take = 10);
    //    T FindOne(Expression<Func<T, bool>> filter);
    //    IQueryable<T> Fetch();
    //    DbContext InternalContext { get; }

    //}
    public interface IRepositoryBase<TModelo, TViewModel>
            where TModelo : class
            where TViewModel : IViewModel<TModelo>
    {
        TViewModel Add(TViewModel model);
        int Borrar(TViewModel model);
        int Borrar(Expression<Func<TModelo, bool>> consulta);
        int Actualizar(TViewModel model);
        ICollection<TViewModel> Get();
        TViewModel Get(params Object[] keys);
        ICollection<TViewModel> Get(Expression<Func<TModelo, bool>> consulta);

    }

}
