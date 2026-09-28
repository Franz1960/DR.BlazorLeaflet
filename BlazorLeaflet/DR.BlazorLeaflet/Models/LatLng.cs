using System.Drawing;
using System.Globalization;

namespace DR.BlazorLeaflet.Models
{
  public class LatLng
  {
    public override string ToString() {
      return $"lat={this.Lat.ToString("0.000",CultureInfo.InvariantCulture)}, lng={this.Lng.ToString("0.000",CultureInfo.InvariantCulture)}";
    }

    public float Lat { get; set; }

    public float Lng { get; set; }

    public float Alt { get; set; }

    public PointF ToPointF() => new PointF(Lat,Lng);

    public LatLng() { }

    public LatLng(PointF position) : this(position.X,position.Y) { }

    public LatLng(float lat,float lng) {
      Lat = lat;
      Lng = lng;
    }

    public LatLng(float lat,float lng,float alt) : this(lat,lng) {
      Alt = alt;
    }
  }
}
