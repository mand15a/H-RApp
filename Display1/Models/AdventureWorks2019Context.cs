﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Display1.Models;

public partial class AdventureWorks2019Context : DbContext
{
    public AdventureWorks2019Context()
    {
    }

    public AdventureWorks2019Context(DbContextOptions<AdventureWorks2019Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Address { get; set; }

    public virtual DbSet<AddressType> AddressType { get; set; }

    public virtual DbSet<BusinessEntity> BusinessEntity { get; set; }

    public virtual DbSet<BusinessEntityAddress> BusinessEntityAddress { get; set; }

    public virtual DbSet<BusinessEntityContact> BusinessEntityContact { get; set; }

    public virtual DbSet<ContactType> ContactType { get; set; }

    public virtual DbSet<CountryRegion> CountryRegion { get; set; }

    public virtual DbSet<Department> Department { get; set; }

    public virtual DbSet<EmailAddress> EmailAddress { get; set; }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }

    public virtual DbSet<EmployeePayHistory> EmployeePayHistory { get; set; }

    public virtual DbSet<JobCandidate> JobCandidate { get; set; }

    public virtual DbSet<Password> Password { get; set; }

    public virtual DbSet<Person> Person { get; set; }

    public virtual DbSet<PersonPhone> PersonPhone { get; set; }

    public virtual DbSet<PhoneNumberType> PhoneNumberType { get; set; }

    public virtual DbSet<Shift> Shift { get; set; }

    public virtual DbSet<StateProvince> StateProvince { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=interns-server-tng.database.windows.net;Initial Catalog=AdventureWorks2019;User ID=Interns;Password=@Password");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Address_AddressID");

            entity.ToTable("Address", "Person", tb => tb.HasComment("Street address information for customers, employees, and vendors."));

            entity.HasIndex(e => e.Rowguid, "AK_Address_rowguid").IsUnique();

            entity.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvinceId, e.PostalCode }, "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode").IsUnique();

            entity.HasIndex(e => e.StateProvinceId, "IX_Address_StateProvinceID");

            entity.Property(e => e.AddressId)
                .HasComment("Primary key for Address records.")
                .HasColumnName("AddressID");
            entity.Property(e => e.AddressLine1)
                .IsRequired()
                .HasMaxLength(60)
                .HasComment("First street address line.");
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(60)
                .HasComment("Second street address line.");
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(30)
                .HasComment("Name of the city.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(15)
                .HasComment("Postal code for the street address.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");
            entity.Property(e => e.StateProvinceId)
                .HasComment("Unique identification number for the state or province. Foreign key to StateProvince table.")
                .HasColumnName("StateProvinceID");

            entity.HasOne(d => d.StateProvince).WithMany(p => p.Address)
                .HasForeignKey(d => d.StateProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.HasKey(e => e.AddressTypeId).HasName("PK_AddressType_AddressTypeID");

            entity.ToTable("AddressType", "Person", tb => tb.HasComment("Types of addresses stored in the Address table. "));

            entity.HasIndex(e => e.Name, "AK_AddressType_Name").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_AddressType_rowguid").IsUnique();

            entity.Property(e => e.AddressTypeId)
                .HasComment("Primary key for AddressType records.")
                .HasColumnName("AddressTypeID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Address type description. For example, Billing, Home, or Shipping.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<BusinessEntity>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_BusinessEntity_BusinessEntityID");

            entity.ToTable("BusinessEntity", "Person", tb => tb.HasComment("Source of the ID that connects vendors, customers, and employees with address and contact information."));

            entity.HasIndex(e => e.Rowguid, "AK_BusinessEntity_rowguid").IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key for all customers, vendors, and employees.")
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<BusinessEntityAddress>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.AddressId, e.AddressTypeId }).HasName("PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID");

            entity.ToTable("BusinessEntityAddress", "Person", tb => tb.HasComment("Cross-reference table mapping customers, vendors, and employees to their addresses."));

            entity.HasIndex(e => e.Rowguid, "AK_BusinessEntityAddress_rowguid").IsUnique();

            entity.HasIndex(e => e.AddressId, "IX_BusinessEntityAddress_AddressID");

            entity.HasIndex(e => e.AddressTypeId, "IX_BusinessEntityAddress_AddressTypeID");

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.")
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.AddressId)
                .HasComment("Primary key. Foreign key to Address.AddressID.")
                .HasColumnName("AddressID");
            entity.Property(e => e.AddressTypeId)
                .HasComment("Primary key. Foreign key to AddressType.AddressTypeID.")
                .HasColumnName("AddressTypeID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.Address).WithMany(p => p.BusinessEntityAddress)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AddressType).WithMany(p => p.BusinessEntityAddress)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.BusinessEntityAddress)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<BusinessEntityContact>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.PersonId, e.ContactTypeId }).HasName("PK_BusinessEntityContact_BusinessEntityID_PersonID_ContactTypeID");

            entity.ToTable("BusinessEntityContact", "Person", tb => tb.HasComment("Cross-reference table mapping stores, vendors, and employees to people"));

            entity.HasIndex(e => e.Rowguid, "AK_BusinessEntityContact_rowguid").IsUnique();

            entity.HasIndex(e => e.ContactTypeId, "IX_BusinessEntityContact_ContactTypeID");

            entity.HasIndex(e => e.PersonId, "IX_BusinessEntityContact_PersonID");

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.")
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.PersonId)
                .HasComment("Primary key. Foreign key to Person.BusinessEntityID.")
                .HasColumnName("PersonID");
            entity.Property(e => e.ContactTypeId)
                .HasComment("Primary key.  Foreign key to ContactType.ContactTypeID.")
                .HasColumnName("ContactTypeID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.BusinessEntityContact)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ContactType).WithMany(p => p.BusinessEntityContact)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Person).WithMany(p => p.BusinessEntityContact)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.HasKey(e => e.ContactTypeId).HasName("PK_ContactType_ContactTypeID");

            entity.ToTable("ContactType", "Person", tb => tb.HasComment("Lookup table containing the types of business entity contacts."));

            entity.HasIndex(e => e.Name, "AK_ContactType_Name").IsUnique();

            entity.Property(e => e.ContactTypeId)
                .HasComment("Primary key for ContactType records.")
                .HasColumnName("ContactTypeID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Contact type description.");
        });

        modelBuilder.Entity<CountryRegion>(entity =>
        {
            entity.HasKey(e => e.CountryRegionCode).HasName("PK_CountryRegion_CountryRegionCode");

            entity.ToTable("CountryRegion", "Person", tb => tb.HasComment("Lookup table containing the ISO standard codes for countries and regions."));

            entity.HasIndex(e => e.Name, "AK_CountryRegion_Name").IsUnique();

            entity.Property(e => e.CountryRegionCode)
                .HasMaxLength(3)
                .HasComment("ISO standard code for countries and regions.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Country or region name.");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_Department_DepartmentID");

            entity.ToTable("Department", "HumanResources", tb => tb.HasComment("Lookup table containing the departments within the Adventure Works Cycles company."));

            entity.HasIndex(e => e.Name, "AK_Department_Name").IsUnique();

            entity.Property(e => e.DepartmentId)
                .HasComment("Primary key for Department records.")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.GroupName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Name of the group to which the department belongs.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Name of the department.");
        });

        modelBuilder.Entity<EmailAddress>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.EmailAddressId }).HasName("PK_EmailAddress_BusinessEntityID_EmailAddressID");

            entity.ToTable("EmailAddress", "Person", tb => tb.HasComment("Where to send a person email."));

            entity.HasIndex(e => e.EmailAddress1, "IX_EmailAddress_EmailAddress");

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key. Person associated with this email address.  Foreign key to Person.BusinessEntityID")
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.EmailAddressId)
                .ValueGeneratedOnAdd()
                .HasComment("Primary key. ID of this email address.")
                .HasColumnName("EmailAddressID");
            entity.Property(e => e.EmailAddress1)
                .HasMaxLength(50)
                .HasComment("E-mail address for the person.")
                .HasColumnName("EmailAddress");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.EmailAddress)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Employee_BusinessEntityID");

            entity.ToTable("Employee", "HumanResources", tb =>
                {
                    tb.HasComment("Employee information such as salary, department, and title.");
                    tb.HasTrigger("dEmployee");
                });

            entity.HasIndex(e => e.LoginId, "AK_Employee_LoginID").IsUnique();

            entity.HasIndex(e => e.NationalIdnumber, "AK_Employee_NationalIDNumber").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_Employee_rowguid").IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasComment("Primary key for Employee records.  Foreign key to BusinessEntity.BusinessEntityID.")
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.BirthDate)
                .HasComment("Date of birth.")
                .HasColumnType("date");
            entity.Property(e => e.CurrentFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Inactive, 1 = Active");
            entity.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("M = Male, F = Female");
            entity.Property(e => e.HireDate)
                .HasComment("Employee hired on this date.")
                .HasColumnType("date");
            entity.Property(e => e.JobTitle)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Work title such as Buyer or Sales Representative.");
            entity.Property(e => e.LoginId)
                .IsRequired()
                .HasMaxLength(256)
                .HasComment("Network login.")
                .HasColumnName("LoginID");
            entity.Property(e => e.MaritalStatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("M = Married, S = Single");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.NationalIdnumber)
                .IsRequired()
                .HasMaxLength(15)
                .HasComment("Unique national identification number such as a social security number.")
                .HasColumnName("NationalIDNumber");
            entity.Property(e => e.OrganizationLevel)
                .HasComputedColumnSql("([OrganizationNode].[GetLevel]())", false)
                .HasComment("The depth of the employee in the corporate hierarchy.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalariedFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.");
            entity.Property(e => e.SickLeaveHours).HasComment("Number of available sick leave hours.");
            entity.Property(e => e.VacationHours).HasComment("Number of available vacation hours.");

            entity.HasOne(e => e.BusinessEntity).WithOne(e => e.Employee)
                .HasForeignKey<Employee>(d => d.BusinessEntityId);

            entity.HasOne(d => d.Person).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmployeeDepartmentHistory>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.StartDate, e.DepartmentId, e.ShiftId }).HasName("PK_EmployeeDepartmentHistory_BusinessEntityID_StartDate_DepartmentID");

            entity.ToTable("EmployeeDepartmentHistory", "HumanResources", tb => tb.HasComment("Employee department transfers."));

            entity.HasIndex(e => e.DepartmentId, "IX_EmployeeDepartmentHistory_DepartmentID");

            entity.HasIndex(e => e.ShiftId, "IX_EmployeeDepartmentHistory_ShiftID");

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Employee identification number. Foreign key to Employee.BusinessEntityID.")
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.StartDate)
                .HasComment("Date the employee started work in the department.")
                .HasColumnType("date");
            entity.Property(e => e.DepartmentId)
                .HasComment("Department in which the employee worked including currently. Foreign key to Department.DepartmentID.")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.ShiftId)
                .HasComment("Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.")
                .HasColumnName("ShiftID");
            entity.Property(e => e.EndDate)
                .HasComment("Date the employee left the department. NULL = Current department.")
                .HasColumnType("date");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.EmployeeDepartmentHistory)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeeDepartmentHistory)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Shift).WithMany(p => p.EmployeeDepartmentHistory)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmployeePayHistory>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.RateChangeDate }).HasName("PK_EmployeePayHistory_BusinessEntityID_RateChangeDate");

            entity.ToTable("EmployeePayHistory", "HumanResources", tb => tb.HasComment("Employee pay history."));

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Employee identification number. Foreign key to Employee.BusinessEntityID.")
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.RateChangeDate)
                .HasComment("Date the change in pay is effective")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.PayFrequency).HasComment("1 = Salary received monthly, 2 = Salary received biweekly");
            entity.Property(e => e.Rate)
                .HasComment("Salary hourly rate.")
                .HasColumnType("money");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.EmployeePayHistory)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<JobCandidate>(entity =>
        {
            entity.HasKey(e => e.JobCandidateId).HasName("PK_JobCandidate_JobCandidateID");

            entity.ToTable("JobCandidate", "HumanResources", tb => tb.HasComment("Résumés submitted to Human Resources by job applicants."));

            entity.HasIndex(e => e.BusinessEntityId, "IX_JobCandidate_BusinessEntityID");

            entity.Property(e => e.JobCandidateId)
                .HasComment("Primary key for JobCandidate records.")
                .HasColumnName("JobCandidateID");
            entity.Property(e => e.BusinessEntityId)
                .HasComment("Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID.")
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Resume)
                .HasComment("Résumé in XML format.")
                .HasColumnType("xml");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.JobCandidate).HasForeignKey(d => d.BusinessEntityId);
        });

        modelBuilder.Entity<Password>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Password_BusinessEntityID");

            entity.ToTable("Password", "Person", tb => tb.HasComment("One way hashed authentication information"));

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Password for the e-mail account.");
            entity.Property(e => e.PasswordSalt)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Random value concatenated with the password string before the password is hashed.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.BusinessEntity).WithOne(p => p.Password)
                .HasForeignKey<Password>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Person_BusinessEntityID");

            entity.ToTable("Person", "Person", tb =>
                {
                    tb.HasComment("Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.");
                    tb.HasTrigger("iuPerson");
                });

            entity.HasIndex(e => e.Rowguid, "AK_Person_rowguid").IsUnique();

            entity.HasIndex(e => new { e.LastName, e.FirstName, e.MiddleName }, "IX_Person_LastName_FirstName_MiddleName");

            entity.HasIndex(e => e.AdditionalContactInfo, "PXML_Person_AddContact");

            entity.HasIndex(e => e.Demographics, "PXML_Person_Demographics");

            entity.HasIndex(e => e.Demographics, "XMLPATH_Person_Demographics");

            entity.HasIndex(e => e.Demographics, "XMLPROPERTY_Person_Demographics");

            entity.HasIndex(e => e.Demographics, "XMLVALUE_Person_Demographics");

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasComment("Primary key for Person records.")
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.AdditionalContactInfo)
                .HasComment("Additional contact information about the person stored in xml format. ")
                .HasColumnType("xml");
            entity.Property(e => e.Demographics)
                .HasComment("Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.")
                .HasColumnType("xml");
            entity.Property(e => e.EmailPromotion).HasComment("0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. ");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("First name of the person.");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Last name of the person.");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasComment("Middle name or middle initial of the person.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.NameStyle).HasComment("0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.");
            entity.Property(e => e.PersonType)
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength()
                .HasComment("Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");
            entity.Property(e => e.Suffix)
                .HasMaxLength(10)
                .HasComment("Surname suffix. For example, Sr. or Jr.");
            entity.Property(e => e.Title)
                .HasMaxLength(8)
                .HasComment("A courtesy title. For example, Mr. or Ms.");

            entity.HasOne(d => d.BusinessEntity).WithOne(p => p.Person)
                .HasForeignKey<Person>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PersonPhone>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.PhoneNumber, e.PhoneNumberTypeId }).HasName("PK_PersonPhone_BusinessEntityID_PhoneNumber_PhoneNumberTypeID");

            entity.ToTable("PersonPhone", "Person", tb => tb.HasComment("Telephone number and type of a person."));

            entity.HasIndex(e => e.PhoneNumber, "IX_PersonPhone_PhoneNumber");

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Business entity identification number. Foreign key to Person.BusinessEntityID.")
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .HasComment("Telephone number identification number.");
            entity.Property(e => e.PhoneNumberTypeId)
                .HasComment("Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.")
                .HasColumnName("PhoneNumberTypeID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.PersonPhone)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PhoneNumberType).WithMany(p => p.PersonPhone)
                .HasForeignKey(d => d.PhoneNumberTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PhoneNumberType>(entity =>
        {
            entity.HasKey(e => e.PhoneNumberTypeId).HasName("PK_PhoneNumberType_PhoneNumberTypeID");

            entity.ToTable("PhoneNumberType", "Person", tb => tb.HasComment("Type of phone number of a person."));

            entity.Property(e => e.PhoneNumberTypeId)
                .HasComment("Primary key for telephone number type records.")
                .HasColumnName("PhoneNumberTypeID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Name of the telephone number type");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK_Shift_ShiftID");

            entity.ToTable("Shift", "HumanResources", tb => tb.HasComment("Work shift lookup table."));

            entity.HasIndex(e => e.Name, "AK_Shift_Name").IsUnique();

            entity.HasIndex(e => new { e.StartTime, e.EndTime }, "AK_Shift_StartTime_EndTime").IsUnique();

            entity.Property(e => e.ShiftId)
                .ValueGeneratedOnAdd()
                .HasComment("Primary key for Shift records.")
                .HasColumnName("ShiftID");
            entity.Property(e => e.EndTime).HasComment("Shift end time.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Shift description.");
            entity.Property(e => e.StartTime).HasComment("Shift start time.");
        });

        modelBuilder.Entity<StateProvince>(entity =>
        {
            entity.HasKey(e => e.StateProvinceId).HasName("PK_StateProvince_StateProvinceID");

            entity.ToTable("StateProvince", "Person", tb => tb.HasComment("State and province lookup table."));

            entity.HasIndex(e => e.Name, "AK_StateProvince_Name").IsUnique();

            entity.HasIndex(e => new { e.StateProvinceCode, e.CountryRegionCode }, "AK_StateProvince_StateProvinceCode_CountryRegionCode").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_StateProvince_rowguid").IsUnique();

            entity.Property(e => e.StateProvinceId)
                .HasComment("Primary key for StateProvince records.")
                .HasColumnName("StateProvinceID");
            entity.Property(e => e.CountryRegionCode)
                .IsRequired()
                .HasMaxLength(3)
                .HasComment("ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. ");
            entity.Property(e => e.IsOnlyStateProvinceFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("0 = StateProvinceCode exists. 1 = StateProvinceCode unavailable, using CountryRegionCode.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("State or province description.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasColumnName("rowguid");
            entity.Property(e => e.StateProvinceCode)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("ISO standard state or province code.");
            entity.Property(e => e.TerritoryId)
                .HasComment("ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.")
                .HasColumnName("TerritoryID");

            entity.HasOne(d => d.CountryRegionCodeNavigation).WithMany(p => p.StateProvince)
                .HasForeignKey(d => d.CountryRegionCode)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}