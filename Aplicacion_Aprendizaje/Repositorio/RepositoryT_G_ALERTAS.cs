using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplicacion_Aprendizaje.Models;

namespace Aplicacion_Aprendizaje.Repositorio
{
    public partial class RepositoryUsuarios : RepositoryBase<Usuarios>
    {
        public RepositoryUsuarios(UsuariosEntities context)
            : base(context)
        {

        }
    }
}