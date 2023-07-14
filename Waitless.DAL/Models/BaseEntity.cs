using System.ComponentModel.DataAnnotations.Schema;

namespace Waitless.DAL.Models;

[NotMapped]
public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifyDate { get; set; }
    public bool IsDeleted { get; set; }
}

[NotMapped]
public class BaseTranslationEntity : BaseEntity
{
    public int LanguageId { get; set; }
}

[NotMapped]
public class BasePhotoEntity : BaseEntity
{
    public BasePhotoEntity()
    {

    }
    public BasePhotoEntity(string fileUrl)
    {
        FileUrl = fileUrl;
    }

    public string FileUrl { get; set; }
}

[NotMapped]
public class BaseWithMedia<T> : BaseEntity where T : BasePhotoEntity
{
    public BaseWithMedia()
    {
        Files = new HashSet<T>();
    }

    public ICollection<T> Files { get; set; }
}