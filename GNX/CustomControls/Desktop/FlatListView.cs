using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GNX
{
    public partial class FlatListView : ListView
    {
        public int ImagePadding = 6;
        public List<Image> images = new List<Image>();

        public FlatListView()
        {
            DoubleBuffered = true;

            View = View.Tile;
            TileSize = new Size(52, 52);
            BackColor = SystemColors.Control;

            OwnerDraw = true;
            DrawItem += ListView_DrawItem;
            DrawSubItem += ListView_DrawSubItem;
            DrawColumnHeader += ListView_DrawColumnHeader;
            AutoArrange = true;
        }

        void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            int x = (e.Bounds.Left) + 2 + 4;
            int y = (e.Bounds.Top - 2) + 2;

            if (e.ItemIndex >= Items.Count + 1 - 5)
            {
                TileSize = new System.Drawing.Size(54, 54);
            }


            Image imageNewSize = LargeImageList.Images[e.Item.ImageIndex];
            var rect = new Rectangle(x, y, imageNewSize.Width, imageNewSize.Height);
            var rectImage = new Rectangle(x + 2, y + 2, imageNewSize.Width - 4, imageNewSize.Height - 4);

            //Bitmap imageResized = new Bitmap(imageNewSize.Width, imageNewSize.Height);
            e.Graphics.DrawImage(imageNewSize, rect);
            //var g = e.Graphics;
            //using (Graphics g = Graphics.FromImage(imageNewSize))
            //{
            //    //Bitmap image = FromFile(imageFile);
            //var image = images[e.Item.Index];

            //}



            //using srcImg As Image = Image.FromFile(fn)

            //using (var srcImg = Image.FromFile(imagePaths[e.ItemIndex]))
            //{
            //    var imgBounds = new Rectangle(Point.Empty, LargeImageList.ImageSize);

            //    var bit = new Bitmap(imgBounds.Width, imgBounds.Height, PixelFormat.Format32bppArgb);
            //    using (var gx = Graphics.FromImage(bit))
            //    {
            //        gx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //        gx.DrawImage(srcImg, imgBounds);
            //    }
            //}

            //e.Graphics.DrawString(e.Item.Text, e.Item.Font, Brushes.Black,
            //    new Rectangle(e.Bounds.Left - 2, e.Bounds.Top - 4, e.Bounds.Width, e.Bounds.Height));
            //using (Brush brush = new SolidBrush((e.State.HasFlag(ListViewItemStates.Focused)) ? SystemColors.Highlight : e.Item.BackColor))
            //    e.Graphics.FillRectangle(brush, e.Bounds);

            Color textColor = SystemColors.WindowText;
            if (e.Item.Selected)
            {
                if (Focused)
                {
                    textColor = SystemColors.HighlightText;
                    Brush brush = new SolidBrush(Color.FromArgb(120, 0, 120, 215));
                    e.Graphics.FillRectangle(brush, rectImage);
                }
                else if (!HideSelection)
                {
                    textColor = SystemColors.ControlText;
                    //e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds);
                }
            }
            else
            {
                using (SolidBrush br = new SolidBrush(BackColor))
                {
                    //e.Graphics.FillRectangle(br, e.Bounds);
                }
            }

            //e.Graphics.DrawRectangle(Pens.Red, e.Bounds);
            //TextRenderer.DrawText(e.Graphics, e.Item.Text, Font, e.Bounds,
            //                      textColor, Color.Empty,
            //                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            //e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.DrawDefault = true;
        }

        void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            //e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            if (e.ColumnIndex > 0)
                e.DrawDefault = true;
        }

        public Padding getPadding()
        {
            return Padding;
        }

        public async Task AddImageList(List<Bitmap> imageList, Size imagesSize)
        {
            Items.Clear();
            images.Clear();
            AutoScrollOffset = Point.Empty;

            await Task.Run(() =>
            {
                //Convert Images
                foreach (var img in imageList)
                {
                    var newImage = new Bitmap(imagesSize.Width, imagesSize.Height, PixelFormat.Format24bppRgb);

                    using (Graphics g = Graphics.FromImage(newImage))
                    {
                        g.Clear(Color.Gold);

                        //copy in High Quality
                        g.CompositingMode = CompositingMode.SourceCopy;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.SmoothingMode = SmoothingMode.HighQuality;

                        //prevents ghosting around the image borders
                        var wrapMode = new ImageAttributes();
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);

                        g.InterpolationMode = (img.Height > imagesSize.Height) || (img.Width > imagesSize.Width) ? InterpolationMode.HighQualityBicubic : InterpolationMode.NearestNeighbor;
                        g.PixelOffsetMode = (img.Height > imagesSize.Height) || (img.Width > imagesSize.Width) ? PixelOffsetMode.HighQuality : PixelOffsetMode.Half;

                        var rectAll = new Rectangle(0, 0, imagesSize.Width, imagesSize.Height);
                        var rectImage = new Rectangle(2, 2, imagesSize.Width - 4, imagesSize.Height - 4);

                        g.DrawImage(img, rectImage, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);

                        //DrawToBitmap(img, rectAll);
                        images.Add(newImage);
                    }
                }
                //images = imageList;

                //if (size.IsEmpty) size = new Size(32, 32);
                //if (ImagePadding < 6) ImagePadding = 6;
            });

            var pics = new ImageList()
            {
                ImageSize = imagesSize,
                ColorDepth = ColorDepth.Depth24Bit,
            };

            pics.Images.AddRange(images.ToArray());

            int index = 0;
            foreach (var imageItem in images)
            {
                var viewItem = new ListViewItem()
                {
                    ImageIndex = index,
                    //Text = "X",
                };
                index++;

                Items.Add(viewItem);
            }

            //TileSize = new Size(size.Width + ImagePadding, size.Height + ImagePadding);
            LargeImageList = pics;
            SmallImageList = pics;
        }
    }
}
