using System;
using AppKit;
using CoreGraphics;
using SkiaSharp.Views.Mac;

namespace microcosm.Views
{
    public class CanvasView : SKCanvasView
    {
        public CanvasView(CGRect rect) : base(rect)
        {
            Console.WriteLine("canvas");
        }

        public override void MouseEntered(NSEvent theEvent)
        {
            base.MouseEntered(theEvent);
            CGPoint p = theEvent.Window.MouseLocationOutsideOfEventStream;
            Console.WriteLine("MouseEntered");
        }

        NSTrackingArea _trackingArea;

        public override void UpdateTrackingAreas()
        {
            if (_trackingArea != null)
            {
                this.RemoveTrackingArea(_trackingArea);
            }

            _trackingArea = new NSTrackingArea(
                rect: this.Bounds,
                 options: NSTrackingAreaOptions.ActiveAlways |
                          NSTrackingAreaOptions.InVisibleRect |
                          NSTrackingAreaOptions.MouseEnteredAndExited |
                          NSTrackingAreaOptions.MouseMoved,
                owner: this,
                userInfo: null);

            this.AddTrackingArea(_trackingArea);

            base.UpdateTrackingAreas();
        }
    }
}
