using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplicacion_Aprendizaje.IViewModel;

namespace Aplicacion_Aprendizaje.Models.ViewModels
{
    public class UsuariosViewModel:IViewModel<Usuarios>
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public int estado { get; set; }
        // Atributos que no están en la BBDD
        public string estado_descripcion { get; set; }

        public Usuarios ToBaseDatos()
        {
            var datos = new Usuarios()
            {
                id = id,
                edad = edad,
                estado = estado,
                nombre = nombre
            };
            return datos;
        }

        public void FromBaseDatos(Usuarios modelo)
        {
            id = modelo.id;
            nombre = modelo.nombre;
            edad = modelo.edad;
            estado = modelo.estado;
            try
            {
                estado_descripcion = modelo.Estado1.descripcion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateBaseDatos(Usuarios modelo)
        {
            modelo.id = id;
           modelo.nombre = nombre;
            modelo.edad = edad;
            modelo.estado = estado;
        }

        public object[] GetKeys()
        {
            return new[] { (object)id };
        }
    }
}