using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.VideoClub.MVVM
{
    internal class MVUsuario : MVBaseCRUD<usuario>
    {
        // VARIABLES PRIVADAS
        //Base de datos
        private videoclubEntities vcEnt;
        //Servicios
        private UsuarioServicio usuServ;
        private RolServicio rolServ;

        private usuario usuNuevo;
       

        //CONSTRUCTOR
        public MVUsuario(videoclubEntities ent)
        {
            vcEnt = ent;
            inicializa();
        }

        private void inicializa()
        {
            usuServ = new UsuarioServicio(vcEnt);
            rolServ = new RolServicio(vcEnt);
            servicio = usuServ;
            usuNuevo = new usuario();

        }

        //VARIABLES PUBLICAS

        public List<rol> listaRol { get { return rolServ.getAll().ToList(); } }

        public usuario usuarioNuevo
        {
            get { return usuNuevo; }
            set
            {
                usuNuevo = value;
                NotifyPropertyChanged(nameof(usuarioNuevo));
            }
        }
        public bool guarda { get { return add(usuarioNuevo); } }

    }

}
