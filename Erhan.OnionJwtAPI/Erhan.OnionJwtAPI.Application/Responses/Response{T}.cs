using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Responses
{
    public class Response<T> : Response, IResponse<T>
    {
        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }

        public Response(ResponseType responseType, string message) : base(responseType, message) // miras alınanın ctoruna gönder
        {
        }
        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        // validation error durumunda kullanılacak ctor
        public Response(T data, List<CustomValidationError> errors) : base(ResponseType.ValidationError)
        {
            ValidationErrors = errors;
            Data = data;
        }

        public Response(List<CustomValidationError> errors) : base(ResponseType.ValidationError)
        {
            ValidationErrors = errors;
        }

    }
}
