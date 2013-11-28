using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ImproveIT.Data;
using Rhino.Mocks;

namespace HarryPotter.Services.Tests
{

    [TestFixture]
    public class OrderServiceTests
    {

        private OrderService _orderService;
        MockRepository _repository;

        [SetUp]
        public void Setup()
        {
            this._repository = new MockRepository();
        }

        [Test]
        public void New_SendDataContext_DataContextCompositionCorrect()
        {
            IDataContext dataContext = _repository.Stub<IDataContext>();
            this._orderService = new OrderService(dataContext);
            Assert.AreEqual(dataContext, this._orderService.dataContext);
        }

        [Test]
        public void Create_ValidOrder_SaveOrderAndSendEmailForNotification()
        {
            IDataContext dataContext = _repository.DynamicMock<IDataContext>();
            this._orderService = new OrderService(dataContext);

            HarryPotter.Domain.Order newOrder = new HarryPotter.Domain.Order();
            this._orderService.dataContext.Expect(x => x.Add<HarryPotter.Domain.Order>(newOrder));
            _repository.ReplayAll();

            this._orderService.Create(newOrder);

            _repository.VerifyAll();
        }
    }
}
