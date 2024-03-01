using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace proyecto.VideoClub.MVVM
{
    internal class MVUsuario : MVBaseCRUD<usuario>
    {
        // VARIABLES PRIVADAS
        //Base de datos
        private videoclubEntities vcEnt;
        //Servicios
        private UsuarioServicio usuServ;
        private AlquilerServicio alqServ;
        private RolServicio rolServ;
        private usuario usuLogin;
        private usuario usuNuevo;

        //Lista de jugadores para la tabla
        private ListCollectionView listaAux;

        //Criterio de filtro
       
        private string apellido;

        //Predicados
        //Comun para todos los filtros
        private List<Predicate<usuario>> criterios;
        private Predicate<object> predicadoFiltro;

        //Criterios especificos
       
        private Predicate<usuario> criterioApellido;

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
            usuServ = new UsuarioServicio(vcEnt);
            alqServ = new AlquilerServicio(vcEnt);
            rolServ = new RolServicio(vcEnt);
            usuNuevo = new usuario();
            servicio = usuServ;
           // listaAux = new ListCollectionView(servicio.getAll().ToList());

            //lista de criterios de filtrar
            listaAux = new ListCollectionView(usuServ.getAll().ToList());
            //Predicado que nos indica el método de filtrado
            criterios = new List<Predicate<usuario>>();


            //Criterio puntos
          
            criterioApellido = new Predicate<usuario>(u => !string.IsNullOrEmpty(u.apellido_1) && u.apellido_1.ToUpper().StartsWith(apellidoUsuario.ToUpper()));



            //PARA TODOS
            predicadoFiltro = new Predicate<object>(FiltroCriterios);
        }
        public string apellidoUsuario
        {
            get { return apellido; }
            set { apellido = value; NotifyPropertyChanged(nameof(apellidoUsuario)); }
        }
        //VARIABLES PUBLICAS

        public List<rol> listaRol { get { return rolServ.getAll().ToList(); } }
        public ListCollectionView listaUsuarios { get { return listaAux; } }
        public List<usuario> listaDatosUsuario { get { return usuServ.getUsuario(usuLogin.usuario1.ToString()); } }
        public List<alquiler> listaDatosUsuarioAlquiler { get { return alqServ.getUsuarioAlquileres(usuLogin); } }



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
        public bool update { get { return update(usuarioNuevo); } }
        public bool BorrarUsu (usuario susDel) {
             return delete(susDel); 

        }

        
        public ListCollectionView Refresca()
        {
            return new ListCollectionView(servicio.getAll().ToList());
        }
        private bool FiltroCriterios(object item)
        {
            bool correcto = true;
            usuario entity = (usuario)item;
            if (criterios.Count() != 0)
            {
                correcto = criterios.TrueForAll(x => x(entity));
            }
            return correcto;
        }
        //AÑADIR CRITERIO
        private void addCriterios()
        {
            criterios.Clear();
           
            if (!string.IsNullOrEmpty(apellido)) { criterios.Add(criterioApellido); }

        }

        //FILTRAR
        public void Filtra()
        {
            addCriterios();
            listaUsuarios.Filter = predicadoFiltro;

        }

        //QUITAR FILTRO
        public void QuitaFiltros()
        {
            listaUsuarios.Filter = null;
          
            apellidoUsuario = "";

        }


    }

}
