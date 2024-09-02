using FluentValidation;
using MediatR;
using PosTech.FaseV.Application.Notifications;

namespace PosTech.FaseV.Application.UseCases
{
    public abstract class RequestHandlerBase
    {
        protected readonly INotificator _notificator;
        protected RequestHandlerBase(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool ExecValidation<TValitator, TRequest>
            (TValitator validator, TRequest request) where TValitator : IValidator<TRequest> where TRequest : IRequest
        {
            var validation = validator.Validate(request);
            if (validation.IsValid) return true;
            _notificator.AddNotifications(validation);
            return false;
        }
    }
}
