using AngularWithCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWithCore.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                db.Database.EnsureCreated();
                //Look for any user
                //if (db.Users.Any())
                //{
                //    return;
                //}
                await InsertTestData(serviceProvider);
            }
        }
        private static async Task InsertTestData(IServiceProvider serviceProvider)
        {
            //add users
            var users = GetUsers();
            await AddOrUpdateAsync(serviceProvider,u=>u.Id,users);
        }
        public static IEnumerable<ApplicationUser> GetUsers()
        {
            var users = new ApplicationUser[] {
                //new ApplicationUser{ Id="1", UserName="Tom" },
                //new ApplicationUser{ Id="2",UserName="Jim"},
                new ApplicationUser{ Id="3",UserName="Tony"}
            };
            return users;
        }

        private static async Task<IEnumerable<TEntity>> AddOrUpdateAsync<TEntity>(IServiceProvider serviceProvider,
            Func<TEntity,object> propertyToMatch, IEnumerable<TEntity> entities) where TEntity : class
        {
            //query existing data in a separate context, and then attach them as modified
            List<TEntity> existingData;
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                existingData = db.Set<TEntity>().ToList();
            }
            var resultList = new List<TEntity>();
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                foreach (var item in entities)
                {
                    var state = existingData.Any(data => propertyToMatch(data).Equals(propertyToMatch(item))) ? EntityState.Modified : EntityState.Added;
                    if (state == EntityState.Added)
                    {
                        await db.Set<TEntity>().AddAsync(item);
                        resultList.Add(item);
                    }
                    else
                    {
                        var existData = db.Set<TEntity>().Where(data => propertyToMatch(data).Equals(propertyToMatch(item))).FirstOrDefault();
                        db.Set<TEntity>().Update(item);
                        resultList.Add(existData);
                    }
                }
                db.SaveChanges();
                return resultList;
            }
        }
    }
}
