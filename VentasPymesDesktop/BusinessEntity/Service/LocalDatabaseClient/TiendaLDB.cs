using Database;
using Database.Class;
using ModelData.Model;
using ModelData.Repository;
using System;
using System.Collections.Generic;

namespace ModelData.Service.LocalDatabaseClient
{
    public class TiendaLDB
    {
        private TiendaRepository repo;
        public TiendaLDB()
        {
            repo = RepositoryFactory.Tienda_Local();
        }
        public List<Tienda> getTiendas(int annoActual, string tokenId)
        {
            try
            {
                List<Tienda> tiendas = repo.inicializar();
                foreach (Tienda tienda in tiendas)
                {
                    if (tienda.planesVentas.Count == 0)
                    {
                        tienda.planesVentas = new PlanVentaMensualLDB().inicializarPlanVentaTienda(tienda, annoActual, tokenId);
                    }
                }
                return tiendas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Tienda> getActivasByComplejosNotSincronizados(List<string> idComplejos)
        {
            try
            {
                List<Tienda> tiendas = new List<Tienda>();
                foreach (string id in idComplejos)
                {
                    tiendas.AddRange(repo.getActivasByComplejoNotSincronizados(id));
                }
                return tiendas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updateFromRemoteData(List<Tienda> tiendasRemotos)
        {
            try
            {
                if (tiendasRemotos.Count > 0)
                {
                    foreach (Tienda tienda in tiendasRemotos)
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
                modificarTienda(tienda);
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
                modificarTienda(tienda);
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
                modificarTienda(tienda);
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
                tienda.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                repo.update(tienda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Tienda crearTienda(Tienda tienda, int idTienda)
        {
            try
            {
                tienda.id.Value = idTienda;
                tienda.preInsertObjecto(VariablesEntorno.securityToken.token.Value);
                repo.insert(tienda);
                return tienda;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
