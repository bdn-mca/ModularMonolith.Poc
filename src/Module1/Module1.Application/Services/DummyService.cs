using System.Threading.Tasks;

namespace Module1.Application.Services
{
    public class DummyService : IDummyService
    {
        public async Task Validate()
        {
            await Task.Delay(1000);
        }
    }
}
