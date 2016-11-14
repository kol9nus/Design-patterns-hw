using Homework4.SecondOrmLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example_04.Homework.Models;

namespace Homework4
{
    class SecondAdapter : SecondOrm, ITarget
    {
        public void Create(DbUserEntity user, DbUserInfoEntity info)
        {
            Context.Users.Add(user);
            Context.UserInfos.Add(info);
        }

        public void Delete(DbUserEntity user, DbUserInfoEntity info)
        {
            Context.Users.Remove(user);
            Context.UserInfos.Remove(info);
        }

        public Tuple<DbUserEntity, DbUserInfoEntity> Read(int id)
        {
            if (Context.Users.Count > 0)
            {
                DbUserEntity user = Context.Users.First(e => e.Id == id);
                if (user != null)
                {
                    DbUserInfoEntity info = Context.UserInfos.First(e => e.Id == user.UserInfoId);
                    Console.WriteLine("Пользователь с идом: " + user.Id + "Имеет следующую инфу:\n" +
                        user.Login + " " + user.PasswordHash + " " + info.Name + " " + info.Birthday
                        );
                    return new Tuple<DbUserEntity, DbUserInfoEntity>(user, info);
                }
            }
            Console.WriteLine("Нет таких " + id);
            return default(Tuple<DbUserEntity, DbUserInfoEntity>);
        }

        public void Update(DbUserEntity user, DbUserInfoEntity info)
        {
            Context.Users.Remove(user);
            Context.UserInfos.Remove(info);
            this.Create(user, info);
        }
    }
}
