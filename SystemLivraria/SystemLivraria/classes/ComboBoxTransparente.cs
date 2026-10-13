using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SystemLivraria.classes
{
    [DefaultEvent("SelectedIndexChanged")]
    public class ComboBoxTransparente : UserControl
    {
        // Campos de estilo
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 1;
        private int borderRadius = 15;

        // Componentes internos
        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;

        // Construtor
        public ComboBoxTransparente()
        {
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            this.SuspendLayout();

            // Configuração do ComboBox interno
            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(this.Font.FontFamily, 10F);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(CmbList_SelectedIndexChanged);
            cmbList.TextChanged += new EventHandler(CmbList_TextChanged);

            // Configuração do Botão da Seta (Ícone)
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);

            // Configuração do Rótulo de Texto
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(this.Font.FontFamily, 10F);
            lblText.Click += new EventHandler(Surface_Click);

            // Configuração do Container (UserControl)
            this.Controls.Add(lblText);
            this.Controls.Add(btnIcon);
            this.Controls.Add(cmbList);
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);
            base.BackColor = borderColor;
            this.ResumeLayout(false);

            AdjustComboBoxBounds();
        }

        // Propriedades de Estilo
        [Category("Personalização")]
        public new Color BackColor
        {
            get => backColor;
            set
            {
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }
        }

        [Category("Personalização")]
        public Color IconColor
        {
            get => iconColor;
            set
            {
                iconColor = value;
                btnIcon.Invalidate();
            }
        }

        [Category("Personalização")]
        public Color ListBackColor
        {
            get => listBackColor;
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }

        [Category("Personalização")]
        public Color ListTextColor
        {
            get => listTextColor;
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }

        [Category("Personalização")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                base.BackColor = borderColor;
                this.Invalidate();
            }
        }

        [Category("Personalização")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize);
                AdjustComboBoxBounds();
                this.Invalidate();
            }
        }

        [Category("Personalização")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        // Propriedades de Dados do ComboBox
        [Category("Dados")]
        public ComboBox.ObjectCollection Items => cmbList.Items;

        [Category("Dados")]
        public object DataSource
        {
            get => cmbList.DataSource;
            set => cmbList.DataSource = value;
        }

        [Category("Dados")]
        public string DisplayMember
        {
            get => cmbList.DisplayMember;
            set => cmbList.DisplayMember = value;
        }

        [Category("Dados")]
        public string ValueMember
        {
            get => cmbList.ValueMember;
            set => cmbList.ValueMember = value;
        }

        [Category("Dados")]
        public int SelectedIndex
        {
            get => cmbList.SelectedIndex;
            set => cmbList.SelectedIndex = value;
        }

        [Category("Dados")]
        public object SelectedItem
        {
            get => cmbList.SelectedItem;
            set => cmbList.SelectedItem = value;
        }

        // Eventos
        public event EventHandler SelectedIndexChanged;

        private void CmbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbList.SelectedItem != null)
                lblText.Text = cmbList.SelectedItem.ToString();

            SelectedIndexChanged?.Invoke(sender, e);
        }

        private void CmbList_TextChanged(object sender, EventArgs e)
        {
            lblText.Text = cmbList.Text;
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            if (cmbList.DropDownStyle != ComboBoxStyle.Simple)
                cmbList.DroppedDown = true;
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        // Desenho da Seta
        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            int iconWidth = 14;
            int iconHeight = 6;
            Rectangle rect = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rect.X, rect.Y, rect.X + (iconWidth / 2), rect.Bottom);
                path.AddLine(rect.X + (iconWidth / 2), rect.Bottom, rect.Right, rect.Y);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void AdjustComboBoxBounds()
        {
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point(this.Width - this.Padding.Right - cmbList.Width, lblText.Bottom - cmbList.Height);
        }

        private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = this.ClientRectangle;
            RectangleF rectBorder = RectangleF.Inflate(rectSurface, -borderSize / 2F, -borderSize / 2F);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius - borderSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(pathSurface);
                    if (borderSize >= 1)
                    {
                        penBorder.Alignment = PenAlignment.Center;
                        e.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxBounds();
        }
    }
}