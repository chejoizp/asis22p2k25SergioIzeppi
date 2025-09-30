using System;
using System.Text;
using System.Data;
using System.IO;
using CapaModelo_Seguridad;

namespace CapaControlador_Seguridad
{
    public class Controlador
    {
        Sentencias sn = new Sentencias();
        public DataTable MostrarBitacora() => sn.Listar();
        //Busca por fecha
        public DataTable BuscarPorFecha(DateTime fecha) => sn.ConsultarPorFecha(fecha);
        //Busca por rango de fechas
        public DataTable BuscarPorRango(DateTime inicio, DateTime fin) => sn.ConsultarPorRango(inicio, fin);
        //Busca por usuario
        public DataTable BuscarPorUsuario(int iIdUsuario) => sn.ConsultarPorUsuario(iIdUsuario);

        //Registrar acciones
        public void RegistrarAccion(int iIdUsuario, int iIdAplicacion, string sAccion, bool bEstado)
        {
            sn.InsertarBitacora(iIdUsuario, iIdAplicacion, sAccion, bEstado);
        }

        public void insertarFacultad(string codigo_facultad, string nombre_facultad, string status_facultad)
        {
            Sentencias.InsertarFacultades(codigo_facultad, nombre_facultad, status_facultad);
        }

    }
}
