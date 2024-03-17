namespace Esame_Enterprise.Application.Abstractions.Models.Dto
{
    public interface GenericDto<T>
    {

        public T ToEntity();

    }
}
