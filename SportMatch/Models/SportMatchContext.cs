﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SportMatch.Models;

public partial class SportMatchContext : DbContext
{
    public SportMatchContext()
    {
    }

    public SportMatchContext(DbContextOptions<SportMatchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Apply> Applies { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventGroup> EventGroups { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<JoinInformation> JoinInformations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Pay> Pays { get; set; }

    public virtual DbSet<ProducCategory> ProducCategories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategoryMapping> ProductCategoryMappings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    public virtual DbSet<SportsVenue> SportsVenues { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamMemberMapping> TeamMemberMappings { get; set; }

    public virtual DbSet<UserDatum> UserData { get; set; }

    public virtual DbSet<VenueImage> VenueImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-MAST92V2\\SQLEXPRESS;Database=SportMatch;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apply>(entity =>
        {
            entity.HasKey(e => e.ApplyId).HasName("PK__Apply__F0687F9145A23FA4");

            entity.ToTable("Apply");

            entity.HasIndex(e => e.ApplyId, "UQ__Apply__F0687F90CB899C1F").IsUnique();

            entity.Property(e => e.ApplyId).HasColumnName("ApplyID");
            entity.Property(e => e.Memo).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(4);
            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Team).WithMany(p => p.Applies)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Apply__TeamID__160F4887");

            entity.HasOne(d => d.User).WithMany(p => p.Applies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Apply__UserID__151B244E");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Area__70B8202846684C5B");

            entity.ToTable("Area");

            entity.HasIndex(e => e.AreaId, "UQ__Area__70B82029B6789D99").IsUnique();

            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.AreaName).HasMaxLength(2);
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__ContactU__C87C037C9C0D05E3");

            entity.HasIndex(e => e.MessageId, "UQ__ContactU__C87C037D66C16B84").IsUnique();

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.CreatedTime).HasColumnName("Created_time");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.ReplyBy).HasMaxLength(50);
            entity.Property(e => e.ReplyTime).HasColumnName("Reply_time");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__7944C87051D762BA");

            entity.ToTable("Event");

            entity.HasIndex(e => e.EventId, "UQ__Event__7944C871BD6D0269").IsUnique();

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.EventGroupId).HasColumnName("EventGroupID");
            entity.Property(e => e.EventLocation).HasMaxLength(50);
            entity.Property(e => e.EventName).HasMaxLength(50);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.SportId).HasColumnName("SportID");

            entity.HasOne(d => d.Area).WithMany(p => p.Events)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__AreaID__08B54D69");

            entity.HasOne(d => d.EventGroup).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__EventGrou__06CD04F7");

            entity.HasOne(d => d.Gender).WithMany(p => p.Events)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__GenderID__03F0984C");

            entity.HasOne(d => d.Sport).WithMany(p => p.Events)
                .HasForeignKey(d => d.SportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__SportID__07C12930");
        });

        modelBuilder.Entity<EventGroup>(entity =>
        {
            entity.HasKey(e => e.EventGroupId).HasName("PK__EventGro__59A1D1922B62461C");

            entity.ToTable("EventGroup");

            entity.HasIndex(e => e.EventGroupId, "UQ__EventGro__59A1D1939E370DED").IsUnique();

            entity.Property(e => e.EventGroupId).HasColumnName("EventGroupID");
            entity.Property(e => e.EventGroupName).HasMaxLength(5);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__Gender__4E24E8170EC50C43");

            entity.ToTable("Gender");

            entity.HasIndex(e => e.GenderId, "UQ__Gender__4E24E8169A065461").IsUnique();

            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GenderType).HasMaxLength(3);
        });

        modelBuilder.Entity<JoinInformation>(entity =>
        {
            entity.HasKey(e => e.JoinId).HasName("PK__JoinInfo__AD6AA8BA15F13A25");

            entity.ToTable("JoinInformation");

            entity.HasIndex(e => e.JoinId, "UQ__JoinInfo__AD6AA8BB87DB6EF4").IsUnique();

            entity.Property(e => e.JoinId).HasColumnName("JoinID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.PayStatus).HasMaxLength(2);
            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Event).WithMany(p => p.JoinInformations)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JoinInfor__Event__02FC7413");

            entity.HasOne(d => d.Team).WithMany(p => p.JoinInformations)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JoinInfor__TeamI__05D8E0BE");

            entity.HasOne(d => d.User).WithMany(p => p.JoinInformations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JoinInfor__UserI__04E4BC85");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAF1415A87A");

            entity.ToTable("Order");

            entity.HasIndex(e => e.OrderId, "UQ__Order__C3905BAEA86B660D").IsUnique();

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderNumber).HasMaxLength(30);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__ProductID__1AD3FDA4");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__UserID__1BC821DD");
        });

        modelBuilder.Entity<Pay>(entity =>
        {
            entity.HasKey(e => e.PayStatusId).HasName("PK__Pay__8D8918BBB4384377");

            entity.ToTable("Pay");

            entity.HasIndex(e => e.PayStatusId, "UQ__Pay__8D8918BACF80277A").IsUnique();

            entity.Property(e => e.PayStatusId).HasColumnName("PayStatusID");
            entity.Property(e => e.PayStatus).HasMaxLength(2);
            entity.Property(e => e.PayStatusNumber).HasMaxLength(30);
            entity.Property(e => e.TeamId).HasColumnName("TeamID");

            entity.HasOne(d => d.Team).WithMany(p => p.Pays)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pay__TeamID__09A971A2");
        });

        modelBuilder.Entity<ProducCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__ProducCa__19093A2BD7F52F5A");

            entity.HasIndex(e => e.CategoryId, "UQ__ProducCa__19093A2ABA56121D").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.SubCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDAE257D5F");

            entity.HasIndex(e => e.ProductId, "UQ__Products__B40CC6ECFB6134EB").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ParentProductId).HasColumnName("ParentProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductDetails).HasColumnType("text");
            entity.Property(e => e.ProductName).HasMaxLength(255);
        });

        modelBuilder.Entity<ProductCategoryMapping>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.CategoryId }).HasName("PK__ProductC__159C554FEB437D77");

            entity.ToTable("ProductCategoryMapping");

            entity.HasIndex(e => e.ProductId, "UQ__ProductC__B40CC6EC95FBA66B").IsUnique();

            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductCategoryMappings)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductCa__Categ__19DFD96B");

            entity.HasOne(d => d.Product).WithOne(p => p.ProductCategoryMapping)
                .HasForeignKey<ProductCategoryMapping>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductCa__Produ__18EBB532");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A9F1C06F9");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleId, "UQ__Role__8AFACE3BE972BAE4").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(10);
            entity.Property(e => e.SportId).HasColumnName("SportID");

            entity.HasOne(d => d.Sport).WithMany(p => p.Roles)
                .HasForeignKey(d => d.SportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Role__SportID__10566F31");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.SportId).HasName("PK__Sport__7A41AF1CE8790A07");

            entity.ToTable("Sport");

            entity.HasIndex(e => e.SportId, "UQ__Sport__7A41AF1DB1D7A05C").IsUnique();

            entity.Property(e => e.SportId).HasColumnName("SportID");
            entity.Property(e => e.SportName).HasMaxLength(40);
        });

        modelBuilder.Entity<SportsVenue>(entity =>
        {
            entity.HasKey(e => e.VenueId).HasName("PK__SportsVe__3C57E5D2DD740FC9");

            entity.HasIndex(e => e.VenueId, "UQ__SportsVe__3C57E5D38E214F40").IsUnique();

            entity.Property(e => e.VenueId).HasColumnName("VenueID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.ContactLineId)
                .HasMaxLength(255)
                .HasColumnName("ContactLineID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Facilities).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.SportId).HasColumnName("SportID");
            entity.Property(e => e.VenueName).HasMaxLength(100);

            entity.HasOne(d => d.Sport).WithMany(p => p.SportsVenues)
                .HasForeignKey(d => d.SportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SportsVen__Sport__17036CC0");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Team__123AE7B97D78959D");

            entity.ToTable("Team");

            entity.HasIndex(e => e.TeamId, "UQ__Team__123AE7B810BE2327").IsUnique();

            entity.HasIndex(e => e.TeamName, "UQ__Team__4E21CAAC80058341").IsUnique();

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.SportId).HasColumnName("SportID");
            entity.Property(e => e.TeamMemo).HasMaxLength(100);
            entity.Property(e => e.TeamName).HasMaxLength(20);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Area).WithMany(p => p.Teams)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__Team__AreaID__0E6E26BF");

            entity.HasOne(d => d.Event).WithMany(p => p.Teams)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Team__EventID__0F624AF8");

            entity.HasOne(d => d.Gender).WithMany(p => p.Teams)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Team__GenderID__0D7A0286");

            entity.HasOne(d => d.Role).WithMany(p => p.Teams)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Team__RoleID__0C85DE4D");

            entity.HasOne(d => d.Sport).WithMany(p => p.Teams)
                .HasForeignKey(d => d.SportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Team__SportID__0A9D95DB");

            entity.HasOne(d => d.User).WithMany(p => p.Teams)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Team__UserID__0B91BA14");
        });

        modelBuilder.Entity<TeamMemberMapping>(entity =>
        {
            entity.HasKey(e => e.MappingId).HasName("PK__TeamMemb__8B5781BD52E44284");

            entity.ToTable("TeamMemberMapping");

            entity.HasIndex(e => e.MappingId, "UQ__TeamMemb__8B5781BC1428BB7A").IsUnique();

            entity.Property(e => e.MappingId).HasColumnName("MappingID");
            entity.Property(e => e.SportId).HasColumnName("SportID");
            entity.Property(e => e.TeamIdLeader).HasColumnName("TeamID_Leader");
            entity.Property(e => e.TeamIdMember).HasColumnName("TeamID_Member");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Sport).WithMany(p => p.TeamMemberMappings)
                .HasForeignKey(d => d.SportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeamMembe__Sport__123EB7A3");

            entity.HasOne(d => d.TeamIdLeaderNavigation).WithMany(p => p.TeamMemberMappingTeamIdLeaderNavigations)
                .HasForeignKey(d => d.TeamIdLeader)
                .HasConstraintName("FK__TeamMembe__TeamI__1332DBDC");

            entity.HasOne(d => d.TeamIdMemberNavigation).WithMany(p => p.TeamMemberMappingTeamIdMemberNavigations)
                .HasForeignKey(d => d.TeamIdMember)
                .HasConstraintName("FK__TeamMembe__TeamI__14270015");

            entity.HasOne(d => d.User).WithMany(p => p.TeamMemberMappings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeamMembe__UserI__114A936A");
        });

        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserData__1788CCACB59655EF");

            entity.HasIndex(e => e.UserId, "UQ__UserData__1788CCAD6A43C6F3").IsUnique();

            entity.HasIndex(e => e.Mobile, "UQ__UserData__6FAE07825AF86FFC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__UserData__A9D10534DB08F3A6").IsUnique();

            entity.HasIndex(e => e.Account, "UQ__UserData__B0C3AC46BCE3FEAA").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID ");
            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.Invited)
                .HasMaxLength(2)
                .HasDefaultValue("Y")
                .HasColumnName("invited");
            entity.Property(e => e.Mobile).HasMaxLength(15);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.SportId).HasColumnName("SportID");
            entity.Property(e => e.UserMemo).HasMaxLength(255);

            entity.HasOne(d => d.Area).WithMany(p => p.UserData)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__UserData__AreaID__1EA48E88");

            entity.HasOne(d => d.Role).WithMany(p => p.UserData)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserData__RoleID__1DB06A4F");

            entity.HasOne(d => d.Sport).WithMany(p => p.UserData)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("FK__UserData__SportI__1CBC4616");
        });

        modelBuilder.Entity<VenueImage>(entity =>
        {
            entity.HasKey(e => e.PicId).HasName("PK__VenueIma__B04A93E1DE0219B9");

            entity.HasIndex(e => e.PicId, "UQ__VenueIma__B04A93E07B3641DB").IsUnique();

            entity.Property(e => e.PicId).HasColumnName("PicID");
            entity.Property(e => e.VenueId).HasColumnName("VenueID");

            entity.HasOne(d => d.Venue).WithMany(p => p.VenueImages)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VenueImag__Venue__17F790F9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
