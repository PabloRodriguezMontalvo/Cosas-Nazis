using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplicacion_Aprendizaje.Models;
using Aplicacion_Aprendizaje.Models.ViewModels;

namespace Aplicacion_Aprendizaje.Repositorio
{
    public partial class RepositoryEstados : RepositoryBase<Estado, EstadosViewModel>
    {
        public RepositoryEstados(UsuariosEntities1 context)
            : base(context)
        {

        }
    }
}