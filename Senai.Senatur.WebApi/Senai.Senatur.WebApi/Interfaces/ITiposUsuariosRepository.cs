using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    public interface ITiposUsuariosRepository
    {
        /// <summary>
        /// Lista de todos tipos de usuarios
        /// </summary>
        /// <returns></returns>
        List<TiposUsuarios> Get();
    }
}
