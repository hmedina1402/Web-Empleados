using FrontEnd.Service.Entidades;
using FrontEnd.Util.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Service.Interfaces
{
    public interface IEmpleado
    {
        Task<List<Ent_Empleado>> Listado();
        Task<ResponseMensaje> Insertar(Ent_Empleado ent_Empleado); 
    }
}
