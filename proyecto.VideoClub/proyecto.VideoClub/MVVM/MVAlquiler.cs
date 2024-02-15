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

        //Lista de jugadores para la tabla
        private ListCollectionView listaAux;

        //Criterio de filtro
        private bool devuelto;

        //Predicados
        //Comun para todos los filtros
        private List<Predicate<alquiler>> criterios;
        private Predicate<object> predicadoFiltro;

        //Criterios especificos
        private Predicate<alquiler> criterioDevuelto;

        //CONSTRUCTOR
        public MVAlquiler(videoclubEntities ent)
        {
            vcEnt = ent;
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
            



            //PARA TODOS
            predicadoFiltro = new Predicate<object>(FiltroCriterios);
        }


        //--- FILTROS ---
       // public List<alquiler> listaAlquileres { get { return alqServ.getAll().ToList(); } }

        //Ver los alquleres devueltos
        public bool devueltoCheck
        {
            get { return devuelto; }
            set { devuelto = value; NotifyPropertyChanged(nameof(devueltoCheck)); }
        }

        public ListCollectionView ListaAlquileres { get { return listaAux; } }
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

        }

        public void  Devolver ()
        {
       
            
        }
    }
}
