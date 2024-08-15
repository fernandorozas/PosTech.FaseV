namespace PosTech.FaseV.Application.Notifications
{
    public interface INotificator
    {
        bool HasNotification();
        IEnumerable<string> GetNotifications();
        void AddNotification(string notification);
        void AddNotifications(FluentValidation.Results.ValidationResult notifications);
    }
}
