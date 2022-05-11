
using System;

namespace demo.DAL
{
    using Microsoft.EntityFrameworkCore;
    using demo.Models;

    public class MyContext:DbContext
    {
        public MyContext() { }

        //在startup.cs中进行注入时使用
        public MyContext(DbContextOptions<MyContext> options) 
            : base(options) {
        }

        //如果不有参的构造函数，则连接字符串需要在这个方法中实现
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        //设置数据集
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        //在模型创建时给实体属性添加约束
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //产品类型
            modelBuilder.Entity<ProductType>(e =>
            {
                //设置主键
                e.HasKey( p=>p.PTID );
                //设置属性PTName的约束
                e.Property( p => p.PTName )
                 .IsRequired() //非空约束
                 .HasMaxLength(20) //设置字符串长度
                 .IsUnicode(true) //是不是nvarchar
                 //.IsFixedLength(10) //char/nchar
                 ;
            });
            //设置产品
            modelBuilder.Entity<Products>(e => { 
                e.HasKey(e=>e.ProID);
                e.Property(p => p.PorName)
                .IsRequired().HasMaxLength(20).IsUnicode(true);
                e.Property(p => p.ProPrice).IsRequired();


                e.HasOne(e=>e.ProductType)
                .WithMany(e=>e.Products)
                .HasForeignKey(e=>e.PTID )
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Products_ProductType");
            });
        }
    }

}
