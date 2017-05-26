using DataTransferObjects.Enumerations;
using DbEntities.Models;
using System;

namespace DbEntities.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DbEntities.IssueTrackerContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DbEntities.IssueTrackerContext context)
        {
            Role role = new Role()
            {
                Id = (int)UserRoleTypes.Regular,
                Name = Enum.GetName(typeof(UserRoleTypes), UserRoleTypes.Regular)
            };


            Role role2 = new Role()
            {
                Id = (int)UserRoleTypes.Administrator,
                Name = Enum.GetName(typeof(UserRoleTypes), UserRoleTypes.Administrator)
            };


            context.UserRoles.AddOrUpdate(role);
            context.UserRoles.AddOrUpdate(role2);

            Status status = new Status()
            {
                Id = (int)IssueStatusTypes.New,
                Name = Enum.GetName(typeof(IssueStatusTypes), IssueStatusTypes.New)
            };

            Status status2 = new Status()
            {
                Id = (int)IssueStatusTypes.Solved,
                Name = Enum.GetName(typeof(IssueStatusTypes), IssueStatusTypes.Solved)
            };

            context.IssueStatuses.AddOrUpdate(status);
            context.IssueStatuses.AddOrUpdate(status2);

            Priority priorityLow = new Priority()
            {
                Id = (int)IssuePriorityTypes.Low,
                Name = Enum.GetName(typeof(IssuePriorityTypes), IssuePriorityTypes.Low)
            };

            Priority priorityMedium = new Priority()
            {
                Id = (int)IssuePriorityTypes.Medium,
                Name = Enum.GetName(typeof(IssuePriorityTypes), IssuePriorityTypes.Medium)
            };

            Priority priorityHigh = new Priority()
            {
                Id = (int)IssuePriorityTypes.High,
                Name = Enum.GetName(typeof(IssuePriorityTypes), IssuePriorityTypes.High)
            };

            context.IssuePriorities.AddOrUpdate(priorityLow);
            context.IssuePriorities.AddOrUpdate(priorityMedium);
            context.IssuePriorities.AddOrUpdate(priorityHigh);

            context.SaveChanges();
        }
    }
}
