using LearningProject2.Models;
using Microsoft.EntityFrameworkCore;
using LearningProject2.Models;
namespace LearningProject2.Data;


//public class DataContext:DbContext
public class OldContext(DbContextOptions <OldContext> options):DbContext(options)
{
    
    public DbSet<Band> Bands { get; set; }
    /*
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration) 
    {
        this.Configuration = configuration;
    }



    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
     //connect to postgres with connection string from app settings
     options.UseNpgsql(Configuration.GetConnectionString("postgres"));
    }*/
    
   /*    Diferencia en primer video
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }*/

   
}