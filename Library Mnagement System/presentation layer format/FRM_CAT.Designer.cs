namespace Library_Mnagement_System.presentation_layer_format
{
    partial class FRM_CAT
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CAT));
            this.lb_mainsystem = new System.Windows.Forms.Label();
            this.btn_add = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btn_closee = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.txt_cat = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_closee)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_mainsystem
            // 
            this.lb_mainsystem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_mainsystem.AutoSize = true;
            this.lb_mainsystem.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.lb_mainsystem, BunifuAnimatorNS.DecorationType.None);
            this.lb_mainsystem.Font = new System.Drawing.Font("Arabic Typesetting", 28F, System.Drawing.FontStyle.Bold);
            this.lb_mainsystem.ForeColor = System.Drawing.Color.Black;
            this.lb_mainsystem.Location = new System.Drawing.Point(139, 55);
            this.lb_mainsystem.Name = "lb_mainsystem";
            this.lb_mainsystem.Size = new System.Drawing.Size(148, 55);
            this.lb_mainsystem.TabIndex = 4;
            this.lb_mainsystem.Text = "اسم الصنف";
            this.lb_mainsystem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_add
            // 
            this.btn_add.ActiveBorderThickness = 1;
            this.btn_add.ActiveCornerRadius = 20;
            this.btn_add.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_add.ActiveForecolor = System.Drawing.Color.Black;
            this.btn_add.ActiveLineColor = System.Drawing.Color.Black;
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add.BackgroundImage")));
            this.btn_add.ButtonText = "اضافة";
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.btn_add, BunifuAnimatorNS.DecorationType.None);
            this.btn_add.Font = new System.Drawing.Font("DecoType Naskh Variants", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_add.ForeColor = System.Drawing.Color.Black;
            this.btn_add.IdleBorderThickness = 1;
            this.btn_add.IdleCornerRadius = 20;
            this.btn_add.IdleFillColor = System.Drawing.Color.White;
            this.btn_add.IdleForecolor = System.Drawing.Color.Black;
            this.btn_add.IdleLineColor = System.Drawing.Color.Black;
            this.btn_add.Location = new System.Drawing.Point(12, 168);
            this.btn_add.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(402, 64);
            this.btn_add.TabIndex = 3;
            this.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btn_closee
            // 
            this.btn_closee.BackColor = System.Drawing.Color.Transparent;
            this.btn_closee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.btn_closee, BunifuAnimatorNS.DecorationType.None);
            this.btn_closee.Image = ((System.Drawing.Image)(resources.GetObject("btn_closee.Image")));
            this.btn_closee.ImageActive = null;
            this.btn_closee.Location = new System.Drawing.Point(2, 9);
            this.btn_closee.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            this.btn_closee.Name = "btn_closee";
            this.btn_closee.Size = new System.Drawing.Size(27, 29);
            this.btn_closee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_closee.TabIndex = 5;
            this.btn_closee.TabStop = false;
            this.btn_closee.Zoom = 10;
            this.btn_closee.Click += new System.EventHandler(this.btn_closee_Click);
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlideAndRotate;
            this.bunifuTransition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(50);
            animation1.RotateCoeff = 0.3F;
            animation1.RotateLimit = 0.2F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation1;
            this.bunifuTransition1.Interval = 250;
            // 
            // txt_cat
            // 
            this.txt_cat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cat.AutoSize = true;
            this.txt_cat.BackColor = System.Drawing.Color.White;
            this.txt_cat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTransition1.SetDecoration(this.txt_cat, BunifuAnimatorNS.DecorationType.None);
            this.txt_cat.Font = new System.Drawing.Font("Arabic Typesetting", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txt_cat.ForeColor = System.Drawing.Color.Black;
            this.txt_cat.HintForeColor = System.Drawing.Color.Black;
            this.txt_cat.HintText = "ادخل اسم الصنف الجديد";
            this.txt_cat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_cat.isPassword = false;
            this.txt_cat.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_cat.LineIdleColor = System.Drawing.Color.Black;
            this.txt_cat.LineMouseHoverColor = System.Drawing.Color.Gray;
            this.txt_cat.LineThickness = 4;
            this.txt_cat.Location = new System.Drawing.Point(12, 110);
            this.txt_cat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txt_cat.Name = "txt_cat";
            this.txt_cat.Size = new System.Drawing.Size(402, 58);
            this.txt_cat.TabIndex = 2;
            this.txt_cat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FRM_CAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(30F, 76F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(427, 258);
            this.Controls.Add(this.btn_closee);
            this.Controls.Add(this.txt_cat);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lb_mainsystem);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Font = new System.Drawing.Font("DecoType Naskh Variants", 22.2F, System.Drawing.FontStyle.Italic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(11, 14, 11, 14);
            this.Name = "FRM_CAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.btn_closee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_mainsystem;
        public Bunifu.Framework.UI.BunifuThinButton2 btn_add;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton btn_closee;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_cat;
    }
}