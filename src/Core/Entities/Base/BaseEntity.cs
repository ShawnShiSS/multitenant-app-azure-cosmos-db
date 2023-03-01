using Newtonsoft.Json;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        [JsonProperty(PropertyName = "id")]
        public virtual string Id { get; set; }

        public virtual string TenantId { get; set; }
    }
}
