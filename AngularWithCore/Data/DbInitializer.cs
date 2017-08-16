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
            await AddOrUpdateAsync(serviceProvider, u => u.Id, users);
            //add forms
            var forums = GetForums();
            await AddOrUpdateAsync(serviceProvider,f=>f.Id, forums);
        }
        public static IEnumerable<ApplicationUser> GetUsers()
        {
            var users = new ApplicationUser[] {
                new ApplicationUser{ Id="1", UserName="Vicky", ConcurrencyStamp=Guid.NewGuid().ToString() }
               //,new ApplicationUser{ Id="2",UserName="Jim", ConcurrencyStamp=Guid.NewGuid().ToString()},
            };
            return users;
        }
        public static IEnumerable<Forum> GetForums()
        {
            var forums = new Forum[] {
                new Forum {  Name="OfficeDev" },
                new Forum {  Name="WCF"}
            };
            return forums;
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
                foreach (TEntity item in entities)
                {
                    var state = existingData.Any(data => propertyToMatch(data).Equals(propertyToMatch(item))) ? EntityState.Modified : EntityState.Added;
                    if (state == EntityState.Added)
                    {
                        await db.Set<TEntity>().AddAsync(item);
                        resultList.Add(item);
                    }
                    else
                    {
                        db.Entry(item).State = state;
                        db.Set<TEntity>().Update(item);
                        resultList.Add(item);
                    }
                }
                await db.SaveChangesAsync();
                return resultList;
            }
        }
    }
}
