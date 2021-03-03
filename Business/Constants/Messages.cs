using Core.Entities.Concrete;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public class Messages
    {
        public static string EntityAdded = "Entity added";
        public static string EntityNameInvalid = "Entity name is invalid";
        public static string MaintenanceTime = "Maintenance Time";
        public static string EntitiesListed = "Entities Listed";
        public static string EntityUpdated = "Entity Updated";
        public static string EntityDelete = "Entity Deleted";
        public static string CarImagesLimitExceeded="Images Limit Exceeded!";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password Error";
        public static string SuccessfulLogin = "Successful Login";
        public static string UserExists = "User already exists";
        public static string UserRegistered = "User Registered";
        public static string AccessTokenCreated = "Access Token Created";
        public static string AuthorizationDenied = "Auhorization Denied";
    }
}