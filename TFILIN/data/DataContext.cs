using core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace data
{
    public class DataContext:DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<CreditStatus> CreditStatuses { get; set; }
        public DbSet<Dedication> Dedications { get; set; }
        public DbSet<DedicationKind> DedicationKinds { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<DonorsConversation> DonorsConversations { get; set; }
        public DbSet<StoreOwnerConversation> StoreOwnerConversations { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<MonthlyDonation> MonthlyDonations { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Stand> Stands { get; set; }
        public DbSet<StandItem> StandsItem { get; set; }
        public DbSet<StatusCall> StatusCalls { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreOwner> StoreOwners { get; set; }
        public DbSet<StoreStand> StoreStands { get; set; }
        public DbSet<TefilinStatus> TefilinStatuses { get; set; }
        public DbSet<ToDoVisit> ToDoStand { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Visit> Visits { get; set; }
        public DbSet<ToDo> Todo { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
