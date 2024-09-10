using System;
using Autofac;

namespace Composition.Tools.MessageBox;

public class Module : Autofac.Module, Base.IMessageBox
{
    public void ShowMessage(string message) { }

    public bool? ShowQuestion(string question)
    {
        return null;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterInstance<Base.IMessageBox>(this);
    }
}
