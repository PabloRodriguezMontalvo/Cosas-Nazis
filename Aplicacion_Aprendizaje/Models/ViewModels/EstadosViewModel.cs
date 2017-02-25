using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplicacion_Aprendizaje.IViewModel;

namespace Aplicacion_Aprendizaje.Models.ViewModels
{
    public class EstadosViewModel : IViewModel<Estado>
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public Estado ToBaseDatos()
        {
            var data = new Estado()
            {
                descripcion = descripcion,
                id = id
            };
            return data;
        }

        public void FromBaseDatos(Estado modelo)
        {
            id = modelo.id;
            descripcion = modelo.descripcion;
        }

        public void UpdateBaseDatos(Estado modelo)
        {
            modelo.id = id;
            modelo.descripcion = descripcion;
        }

        public object[] GetKeys()
        {
            return new[] { (object)id };
        }
    }
}