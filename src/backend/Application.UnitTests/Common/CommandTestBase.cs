using AutoMapper;
using Infrastructure.Data;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Application.Common.Mappings;

namespace Application.UnitTests.Common;

public class CommandTestBase : IDisposable
{
    protected readonly ApplicationDbContext _context;
    protected readonly IMapper _mapper;
    protected readonly IUser _user;

    public CommandTestBase()
    {
        var config = new MapperConfiguration(config => config.AddProfile<MappingProfile>());

        config.AssertConfigurationIsValid();

        _mapper = config.CreateMapper();

        _user = new Mock<IUser>().Object;

        _context = ApplicationDbContextFactory.Create();
    }

    public void Dispose()
    {
        ApplicationDbContextFactory.Destroy(_context);
    }
}
