using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Homework4.SecondOrmLibrary
{
    class SecondOrm : ISecondOrm
    {
        public ISecondOrmContext Context { get; }

        public SecondOrm(ISecondOrmContext context)
        {
            this.Context = context;
        }

        public SecondOrm()
        {
            this.Context = new SecondOrmContext();
        }
    }

    class SecondOrmContext : ISecondOrmContext
    {
        public HashSet<DbUserEntity> Users { get; }
        public HashSet<DbUserInfoEntity> UserInfos { get; }

        public SecondOrmContext(HashSet<DbUserEntity> users, HashSet<DbUserInfoEntity> userInfos)
        {
            this.Users = users;
            this.UserInfos = userInfos;
        }

        public SecondOrmContext()
        {
            this.Users = new HashSet<DbUserEntity>();
            this.UserInfos = new HashSet<DbUserInfoEntity>();
        }
    }
}
