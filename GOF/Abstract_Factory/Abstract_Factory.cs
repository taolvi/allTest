using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 大话设计模式，就不能不换DB吗？
namespace GoF
{
    class Abstract_Factory
    {
        static void Main(string[] args)
        {
            User user = new User();
            Department dept = new Department();
            // IFactory factory = new AccessFactory();
            IFactory factory = new SqlServerFactry();

            IUser iu = factory.CreateUser();
            iu.Insert(user);
            iu.GetUser(1);

            IDepartment idept = factory.CreateDepartment();
            idept.Insert(dept);
            idept.GetDepartment(1);

            Console.Read();            
        }
    }

    /******************数据库中的Department******************/
    class Department
    { }

    // 用于访问数据库中的Department
    interface IDepartment
    {
        void Insert(Department department);
        Department GetDepartment(int id);
    }

    // 用于访问SQL中的Department
    class SqlServerDepartment : IDepartment
    {
        public void Insert(Department d)
        {
            Console.WriteLine("在SQLserver 中给Department表添加一条记录");
        }

        Department IDepartment.GetDepartment(int id)
        {
            Console.WriteLine("在SQLserver 中根据ID得到Department表的一条记录");
            return null;
        }
    }
    // 用于访问Access中的Department
    class AccessDepartment : IDepartment
    {
        public void Insert(Department d)
        {
            Console.WriteLine("在Access 中给Department表添加一条记录");
        }

        Department IDepartment.GetDepartment(int id)
        {
            Console.WriteLine("在Access 中根据ID得到Department表的一条记录");
            return null;
        }
    }
    /******************数据库中的Department end******************/

    /******************数据库中的 User ******************/
    class User
    { }

    // 用于访问数据库中的Department
    interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    }

    // 用于访问SQL中的Department
    class SqlServerUser : IUser
    {
        public void Insert(User u)
        {
            Console.WriteLine("在SQLserver 中给User表添加一条记录");
        }

        User IUser.GetUser(int id)
        {
            Console.WriteLine("在SQLserver 中根据ID得到User表的一条记录");
            return null;
        }
    }
    // 用于访问Access中的Department
    class AccessUser : IUser
    {
        public void Insert(User d)
        {
            Console.WriteLine("在Access 中给User表添加一条记录");
        }
        public User GetUser(int id)
        {
            Console.WriteLine("在Access 中根据ID得到User表的一条记录");
            return null;
        }
    }
    /******************数据库中的User end******************/

    interface IFactory
    {
        IDepartment CreateDepartment();
        IUser CreateUser();
    }

    class SqlServerFactry : IFactory
    {
        public IDepartment CreateDepartment()
        {
            return new SqlServerDepartment();
        }

        public IUser CreateUser()
        {
            return new SqlServerUser();
        }
    }

    class AccessFactory : IFactory
    {
        public IDepartment CreateDepartment()
        {
           return new AccessDepartment();
        }

        public IUser CreateUser()
        {
            return new AccessUser();
        }
    }
}
