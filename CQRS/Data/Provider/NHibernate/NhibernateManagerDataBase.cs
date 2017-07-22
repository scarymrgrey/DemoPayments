using System;
using FluentNHibernate.Cfg;
using Incoding.Data;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace CQRS.Data.Provider.NHibernate
{

    ////ncrunch: no coverage start
    public class NhibernateManagerDataBase : IManagerDataBase
    {
        #region Fields

        readonly Lazy<SchemaExport> schemaExport;

        readonly Lazy<SchemaValidator> schemaValidate;

        readonly Lazy<SchemaUpdate> schemaUpdate;

        #endregion

        #region Constructors

        public NhibernateManagerDataBase(Configuration configuration)
        {
            schemaExport = new Lazy<SchemaExport>(() => new SchemaExport(configuration));
            schemaUpdate = new Lazy<SchemaUpdate>(() => new SchemaUpdate(configuration));
            schemaValidate = new Lazy<SchemaValidator>(() => new SchemaValidator(configuration));
        }

        public NhibernateManagerDataBase(FluentConfiguration builderConfiguration)
                : this(builderConfiguration.BuildConfiguration()) { }

        #endregion

        #region IManagerDataBase Members

        public void Create()
        {
            schemaExport.Value.Create(true, true);
        }

        public bool isExist()
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            schemaExport.Value.Drop(false, true);
        }

        public void Update()
        {
            this.schemaUpdate.Value.Execute(true, true);
        }

        public bool IsExist()
        {
            Exception exception;
            return IsExist(out exception);
        }

        public bool IsExist(out Exception outException)
        {
            outException = null;
            try
            {
                this.schemaValidate.Value.Validate();
                return true;
            }
            catch (Exception exception)
            {
                outException = exception;
                return false;
            }
        }

        #endregion
    }

    ////ncrunch: no coverage end
}