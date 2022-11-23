﻿using EFGetStarted;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }

    public IMyConfiguration? PhysicalStructureConfiguration { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Debugger.Launch();

        // how to get data to here? I could not get this to work
        //var myConfiguration = this.GetService<IMyConfiguration>();

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


    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
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