using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarryPotter.Domain;
using ImproveIT.Data;

namespace HarryPotter.Services
{
    public class OrderService: IOrderService
    {

        public IDataContext dataContext;

        public void Create(Domain.Order order)
        {
            this.dataContext.Add<Domain.Order>(order);
        }

        public OrderService()
        { 
            NHibernate.ISession session = HarryPotter.Data.DataContextBuilder.BuildSession();
            this.dataContext = new ImproveIT.Data.Hibernate.HibernateDataContext(session);
        }

        public OrderService(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
