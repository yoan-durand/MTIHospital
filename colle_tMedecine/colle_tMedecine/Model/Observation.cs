using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace colle_tMedecine.Model
{
    [DataContract]
    class Observation
    {
        #region Variables
        private DateTime _date;
        private string _comments;
        private List<string> _prescriptions;
        private Byte[][] _pic;
        private int _weight;
        private int _pressure;
        #endregion

        #region Getter/Setter
        [DataMember]
        public int Pressure
        {
            get { return _pressure; }
            set { _pressure = value; }
        }

        [DataMember]
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        [DataMember]
        public Byte[][] Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }

        [DataMember]
        public List<string> Prescriptions
        {
            get { return _prescriptions; }
            set { _prescriptions = value; }
        }

        [DataMember]
        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion

    }
}
