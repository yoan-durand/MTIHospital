using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace colle_tMedecine.Services
{
    class User : ServiceUser.IServiceUser

    {
        public ServiceUser.User[] GetListUser()
        {
            try
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
            catch
            {
                throw new TimeoutException();
            }
        }

        public ServiceUser.User GetUser(string login)
        {
            try
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
            catch
            {
                throw new TimeoutException();
            }
        }

        public bool AddUser(ServiceUser.User user)
        {
            try
            {
                using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
                {
                    return client.AddUser(user);
                }
            }
            catch
            {
                throw new TimeoutException();
            }
        }

        public bool DeleteUser(string login)
        {
            try
            {
                using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
                {
                    return client.DeleteUser(login);
                }
            }
            catch
            {
                throw new TimeoutException();
            }
        }

        public bool Connect(string login, string pwd)
        {
            try
            {
                using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
                {
                    return client.Connect(login, pwd);
                }
            }
            catch
            {
                throw new TimeoutException();
            }
        }

        public void Disconnect(string login)
        {
            try
            {
                using (ServiceUser.ServiceUserClient client = new ServiceUser.ServiceUserClient())
                {
                    client.Disconnect(login);
                }
            }
            catch
            {
                throw new TimeoutException();
            }
        }

        public string GetRole(string login)
        {
            try
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
            catch
            {
                throw new TimeoutException();
            }
        }
    }
}
