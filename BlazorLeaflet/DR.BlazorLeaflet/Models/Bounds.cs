using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace DR.BlazorLeaflet.Models
{
  public class Bounds
  {
    public LatLng SouthWest { get; set; }
    public LatLng NorthEast { get; set; }

    public float DiagonalDistance => MathF.Sqrt((this.SouthWest.Lat - this.NorthEast.Lat) * (this.SouthWest.Lat - this.NorthEast.Lat) + (this.SouthWest.Lng - this.NorthEast.Lng) * (this.SouthWest.Lng - this.NorthEast.Lng));

    public static Bounds? FromLatLng(IEnumerable<LatLng> latLngs) {
      if (latLngs != null) {
        float south = default;
        float west = default;
        float north = default;
        float east = default;
        bool first = true;
        foreach (LatLng latLng in latLngs) {
          if (first) {
            first = false;
            south = north = latLng.Lat;
            west = east = latLng.Lng;
          } else {
            south = Math.Min(south, latLng.Lat);
            north = Math.Max(north, latLng.Lat);
            west = Math.Min(west, latLng.Lng);
            east = Math.Min(east, latLng.Lng);
          }
        }
        return new Bounds() {
          SouthWest = new LatLng(south, west),
          NorthEast = new LatLng(north, east),
        };
      }
      return null;
    }
  }
}
