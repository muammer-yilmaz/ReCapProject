using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        internal static string CarAdded = "Araba ekleme başarılı";
        internal static string CarImageAdded = "Araba resmi ekleme başarılı";
        internal static string CarImageLimitExceeded = "Araba resmi ekleme limiti aşıldı";
        internal static string CarImageDeleted = "Araba resmi silme başarılı";
        internal static string CarImageUpdated = "Araba resmi güncellme başarılı";
        internal static string UserRegistered;
        internal static string UserNotFound;
        internal static string PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
        internal static string AuthorizationDenied = "Yetki Yok";
    }
}
