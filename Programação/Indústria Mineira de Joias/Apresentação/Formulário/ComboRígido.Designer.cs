namespace Apresentação.Formulário
{
    partial class ComboRígido
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ComboRígido
            // 
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Validating += new System.ComponentModel.CancelEventHandler(this.ComboRígido_Validating);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
