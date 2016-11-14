using Example_04.Homework.Models;
using Example_04.Homework.Models.Interfaces;
using Example_04.Homework.SecondOrmLibrary;
using System;

namespace Homework4
{
    public interface ITarget
    {
        void Create(DbUserEntity user, DbUserInfoEntity info);
        Tuple<DbUserEntity, DbUserInfoEntity> Read(int id);
        void Update(DbUserEntity user, DbUserInfoEntity info);
        void Delete(DbUserEntity user, DbUserInfoEntity info);
    }
}
