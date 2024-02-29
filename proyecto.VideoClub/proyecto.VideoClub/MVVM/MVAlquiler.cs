using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios.Base;
using proyecto.VideoClub.Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace proyecto.VideoClub.MVVM
{
    class MVAlquiler: MVBaseCRUD<alquiler>
    {
        private videoclubEntities vcEnt;
        private AlquilerServicio alqServ;
       

        private producto _producto;
        private usuario _usuario;
        private alquiler alqNuevo;
        private usuario usuLogin;
        

        //Lista de jugadores para la tabla
        private ListCollectionView listaAux;

        //Criterio de filtro
        private bool devuelto;
        private string apellido;

        //Predicados
        //Comun para todos los filtros
        private List<Predicate<alquiler>> criterios;
        private Predicate<object> predicadoFiltro;

        //Criterios especificos
        private Predicate<alquiler> criterioDevuelto;
        private Predicate<alquiler> criterioApellido;

        //CONSTRUCTOR
        public MVAlquiler(videoclubEntities ent)
        {
            vcEnt = ent;
            alqServ = new AlquilerServicio(vcEnt);
            servicio = alqServ;
            inicializa();
        }
        public MVAlquiler(videoclubEntities ent, usuario usu)
        {
            vcEnt = ent;
            alqServ = new AlquilerServicio(vcEnt);
            servicio = alqServ;
            usuLogin = usu;
            inicializa();
        }
        public MVAlquiler(videoclubEntities ent, usuario usu, producto pr)
        {
            vcEnt = ent;

            _producto = pr;
            _usuario = usu;

            alqNuevo = new alquiler();

            alqNuevo.id_usuario = usu.id_usuario;
            alqNuevo.usuario = usu;
            alqNuevo.id_tipo=1;
           
            
            alqServ = new AlquilerServicio(vcEnt);
            servicio = alqServ;
            inicializa();
        }
        private void inicializa()
        {
            //lista de criterios de filtrar
            listaAux = new ListCollectionView(alqServ.getAll().ToList());
            //Predicado que nos indica el método de filtrado
            criterios = new List<Predicate<alquiler>>();


            //Criterio puntos
            criterioDevuelto = new Predicate<alquiler>(a => a.devuelto != null && a.devuelto == false);
            criterioApellido = new Predicate<alquiler>(a => !string.IsNullOrEmpty(a.usuario.apellido_1) && a.usuario.apellido_1.ToUpper().StartsWith(apellidoUsuario.ToUpper()));



            //PARA TODOS
            predicadoFiltro = new Predicate<object>(FiltroCriterios);
        }

        //LISTAS
       public List <item> listaItems { get { return alqServ.getItems(); } }
       public List <item> listaItemsDisponibles { get { return alqServ.getItemsDisponibles(); } }
       public List <item> listaItemsDisponiblesProducto { get { return alqServ.getItemsDispProd(_producto); } }
       public List<alquiler> listaDatosUsuarioAlquiler { get { return alqServ.getUsuarioAlquileres(usuLogin); } }


        //--- FILTROS ---
        // public List<alquiler> listaAlquileres { get { return alqServ.getAll().ToList(); } }

        //Ver los alquleres devueltos
        public ListCollectionView ListaAlquileres { get { return listaAux; } }
        public bool devueltoCheck
        {
            get { return devuelto; }
            set { devuelto = value; NotifyPropertyChanged(nameof(devueltoCheck)); }
        }


        public string apellidoUsuario
        {
            get { return apellido; }
            set { apellido = value; NotifyPropertyChanged(nameof(apellidoUsuario)); }
        }
        private bool FiltroCriterios(object item)
        {
            bool correcto = true;
            alquiler entity = (alquiler)item;
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
            if (devueltoCheck == true)
            {
                criterios.Add(criterioDevuelto);

            }
            else
            {
                devueltoCheck = false;
            }
            if (!string.IsNullOrEmpty(apellido)) { criterios.Add(criterioApellido); }

        }

        //FILTRAR
        public void Filtra()
        {
            addCriterios();
            ListaAlquileres.Filter = predicadoFiltro;

        }

        //QUITAR FILTRO
        public void QuitaFiltros()
        {
            ListaAlquileres.Filter = null;
            devueltoCheck = false;
            apellidoUsuario = "";

        }


        public alquiler alquilerNuevo
        {
            get { return alqNuevo; }
            set
            {
                alqNuevo = value;
                NotifyPropertyChanged(nameof(alquilerNuevo));
            }
        }


        public bool guarda { get { return add(alquilerNuevo); } }
        public bool actualiza { get { return update(alquilerNuevo); } }
        public bool ActualizarAlq(alquiler aq)
        {
            return update(aq);

        }

        public int CarcularRecargo (alquiler aq)
        {
            int recargo =0;

            if (aq.fecha_prev_devolucion< aq.fecha_devolucion)
            {
                DateTime otherDateTime = (DateTime)aq.fecha_prev_devolucion; // Your other DateTime value
                TimeSpan diff = DateTime.Now - otherDateTime;
                recargo = (int)Math.Abs(Math.Round(diff.TotalDays));


            }
            return recargo;
        }
    }
}
