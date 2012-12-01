using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace colle_tMedecineServices.Services
{
    class User : ServiceUser.IServiceUser
    {
        public ServiceUser.User[] GetListUser()
        {
            using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
            {
                ServiceUser.User[] listUser = client.GetListUser();
                if (listUser == null || listUser.Count() == 0)
                    throw new ArgumentNullException();
                else
                    return listUser;
            }
        }

        public ServiceUser.User GetUser(string login)
        {
            using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
            {
                ServiceUser.User user = client.GetUser(login);
                if (user == null)
                    throw new ArgumentNullException();
                else
                    return user;
            }
        }

        public bool AddUser(ServiceUser.User user)
        {
            using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
            {
                return client.AddUser(user);
            }
        }

        public bool DeleteUser(string login)
        {
            using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
            {
                return client.DeleteUser(login);
            }
        }

        public bool Connect(string login, string pwd)
        {
            using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
            {
                return client.Connect(login, pwd);
            }
        }

        public void Disconnect(string login)
        {
            using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
            {
                client.Disconnect(login);
            }
        }

        public string GetRole(string login)
        {
            using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
            {
                string role = client.GetRole(login);

                if (role == null)
                    throw new ArgumentNullException();
                else
                    return role;
            }
        }
    }
}
