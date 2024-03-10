using System.Collections.Generic;
using ModelData.Model;
using Database;
using System;
using System.Data.Common;
using Database.Class;
using System.Numerics;

namespace ModelData.Repository
{
    internal class ServidorSmtpRepository : BaseRepository<ServidorSMTP, ServidorSmtpRepository, int>,ICrudRepository<ServidorSMTP>, ISqlReaderble<ServidorSMTP>
    {
        public ServidorSmtpRepository(ServidorSMTP tipo, string conextionString, TipoBaseDatos tipoBaseDatos) : base(tipo, conextionString, tipoBaseDatos) { repo = this; }
        public new ServidorSMTP readSQLReader(object sqlReader)
        {
            try
            {
                return new ServidorSMTP((DbDataReader)sqlReader,tipoBaseDatos);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void insert(ServidorSMTP servidorSmtp)
        {           
            try
            {
                List<Parameter> parameters = BaseModelRepository.insert<ServidorSMTP, int>(servidorSmtp, tipoBaseDatos);
                parameters.Add(ParameterFactory.Insert(servidorSmtp.id, tipoBaseDatos));
                parameters.Add(ParameterFactory.Insert(servidorSmtp.puerto, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Insert(servidorSmtp.usuarioServidor, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Insert(servidorSmtp.servidor, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Insert(servidorSmtp.password, tipoBaseDatos));
                insert(parameters, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void update(ServidorSMTP servidorSmtp)
        {
            try
            {
                List<Parameter> parameters = BaseModelRepository.update<ServidorSMTP, int>(servidorSmtp, tipoBaseDatos);
                parameters.Add(ParameterFactory.Update(servidorSmtp.puerto, tipoBaseDatos));               
                parameters.Add(ParameterFactory.Update(servidorSmtp.usuarioServidor, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Update(servidorSmtp.servidor, tipoBaseDatos));              
                parameters.Add(ParameterFactory.Update(servidorSmtp.password, tipoBaseDatos));             
                parameters.Add(ParameterFactory.Where(servidorSmtp.id, tipoBaseDatos));
                update(parameters);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      
        public override void setSincronizadoTRUE<PK>(Atributo_PK<PK> id)
        {
            RepositoryFactory.ServidorSmtp_Local().updateSincronizadoTrue(id as Atributo_PK<int>);
        }
        public List<ServidorSMTP> getNoSincronizados()
        {
            try
            {
                List<Parameter> parameters = new List<Parameter>();
                if (tipoBaseDatos == TipoBaseDatos.Local)
                    parameters.Add(ParameterFactory.Where(new Atributo<bool>(false, data.isSincronizada.ColumnName), tipoBaseDatos));
                return getBy(parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
