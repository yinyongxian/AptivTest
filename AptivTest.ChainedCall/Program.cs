using System;

namespace AptivTest.ChainedCall
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User {Name = "清流", Age = 18};
            var project = new Project() {Name = "静流", Age = 19};

            var userExpressionMenber = new ExpressionMenber<User>(user);
            var projectExpressionMenber = new ExpressionMenber<Project>(project);

            userExpressionMenber
                .Print(item => item.Name)
                .Print(item => item.Age);


            projectExpressionMenber
                .Print(item => item.Name)
                .Print(item => item.Age);

            Console.ReadKey();
        }
    }
}
