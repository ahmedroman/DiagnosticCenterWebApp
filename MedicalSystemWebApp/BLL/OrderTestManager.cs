using MedicalSystemWebApp.DAL;
using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.BLL
{
    public class OrderTestManager
    {
        OrderTestGateway orderTestGateway = new OrderTestGateway();

        public int SaveOrderTest(OrderTest orderTest)
        {
            return orderTestGateway.SaveOrderTest(orderTest);
        }
    }
}