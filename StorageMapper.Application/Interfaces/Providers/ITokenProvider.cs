using StorageMapper.Domain.Entitites;

namespace StorageMapper.Application.Interfaces;

public interface ITokenProvider
{
    string Create(User user);
}
