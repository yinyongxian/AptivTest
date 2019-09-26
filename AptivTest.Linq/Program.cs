using System;
using System.Collections.Generic;
using System.Linq;

namespace AptivTest.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var school1 = new School { ProvinceId = 1, Province = "上海", SchoolName = "复旦大学" };
            var school2 = new School { ProvinceId = 2, Province = "河南", SchoolName = "河南大学" };
            var school3 = new School { ProvinceId = 3, Province = "北京", SchoolName = "北京大学" };

            var department1 = new Department { ProvinceId = 1, Province = "上海", DepartmentName = "医学系" };
            var department2 = new Department { ProvinceId = 2, Province = "河南", DepartmentName = "计算机系" };
            var department3 = new Department { ProvinceId = 3, Province = "北京", DepartmentName = "化学系" };

            var student1 = new Student { ProvinceId = 1, Province = "上海", Name = "清流" };
            var student2 = new Student { ProvinceId = 2, Province = "河南", Name = "静流" };
            var student6 = new Student { ProvinceId = 6, Province = "云南", Name = "空流" };

            var schools = new List<School> { school1, school2, school3 };
            var departments = new List<Department> { department1, department2, department3 };
            var students = new List<Student> { student1, student2, student6 };

            //var query =
            //    from school in schools
            //    from department in departments
            //    from student in students
            //    where school.ProvinceId == department.ProvinceId
            //    where school.Province == department.Province
            //    where school.ProvinceId == student.ProvinceId
            //    select new StudentDetail
            //    {
            //        ProvinceId = school.ProvinceId,
            //        Province = student.Province,
            //        SchoolName = school.SchoolName,
            //        DepartmentName = department.DepartmentName,
            //        Name = student.Name
            //    };

            var query =
                from school in schools
                join department in departments
                    on new { school.ProvinceId, school.Province } equals new { department.ProvinceId, department.Province } into ds
                join student in students
                    on school.ProvinceId equals student.ProvinceId into ss
                from d in ds.DefaultIfEmpty()
                from s in ss.DefaultIfEmpty()
                select new StudentDetail
                {
                    ProvinceId = school.ProvinceId,
                    Province = school.Province,
                    SchoolName = school.SchoolName,
                    DepartmentName = d.DepartmentName,
                    Name = s == null ? "null" : s.Name
                };

            query.ToList().ForEach(item =>
            {
                var message = $"{item.ProvinceId}/{item.Province}/{item.SchoolName}/{item.DepartmentName}/{item.Name}";
                Console.WriteLine(message);
            });

            Console.ReadKey();
        }
    }
}
