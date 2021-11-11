using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.Models;
using Selenium.Pages;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;


namespace Selenium
{
    public class TestItem
    {
        private IWebDriver _driver;
        private List<Item> _items;
        private bool isPresentation = true;

        /// <summary>
        /// Tạo Driver Chome và cấu hình
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://localhost:44380/";
            generateData();
        }

        /// <summary>
        /// Tạo dữ liệu hàng hóa
        /// </summary>
        public void generateData()
        {
            _items = new List<Item>() {
                 new Item() {
                    Code = 2,
                    Name = "Quần Jean",
                    Description = "Đẹp và chất",
                    Quantity = 132,
                    Price = 200000,
                 },

                 new Item() {
                     Code = 2,
                     Name = "Áo phông",
                     Description = "Chất và đẹp",
                     Quantity = 122,
                     Price = 1200000,
                 },
            };
        }

        /// <summary>
        /// Test Lấy dữ liệu
        /// </summary>
        [Test, Order(1)]
        public void GetItem()
        {
            _driver.Navigate().Refresh();
            SleepWithPresentation();


        }

        /// <summary>
        /// Test tạo hàng hóa
        /// </summary>
        [Test, Order(2)]
        public void CreateItem()
        {
            var itemPage = new ElementItemPage();
            PageFactory.InitElements(_driver, itemPage);

            // Mở màn hình tạo hàng hóa
            _driver.FindElement(By.XPath("/html/body/div/main/p/a")).Click();

            // Thêm dữ liệu
            itemPage.Code.SendKeys(_items[0].Code.ToString());
            SleepWithPresentation();

            itemPage.Name.SendKeys(_items[0].Name.ToString());
            SleepWithPresentation();

            itemPage.Description.SendKeys(_items[0].Description.ToString());
            SleepWithPresentation();

            itemPage.Quantity.SendKeys(_items[0].Quantity.ToString());
            SleepWithPresentation();

            itemPage.Price.SendKeys(_items[0].Price.ToString());
            SleepWithPresentation();

            // Lưu hàng hóa
            _driver.FindElement(By.XPath("//*[@id=\"submit\"]")).Click();
        }

        /// <summary>
        /// Test sửa hàng hóa
        /// </summary>
        [Test, Order(3)]
        public void UpdateItem()
        {
            _driver.Navigate().Refresh();
            SleepWithPresentation();
            var itemPage = new ElementItemPage();
            PageFactory.InitElements(_driver, itemPage);

            // Mở màn hình sửa hàng hóa
            _driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr/td[6]/a[1]")).Click();

            // Sửa dữ liệu
            itemPage.Code.Clear();
            itemPage.Code.SendKeys(_items[1].Code.ToString());
            SleepWithPresentation();

            itemPage.Name.Clear();
            itemPage.Name.SendKeys(_items[1].Name.ToString());
            SleepWithPresentation();

            itemPage.Description.Clear();
            itemPage.Description.SendKeys(_items[1].Description.ToString());
            SleepWithPresentation();

            itemPage.Quantity.Clear();
            itemPage.Quantity.SendKeys(_items[1].Quantity.ToString());
            SleepWithPresentation();

            itemPage.Price.Clear();
            itemPage.Price.SendKeys(_items[1].Price.ToString());
            SleepWithPresentation();

            // Lưu hàng hóa
            _driver.FindElement(By.XPath("//*[@id=\"form\"]/div[6]/input")).Click();
        }

        /// <summary>
        /// Test xóa hàng hóa
        /// </summary>
        [Test, Order(4)]
        public void DeleteItem()
        {
            SleepWithPresentation();
            _driver.Navigate().Refresh();

            // Mở màn hình xóa hàng hóa
            _driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr/td[6]/a[3]")).Click();
            SleepWithPresentation();

            // Xác nhận xóa hàng hóa
            _driver.FindElement(By.XPath("/html/body/div/main/div/form/input[2]")).Click();
        }

        /// <summary>
        /// Chạy chậm để trình bày 
        /// </summary>
        public void SleepWithPresentation()
        {
            if (isPresentation)
            {
                Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// Đóng trình duyệt trước khi kết thúc test
        /// </summary>
        [OneTimeTearDown]
        public void End()
        {
            _driver.Quit();
        }
    }
}