using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplicacion_Aprendizaje.IViewModel;

namespace Aplicacion_Aprendizaje.Models.ViewModels
{
    //public class EstadosViewModel:IViewModel<Estados>
    //{
    //    public int id { get; set; }
    //    public string descripcion { get; set; }

    //    public Estados ToBaseDatos()
    //    {
    //        var data = new Estados()
    //        {
    //            descripcion = descripcion,
    //            id = id
    //        };
    //        return data;
    //    }

    //    public void FromBaseDatos(Estados modelo)
    //    {
    //        id = modelo.id;
    //        descripcion = modelo.descripcion;
    //    }

    //    public void UpdateBaseDatos(Estados modelo)
    //    {
    //        modelo.id=id;
    //        modelo.descripcion = descripcion;
    //    }

    //    public object[] GetKeys()
    //    {
    //        return new[] { (object)id };
    //    }
    //}
}