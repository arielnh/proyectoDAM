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
        private usuario usuLogin;
        private usuario usuNuevo;

        private usuario _usuario;


        //CONSTRUCTOR
        public MVUsuario(videoclubEntities ent)
        {
            vcEnt = ent;

            inicializa();
        }
        public MVUsuario(videoclubEntities ent, usuario usu)
        {
            vcEnt = ent;
            usuLogin = usu;
            inicializa();
        }

        private void inicializa()
        {
            _usuario = new usuario();

            usuServ = new UsuarioServicio(vcEnt);
            rolServ = new RolServicio(vcEnt);
            usuNuevo = new usuario();
            servicio = usuServ;

        }

        //VARIABLES PUBLICAS

        public List<rol> listaRol { get { return rolServ.getAll().ToList(); } }
        public List<usuario> listaUsuarios { get { return usuServ.getAll().ToList(); } }
        public List<usuario> listaDatosUsuario { get { return usuServ.getUsuario(usuLogin.usuario1.ToString()); } }

        public usuario usuarioEdit
        {
            get { return _usuario; }
            set { _usuario = value; NotifyPropertyChanged(nameof(usuarioEdit)); }
        }
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
