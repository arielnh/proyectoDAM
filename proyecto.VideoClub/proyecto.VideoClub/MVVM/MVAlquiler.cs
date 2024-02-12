using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios.Base;
using proyecto.VideoClub.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.VideoClub.MVVM
{
    class MVAlquiler: MVBaseCRUD<alquiler>
    {
        private videoclubEntities vcEnt;
        private AlquilerServicio alqServ;

        //CONSTRUCTOR
        public MVAlquiler(videoclubEntities ent)
        {
            vcEnt = ent;
            alqServ = new AlquilerServicio(vcEnt);
            servicio = alqServ;

        }

        public List<alquiler> listaAlquileres { get { return alqServ.getAll().ToList(); } }

        public bool Devolver (alquiler aq)
        {
         return delete(aq);
            
        }
    }
}
