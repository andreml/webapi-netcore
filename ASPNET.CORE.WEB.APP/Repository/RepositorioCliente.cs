using ASPNET.CORE.WEB.APP.Models;
using System.Collections.Generic;
using System.Linq;


namespace ASPNET.CORE.WEB.APP.Repository
{
    public class RepositorioCliente
    {
        #region PRIVATE
        private List<ClienteModel> listClientes = new List<ClienteModel>();
        private ClienteModel cliente;
        private DataDbContext db = new DataDbContext();
        #endregion

        #region PUBLIC
        public List<ClienteModel> ConsultarCliente(string documento)
        {
            if (string.IsNullOrEmpty(documento))
                listClientes = db.Clientes.ToList();
            else
                listClientes = db.Clientes.Where(x => x.documento.Equals(documento)).ToList();

            return listClientes;
        }
        public void CadastrarCliente(string _documento, string _nome)
        {
            cliente = new ClienteModel()
            {
                documento = _documento.Trim(),
                nome = _nome.Trim()
            };

            db.Clientes.Add(cliente);
            db.SaveChanges();
        }
        #endregion
    }
}
