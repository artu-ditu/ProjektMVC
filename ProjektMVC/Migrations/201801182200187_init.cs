namespace ProjektMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookFiles",
                c => new
                    {
                        bookFileID = c.Int(nullable: false, identity: true),
                        bookID = c.Int(nullable: false),
                        fileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bookFileID)
                .ForeignKey("dbo.Books", t => t.bookID, cascadeDelete: true)
                .ForeignKey("dbo.Files", t => t.fileID, cascadeDelete: true)
                .Index(t => t.bookID)
                .Index(t => t.fileID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        bookID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        author = c.String(),
                        iSBN = c.String(),
                        releaseDate = c.DateTime(nullable: false),
                        addDate = c.DateTime(nullable: false),
                        description = c.String(),
                        contents = c.String(),
                        categoryID = c.Int(nullable: false),
                        stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bookID)
                .ForeignKey("dbo.Categories", t => t.categoryID, cascadeDelete: true)
                .Index(t => t.categoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.categoryID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        fileID = c.Int(nullable: false, identity: true),
                        filename = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.fileID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        tagID = c.Int(nullable: false, identity: true),
                        value = c.String(),
                    })
                .PrimaryKey(t => t.tagID);
            
            CreateTable(
                "dbo.BookTags",
                c => new
                    {
                        bookTagID = c.Int(nullable: false, identity: true),
                        bookID = c.Int(nullable: false),
                        tagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bookTagID)
                .ForeignKey("dbo.Books", t => t.bookID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.tagID, cascadeDelete: true)
                .Index(t => t.bookID)
                .Index(t => t.tagID);
            
            CreateTable(
                "dbo.Borrows",
                c => new
                    {
                        borrowID = c.Int(nullable: false, identity: true),
                        borrowState = c.String(),
                        readerID = c.Int(nullable: false),
                        bookID = c.Int(nullable: false),
                        borrowDate = c.DateTime(nullable: false),
                        maxReturnDate = c.DateTime(nullable: false),
                        actualReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.borrowID)
                .ForeignKey("dbo.Books", t => t.bookID, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.readerID, cascadeDelete: true)
                .Index(t => t.readerID)
                .Index(t => t.bookID);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        readerID = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        password = c.String(),
                        email = c.String(),
                        name = c.String(),
                        surname = c.String(),
                        birthDate = c.DateTime(nullable: false),
                        address = c.String(),
                        borrowed = c.Int(nullable: false),
                        isBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.readerID);
            
            CreateTable(
                "dbo.CategoryParents",
                c => new
                    {
                        categoryParentID = c.Int(nullable: false, identity: true),
                        parentID = c.Int(nullable: false),
                        childID = c.Int(nullable: false),
                        Child_categoryID = c.Int(),
                        Parent_categoryID = c.Int(),
                    })
                .PrimaryKey(t => t.categoryParentID)
                .ForeignKey("dbo.Categories", t => t.Child_categoryID)
                .ForeignKey("dbo.Categories", t => t.Parent_categoryID)
                .Index(t => t.Child_categoryID)
                .Index(t => t.Parent_categoryID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        messageID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        content = c.String(),
                        addDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.messageID);
            
            CreateTable(
                "dbo.Penalties",
                c => new
                    {
                        penaltyID = c.Int(nullable: false, identity: true),
                        readerID = c.Int(nullable: false),
                        bookID = c.Int(nullable: false),
                        fine = c.Double(nullable: false),
                        isPayed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.penaltyID)
                .ForeignKey("dbo.Books", t => t.bookID, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.readerID, cascadeDelete: true)
                .Index(t => t.readerID)
                .Index(t => t.bookID);
            
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        queueID = c.Int(nullable: false, identity: true),
                        bookID = c.Int(nullable: false),
                        readerID = c.Int(nullable: false),
                        addDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.queueID)
                .ForeignKey("dbo.Books", t => t.bookID, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.readerID, cascadeDelete: true)
                .Index(t => t.bookID)
                .Index(t => t.readerID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Searches",
                c => new
                    {
                        searchID = c.Int(nullable: false, identity: true),
                        readerID = c.Int(nullable: false),
                        searchString = c.String(),
                    })
                .PrimaryKey(t => t.searchID)
                .ForeignKey("dbo.Readers", t => t.readerID, cascadeDelete: true)
                .Index(t => t.readerID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        workerID = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        password = c.String(),
                        email = c.String(),
                        name = c.String(),
                        surname = c.String(),
                        birthDate = c.DateTime(nullable: false),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.workerID);
            
            CreateTable(
                "dbo.FileBooks",
                c => new
                    {
                        File_fileID = c.Int(nullable: false),
                        Book_bookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.File_fileID, t.Book_bookID })
                .ForeignKey("dbo.Files", t => t.File_fileID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_bookID, cascadeDelete: true)
                .Index(t => t.File_fileID)
                .Index(t => t.Book_bookID);
            
            CreateTable(
                "dbo.TagBooks",
                c => new
                    {
                        Tag_tagID = c.Int(nullable: false),
                        Book_bookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_tagID, t.Book_bookID })
                .ForeignKey("dbo.Tags", t => t.Tag_tagID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_bookID, cascadeDelete: true)
                .Index(t => t.Tag_tagID)
                .Index(t => t.Book_bookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Searches", "readerID", "dbo.Readers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Queues", "readerID", "dbo.Readers");
            DropForeignKey("dbo.Queues", "bookID", "dbo.Books");
            DropForeignKey("dbo.Penalties", "readerID", "dbo.Readers");
            DropForeignKey("dbo.Penalties", "bookID", "dbo.Books");
            DropForeignKey("dbo.CategoryParents", "Parent_categoryID", "dbo.Categories");
            DropForeignKey("dbo.CategoryParents", "Child_categoryID", "dbo.Categories");
            DropForeignKey("dbo.Borrows", "readerID", "dbo.Readers");
            DropForeignKey("dbo.Borrows", "bookID", "dbo.Books");
            DropForeignKey("dbo.BookTags", "tagID", "dbo.Tags");
            DropForeignKey("dbo.BookTags", "bookID", "dbo.Books");
            DropForeignKey("dbo.BookFiles", "fileID", "dbo.Files");
            DropForeignKey("dbo.BookFiles", "bookID", "dbo.Books");
            DropForeignKey("dbo.TagBooks", "Book_bookID", "dbo.Books");
            DropForeignKey("dbo.TagBooks", "Tag_tagID", "dbo.Tags");
            DropForeignKey("dbo.FileBooks", "Book_bookID", "dbo.Books");
            DropForeignKey("dbo.FileBooks", "File_fileID", "dbo.Files");
            DropForeignKey("dbo.Books", "categoryID", "dbo.Categories");
            DropIndex("dbo.TagBooks", new[] { "Book_bookID" });
            DropIndex("dbo.TagBooks", new[] { "Tag_tagID" });
            DropIndex("dbo.FileBooks", new[] { "Book_bookID" });
            DropIndex("dbo.FileBooks", new[] { "File_fileID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Searches", new[] { "readerID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Queues", new[] { "readerID" });
            DropIndex("dbo.Queues", new[] { "bookID" });
            DropIndex("dbo.Penalties", new[] { "bookID" });
            DropIndex("dbo.Penalties", new[] { "readerID" });
            DropIndex("dbo.CategoryParents", new[] { "Parent_categoryID" });
            DropIndex("dbo.CategoryParents", new[] { "Child_categoryID" });
            DropIndex("dbo.Borrows", new[] { "bookID" });
            DropIndex("dbo.Borrows", new[] { "readerID" });
            DropIndex("dbo.BookTags", new[] { "tagID" });
            DropIndex("dbo.BookTags", new[] { "bookID" });
            DropIndex("dbo.Books", new[] { "categoryID" });
            DropIndex("dbo.BookFiles", new[] { "fileID" });
            DropIndex("dbo.BookFiles", new[] { "bookID" });
            DropTable("dbo.TagBooks");
            DropTable("dbo.FileBooks");
            DropTable("dbo.Workers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Searches");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Queues");
            DropTable("dbo.Penalties");
            DropTable("dbo.Messages");
            DropTable("dbo.CategoryParents");
            DropTable("dbo.Readers");
            DropTable("dbo.Borrows");
            DropTable("dbo.BookTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Files");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.BookFiles");
        }
    }
}
