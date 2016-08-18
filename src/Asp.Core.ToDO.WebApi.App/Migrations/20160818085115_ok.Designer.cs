using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Asp.Core.ToDO.WebApi.App.Layer.Repository;

namespace Asp.Core.ToDO.WebApi.App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20160818085115_ok")]
    partial class ok
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });
        }
    }
}
