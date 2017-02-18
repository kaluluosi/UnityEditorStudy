namespace EditorFramework
{
    /// <summary>
    /// 这个类其实只是用来占坑用的，以后如果想到了什么设计框架，可以在这个类开始构筑框架层。
    /// </summary>
    public abstract class UIFramework:UIElement {

        private object dataContext;
        public virtual object DataContext
        {
            get
            {
                if (dataContext != null)
                    return dataContext;

                if (VisualParent != null && VisualParent is UIFramework)
                {
                    UIFramework parent= (UIFramework)VisualParent;
                    return parent.DataContext;
                }
                return dataContext;
            }
            set
            {
                dataContext = value;
            }
        }

        private BindingCollection bindings;

        public BindingCollection Binding
        { 
            get {
                return bindings == null ? bindings = new BindingCollection(this) : bindings;
            } 
        }

        public UIFramework()
        {
            RenderEvent += UIFramework_RenderEvent;
        }

        void UIFramework_RenderEvent(object sender, RenderEventArgs e)
        {
            if (bindings == null) return;

            foreach (var binding in Binding)
            {
                binding.Update();
            }
        }

    }
}
