namespace SDVE;

partial class PapeletaForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        panelPapeleta = new FlowLayoutPanel();
        panelInferior = new Panel();
        btnCancelar = new Button();
        btnConfirmar = new Button();
        panelHeader = new Panel();
        lblTitulo = new Label();
        panelInferior.SuspendLayout();
        panelHeader.SuspendLayout();
        SuspendLayout();
        //
        // panelPapeleta
        //
        panelPapeleta.AutoScroll = true;
        panelPapeleta.Dock = DockStyle.Fill;
        panelPapeleta.FlowDirection = FlowDirection.TopDown;
        panelPapeleta.Location = new Point(0, 60);
        panelPapeleta.Name = "panelPapeleta";
        panelPapeleta.Padding = new Padding(15);
        panelPapeleta.Size = new Size(944, 561);
        panelPapeleta.TabIndex = 0;
        panelPapeleta.WrapContents = false;
        //
        // panelInferior
        //
        panelInferior.Controls.Add(btnCancelar);
        panelInferior.Controls.Add(btnConfirmar);
        panelInferior.Dock = DockStyle.Bottom;
        panelInferior.Location = new Point(0, 621);
        panelInferior.Name = "panelInferior";
        panelInferior.Size = new Size(944, 60);
        panelInferior.TabIndex = 1;
        //
        // btnCancelar
        //
        btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCancelar.Location = new Point(605, 10);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(110, 40);
        btnCancelar.TabIndex = 0;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;
        btnCancelar.Click += btnCancelar_Click;
        //
        // btnConfirmar
        //
        btnConfirmar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnConfirmar.BackColor = Color.FromArgb(34, 139, 34);
        btnConfirmar.FlatStyle = FlatStyle.Flat;
        btnConfirmar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnConfirmar.ForeColor = Color.White;
        btnConfirmar.Location = new Point(730, 10);
        btnConfirmar.Name = "btnConfirmar";
        btnConfirmar.Size = new Size(190, 40);
        btnConfirmar.TabIndex = 1;
        btnConfirmar.Text = "✔  Confirmar voto";
        btnConfirmar.UseVisualStyleBackColor = false;
        btnConfirmar.Click += btnConfirmar_Click;
        //
        // panelHeader
        //
        panelHeader.BackColor = Color.FromArgb(30, 60, 114);
        panelHeader.Controls.Add(lblTitulo);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(944, 60);
        panelHeader.TabIndex = 2;
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(20, 14);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "🗳  Papeleta electrónica";
        //
        // PapeletaForm
        //
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(944, 681);
        Controls.Add(panelPapeleta);
        Controls.Add(panelHeader);
        Controls.Add(panelInferior);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        Name = "PapeletaForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "SDVE - Papeleta electrónica";
        panelInferior.ResumeLayout(false);
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private FlowLayoutPanel panelPapeleta;
    private Panel panelInferior;
    private Button btnCancelar;
    private Button btnConfirmar;
    private Panel panelHeader;
    private Label lblTitulo;
}
