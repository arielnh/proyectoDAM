using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.VideoClub.MVVM
{
    internal class MVCliente : MVBase
    {
        // VARIABLES PRIVADAS
        //Base de datos
        private videoclubEntities vCEnt;
        //Servicios
        private UsuarioServicio usrServ;
       

        //CONSTRUCTOR
        public MVCliente(videoclubEntities ent)
        {
            vCEnt = ent;
            inicializa();
        }

        private void inicializa()
        {
            usrServ = new UsuarioServicio(vCEnt);
            
        }

        //VARIABLES PUBLICAS

        
    }

}
