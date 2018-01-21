using System;
using AppKit;
using CoreGraphics;
using SkiaSharp.Views.Mac;

namespace microcosm.Views
{
    public class CanvasView : SKCanvasView
    {
        public CanvasView()
        {
        }



        public override void DrawRect(CoreGraphics.CGRect dirtyRect)
        {
            base.DrawRect(dirtyRect);
            using (CGContext context = NSGraphicsContext.CurrentContext.GraphicsPort) {

                context.SetLineWidth(2);
                context.SetStrokeColor(new CGColor(255, 0, 0));
                var path = new NSBezierPath();
                path.MoveTo(new CoreGraphics.CGPoint(30, 30));
                path.LineTo(new CoreGraphics.CGPoint(40, 40));
                path.Stroke();
            }

        }
    }
}
