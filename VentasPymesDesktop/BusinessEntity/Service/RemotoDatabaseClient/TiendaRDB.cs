using Database;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.RemotoDatabaseClient
{
    public class TiendaRDB
    {
        private TiendaRepository repo;
        public TiendaRDB()
        {
            repo = RepositoryFactory.Tienda_Postgres();
        }
        public List<Tienda> getAll()
        {
            try
            {
                return repo.getAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      
        public bool updateFromLocalData(List<Tienda> tiendaLocales)
        {
            try
            {
                if (tiendaLocales.Count > 0)
                {
                    foreach (Tienda tienda in tiendaLocales)
                    {
                        SicronizacionResult result = repo.sincronizarDatos(tienda);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void eliminarTienda(Tienda tienda)
        {
            try
            {
                tienda.isEliminada.Value = true;
                tienda.isActivo.Value = false;
                modificar(tienda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void abrirTienda(Tienda tienda)
        {
            try
            {
                tienda.isAbierta.Value = true;
                modificar(tienda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void cerrarTienda(Tienda tienda)
        {
            try
            {
                tienda.isAbierta.Value = false;
                modificar(tienda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Tienda crearTienda(Tienda tienda)
        {
            try
            {
                repo.insert(tienda);               
                return tienda;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void modificarTienda(Tienda tienda)
        {
            try
            {               
                           
                modificar(tienda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        void modificar(Tienda tienda)
        {
            try
            {               
                tienda.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                repo.update(tienda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int getNextId()
        {
            try
            {               
                return repo.getNextId();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
