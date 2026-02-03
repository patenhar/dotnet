using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using SimpleStore.Business.Mappings;

namespace SimpleStore.Presentation;

public class Startup
{
    public void ConfigureServices(IServiceCollection services) {

     var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));

     IMapper mapper = mapperConfig.CreateMapper();
     services.AddSingleton(mapper);

     services.AddMvc();

 }

}