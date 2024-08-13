using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;


    public class BloggingContext : DbContext
{
    // Propiedad DbSet para la entidad Blog
    public DbSet<Blog> Blogs { get; set; }
    // Propiedad DbSet para la entidad Post
    public DbSet<Post> Posts { get; set; }

    // Ruta del archivo de base de datos
    public string DbPath { get; }

    // Constructor que establece la ruta del archivo de base de datos
    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    //Configuracion del contexto
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    =>  
        // Configura el uso de SQLite con la ruta del archivo
        options.UseSqlite($"Data Source={DbPath}");
    


    // Creacion entidad Blog
   
    public class Blog 
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

         public List<Post> Posts { get; } = new();
       
    }
    


    // Creacion entidad Post
    public class Post
    {

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    


    public int BlogId{ get; set; }
    public Blog Blog{ get; set; }
    }
}
    
    
