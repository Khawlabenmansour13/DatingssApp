using DatingApp.Domaine.Entities;


namespace DatingsApp.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
