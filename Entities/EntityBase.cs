namespace EFCore_Multi_BD.Entities
{
    public class EntityBase<T> where T : struct
    {
        public T Id { get; set; }
    }
}