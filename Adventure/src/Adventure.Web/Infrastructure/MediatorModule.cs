using System.Reflection;
using Adventure.Web.Behaviours;
using Adventure.Web.Commands;
using Adventure.Web.Validations;
using Autofac;
using FluentValidation;
using MediatR;
using Module = Autofac.Module;

namespace Adventure.Web.Infrastructure;

public class MediatorModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
      .AsImplementedInterfaces();

   
    builder.RegisterAssemblyTypes(typeof(CreateAdventureCommand).GetTypeInfo().Assembly)
      .AsClosedTypesOf(typeof(IRequestHandler<,>));

    builder
      .RegisterAssemblyTypes(typeof(CreateAdventureCommandValidator).GetTypeInfo().Assembly)
      .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
      .AsImplementedInterfaces();

    builder.Register<ServiceFactory>(context =>
    {
      var componentContext = context.Resolve<IComponentContext>();
      return t =>
      {
        object o;
        return componentContext.TryResolve(t, out o) ? o : null;
      };
    });

    builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
  }
}
