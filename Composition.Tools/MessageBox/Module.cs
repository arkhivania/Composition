using System;
using Autofac;

namespace Composition.Tools.MessageBox;

public class Module : Autofac.Module, Base.IMessageBox
{
    public Task ShowMessage(string message)
    {
        return Task.CompletedTask;
    }

    public Task<bool?> ShowQuestion(string question)
    {
        return Task.FromResult<bool?>(true);
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterInstance<Base.IMessageBox>(this);
    }
}
