using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace AppCmn
{
    /**//**//**//// <summary>
    /**//// ImageHelper 的摘要说明
    /**//// </summary>
    public class ImageHelper
    {
        public ImageHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region Image水印
        /**/
        /**/
        /**/
        /// <summary>
        /**/
        /// 写入图像水印
        /**/
        /// </summary>
        /**/
        /// <param name="str">水印字符串</param>
        /**/
        /// <param name="filePath">原图片位置</param>
        /**/
        /// <param name="savePath">水印加入后的位置</param>
        /**/
        /// <returns></returns>
        public string CreateBackImage(System.Web.UI.Page pageCurrent, string str, string filePath, string savePath, int x, int y)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(pageCurrent.MapPath(filePath));
            //创建图片
            Graphics graphics = Graphics.FromImage(img);
            //指定要绘制的面积
            graphics.DrawImage(img, 0, 0, img.Width, img.Height);
            //定义字段和画笔
            Font font = new Font("黑体", 16);
            Brush brush = new SolidBrush(Color.Yellow);
            graphics.DrawString(str, font, brush, x, y);
            //保存并输出图片
            img.Save(pageCurrent.MapPath(savePath), System.Drawing.Imaging.ImageFormat.Jpeg);
            return savePath;

        }

        /// <summary>
        ///  加水印图片
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="WaterMarkPicPath">水印图片的地址</param>
        /// <param name="top,left">水印位置</param>
        /// <param name="_width">被加水印图片的宽</param>
        /// <param name="_height">被加水印图片的高</param>
        public void addWatermarkImage(Graphics picture, string WaterMarkPicPath, int top, int left, int _width, int _height)
        {
            Image watermark = new Bitmap(WaterMarkPicPath);

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float[][] colorMatrixElements = {
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 0.0f}
                                            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;
            int WatermarkWidth = 0;
            int WatermarkHeight = 0;
            double bl = 1d;
            //计算水印图片的比率
            //取背景的1/4宽度来比较
            //if ((_width > watermark.Width * 4) && (_height > watermark.Height * 4))
            //{
            //    bl = 1;
            //}
            //else if ((_width > watermark.Width * 4) && (_height < watermark.Height * 4))
            //{
            //    bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);
            //}
            //else if ((_width < watermark.Width * 4) && (_height > watermark.Height * 4))
            //{
            //    bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
            //}
            //else
            //{
            //    if ((_width * watermark.Height) > (_height * watermark.Width))
            //    {
            //        bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);
            //    }
            //    else
            //    {
            //        bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
            //    }
            //}

            WatermarkWidth = Convert.ToInt32(watermark.Width * bl);
            WatermarkHeight = Convert.ToInt32(watermark.Height * bl);

            xpos = left;
            ypos = top;


            picture.DrawImage(watermark, new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);


            watermark.Dispose();
            imageAttributes.Dispose();
        }
        public void addWatermarkImage(Graphics picture, string WaterMarkPicPath, string _watermarkPosition, int _width, int _height)
        {
            Image watermark = new Bitmap(WaterMarkPicPath);

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float[][] colorMatrixElements = {
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 0.0f}
                                            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;
            int WatermarkWidth = 0;
            int WatermarkHeight = 0;
            double bl = 1d;
            //计算水印图片的比率
            //取背景的1/4宽度来比较
            if ((_width > watermark.Width * 4) && (_height > watermark.Height * 4))
            {
                bl = 1;
            }
            else if ((_width > watermark.Width * 4) && (_height < watermark.Height * 4))
            {
                bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);

            }
            else

                if ((_width < watermark.Width * 4) && (_height > watermark.Height * 4))
                {
                    bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
                }
                else
                {
                    if ((_width * watermark.Height) > (_height * watermark.Width))
                    {
                        bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);

                    }
                    else
                    {
                        bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);

                    }

                }

            WatermarkWidth = Convert.ToInt32(watermark.Width * bl);
            WatermarkHeight = Convert.ToInt32(watermark.Height * bl);



            switch (_watermarkPosition)
            {
                case "WM_TOP_LEFT":
                    xpos = 10;
                    ypos = 10;
                    break;
                case "WM_TOP_RIGHT":
                    xpos = _width - WatermarkWidth - 10;
                    ypos = 10;
                    break;
                case "WM_BOTTOM_RIGHT":
                    xpos = _width - WatermarkWidth - 10;
                    ypos = _height - WatermarkHeight - 10;
                    break;
                case "WM_BOTTOM_LEFT":
                    xpos = 10;
                    ypos = _height - WatermarkHeight - 10;
                    break;
            }

            picture.DrawImage(watermark, new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);


            watermark.Dispose();
            imageAttributes.Dispose();
        }

        #endregion
        #region Image自动缩小
        /**/
        /**/
        /**/
        /// <summary>
        /**/
        /// 缩小图片到指定的大小
        /**/
        /// </summary>
        /**/
        /// <param name="strOldPic">
        /**/
        /// 原图片的位置
        /**/
        /// </param>
        /**/
        /// <param name="strNewPic">
        /**/
        /// 缩小后的图片位置
        /**/
        /// </param>
        /**/
        /// <param name="intWidth">
        /**/
        /// 宽度
        /**/
        /// </param>
        /**/
        /// <param name="intHeight">
        /**/
        /// 高度
        /**/
        /// </param>
        public void SmallPic(string strOldPic, string strNewPic, int intWidth, int intHeight)
        {

            System.Drawing.Bitmap objPic, objNewPic;
            try
            {
                objPic = new System.Drawing.Bitmap(strOldPic);
                objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
                objNewPic.Save(strNewPic);

            }
            catch (Exception exp) { throw exp; }
            finally
            {
                objPic = null;
                objNewPic = null;
            }
        }

        public void SmallPic(string strOldPic, string strNewPic, int intWidth)
        {

            System.Drawing.Bitmap objPic, objNewPic;
            try
            {
                objPic = new System.Drawing.Bitmap(strOldPic);
                int intHeight = Convert.ToInt32(((intWidth * 1.0) / (objPic.Width * 1.0)) * objPic.Height);
                objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
                objNewPic.Save(strNewPic, objPic.RawFormat);

            }
            catch (Exception exp) { throw exp; }
            finally
            {
                objPic = null;
                objNewPic = null;
            }
        }

        //public void SmallPic(string strOldPic, string strNewPic, int intHeight)
        //{

        //    System.Drawing.Bitmap objPic, objNewPic;
        //    try
        //    {
        //        objPic = new System.Drawing.Bitmap(strOldPic);
        //        int intWidth = Convert.ToInt32(((intHeight * 1.0) / objPic.Height) * objPic.Width);
        //        objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
        //        objNewPic.Save(strNewPic, objPic.RawFormat);

        //    }
        //    catch (Exception exp) { throw exp; }
        //    finally
        //    {
        //        objPic = null;
        //        objNewPic = null;
        //    }
        //}
        #endregion

        #region 获取缩略图
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromImg">原图</param>
        /// <param name="width">目标最大宽度</param>
        /// <param name="height">目标最大高度</param>
        /// <param name="israte">按比例缩放</param>
        /// <returns></returns>
        public static Bitmap MakeThumbnail(Image fromImg, int width, int height, bool israte)
        {
            Bitmap bmp = new Bitmap(width, height);
            int ow = fromImg.Width;
            int oh = fromImg.Height;

            //按比例计算出缩略图的宽度和高度
            if (ow >= oh)
            {
                height = (int)Math.Floor(Convert.ToDouble(oh) * (Convert.ToDouble(width) / Convert.ToDouble(ow)));//等比设定高度
            }
            else
            {
                width = (int)Math.Floor(Convert.ToDouble(ow) * (Convert.ToDouble(height) / Convert.ToDouble(oh)));//等比设定宽度
            }


            //新建一个画板
            using (Graphics g = Graphics.FromImage(bmp))
            {
                //设置高质量插值法
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //设置高质量,低速度呈现平滑程度
                g.SmoothingMode = SmoothingMode.HighQuality;
                //清空画布并以透明背景色填充
                g.Clear(Color.Transparent);

                g.DrawImage(fromImg, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, ow, oh),
                    GraphicsUnit.Pixel);

                return bmp;
            }
        }

        public static string SaveThumbnail(string pPath, string pSavedPath,string filename, int width, int height, bool israte)
        {
            using (Image originalImg = Image.FromFile(pPath))
            {
                if (filename == "")
                {
                    filename = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(9999).ToString() + ".jpg";
                }
                string filePath = pSavedPath + "\\" + filename;
                Bitmap thumimg = MakeThumbnail(originalImg, width, height, israte);
                thumimg.Save(filePath, ImageFormat.Jpeg);
                thumimg.Dispose();

            }
            return filename;
        }
        #endregion

        #region 图像切割
        public static string SaveCutPic(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY, int imageWidth, int imageHeight)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(9999).ToString() + ".jpg";
            string filePath = pSavedPath + "\\" + filename;
            using (Image originalImg = Image.FromFile(pPath))
            {
                if (originalImg.Width == imageWidth && originalImg.Height == imageHeight)
                {
                    return SaveCutPic(pPath, pSavedPath, pPartStartPointX, pPartStartPointY, pPartWidth, pPartHeight,
                            pOrigStartPointX, pOrigStartPointY);

                }
                Bitmap thumimg = MakeThumbnail(originalImg, imageWidth, imageHeight,true);

                Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);

                Graphics graphics = Graphics.FromImage(partImg);
                Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//目标位置
                Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）

                ///文字水印  
                Graphics G = Graphics.FromImage(partImg);
                //Font f = new Font("Lucida Grande", 6);
                //Brush b = new SolidBrush(Color.Gray);
                G.Clear(Color.White);
                // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // 指定高质量、低速度呈现。 
                G.SmoothingMode = SmoothingMode.HighQuality;

                graphics.DrawImage(thumimg, destRect, origRect, GraphicsUnit.Pixel);
                //G.DrawString("Xuanye", f, b, 0, 0);
                G.Dispose();

                originalImg.Dispose();
                partImg.Save(filePath, ImageFormat.Jpeg);

                partImg.Dispose();
                thumimg.Dispose();
            }
            File.Delete(pPath);
            return filename;
        }

        public static string SaveCutPic(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(9999).ToString() + ".jpg";
            string filePath = pSavedPath + "\\" + filename;

            using (Image originalImg = Image.FromFile(pPath))
            {
                Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);
                Graphics graphics = Graphics.FromImage(partImg);
                Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//目标位置
                Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）

                ///注释 文字水印  
                Graphics G = Graphics.FromImage(partImg);
                //Font f = new Font("Lucida Grande", 6);
                //Brush b = new SolidBrush(Color.Gray);
                G.Clear(Color.White);
                // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // 指定高质量、低速度呈现。 
                G.SmoothingMode = SmoothingMode.HighQuality;

                graphics.DrawImage(originalImg, destRect, origRect, GraphicsUnit.Pixel);
                //G.DrawString("Xuanye", f, b, 0, 0);
                G.Dispose();

                originalImg.Dispose();
                partImg.Save(filePath, ImageFormat.Jpeg);
                partImg.Dispose();
            }
            File.Delete(pPath);
            return filename;
        }
        #endregion

    }
}
