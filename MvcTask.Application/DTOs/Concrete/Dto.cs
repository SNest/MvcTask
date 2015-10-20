namespace MvcTask.Application.DTOs.Concrete
{
    using MvcTask.Application.DTOs.Abstract;

    public class Dto<TPrimaryKey> : IDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
