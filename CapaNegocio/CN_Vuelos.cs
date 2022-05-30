using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaDatos.Entities;

namespace CapaNegocio
{
    public class CN_Vuelos
    {
        CD_Vuelo CD_Vuelo = new CD_Vuelo();


        public DataTable CargarVuelosProgramados()
        {
            return CD_Vuelo.CargarVuelos();
        }

        public void RistrarVuelo(E_Vuelo e_Vuelo)
        {
            CD_Vuelo.CD_Insertar(e_Vuelo);
        }

        public void ModifificarVuelo(E_Vuelo e_Vuelo)
        {
            CD_Vuelo.CD_Editar(e_Vuelo);
        }

        public E_Vuelo ConsultarVuelo(string id)
        {
            return CD_Vuelo.ConsultarVuelo(id);
        }

        public E_Vuelo VueloExiste(string vuelo)
        {
            return CD_Vuelo.validarVuerloExiste(vuelo);
        }
    }
}
