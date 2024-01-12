using System.Collections.Generic;

namespace Organizer_2
{
    public interface INotificationRepository
    {
        public Notification FindByName(string name);
        public Notification Edit(string name);
        public List<Notification> Browse();
        public void SaveFile();
        public void Add(Notification notification);
        public void Delete(string name);

    }
}
