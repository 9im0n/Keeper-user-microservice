using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserMicroservice.Models.Database
{
    public class Profiles : BaseModel
    {
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [JsonIgnore]
        public Users User { get; set; }
    }
}
