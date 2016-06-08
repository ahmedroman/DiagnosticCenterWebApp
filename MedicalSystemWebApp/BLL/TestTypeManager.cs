using MedicalSystemWebApp.DAL;
using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.BLL
{
    public class TestTypeManager
    {
        TestTypeGateway testTypeGateway = new TestTypeGateway();
        public int SaveTestType(TestType testType)
        {
            return testTypeGateway.SaveTestType(testType);
        }
        public List<TestType> GetAllTestType() 
        {
            return testTypeGateway.GetAllTestType();
        }
        public TestType GetTestTypeByName(string name) 
        {
            return testTypeGateway.GetTestTypeByName(name);
        }
        public void ValidationFunction(TestType testType)
        {
            if (!IsPresent(testType.Name))
            {
                throw new Exception("Name can't be empty.");
            }
            if(testTypeGateway.GetTestTypeByName(testType.Name) != null)
            {
                throw new Exception("Name must be unique.");
            }
        }
        private bool IsPresent(string value)
        {
            return value.Length > 0;
        }
    }
}