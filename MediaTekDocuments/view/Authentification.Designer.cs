
namespace MediaTekDocuments.view
{
    partial class Authentification
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtlogin = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.btnvalider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bienvenue";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Identifiant";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mot de passe";
            // 
            // txtlogin
            // 
            this.txtlogin.Location = new System.Drawing.Point(184, 69);
            this.txtlogin.Multiline = true;
            this.txtlogin.Name = "txtlogin";
            this.txtlogin.Size = new System.Drawing.Size(141, 29);
            this.txtlogin.TabIndex = 12;
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(184, 121);
            this.txtpwd.Multiline = true;
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Size = new System.Drawing.Size(141, 29);
            this.txtpwd.TabIndex = 13;
            // 
            // btnvalider
            // 
            this.btnvalider.Location = new System.Drawing.Point(80, 190);
            this.btnvalider.Name = "btnvalider";
            this.btnvalider.Size = new System.Drawing.Size(211, 33);
            this.btnvalider.TabIndex = 14;
            this.btnvalider.Text = "Valider";
            this.btnvalider.UseVisualStyleBackColor = true;
            this.btnvalider.Click += new System.EventHandler(this.btnvalider_Click);
            // 
            // Authentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 244);
            this.Controls.Add(this.btnvalider);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtlogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Authentification";
            this.Text = "Authentification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtlogin;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Button btnvalider;
    }
}