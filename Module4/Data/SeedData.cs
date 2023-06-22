using Microsoft.EntityFrameworkCore;
using Module4.Models;
using System;

namespace Module4.Data
{
    public static class SeedData
    {
        public static void Seed (WebApplication app) {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<ToDoContext>();

            var item1 = new ToDoItem() { Id = 1, Name = "walk dog", IsComplete = true };
            var item2 = new ToDoItem() { Id = 2, Name = "walk", IsComplete = false };
            var item3 = new ToDoItem() { Id = 3, Name = "Work", IsComplete = true };
            var item4 = new ToDoItem() { Id = 4, Name = "Sleep", IsComplete = false };

            db.Add(item1);
            db.Add(item2);
            db.Add(item3);
            db.Add(item4);
            db.SaveChanges();
        }
    }
}
