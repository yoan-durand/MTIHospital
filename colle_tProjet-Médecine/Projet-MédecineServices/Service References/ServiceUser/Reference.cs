﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.296
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projet_MédecineServices.ServiceUser {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Dbo")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ConnectedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] PictureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PwdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Connected {
            get {
                return this.ConnectedField;
            }
            set {
                if ((this.ConnectedField.Equals(value) != true)) {
                    this.ConnectedField = value;
                    this.RaisePropertyChanged("Connected");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Firstname {
            get {
                return this.FirstnameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstnameField, value) != true)) {
                    this.FirstnameField = value;
                    this.RaisePropertyChanged("Firstname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Picture {
            get {
                return this.PictureField;
            }
            set {
                if ((object.ReferenceEquals(this.PictureField, value) != true)) {
                    this.PictureField = value;
                    this.RaisePropertyChanged("Picture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pwd {
            get {
                return this.PwdField;
            }
            set {
                if ((object.ReferenceEquals(this.PwdField, value) != true)) {
                    this.PwdField = value;
                    this.RaisePropertyChanged("Pwd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Role {
            get {
                return this.RoleField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleField, value) != true)) {
                    this.RoleField = value;
                    this.RaisePropertyChanged("Role");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceUser.IServiceUser")]
    public interface IServiceUser {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/GetListUser", ReplyAction="http://tempuri.org/IServiceUser/GetListUserResponse")]
        Projet_MédecineServices.ServiceUser.User[] GetListUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/GetUser", ReplyAction="http://tempuri.org/IServiceUser/GetUserResponse")]
        Projet_MédecineServices.ServiceUser.User GetUser(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/AddUser", ReplyAction="http://tempuri.org/IServiceUser/AddUserResponse")]
        bool AddUser(Projet_MédecineServices.ServiceUser.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/DeleteUser", ReplyAction="http://tempuri.org/IServiceUser/DeleteUserResponse")]
        bool DeleteUser(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/Connect", ReplyAction="http://tempuri.org/IServiceUser/ConnectResponse")]
        bool Connect(string login, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/Disconnect", ReplyAction="http://tempuri.org/IServiceUser/DisconnectResponse")]
        void Disconnect(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/GetRole", ReplyAction="http://tempuri.org/IServiceUser/GetRoleResponse")]
        string GetRole(string login);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceUserChannel : Projet_MédecineServices.ServiceUser.IServiceUser, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceUserClient : System.ServiceModel.ClientBase<Projet_MédecineServices.ServiceUser.IServiceUser>, Projet_MédecineServices.ServiceUser.IServiceUser {
        
        public ServiceUserClient() {
        }
        
        public ServiceUserClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceUserClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceUserClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceUserClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Projet_MédecineServices.ServiceUser.User[] GetListUser() {
            return base.Channel.GetListUser();
        }
        
        public Projet_MédecineServices.ServiceUser.User GetUser(string login) {
            return base.Channel.GetUser(login);
        }
        
        public bool AddUser(Projet_MédecineServices.ServiceUser.User user) {
            return base.Channel.AddUser(user);
        }
        
        public bool DeleteUser(string login) {
            return base.Channel.DeleteUser(login);
        }
        
        public bool Connect(string login, string pwd) {
            return base.Channel.Connect(login, pwd);
        }
        
        public void Disconnect(string login) {
            base.Channel.Disconnect(login);
        }
        
        public string GetRole(string login) {
            return base.Channel.GetRole(login);
        }
    }
}
