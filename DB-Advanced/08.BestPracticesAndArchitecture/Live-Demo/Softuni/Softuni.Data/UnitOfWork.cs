namespace Softuni.Data
{
    using Softuni.Data.Contracts;
    using Softuni.Data.Repositories;
    using Softuni.Models;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoftuniContext context = new SoftuniContext();

        private IRepository<Employee> employees;
        private IRepository<Address> addresses;
        private IRepository<Town> towns;
        private IRepository<Department> department;
        private IRepository<Project> projects;

        public IRepository<Employee> Employees
        {
            get { return employees ?? (this.employees = new Repository<Employee>(this.context.Set<Employee>())); }
        }

        public IRepository<Address> Addresses
        {
            get { return addresses ?? (this.addresses = new Repository<Address>(this.context.Set<Address>())); }
        }

        public IRepository<Town> Towns
        {
            get { return towns ?? (this.towns = new Repository<Town>(this.context.Set<Town>())); }
        }

        public IRepository<Department> Department
        {
            get { return department ?? (this.department = new Repository<Department>(this.context.Set<Department>())); }
        }

        public IRepository<Project> Projects
        {
            get { return projects ?? (this.projects = new Repository<Project>(this.context.Set<Project>())); }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
