using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.TextControl;
using JetBrains.Util;

namespace ReSharper.Plugins
{
    [ContextAction(Name = "Make static", Group = "C#", Description = "Makes a method static", Priority = -20)]
    public class MakeMethodStaticContextActions : ContextActionBase
    {
        private readonly ICSharpContextActionDataProvider _provider;

        public MakeMethodStaticContextActions(ICSharpContextActionDataProvider provider)
        {
            _provider = provider;
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            if (_provider != null)
            {

                var method = _provider.GetSelectedElement<IMethodDeclaration>(false, true);

                if (method != null)
                {
                    method.SetStatic(true);
                }
            }

            return null;
        }

        public override string Text
        {
            get { return "Static"; }
        }


        public override bool IsAvailable(IUserDataHolder cache)
        {
            if (_provider != null)
            {

                var item = _provider.GetSelectedElement<IMethodDeclaration>(false, true);

                if (item != null)
                {
                    var accessRights = item.GetAccessRights();

                    if (accessRights == AccessRights.PUBLIC && !item.IsStatic && !item.IsVirtual && !item.IsOverride && !item.IsAbstract)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void T() { }
    }
}
