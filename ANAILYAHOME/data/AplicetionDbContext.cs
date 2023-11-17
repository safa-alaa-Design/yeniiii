using ANAILYAHOME.entityes;
using ANAILYAHOME.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ANAILYAHOME.models;


    public class AplicetionDbContext:IdentityDbContext<AplicationUser, IdentityRole<int> , int>
    {

   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("server=ALAA_SHAHROR\\SQLEXPRESS02; database=ILYAHOME;Integrated Security=true; TrustServerCertificate=true; ");
    }
    public AplicetionDbContext()
    {
    }
    public AplicetionDbContext(DbContextOptions options) : base(options)
        {
        }
         public DbSet<urunEntity> urun { get; set; }
         public DbSet<OturmaOdasi> oturma { get; set; }
         public DbSet<YatmaOdasi> yatma { get; set; }
         public DbSet<CocukOdasi> cocuk { get; set; }
         public DbSet<YemekOdasi> yemek { get; set; }
         public DbSet<Degerler> deger { get; set; }
         public DbSet<FiyatEntity> fiyat { get; set; }
         public DbSet<oturmafiyatler> oturmafiyat { get; set; }
         public DbSet<yatmafiyatler> yatmafiyat { get; set; }
         public DbSet<cocukfiyatler> cocukfiyat { get; set; }
         public DbSet<yemekfiyatler> yemekfiyat { get; set; }
         public DbSet<FotoEntity> foto { get; set; }
         public DbSet<ProductDeger> prodouct { get; set; }
         public DbSet<emailgonderEntity> emailgonder { get; set; }
         public DbSet<AdmenbanalEntity> Admenbanal { get; set; }
         public DbSet<BayiKategori> BayiKategoriler { get; set; }
         public DbSet<AliciEntity> Alici { get; set; }
         public DbSet<alışverişEntity> alışveriş { get; set; }
         public DbSet<Buyutlar> buyut { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        modelBuilder.Entity<IdentityRole<int>>().HasData(
             new IdentityRole<int>()
             {
                 Id=1,
                 Name = "ADMIN",
                 NormalizedName = "ADMIN",
                 ConcurrencyStamp = Guid.NewGuid().ToString(),
             },
             new IdentityRole<int>()
             {

                Id=3,
                 Name = "USER",
                 NormalizedName = "USER",
                 ConcurrencyStamp = Guid.NewGuid().ToString(),
             },

        new IdentityRole<int>()
        {
            Id=2,
            Name = "SATICI",
            NormalizedName = "SATICI",
            ConcurrencyStamp = Guid.NewGuid().ToString(),
        });

        base.OnModelCreating(modelBuilder);










        modelBuilder.Entity<AliciEntity>()
               .HasMany(a => a.Listofalışveriş)
               .WithOne(a => a.Alici)
               .HasForeignKey(a => a.AliciId);

        base.OnModelCreating(modelBuilder);



        modelBuilder.Entity<urunEntity>()
            .HasMany(a => a.Listofalışveriş)
            .WithOne(a => a.urun)
            .HasForeignKey(a => a.urunId);

        base.OnModelCreating(modelBuilder);



        modelBuilder.Entity<urunEntity>()
                .HasMany(a => a.Listoffiyat)
                .WithOne(a => a.urun)
                .HasForeignKey(a => a.UrunId)
                .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<urunEntity>()
                .HasMany(a => a.ListofBuyut)
                .WithOne(a => a.urun)
                .HasForeignKey(a => a.UrunId)
                .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(modelBuilder);




        modelBuilder.Entity<urunEntity>()
                .HasMany(a => a.Listoffoto)
                .WithOne(a => a.urun)
                .HasForeignKey(a => a.UrunId)
                .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(modelBuilder);




        base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductDeger>()
                .HasMany(c => c.Listofdegerler)
                .WithOne(c => c.prodouct)
                .HasForeignKey(c => c.prodouctId);


            base.OnModelCreating(modelBuilder);




        modelBuilder.Entity<AdmenbanalEntity>()
               .HasMany(a => a.Listofurun)
               .WithOne(a => a.Admenbanal)
               .HasForeignKey(a => a.AdmenbanalId);


           base.OnModelCreating(modelBuilder);




        modelBuilder.Entity<AdmenbanalEntity>()
             .HasMany(a => a.BayiKategorilist)
             .WithOne(a => a.Admenbanal)
             .HasForeignKey(a => a.Bayiid);


        base.OnModelCreating(modelBuilder);





        modelBuilder.Entity<AdmenbanalEntity>()
               .HasOne(a => a.AspNetUsers)
               .WithOne(a => a.Admenbanal)
               .HasForeignKey<AdmenbanalEntity>(a => a.userId).
               OnDelete(DeleteBehavior.ClientSetNull); 


        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<AliciEntity>()
              .HasOne(a => a.AspNetUsers)
              .WithOne(a => a.Alici)
              .HasForeignKey<AliciEntity>(a => a.userId).
               OnDelete(DeleteBehavior.ClientSetNull);

        base.OnModelCreating(modelBuilder);








        //علاقات جداول المنتجات بال الاورون


        modelBuilder.Entity<urunEntity>()
               .HasOne(a => a.oturma)
               .WithOne(a => a.urun)
               .HasForeignKey<OturmaOdasi>(a => a.UrunId)
               .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(modelBuilder);






        modelBuilder.Entity<urunEntity>()
              .HasOne(a => a.yatma)
              .WithOne(a => a.urun)
              .HasForeignKey<YatmaOdasi>(a => a.UrunId)
              .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(modelBuilder);



        modelBuilder.Entity<urunEntity>()
             .HasOne(a => a.cocuk)
             .WithOne(a => a.urun)
             .HasForeignKey<CocukOdasi>(a => a.UrunId)
             .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(modelBuilder);



        modelBuilder.Entity<urunEntity>()
             .HasOne(a => a.yemek)
             .WithOne(a => a.urun)
             .HasForeignKey<YemekOdasi>(a => a.UrunId)
             .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<urunEntity>()
             .HasOne(a => a.deger)
             .WithOne(a => a.urun)
             .HasForeignKey<Degerler>(a => a.UrunId)
             .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(modelBuilder);







        //علاقات جداول اسعال المنتجات الفرديه بال الاسعار



        modelBuilder.Entity<FiyatEntity>()
              .HasOne(a => a.oturmafiyat)
              .WithOne(a => a.fiyat)
              .HasForeignKey<oturmafiyatler>(a => a.fiyatId);
              

        base.OnModelCreating(modelBuilder);





        modelBuilder.Entity<FiyatEntity>()
              .HasOne(a => a.yatmafiyat)
              .WithOne(a => a.fiyat)
              .HasForeignKey<yatmafiyatler>(a => a.fiyatId);


        base.OnModelCreating(modelBuilder);




        modelBuilder.Entity<FiyatEntity>()
             .HasOne(a => a.cocukfiyat)
             .WithOne(a => a.fiyat)
             .HasForeignKey<cocukfiyatler>(a => a.fiyatId);


        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FiyatEntity>()
           .HasOne(a => a.yemekfiyat)
           .WithOne(a => a.fiyat)
           .HasForeignKey<yemekfiyatler>(a => a.fiyatId);


        base.OnModelCreating(modelBuilder);


    }



    public DbSet<ANAILYAHOME.models.oturmaEkleModels>? oturmaEkleModels { get; set; }





}

