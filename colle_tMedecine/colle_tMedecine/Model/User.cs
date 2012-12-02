using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace colle_tMedecine.Model
{
    [DataContract]
    class User : colle_tMedecineServices.ServiceUser.User
    {
        #region Variables
        private string _login;
        private string _password;
        private string _name;
        private string _firstname;
        private Byte[] _pic;
        private string _role;
        private bool _co;

        #endregion

        #region Getter/Setter
        [DataMember]
        public bool Co
        {
            get { return _co; }
            set { _co = value; }
        }

        [DataMember]
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        [DataMember]
        public Byte[] Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }

        [DataMember]
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember]
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        #endregion

    }
}
