using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.CustomMessages
{
    public static class HandlerMessages
    {
        public static string SucceededMessage = "İşlem başarıyla tamamlandı.";
        public static string SucceededDeleteMessage = "Silme işlemi başarıyla tamamlandı.";
        public static string SucceededUpdateMessage = "Güncelleme işlemi başarıyla tamamlandı.";
        public static string SucceededAddMessage = "Ekleme işlemi başarıyla tamamlandı.";
        public static string SucceededCreateMessage = "Yeni kayıt oluşturma işlemi başarıyla tamamlandı.";
        public static string NotFoundMessage = "Aradığınız ID ile eşleşen kayıt bulunamadı.";
        public static string ChairNotFoundMessage = "Aradığınız ID ile eşleşen koltuk bulunamadı.";
        public static string MovieNotFoundMessage = "Aradığınız ID ile eşleşen film bulunamadı.";
        public static string HallNotFoundMessage = "Aradığınız ID ile eşleşen salon bulunamadı.";
        public static string GenreNotFoundMessage = "Aradığınız ID ile eşleşen tür bulunamadı.";
        public static string UserNotFoundMessage = "Aradığınız ID ile eşleşen kullanıcı bulunamadı.";
        public static string MovieHallNotFoundMessage = "Bu salonda böyle bir film yer almamaktadır.";
        public static string MovieAlreadyExistInHallMessage = "Bu salonda böyle bir film zaten yer almaktadır.";
        public static string GenreAlreadyExistInMovieMessage = "Bu filmde bu tür zaten yer almaktadır.";
    }
}
