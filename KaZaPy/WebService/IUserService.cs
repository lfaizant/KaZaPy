using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectClass;

namespace WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IUserService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetUserById(int userId);

        [OperationContract]
        User GetUserByEmail(string email);

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        void DeleteUser(User user);

        [OperationContract]
        void LogInUser(User user);

        [OperationContract]
        void LogOutUser(User user);
    }
}
