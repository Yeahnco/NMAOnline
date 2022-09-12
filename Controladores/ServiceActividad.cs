using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistenciaBD;

namespace Controladores
{
    public class ServiceActividad : AbstractService<Actividad>
    {
        public override List<Actividad> GetEntities()
        {
            return nmaEn.Actividad.ToList<Actividad>();
        }

        public override Actividad GetEntity(object key)
        {
            return nmaEn.Actividad.Where(actividad => actividad.id_act == (int)key).FirstOrDefault<Actividad>();
        }
    }
}
