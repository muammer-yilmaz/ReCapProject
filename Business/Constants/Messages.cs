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
        internal static string UserRegistered = "Kullanıcı kaydı başarılı";
        internal static string UserNotFound = "Kullanıcı bulunamadı";
        internal static string PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
        internal static string AuthorizationDenied = "Yetki Yok";
        internal static string CarsListed = "Araba listesi getirildi";
        internal static string RentalAdded = "Araba kiralama başarılı";
        internal static string CardNotFound = "Kredi kartı bulunamadı";
        internal static string BalanceInsufficient = "Bakiye yetersiz";
        internal static string PaymentSuccessful = "Ödeme başarılı";
        internal static string PaymentError = "Ödeme başarısız";
        internal static string AlreadyRented = "araba kirada";
    }
}
