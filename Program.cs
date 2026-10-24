using Shop.Dal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using task2;

namespace Zadanie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var shops = new List<ShopDao>
            {
                new ShopDao { Id = 1, Name = "Пятёрочка", Code = "PYT" },
                new ShopDao { Id = 2, Name = "Магнит",    Code = "MAG" },
                new ShopDao { Id = 3, Name = "Лента",     Code = "LEN" }
            };

            var clients = new List<ClientDao>
            {
                new ClientDao { Id = 1, FirstName = "Иван",    LastName = "Иванов",   Patronymic = "Иванович",   BirthDate = new DateTime(1985, 5, 15) },
                new ClientDao { Id = 2, FirstName = "Пётр",    LastName = "Петров",   Patronymic = "Петрович",   BirthDate = new DateTime(1990, 8, 22) },
                new ClientDao { Id = 3, FirstName = "Анна",    LastName = "Сидорова", Patronymic = "Сергеевна",  BirthDate = new DateTime(1992, 3, 10) },
                new ClientDao { Id = 4, FirstName = "Алексей", LastName = "Смирнов",  Patronymic = "Викторович", BirthDate = new DateTime(1988, 11, 5) },
                new ClientDao { Id = 5, FirstName = "Мария",   LastName = "Кузнецова",Patronymic = "Андреевна",  BirthDate = new DateTime(1995, 7, 19) }
            };

            var goodNames = new[]
            {
                "Хлеб Бородинский", "Молоко 3.2%", "Кефир 1%", "Сметана 20%", "Творог 5%",
                "Сыр Российский", "Масло сливочное", "Колбаса Докторская", "Сосиски молочные", "Куриное филе",
                "Говядина тушёная", "Свинина шея", "Рис круглозёрный", "Гречка ядрица", "Макароны спагетти",
                "Мука пшеничная", "Сахар-песок", "Соль пищевая", "Чай чёрный", "Кофе молотый",
                "Сок яблочный", "Вода минеральная", "Печенье овсяное", "Шоколад молочный", "Конфеты Карамель",
                "Яблоки Гала", "Бананы", "Апельсины", "Картофель", "Морковь"
            };

            var goods = new List<GoodDao>();
            for (int i = 0; i < 30; i++)
            {
                goods.Add(new GoodDao
                {
                    Id = i + 1,
                    Name = goodNames[i],
                    Code = $"G{i + 1:000}"
                });
            }

            new ShopDaoXmlRepository("shops.xml").Save(shops);
            new ClientDaoXmlRepository("clients.xml").Save(clients);
            new GoodDaoXmlRepository("goods.xml").Save(goods);

            new ShopDaoJsonRepository("shops.json").Save(shops);
            new ClientDaoJsonRepository("clients.json").Save(clients);
            new GoodDaoJsonRepository("goods.json").Save(goods);

            Console.WriteLine("Данные сохранены в shops.xml, shops.json, clients.xml, clients.json, goods.xml, goods.json");

          

           
            var context = new ShopEntityContext("shop.db");

            var shopDbRepo = new ShopDaoDataBaseRepository(context);
            var goodDbRepo = new GoodDaoDataBaseRepository(context);
            var clientDbRepo = new ClientDaoDataBaseRepository(context);

           
            shopDbRepo.Add(new ShopDao { Name = "БД-магазин", Code = "DB1" });
            goodDbRepo.Add(new GoodDao { Name = "БД-товар", Code = "DBG" });
            clientDbRepo.Add(new ClientDao
            {
                FirstName = "Тест",
                LastName = "Тестов",
                Patronymic = "Тестович",
                BirthDate = new DateTime(2000, 1, 1)
            });

          
            var shop0 = shopDbRepo.GetAll().FirstOrDefault();
            var good0 = goodDbRepo.GetAll().FirstOrDefault();
            var client0 = clientDbRepo.GetAll().FirstOrDefault();

            if (shop0 != null) Console.WriteLine("Shop   #1: " + shop0.Name);
            if (good0 != null) Console.WriteLine("Good   #1: " + good0.Name);
            if (client0 != null) Console.WriteLine("Client #1: " + client0.FirstName);

           
            foreach (var s in shopDbRepo.GetAll()) Console.WriteLine("Shop:   " + s.Name);
            foreach (var g in goodDbRepo.GetAll()) Console.WriteLine("Good:   " + g.Name);
            foreach (var c in clientDbRepo.GetAll()) Console.WriteLine("Client: " + c.LastName);

            
            if (shop0 != null)
            {
                shop0.Name = "БД-магазин (обновлён)";
                shopDbRepo.Update(shop0);
                Console.WriteLine("After update: " + shopDbRepo.GetById(shop0.Id).Name);
            }

           
            if (good0 != null)
            {
                goodDbRepo.Delete(good0.Id);
                Console.WriteLine("Goods left: " + goodDbRepo.GetAll().Count);
            }

            Console.ReadKey();
        }
    }
}