using Ninject;

namespace CodeIt.Web.Infrastructure.Bindings
{
    public interface INinjectBinding
    {
        void Bind(IKernel kernel);
    }
}
