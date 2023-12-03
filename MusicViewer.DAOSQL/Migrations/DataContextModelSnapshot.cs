﻿// <auto-generated />
using System;
using INF148187148204.MusicViewer.DAOSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace INF148187148204.MusicViewer.DAOSQL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("INF148187148204.MusicViewer.DAOSQL.BO.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("INF148187148204.MusicViewer.DAOSQL.BO.Track", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ArtistID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Genre")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ArtistID");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("INF148187148204.MusicViewer.DAOSQL.BO.Track", b =>
                {
                    b.HasOne("INF148187148204.MusicViewer.DAOSQL.BO.Artist", null)
                        .WithMany("Tracks")
                        .HasForeignKey("ArtistID");
                });

            modelBuilder.Entity("INF148187148204.MusicViewer.DAOSQL.BO.Artist", b =>
                {
                    b.Navigation("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
