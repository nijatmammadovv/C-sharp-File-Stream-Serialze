using C_sharp_File_Stream_Serialze.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace C_sharp_File_Stream_Serialze
{
    class Program
    {
        static void Main(string[] args)
        {
            #region =>Serialize
            //Json faylı yaradırıq və C#-da yaratdığımız obyekti serialize edərək StreamWriter vasitəsi ilə json obyektini dəyişin.
            Product BMWX5 = new Product { Id = 1, Name = "BMW", Price = 50000 };
            Product EClass = new Product { Id = 2, Name = "Mersedes", Price = 75000 };
            Product Mustang = new Product { Id = 3, Name = "Ford", Price = 86000 };
            OrderItem car1 = new OrderItem { Id = 1, Product = BMWX5, Count = 1, TotalPrice = BMWX5.Price * 1 };
            OrderItem car2 = new OrderItem { Id = 2, Product = Mustang, Count = 3, TotalPrice = Mustang.Price * 3 };
            OrderItem car3 = new OrderItem { Id = 3, Product = EClass, Count = 5, TotalPrice = EClass.Price * 5 };
            OrderItem car4 = new OrderItem { Id = 4, Product = Mustang, Count = 1, TotalPrice = Mustang.Price * 1 };
            Console.WriteLine("======================================================================================");
            car1.TotalPrice = BMWX5.Price * car1.Count;
            car2.TotalPrice = EClass.Price * car2.Count;
            car3.TotalPrice = Mustang.Price * car3.Count;
            Console.WriteLine("======================================================================================");
            List<OrderItem> orderItems1 = new List<OrderItem>();
            orderItems1.Add(car1);
            orderItems1.Add(car3);
            List<OrderItem> orderItems2 = new List<OrderItem>();
            orderItems2.Add(car2);
            orderItems2.Add(car4);
            Order order1 = new Order { Id = 1, OrderItems = orderItems1 };
            Order order2 = new Order { Id = 2, OrderItems = orderItems2 };
            var jsonObj = JsonConvert.SerializeObject(order1);
            Console.WriteLine(jsonObj);
            using (StreamWriter sw = new StreamWriter(@"C:\Users\hp\source\repos\C sharp File Stream,Serialze\C sharp File Stream,Serialze\Files\json1.json"))
            {
                sw.WriteLine(jsonObj);
            }
            #endregion
            #region => Deserialize
            string result;
            using (StreamReader sr = new StreamReader(@"C:\Users\hp\source\repos\C sharp File Stream,Serialze\C sharp File Stream,Serialze\Files\json1.json"))
            {
                result = sr.ReadToEnd();
            }
            Order o1 = JsonConvert.DeserializeObject<Order>(result);
            Console.WriteLine(o1.OrderItems[0].Product.Name);
            #endregion
        }
    }
}
