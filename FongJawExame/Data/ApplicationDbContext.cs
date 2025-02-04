using FongJawExame.Models;
using Microsoft.EntityFrameworkCore;

   namespace FongJawExame.Data
   {
       public class ApplicationDbContext : DbContext
       {
           public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
               : base(options)
           {
           }

           public DbSet<UserModel> Users { get; set; }
       }
   }
   