using MedicalSystemWebApp.DAL;
using MedicalSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalSystemWebApp.BLL
{
    public class OrderManager
    {
        OrderGateway orderGateway = new OrderGateway();

        public int SaveOrder(Order order)
        {
            return orderGateway.SaveOrder(order);
        }
        public Order GetOrderByBillNo(string billNo)
        {
            return orderGateway.GetOrderByBillNo(billNo);
        }
        public Order GetOrderById(int id)
        {
            return orderGateway.GetOrderById(id);
        }
        public int PayTheBill(Order order)
        {
            return orderGateway.PayTheBill(order);
        }
        public string GenerateBillNo()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random randomNumber = new Random();
            int firstNumber = randomNumber.Next(0, 9);
            char fistChar = chars[randomNumber.Next(1, 52)];
            int secondNumber = randomNumber.Next(0, 9);
            char secondChar = chars[randomNumber.Next(1, 52)];
            char thirdChar = chars[randomNumber.Next(1, 52)];
            int thirdNumber = randomNumber.Next(0, 9);
            string randomString = firstNumber.ToString() + fistChar + secondNumber.ToString() +
                secondChar + thirdChar + thirdNumber.ToString();
            Order existingOrder = GetOrderByBillNo(randomString);
            if (existingOrder != null)
            {
                randomString = GenerateBillNo();
            }
            return randomString;
        }
    }
}