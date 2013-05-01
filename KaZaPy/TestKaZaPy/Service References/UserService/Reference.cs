﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18034
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestKaZaPy.UserService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserById", ReplyAction="http://tempuri.org/IUserService/GetUserByIdResponse")]
        ObjectClass.User GetUserById(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserById", ReplyAction="http://tempuri.org/IUserService/GetUserByIdResponse")]
        System.Threading.Tasks.Task<ObjectClass.User> GetUserByIdAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByEmail", ReplyAction="http://tempuri.org/IUserService/GetUserByEmailResponse")]
        ObjectClass.User GetUserByEmail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByEmail", ReplyAction="http://tempuri.org/IUserService/GetUserByEmailResponse")]
        System.Threading.Tasks.Task<ObjectClass.User> GetUserByEmailAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AddUser", ReplyAction="http://tempuri.org/IUserService/AddUserResponse")]
        void AddUser(ObjectClass.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AddUser", ReplyAction="http://tempuri.org/IUserService/AddUserResponse")]
        System.Threading.Tasks.Task AddUserAsync(ObjectClass.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        void DeleteUser(ObjectClass.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        System.Threading.Tasks.Task DeleteUserAsync(ObjectClass.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/LogInUser", ReplyAction="http://tempuri.org/IUserService/LogInUserResponse")]
        void LogInUser(ObjectClass.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/LogInUser", ReplyAction="http://tempuri.org/IUserService/LogInUserResponse")]
        System.Threading.Tasks.Task LogInUserAsync(ObjectClass.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/LogOutUser", ReplyAction="http://tempuri.org/IUserService/LogOutUserResponse")]
        void LogOutUser(ObjectClass.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/LogOutUser", ReplyAction="http://tempuri.org/IUserService/LogOutUserResponse")]
        System.Threading.Tasks.Task LogOutUserAsync(ObjectClass.User user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : TestKaZaPy.UserService.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<TestKaZaPy.UserService.IUserService>, TestKaZaPy.UserService.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ObjectClass.User GetUserById(int userId) {
            return base.Channel.GetUserById(userId);
        }
        
        public System.Threading.Tasks.Task<ObjectClass.User> GetUserByIdAsync(int userId) {
            return base.Channel.GetUserByIdAsync(userId);
        }
        
        public ObjectClass.User GetUserByEmail(string email) {
            return base.Channel.GetUserByEmail(email);
        }
        
        public System.Threading.Tasks.Task<ObjectClass.User> GetUserByEmailAsync(string email) {
            return base.Channel.GetUserByEmailAsync(email);
        }
        
        public void AddUser(ObjectClass.User user) {
            base.Channel.AddUser(user);
        }
        
        public System.Threading.Tasks.Task AddUserAsync(ObjectClass.User user) {
            return base.Channel.AddUserAsync(user);
        }
        
        public void DeleteUser(ObjectClass.User user) {
            base.Channel.DeleteUser(user);
        }
        
        public System.Threading.Tasks.Task DeleteUserAsync(ObjectClass.User user) {
            return base.Channel.DeleteUserAsync(user);
        }
        
        public void LogInUser(ObjectClass.User user) {
            base.Channel.LogInUser(user);
        }
        
        public System.Threading.Tasks.Task LogInUserAsync(ObjectClass.User user) {
            return base.Channel.LogInUserAsync(user);
        }
        
        public void LogOutUser(ObjectClass.User user) {
            base.Channel.LogOutUser(user);
        }
        
        public System.Threading.Tasks.Task LogOutUserAsync(ObjectClass.User user) {
            return base.Channel.LogOutUserAsync(user);
        }
    }
}
