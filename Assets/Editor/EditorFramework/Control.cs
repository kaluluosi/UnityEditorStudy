

using UnityEditor;
using UnityEngine;


namespace EditorFramework
{
    public abstract class Control
    {
        private bool enable= true;

        public int Id {
            get{
                return this.GetHashCode();
            }
        }

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