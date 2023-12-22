using System.Collections.Generic;
using System.Linq;
using proyecto.VideoClub.Backend.Modelo;
using proyecto.VideoClub.Backend.Servicios;

namespace proyecto.VideoClub.MVVM
{
    class MVProducto: MVBaseCRUD<producto>
    {
        //Base de datos
        private videoclubEntities vcEnt;

    //Servicios
    private ProductoServicio prodServ;
    public MVProducto(videoclubEntities vcEnt)
    {

        this.vcEnt = vcEnt;
        inicializa();
    }

    private void inicializa()
    {
        prodServ = new ProductoServicio(vcEnt);
        servicio = prodServ;
    }

    //Propiedades públicas para listar
    public List<producto> listaProductos { get { return prodServ.getAll().ToList(); } }
}
}

    {
}
}
