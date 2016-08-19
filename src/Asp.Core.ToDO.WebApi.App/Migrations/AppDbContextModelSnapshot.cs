using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Asp.Core.ToDO.WebApi.App.Layer.Repository;

namespace Asp.Core.ToDO.WebApi.App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Asp.Core.ToDO.WebApi.App.Layer.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<string>("Picture");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Asp.Core.ToDO.WebApi.App.Layer.Models.PersonTask", b =>
                {
                    b.Property<int>("PersonTaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndTime");

                    b.Property<string>("Name");

                    b.Property<int>("PersonId");

                    b.Property<DateTime?>("StartTime");

                    b.HasKey("PersonTaskId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Asp.Core.ToDO.WebApi.App.Layer.Models.PersonTask", b =>
                {
                    b.HasOne("Asp.Core.ToDO.WebApi.App.Layer.Models.Person", "Person")
                        .WithMany("Tasks")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
