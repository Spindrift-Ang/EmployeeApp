using EFEmployeeAccessLibrary.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestEmployeeServices
{
    public class Tests
    {
        private const string baseAddr = "http://localhost:5131/api/";


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestGetAllEmployees()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("baseAddr");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = (await client.GetAsync("Employee/All"));
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        public async Task TestGetEmployee()
        {
           

            //create new entry 

            HttpClient clientPost = new HttpClient();
            clientPost.BaseAddress = new Uri("baseAddr");
            clientPost.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));


            var employee = GetTestEmployee();
            var stringPayload = JsonConvert.SerializeObject(employee);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");


     
            HttpResponseMessage responsePost =  (await clientPost.PostAsync("api/Employeee/", httpContent));
            Assert.IsTrue(responsePost.IsSuccessStatusCode);
     

            //retieve new entry
            HttpClient clientGet = new HttpClient();
            clientGet.BaseAddress = new Uri("baseAddr");




            clientGet.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

   
            HttpResponseMessage responseGet = clientGet.GetAsync("api/Employee/" + employee.Id.ToString()).Result;
            Assert.IsTrue(responseGet.IsSuccessStatusCode);


        }

        public async Task TestPutEmployee()
        {
            HttpClient clientPut = new HttpClient();
            clientPut.BaseAddress = new Uri("baseAddr");
            clientPut.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var employee = GetTestEmployee();
            var stringPayload = JsonConvert.SerializeObject(employee);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            // List data response.
            HttpResponseMessage responsePost = (await clientPut.PutAsync("api/Employeee/" + employee.Id.ToString(), httpContent));
            Assert.IsTrue(responsePost.IsSuccessStatusCode);

        }

        public async Task TestPostEmployee()

        {
            HttpClient clientPost = new HttpClient();
            clientPost.BaseAddress = new Uri("baseAddr");
            clientPost.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));


            var employee = GetTestEmployee();
            var stringPayload = JsonConvert.SerializeObject(employee);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");


            // List data response.
            HttpResponseMessage responsePost = (await clientPost.PostAsync("api/Employeee/", httpContent));
            Assert.IsTrue(responsePost.IsSuccessStatusCode);

        }

        private Employee GetTestEmployee()
        {
            Guid testGuid = Guid.NewGuid();

            var payload = new Employee()
            {
                Id = testGuid,
                Name = "Name of employee",
                DateOfBirth = DateTime.Now,
                Position = "Position field",
                Salary = 100000,
                Address = "the address",
                Department = "the department"
            };


            return payload;
        }

        private String GetJsonSerializedEmployee()
        {
            return JsonConvert.SerializeObject(GetTestEmployee());
        }
    }
}