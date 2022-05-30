using CapaDatos;
using CapaDatos.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Aerolinea
    {
        CD_Aerolinea CD_Aerolinea = new CD_Aerolinea();

        public ObservableCollection<E_Aerolinea> GetAerolinea()
        {
            ObservableCollection<E_Aerolinea> aerolineas = new ObservableCollection<E_Aerolinea>();

            foreach (DataRow item in MostrarAerolinea().Rows)
            {
                var aeroline = new E_Aerolinea
                {
                    Aerolinea = item["Aerolinea"].ToString(),
                    IdAerolinea = Convert.ToInt32(item["IdAerolinea"].ToString())
                };

                aerolineas.Add(aeroline);
            }

            return aerolineas;
        }

        public DataTable MostrarAerolinea()
        {
            DataTable table = new DataTable();
            table = CD_Aerolinea.ListarAerolinea();
            return table;

        }
    }
}
