namespace MvcTask.Application.DTOs.Abstract
{
    public interface IDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
