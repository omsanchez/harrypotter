using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ImproveIT.Data;
using NDbUnit.Core;
using System.Configuration;

namespace HarryPotter.Data.Tests
{

    /// <summary>
    /// Abstract base class for datacontext testing
    /// </summary>
    [TestFixture]
    public abstract class DataContextTestsBase
    {

        internal IDataContext _dataContext;
        internal INDbUnitTest _ndbUnitTest;

        [SetUp]
        public void Setup()
        {
            string cnn = ConfigurationManager.ConnectionStrings["storedb_development"].ConnectionString;
            this._ndbUnitTest = new NDbUnit.Core.MySqlClient.MySqlDbUnitTest(cnn);
            this._ndbUnitTest.ReadXmlSchema("StoreSchema.xsd");
            this._ndbUnitTest.PerformDbOperation(NDbUnit.Core.DbOperationFlag.DeleteAll);

            NHibernate.ISession session =
                HarryPotter.Data.DataContextBuilder.BuildSession();
            this._dataContext = new ImproveIT.Data.Hibernate.HibernateDataContext(session);
        }
    }
}
