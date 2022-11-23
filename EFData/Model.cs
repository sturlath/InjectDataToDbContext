using EFGetStarted;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string IsCloud { get; }

    public IMyConfiguration? MyConfiguration { get; }

    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
    {
        Debugger.Launch();

        // Getting the value from .env file
        IsCloud = Environment.GetEnvironmentVariable("CLOUD");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            throw new Exception("DbContext has not been configured, can't start the db connection.");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This also works (first when I was trying this out I got lots of errors that for some reason I didn´t get this time around)
        var myConfiguration = this.GetService<IMyConfiguration>();

        var cloudEnabled = true;

        if (cloudEnabled)
        {
            //modelBuilder.ApplyConfiguration(new CloudCompanyConfiguration());
        }
        else
        {
            //modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; } = new();
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}