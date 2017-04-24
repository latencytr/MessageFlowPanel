namespace MessageFlowPanel
{
    partial class MessageFlowPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // mainFlowPanel
            // 
            this.mainFlowPanel.AutoScroll = true;
            this.mainFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.mainFlowPanel.MinimumSize = new System.Drawing.Size(183, 32);
            this.mainFlowPanel.Name = "mainFlowPanel";
            this.mainFlowPanel.Size = new System.Drawing.Size(378, 38);
            this.mainFlowPanel.TabIndex = 0;
            this.mainFlowPanel.WrapContents = false;
            this.mainFlowPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.mainFlowPanel_ControlAdded);
            // 
            // MessageFlowPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainFlowPanel);
            this.MinimumSize = new System.Drawing.Size(378, 38);
            this.Name = "MessageFlowPanel";
            this.Size = new System.Drawing.Size(378, 38);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainFlowPanel;

    }
}
