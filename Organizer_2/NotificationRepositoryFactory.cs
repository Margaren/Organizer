namespace Organizer_2
{
    public static class NotificationRepositoryFactory
    {
        public enum Type { Classic, Private }
        public static INotificationRepository Create(string path, Type type)
        {
            return type switch
            {
                Type.Classic => new NotificationRepository(path),
                _ => new NotificationRepository(path),
            };
        }
    }
}
