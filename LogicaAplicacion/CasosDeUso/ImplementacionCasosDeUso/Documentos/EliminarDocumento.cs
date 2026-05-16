using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Documento;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Documentos
{
    public class EliminarDocumento : IEliminarDocumento
    {
        private readonly IRepositorioDocumento _repositorioDocumento;

        public EliminarDocumento(IRepositorioDocumento repositorioDocumento) 
        {
            _repositorioDocumento = repositorioDocumento;
        }
        public void Ejecutar(int id)
        {
            _repositorioDocumento.Delete(id);
        }
    }
}
