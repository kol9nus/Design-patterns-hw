using Example_04.Homework.Models.Interfaces;
using Example_04.Homework.SecondOrmLibrary;
using System;
using Example_04.Homework.Models;
using Homework4.SecondOrmLibrary;
using Homework4.FirstOrmLibrary;
using Example_04.Homework.FirstOrmLibrary;

namespace Homework4
{

    public class FirstAdapter : ITarget
    {
        private readonly IFirstOrm<DbUserEntity> _usersDb = new FirstOrm<DbUserEntity>();
        private readonly IFirstOrm<DbUserInfoEntity> _usersInfosDb = new FirstOrm<DbUserInfoEntity>();

        public void Create(DbUserEntity user, DbUserInfoEntity info)
        {
            _usersDb.Create(user);
            _usersInfosDb.Create(info);
        }

        public void Delete(DbUserEntity user, DbUserInfoEntity info)
        {
            _usersDb.Delete(user);
            _usersInfosDb.Delete(info);
        }

        public Tuple<DbUserEntity, DbUserInfoEntity> Read(int id)
        {
            DbUserEntity user = _usersDb.Read(id);
            if (user != null)
            {
                DbUserInfoEntity info = _usersInfosDb.Read(user.UserInfoId);
                Console.WriteLine("Пользователь с идом: " + user.Id + "Имеет следующую инфу:\n" +
                    user.Login + " " + user.PasswordHash + " " + info.Name + " " + info.Birthday
                    );
                return new Tuple<DbUserEntity, DbUserInfoEntity>(user, info);
            }
            Console.WriteLine("Нет таких " + id);
            return default(Tuple<DbUserEntity, DbUserInfoEntity>);
        }

        public void Update(DbUserEntity user, DbUserInfoEntity info)
        {
            _usersDb.Update(user);
            _usersInfosDb.Update(info);
        }
    }
}
