using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GNX.Desktop
{
    /// <summary>
    /// A PictureBox control extended to allow a variety of interpolations.
    /// </summary>
    public class FlatPictureBox : PictureBox
    {
        readonly IContainer components;
        readonly ContextMenuStrip mnuPicture;
        readonly ToolStripMenuItem mniCopyImage;

        [DefaultValue(false)]
        public bool AutoScale { get; set; }

        public new Image Image
        {
            get { return base.Image; }
            set
            {
                base.Image = value;

                if (value is Image)
                {
                    ContextMenuStrip = mnuPicture;
                }

                if (value is Image && AutoScale)
                {
                    this.ScaleTo(value);
                }
            }
        }

        Align AlignValue { get; set; }

        [DefaultValue(typeof(Align), "None")]
        public Align Align
        {
            get { return AlignValue; }
            set
            {
                AlignValue = value;

                if (Parent is Control)
                    this.AlignBox();
            }
        }

        public FlatPictureBox()
        {
            //SubMenu
            components = new Container();
            SizeChanged += OnSizeChanged;
            ParentChanged += OnParentChanged;

            mniCopyImage = new ToolStripMenuItem
            {
                Name = "mniCopyImage",
                Size = new Size(227, 22),
                Text = "Copy image"
            };

            mnuPicture = new ContextMenuStrip(components)
            {
                Name = "mnuPicture",
                Size = new Size(228, 48)
            };

            mnuPicture.SuspendLayout();
            mnuPicture.Items.AddRange(new ToolStripItem[]{
                mniCopyImage
            });
            mnuPicture.ResumeLayout(false);

            mniCopyImage.MouseDown += MniCopyImage_MouseDown;
        }

        void OnParentChanged(object sender, EventArgs e)
        {
            if (Parent is Control)
            {
                this.AlignBox();
                Parent.SizeChanged += OnSizeChanged;
            }
        }

        void OnSizeChanged(object sender, EventArgs e)
        {
            if (Parent is Control)
            {
                this.AlignBox();
            }
        }

        void MniCopyImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ClipboardSafe.SetImage(Image);
        }

        #region Interpolation Property
        /// <summary>Backing Field</summary>
        InterpolationMode interpolation = InterpolationMode.NearestNeighbor;

        /// <summary>
        /// The interpolation used to render the image.
        /// </summary>
        [DefaultValue(typeof(InterpolationMode), "NearestNeighbor"),
        Description("The interpolation used to render the image.")]
        public InterpolationMode Interpolation
        {
            get { return interpolation; }
            set
            {
                if (value == InterpolationMode.Invalid)
                    throw new ArgumentException("\"Invalid\" is not a valid value."); // (Duh!)

                interpolation = value;
                Invalidate(); // Image should be redrawn when a different interpolation is selected
            }
        }
        #endregion

        /// <summary>
        /// Overridden to modify rendering behavior.
        /// </summary>
        /// <param name="pe">Painting event args.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Before the PictureBox renders the image, we modify the
            // graphics object to change the interpolation.

            // Set the selected interpolation.
            pe.Graphics.InterpolationMode = interpolation;
            // Certain interpolation modes (such as nearest neighbor) need
            // to be offset by half a pixel to render correctly.
            if (interpolation == InterpolationMode.NearestNeighbor)
                pe.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            else
                pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Allow the PictureBox to draw.
            base.OnPaint(pe);
        }
    }
}