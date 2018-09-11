using LightInject;
using Model.Auth;
using Model.Domain;
using Persistence.DbContextScope;
using Persistence.Repository;
using Service.Interface;
using Service.Maestro;

namespace Service.Config
{
    public class ServiceRegister : ICompositionRoot
    {               
        public void Compose(IServiceRegistry container)
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();

            container.Register<IDbContextScopeFactory>((x) => new DbContextScopeFactory(null));
            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(new PerScopeLifetime());

            container.Register<IRepository<ApplicationUser>>((x) => new Repository<ApplicationUser>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationRole>>((x) => new Repository<ApplicationRole>(ambientDbContextLocator));
            container.Register<IRepository<Course>>((x) => new Repository<Course>(ambientDbContextLocator));
            container.Register<IRepository<Student>>((x) => new Repository<Student>(ambientDbContextLocator));

            //eincio
            container.Register<IRepository<Persona>>((x) => new Repository<Persona>(ambientDbContextLocator));
            container.Register<IRepository<TipoDocumento>>((x) => new Repository<TipoDocumento>(ambientDbContextLocator));

            container.Register<IRepository<StudentPerCourse>>((x) => new Repository<StudentPerCourse>(ambientDbContextLocator));

            container.Register<IStudentService, StudentService>();

            //eincio
            container.Register<ITipoDocumentoService, TipoDocumentoService>();
            container.Register<IPersonaService, PersonaService>();

            container.Register<IStudentPerCourseService, StudentPerCourseService>();
            container.Register<ICourseService, CourseService>();
            container.Register<IUserService, UserService>();
        }
    }
}
