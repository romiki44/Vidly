namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6e2a9985-e90b-4196-abf9-af5b41135047', N'admin@vidly.com', 0, N'ADu3Ja3x9sQhPJB7vmaP0A/4LpqDBpCDHylfEPMToCGgpAvs2v7N3B+WlRD8nlfv4w==', N'17975b01-543c-4078-81b0-18684af51012', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'71bea409-9228-4049-9b89-8984596a230f', N'guest@vidly.com', 0, N'AJKpaPThQjpYl8zAYR4f1NbJjG+X1x/MgfSyHNyiWYogYrAlEeHMQh2Jzob//f4NAA==', N'6e22b47e-1b2a-4390-9089-29858726cc41', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c56e392a-a959-4633-b6fe-48b3d7c22264', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6e2a9985-e90b-4196-abf9-af5b41135047', N'c56e392a-a959-4633-b6fe-48b3d7c22264')
");
        }
        
        public override void Down()
        {
        }
    }
}
