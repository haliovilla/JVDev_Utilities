using JVDev.Extensions;

namespace JVDev.Entity
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            UUID = Guid.NewGuid();
            CREATED = new DateTime().GetTimeByTimeZone();
            UPDATED = new DateTime().GetTimeByTimeZone();
            DELETED = false;
        }

        public long ID { get; set; }
        public Guid UUID { get; set; }
        public DateTime CREATED { get; set; }
        public DateTime UPDATED { get; set; }
        public bool DELETED { get; set; }
    }
}
