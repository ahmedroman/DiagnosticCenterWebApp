using MedicalSystemWebApp.DAL;
using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.BLL
{
    public class TestManager
    {
        TestGateway testGateway = new TestGateway();

        public int SaveTest(Test test)
        {
            return testGateway.SaveTest(test);  
        }
        public Test GetTestByName(string name)
        {
            return testGateway.GetTestByName(name);
        }
        public List<Test> GetAllTest()
        {
            return testGateway.GetAllTest();
        }
        public void ValidationFunction(Test test)
        {
            if (!IsPresent(test.Name))
            {
                throw new Exception("Name can't be empty.");
            }
            if (!IsPresent(test.Fee.ToString()))
            {
                throw new Exception("Fee can't be empty.");
            }
            if (!IsPresent(test.TestTypeId.ToString()))
            {
                throw new Exception("Please select a test Type.");
            }
            if (testGateway.GetTestByName(test.Name) != null)
            {
                throw new Exception("Test name must be unique.");
            }
        }
        private bool IsPresent(string value)
        {
            return value.Length > 0;
        }
    }
}