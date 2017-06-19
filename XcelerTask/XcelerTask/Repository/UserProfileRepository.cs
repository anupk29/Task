using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using XcelerTask.Models;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;
using XcelerTask.DependencyServices;
using XcelerTask.CommonData;

namespace XcelerTask.Repository
{
    public class UserProfileRepository
    {
        readonly SQLiteConnection _sqLiteConnection;

        static object lockObj = new object();
        public UserProfile userexists { get; set; }
        public UserProfileRepository()
        {
            try
            {
                _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

                _sqLiteConnection.CreateTable<UserProfile>();
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    Models.AlertMessages.ShowAlert(CommonAppData.CustomError);
                }
            }
        }

        public List<UserProfile> GetAllusers()
        {
            lock (lockObj)
            {
                return _sqLiteConnection.Table<UserProfile>().Where(x=>x.IsActive==true).ToList();
            }

        }
        public UserProfile GetUserById(int id)
        {
            lock (lockObj)
            {
                return _sqLiteConnection.Table<UserProfile>().FirstOrDefault(t => t.Id == id);
            }

        }
        //public void Delete(int id)
        //{
        //    lock (lockObj)
        //    {
        //        _sqLiteConnection.Delete<UserProfile>(id);
        //    }
        //}

        public UserProfile AddItem(UserProfile item)
        {
            lock (lockObj)
            {
                if (item.Id != 0)
                {
                    userexists = GetUserById(item.Id);
                }
                if (userexists == null)
                {
                    _sqLiteConnection.Insert(item);
                    return item;
                }
                else
                {
                    _sqLiteConnection.Update(item);
                    return item;

                }
            }


        }


    }
}
