﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Server.Data;

namespace server.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20200521212906_Follower")]
    partial class Follower
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Models.DataObjects.FollowedUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("SeePosts")
                        .HasColumnType("boolean");

                    b.Property<bool>("SeeReposts")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FollowedUsers");
                });

            modelBuilder.Entity("Models.DataObjects.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ContentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("PosterId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ReplyToId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("PosterId");

                    b.HasIndex("ReplyToId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Models.DataObjects.PostBody", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<List<string>>("Images")
                        .HasColumnType("text[]");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PostBodies");
                });

            modelBuilder.Entity("Models.DataObjects.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.DataObjects.FollowedUser", b =>
                {
                    b.HasOne("Models.DataObjects.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Models.DataObjects.Post", b =>
                {
                    b.HasOne("Models.DataObjects.PostBody", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");

                    b.HasOne("Models.DataObjects.User", "Poster")
                        .WithMany()
                        .HasForeignKey("PosterId");

                    b.HasOne("Models.DataObjects.Post", "ReplyTo")
                        .WithMany()
                        .HasForeignKey("ReplyToId");
                });

            modelBuilder.Entity("Models.DataObjects.PostBody", b =>
                {
                    b.HasOne("Models.DataObjects.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Models.DataObjects.User", b =>
                {
                    b.HasOne("Models.DataObjects.User", null)
                        .WithMany("Following")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
