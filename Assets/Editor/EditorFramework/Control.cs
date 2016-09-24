

using UnityEditor;
using UnityEngine;


namespace EditorFramework
{

    /// <summary>
    /// 所有控件的基类
    /// </summary>
    public abstract class Control:IControlContainer
    {
        private bool enable= true;
        private ControlCollection controls ;

        public Control() {
            controls = new ControlCollection(this);
        }

        public int ID {
            get{
                return this.GetHashCode();
            }
        }

        /// <summary>
        /// 子控件集合
        /// </summary>
        public ControlCollection Controls {
            get { return controls; }
        }

        /// <summary>
        /// 父控件
        /// </summary>
        public Control Owner { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enable {
            get{
                return enable;
            }
            set{
                enable = value;
            }
        }

        public Rect Rect { get; set; }
        /// <summary>
        /// 绘制控件
        /// </summary>
        public abstract void Draw();

        
    }
}