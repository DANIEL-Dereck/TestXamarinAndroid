using Android.OS;
using Android.Support.V7.App;

namespace TestFragment
{
    public abstract class BaseActivity : AppCompatActivity
    {
        #region OverridedMethods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(this.GetContentView());
            this.InitComponents();
            this.InitEvents();
        }
        #endregion

        #region AbstractMethods
        protected abstract void InitComponents();

        protected abstract void InitEvents();

        public abstract int GetContentView();
        #endregion
    }
}
