using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using SoloProject.Models;

namespace SoloProject.Migrations
{
    [DbContext(typeof(PostDbContext))]
    [Migration("20160421020104_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoloProject.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("PostId");

                    b.HasKey("CommentId");
                });

            modelBuilder.Entity("SoloProject.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.HasKey("PostId");
                });

            modelBuilder.Entity("SoloProject.Models.Comment", b =>
                {
                    b.HasOne("SoloProject.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostId");
                });
        }
    }
}
