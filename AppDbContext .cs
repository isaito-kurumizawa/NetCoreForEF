using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NetCoreForEF
{
    // DBコンテキスト
    public class AppDbContext : DbContext
    {
        public DbSet<Test> _test { get; set; }

        public class Test
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime CreateTime { get; set; }
            public Nullable<DateTime> UpdateTime { get; set; }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 接続文字列を指定する
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = "Test",
                InitialCatalog = "Test",
                IntegratedSecurity = true,
            }.ToString();
            
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // テーブルにマッピングする
            modelBuilder.Entity<Test>().ToTable("Test");
        }
    }
}
