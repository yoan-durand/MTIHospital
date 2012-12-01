using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace colle_tMedecine.Model
{
    [DataContract]
    class Patient
    {
        #region Variables
        private string _name;
        private string _firstname;
        private DateTime _birth;
        private List<Model.Observation> _obs;
        #endregion

        #region Getter/Setter
        [DataMember]
        public List<Model.Observation> Obs
        {
            get { return _obs; }
            set { _obs = value; }
        }

        [DataMember]
        public DateTime Birth
        {
            get { return _birth; }
            set { _birth = value; }
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
        #endregion

    }
}