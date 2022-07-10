namespace ComissionCalculator.Mapper
{
    public interface IMapper<Tin, Tout>
    {
        Tout Map(Tin source);
    }
}
