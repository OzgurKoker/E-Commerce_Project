using ETicaretApp.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.DAL
{
    public static class AppDbInitializer
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "admin@gmail.com",
                    Password = "123456",
                    RegisterDate = DateTime.Now,
                    State = true,
                    Role = "Admin"
                }
            );

            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://turkiyeapi.cyclic.app/api/v1/provinces?fields=name,id,districts";

                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    var cityData = JsonConvert.DeserializeObject<CityData>(responseBody);

                    foreach (var city in cityData.Data)
                    {
                        modelBuilder.Entity<City>().HasData(new City { Id = city.Id, Name = city.Name });

                        foreach (var district in city.Districts)
                        {
                            modelBuilder.Entity<District>().HasData(new District { Id = district.Id, CityId = city.Id, Name = district.Name });
                        }
                    }
                }
                else
                {
                    Console.WriteLine("API isteği başarısız oldu. Hata kodu: " + response.StatusCode);
                }
            }
        }

        private class CityData
        {
            public List<City> Data { get; set; }
        }


    }
}
