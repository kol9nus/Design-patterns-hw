using Example_04.Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            DbUserEntity user = new DbUserEntity();
            user.Id = 1;
            user.Login = "Петрович";
            user.PasswordHash = "asdasdasd";
            user.UserInfoId = 2;
            DbUserInfoEntity userInfo = new DbUserInfoEntity();
            userInfo.Id = 2;
            userInfo.Name = "Петров Петр Петрович";
            userInfo.Birthday = new DateTime();

            Console.WriteLine("Первый адаптер");
            RunFirstAdapter(user, userInfo);
            Console.WriteLine();
            Console.WriteLine("Второй адаптер");
            RunSecondAdapter(user, userInfo);

            Console.Read();
        }

        static void RunFirstAdapter(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            FirstAdapter adapter = new FirstAdapter();

            adapter.Create(user, userInfo);
            adapter.Update(user, userInfo);
            adapter.Read(1);
            adapter.Delete(user, userInfo);
            adapter.Read(1);
        }

        static void RunSecondAdapter(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            SecondAdapter adapter = new SecondAdapter();

            adapter.Create(user, userInfo);
            adapter.Update(user, userInfo);
            adapter.Read(1);
            adapter.Delete(user, userInfo);
            adapter.Read(1);
        }
    }
}
