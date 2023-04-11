using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Context; 

public class DbWebAPIContext : DbContext
{
    public DbSet<CategoryModel> Categories{get;set;}
    public DbSet<OpenTaskModel> OpenTasks{get;set;}

    public DbWebAPIContext (DbContextOptions<DbWebAPIContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<CategoryModel> categorySeed = new List<CategoryModel>();
        List<OpenTaskModel> taskSeed = new List<OpenTaskModel>();

        categorySeed.Add(new CategoryModel(){
            CategoryID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e52fa"),
            name = "Pending activities",
            peso = 20
            });
        
        categorySeed.Add(new CategoryModel(){
            CategoryID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e5202"),
            name = "Personal activities",
            peso = 50
            });
        
        taskSeed.Add(new OpenTaskModel(){
            TaskID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e5210"),
            CategoryID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e52fa"),
            Priority = priority.medium,
            tittle = "Public services pay",
            creationDate = DateTime.Now
        });

        taskSeed.Add(new OpenTaskModel(){
            TaskID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e5211"),
            CategoryID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e5202"),
            Priority = priority.Low,
            tittle = "Finish Netflix series",
            creationDate = DateTime.Now
        });

        modelBuilder.Entity<CategoryModel>(category => 
        {
            category.ToTable("Category");
            category.HasKey(p=> p.CategoryID);

            category.Property(p=> p.name).IsRequired().HasMaxLength(150);
            category.Property(p=> p.description).IsRequired(false).HasMaxLength(150);
            category.Property(p=> p.peso);

            category.HasData(categorySeed);
        });

        modelBuilder.Entity<OpenTaskModel>(task => 
        {
            task.ToTable("OpenTask");
            task.HasKey(p=> p.TaskID);
            task.HasOne(p=> p.categoryOfTask).WithMany(p => p.tasksInCategory).HasForeignKey(p => p.CategoryID);

            task.Property(p=> p.tittle).IsRequired().HasMaxLength(200);
            task.Property(p=> p.description).IsRequired(false);
            task.Property(p=> p.Priority);
            task.Property(p=> p.creationDate);
            task.Property(p=> p.Deadline);

            task.Ignore(p=> p.summary);
            
            task.HasData(taskSeed);
        });
    }
}