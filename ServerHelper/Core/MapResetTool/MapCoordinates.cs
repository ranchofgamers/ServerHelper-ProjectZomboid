using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHelper.Core.MapResetTool
{
    public class MapCoordinates
    {
        private PointF _ViewCoords;
        public PointF ViewCoords
        {
            get 
            {
                if (Map != null && Map.Bmp != null)
                {
                    _ImageCoords = TransformGameWorldToImage(_GameWorldCoords.X, _GameWorldCoords.Y);
                    _ViewCoords = TransformImageToCurrentView(_ImageCoords.X, _ImageCoords.Y);
                }
                else _ViewCoords = new PointF(0, 0);

                return _ViewCoords;
            }
            set
            {
                _ViewCoords = value;

                if (Map != null && Map.Bmp != null)
                {
                    _ImageCoords = TransformViewToImage(value.X, value.Y);
                    _GameWorldCoords = TransformImageToGameWorld(_ImageCoords.X, _ImageCoords.Y);
                }
            }
        }

        private PointF _ImageCoords;
        public PointF ImageCoords 
        {
            get
            {
                if (Map != null && Map.Bmp != null)
                    _ImageCoords = TransformGameWorldToImage(_GameWorldCoords.X, _GameWorldCoords.Y);
                else _ImageCoords = new PointF(0, 0);

                return _ImageCoords;
            }
            set
            {
                _ImageCoords = value;

                if (Map != null && Map.Bmp != null)
                {
                    _GameWorldCoords = TransformImageToGameWorld(value.X, value.Y);
                    _ViewCoords = TransformImageToCurrentView(_ImageCoords.X, _ImageCoords.Y);
                }
            }
        }
        
        private PointF _GameWorldCoords;
        public PointF GameWorldCoords 
        {
            get
            {
                return _GameWorldCoords;
            }
            set
            {
                _GameWorldCoords = value;

                if (Map != null && Map.Bmp != null)
                {
                    _ImageCoords = TransformGameWorldToImage(value.X, value.Y);
                    _ViewCoords = TransformImageToCurrentView(_ImageCoords.X, _ImageCoords.Y);
                }
            }
        }

        public Map Map { get; set; }

        public MapCoordinates(Map map)
        {
            Map = map;
            _ViewCoords = new PointF(0, 0);
            _ImageCoords = new PointF(0, 0);
            _GameWorldCoords = new PointF(0, 0);

        }
        public MapCoordinates()
        {
            this.Map = null;
            _ViewCoords = new PointF(0, 0);
            _ImageCoords = new PointF(0, 0);
            _GameWorldCoords = new PointF(0, 0);
        }

        #region Приватные методы
        private PointF TransformImageToCurrentView(float x, float y)
        {
            float XView = (x * Map.Scl) + Map.X0;
            float YView = (y * Map.Scl) + Map.Y0;

            return new PointF(XView, YView);
        }
        private PointF TransformViewToImage(float x, float y)
        {
            var XImage = (x - Map.X0) * 1 / Map.Scl;
            var YImage = (y - Map.Y0) * 1 / Map.Scl;

            return new PointF(XImage, YImage);
        }
        private PointF TransformImageToGameWorld(float x, float y)
        {
            var XGameWorld = ((Map.RB.X - Map.LT.X) / Map.Bmp.Width * x) + Map.LT.X;
            var YGameWorld = ((Map.RB.Y - Map.LT.Y) / Map.Bmp.Height * y) + Map.LT.Y;

            return new PointF(XGameWorld, YGameWorld);
        }
        private PointF TransformGameWorldToImage(float x, float y)
        {
            var XImage = ((x - Map.LT.X) * Map.Bmp.Width) / (Map.RB.X - Map.LT.X);
            var YImage = ((y - Map.LT.Y) * Map.Bmp.Height) / (Map.RB.Y - Map.LT.Y);

            return new PointF(XImage, YImage);
        }
        #endregion
    }
}