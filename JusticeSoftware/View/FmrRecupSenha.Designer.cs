
namespace JusticeSoftware
{
    partial class FmrRecupSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmrRecupSenha));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Voltar = new System.Windows.Forms.Button();
            this.lbl_TituloLogin = new System.Windows.Forms.Label();
            this.txt_EmailUsuario = new System.Windows.Forms.TextBox();
            this.lbl_Usuario = new System.Windows.Forms.Label();
            this.btn_Enviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Enviaremos um e-mail com seus dados de acesso.";
            // 
            // btn_Voltar
            // 
            this.btn_Voltar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Voltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Voltar.Location = new System.Drawing.Point(846, 614);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.Size = new System.Drawing.Size(135, 52);
            this.btn_Voltar.TabIndex = 33;
            this.btn_Voltar.Text = "Voltar";
            this.btn_Voltar.UseVisualStyleBackColor = true;
            this.btn_Voltar.Click += new System.EventHandler(this.btn_Voltar_Click);
            // 
            // lbl_TituloLogin
            // 
            this.lbl_TituloLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_TituloLogin.AutoSize = true;
            this.lbl_TituloLogin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_TituloLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TituloLogin.Location = new System.Drawing.Point(373, 213);
            this.lbl_TituloLogin.Name = "lbl_TituloLogin";
            this.lbl_TituloLogin.Size = new System.Drawing.Size(390, 44);
            this.lbl_TituloLogin.TabIndex = 32;
            this.lbl_TituloLogin.Text = "REENVIO DE SENHA";
            // 
            // txt_EmailUsuario
            // 
            this.txt_EmailUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_EmailUsuario.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EmailUsuario.Location = new System.Drawing.Point(402, 306);
            this.txt_EmailUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txt_EmailUsuario.Name = "txt_EmailUsuario";
            this.txt_EmailUsuario.Size = new System.Drawing.Size(324, 33);
            this.txt_EmailUsuario.TabIndex = 31;
            // 
            // lbl_Usuario
            // 
            this.lbl_Usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Usuario.AutoSize = true;
            this.lbl_Usuario.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Usuario.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Usuario.Location = new System.Drawing.Point(179, 309);
            this.lbl_Usuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Usuario.Name = "lbl_Usuario";
            this.lbl_Usuario.Size = new System.Drawing.Size(215, 27);
            this.lbl_Usuario.TabIndex = 30;
            this.lbl_Usuario.Text = "E-mail de verificação:";
            // 
            // btn_Enviar
            // 
            this.btn_Enviar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enviar.Location = new System.Drawing.Point(431, 363);
            this.btn_Enviar.Name = "btn_Enviar";
            this.btn_Enviar.Size = new System.Drawing.Size(265, 56);
            this.btn_Enviar.TabIndex = 29;
            this.btn_Enviar.Text = "Confirmar";
            this.btn_Enviar.UseVisualStyleBackColor = true;
            this.btn_Enviar.Click += new System.EventHandler(this.btn_Enviar_Click);
            // 
            // FmrRecupSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1067, 735);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Voltar);
            this.Controls.Add(this.lbl_TituloLogin);
            this.Controls.Add(this.txt_EmailUsuario);
            this.Controls.Add(this.lbl_Usuario);
            this.Controls.Add(this.btn_Enviar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FmrRecupSenha";
            this.Text = "FmrRecupSenha";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmrRecupSenha_FormClosing);
            this.Load += new System.EventHandler(this.FmrRecupSenha_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Voltar;
        private System.Windows.Forms.Label lbl_TituloLogin;
        private System.Windows.Forms.TextBox txt_EmailUsuario;
        private System.Windows.Forms.Label lbl_Usuario;
        private System.Windows.Forms.Button btn_Enviar;
    }
}