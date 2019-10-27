using System;
using System.Collections.Generic;
using System.Linq;

namespace AptivTest.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person { Id = 1, Nickname = "清流" };
            var person2 = new Person { Id = 2, Nickname = "静流" };
            var person3 = new Person { Id = 3, Nickname = "空流" };

            var student1 = new Student { PersonId = 1, Name = "尹永贤", Age = 18, Sex = "男" };
            var student2 = new Student { PersonId = 2, Name = "静流", Age = 18, Sex = "女" };
            var student3 = new Student { PersonId = 3, Name = "空流", Age = 18, Sex = "男" };

            var personDetail1 = new PersonDetail() { PersonId = 2, Phone = "18888888888", Address = "上海" };

            var persons = new List<Person> { person1, person2, person3 };
            var students = new List<Student> { student1, student2, student3 };
            var personDetails = new List<PersonDetail> { personDetail1 };

            var query =
                    from person in persons
                    join student in students
                        on new { person.Id, Name = person.Nickname } equals new { Id = student.PersonId, student.Name } into ss
                    join personDetail in personDetails
                        on person.Id equals personDetail.PersonId into ps
                    from s in ss
                    from p in ps.DefaultIfEmpty()
                    select new
                    {
                        person.Id,
                        Name = person.Nickname,
                        s.Age,
                        s.Sex,
                        Phone = p == null ? "NULL" : p.Phone,
                        Address = p == null ? "NULL" : p.Address
                    };

            query.ToList().ForEach(item =>
            {
                var message = $"{item.Id}/{item.Name}/{item.Age}/{item.Sex}/{item.Phone}/{item.Address}";
                Console.WriteLine(message);
            });

            Console.ReadKey();
        }
    }
}
